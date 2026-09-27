using UnityEngine;
using TMPro;

public class Chaining : MonoBehaviour
{
    private int baseValue = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                ScoreManager.instance.RegisterChainCollision();
            }
        }
    }
}
