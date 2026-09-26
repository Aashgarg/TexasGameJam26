using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int totalScore;
    private int currentMultiplier = 1;
    private int basePoints = 1;
    private int currentStreak = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterChainCollision()
    {
        int pointsToGive = basePoints * currentMultiplier;
        

        totalScore += pointsToGive;
        Debug.Log($"Collision! Streak: {currentStreak + 1} | Gained: {pointsToGive} | Total Score: {totalScore}");

        currentMultiplier++;

    }

    public void ResetStreak()
    {
        currentStreak = 0;
    }
}
