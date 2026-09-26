using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        TurnActive,
        TurnNotActive,
        Shop,

    }

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
            currentState = GameState.TurnActive;
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
}
