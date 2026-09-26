using UnityEngine;

public class Chaining : MonoBehaviour
{
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
