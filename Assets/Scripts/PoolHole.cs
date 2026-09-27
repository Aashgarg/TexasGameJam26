using UnityEngine;

public class PoolHole : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolBall ball = other.GetComponent<PoolBall>();

        
        if (ball != null)
        {
            int finalBallScore = ball.GetFinalScoreValue();
            source.PlayOneShot(hitSound);


            ScoreManager.instance.AddPoints(finalBallScore);
            if (!other.GetComponent<DragandShoot>())
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
