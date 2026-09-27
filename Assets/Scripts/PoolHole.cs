using UnityEngine;

public class PoolHole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolBall ball = other.GetComponent<PoolBall>();

        if (ball != null)
        {
            int finalBallScore = ball.GetFinalScoreValue();

            ScoreManager.instance.AddPoints(finalBallScore);
            if (!other.GetComponent<DragandShoot>())
            {
                other.gameObject.SetActive(false);
            }
            
        }
    }
}
