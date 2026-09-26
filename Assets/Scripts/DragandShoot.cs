using UnityEngine;
using System.Collections.Generic;

public class DragandShoot : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float maxDragDistance;
    [SerializeField] private int trajectoryResolution;

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
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);
            if (hit != null && hit.gameObject == gameObject)
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
            Vector3 endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 0;

            Vector2 force = (startPoint - endPoint) * power;
            rb.AddForce(force, ForceMode2D.Impulse);

            lineRend.enabled = false;
            isDragging = false;
        }
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
    }
}
