using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Rendering;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState{
        waitingRoom,
        Interrogation,
        LookingAtClues,
        Pause,
        GameOver
    }

    private GameState currentState = GameState.waitingRoom;
    public GameObject waitingRoomUI;
    public GameObject interrogationUI;

    public NPCData currentNPC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchToInterrogation()
    {
        waitingRoomUI.SetActive(false);
        currentState = GameState.Interrogation;
        interrogationUI.SetActive(true);
        
    }

    public void switchToWaitingRoom()
    {
        waitingRoomUI.SetActive(true);
        currentState = GameState.waitingRoom;
        interrogationUI.SetActive(false);
    }
}
