using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private Vector2 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Hole")
        {
            //adds score to hole
            //get one dollar
            gameObject.transform.position = startingPosition;
            
        }
    }
}
