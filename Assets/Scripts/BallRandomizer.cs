using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BallRandomizer : MonoBehaviour
{
    public List<GameObject> balls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Randomize()
    {
        foreach (GameObject ball in balls){
            int x = Random.Range(-33, 33);
            int y = Random.Range(-15, 15);
            ball.transform.position = new Vector2(x, y);
        }
    }
}
