using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BallRandomizer : MonoBehaviour
{
    public static BallRandomizer instance;
    public List<GameObject> balls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomize()
    {
        foreach (GameObject ball in balls){
            if (!ball.activeSelf) ball.SetActive(true);
            int x = Random.Range(-33, 33);
            int y = Random.Range(-15, 15);
            ball.transform.position = new Vector2(x, y);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;
        }
    }
}
