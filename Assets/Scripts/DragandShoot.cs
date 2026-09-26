using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DragandShoot : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float maxDragDistance;
    [SerializeField] private int trajectoryResolution;
    [SerializeField] private Transform stick;
    [SerializeField] private float offset;

    [SerializeField] private Vector2 startingPosition;

    private Rigidbody2D rb;
    private Camera cam;
    private Vector3 startPoint;
    private LineRenderer lineRend;

    private bool isDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        lineRend = GetComponent<LineRenderer>();
        lineRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stick.transform.parent = null;
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);
            if (hit != null && hit.gameObject.tag == "Player")
            {
                isDragging = true;
                startPoint = mouseWorldPos;
                startPoint.z = 0;
            }
        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 0;

            Vector3 dragVector = startPoint - currentPoint;
            dragVector = Vector3.ClampMagnitude(dragVector, maxDragDistance);

            ShowTrajectory(dragVector * power);
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            stick.gameObject.SetActive(false);
            //stick.GetComponent<Collider2D>().enabled = false;
            //stick.transform.SetParent(gameObject.transform);

            Vector3 endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 0;

            Vector2 force = (startPoint - endPoint) * power;
            rb.AddForce(force, ForceMode2D.Impulse);

            lineRend.enabled = false;
            isDragging = false;
        }

        if (Mathf.Abs(rb.linearVelocity.y) <= .50 && Mathf.Abs(rb.linearVelocity.x) <= .50)
        {
            stick.gameObject.SetActive(true);
            //stick.GetComponent<Collider2D>().enabled = true;
        }
        Debug.Log(rb.linearVelocity);
    }


    void ShowTrajectory(Vector2 initalForce)
    {
        lineRend.enabled = true;
        lineRend.positionCount = trajectoryResolution;

        Vector3[] points = new Vector3[trajectoryResolution];
        Vector2 velocity = initalForce / rb.mass;
        Vector2 startPos = transform.position;

        for (int i = 0; i < trajectoryResolution; i++)
        {
            float t = i * Time.fixedDeltaTime;
            Vector2 point = startPos + velocity * t + 0.5f * Physics2D.gravity * t * t;
            points[i] = point;
        }
        lineRend.SetPositions(points);

        if (initalForce != Vector2.zero)
        {
            stick.gameObject.SetActive(true);
            Vector2 oppositeDirection = -initalForce.normalized;

            Vector3 stickPosition = (Vector2)transform.position + (oppositeDirection * offset);
            stick.position = stickPosition;

            // 3. Rotate the stick to face the cue ball
            float angle = Mathf.Atan2(oppositeDirection.y, oppositeDirection.x) * Mathf.Rad2Deg;

            stick.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void PositionStick()
    {

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Hole")
        {
            //adds score to hole
            //get one dollar
            gameObject.transform.position = startingPosition;
            rb.linearVelocity = Vector2.zero;

        }
    }
}
