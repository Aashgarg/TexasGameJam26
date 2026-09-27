using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        TurnActive,
        TurnNotActive,
        RoundComplete,
        Shop,
        GameOver

    }

    public int turns = 10;
    public int turnsTaken = 0;
    public int roundNumber = 1;
    public TextMeshProUGUI turnsText;
    
    public GameState currentState = GameState.TurnNotActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.TurnNotActive && BallsStopped())
        {
            ScoreManager.instance.ResetStreak();

            if (ScoreManager.instance.totalScore >= ScoreManager.instance.targetScore)
            {
                ShowRoundComplete();
            }
            else if (turnsTaken >= turns)
            {
                GameOver();
            }
            else
            {
                currentState = GameState.TurnActive;
            }
            
        }
    }

    private bool BallsStopped()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb.linearVelocity.y) >= .50 && Mathf.Abs(rb.linearVelocity.x) >= .50)
            {
                currentState = GameState.TurnNotActive;
                return false;
            }
        }
        currentState = GameState.TurnNotActive;
        return true;
    }

    public void UseTurn()
    {
        turnsTaken++;
        currentState = GameState.TurnNotActive;
        turnsText.text = "TurnsLeft: " + (turns - turnsTaken);
    }

    private void ShowRoundComplete()
    {
        currentState = GameState.RoundComplete;
        RoundCompleteUI.instance.Show();
    }

    // Called by RoundCompleteUI's "Continue" button — skip the shop, go straight to next round
    public void ChooseContinue()
    {
        RoundCompleteUI.instance.Hide();
        StartNewRound();
    }

    public void EnterShop()
    {
        RoundCompleteUI.instance.Hide();
        currentState = GameState.Shop;
        ShopManager.instance.OpenShop();
    }

    public void StartNewRound()
    {
        roundNumber++;
        turnsTaken = 0;
        ScoreManager.instance.StartNewRound();
        BallRandomizer.instance.Randomize();
        currentState = GameState.TurnActive;
    }

    private void GameOver()
    {
        currentState = GameState.GameOver;
        Debug.Log("Game Over — final score: " + ScoreManager.instance.totalScore);
        // hook up a game-over UI here, or call StartNewRound() instead if you'd
        // rather just reset the round than truly end the run
    }
}
