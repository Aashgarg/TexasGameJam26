using UnityEngine;

public class PoolBall : MonoBehaviour
{
    public int baseValue = 10;
    [SerializeField] private int currentMultiplier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentMultiplier++;

            Debug.Log($"{gameObject.name} multiplier is now x{currentMultiplier}!");
        }
    }
    public int GetFinalScoreValue()
    {
        return baseValue * currentMultiplier;
    }

}
