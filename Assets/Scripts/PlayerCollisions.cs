using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    
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
            gameObject.SetActive(false);

        }
    }


}
