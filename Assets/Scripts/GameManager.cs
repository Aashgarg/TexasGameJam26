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
    public GameObject poolUI;
    public GameObject gameOver;
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
            PoolBall ballComponent = ball.GetComponent<PoolBall>();
            if (Mathf.Abs(rb.linearVelocity.y) >= .50 || Mathf.Abs(rb.linearVelocity.x) >= .50)
            {
                
                currentState = GameState.TurnNotActive;
                return false;
            }
            else
            {
                
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
        poolUI.SetActive(false);
    }

    // Called by RoundCompleteUI's "Continue" button — skip the shop, go straight to next round
    public void ChooseContinue()
    {
        RoundCompleteUI.instance.Hide();
        poolUI.SetActive(true);
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
        turnsText.text = "TurnsLeft: " + turnsTaken;
        BallRandomizer.instance.Randomize();
        currentState = GameState.TurnActive;
    }

    private void GameOver()
    {
        currentState = GameState.GameOver;
        Debug.Log("Game Over — final score: " + ScoreManager.instance.totalScore);
        gameOver.SetActive(true);
        // hook up a game-over UI here, or call StartNewRound() instead if you'd
        // rather just reset the round than truly end the run
    }
}
