using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetText;
    //public TextMeshProUGUI currencyText;

    public int totalScore = 0;
    public int targetScore = 50;
    public int targetIncrement = 50;
    //public int currency = 0;
    //public int currencyIncrement = 1;

    private int currentMultiplier = 1;
    private int basePoints = 5;
    private int currentStreak = 0;

    public UnityEvent targetReached;

    private void Start()
    {
        targetText.text = "Target: " + targetScore;
    }
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

    public void AddPoints(int points)
    {
        totalScore += points;
        Debug.Log($"Scored! Gained: {points} | Total Score: {totalScore}");
        scoreText.text = "Score: " + totalScore;
        //currency += currencyIncrement;
        //currencyText.text = "Currency: " + currency;
    }

    public void ResetStreak()
    {
        currentStreak = 0;
    }

    public void StartNewRound()
    {
        totalScore = 0;
        targetScore *= 2;
        scoreText.text = "Score: " + totalScore;
        targetText.text = "Target: " + targetScore;
        //currencyText.text = "Currency: " + currency;

    }
}
