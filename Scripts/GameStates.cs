using UnityEngine;

public abstract class GameState
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class MenuState : GameState
{
    public override void Enter()
    {
        Debug.Log("Entering Menu State...");
    }
    public override void Update()
    {
        Debug.Log("MenuState: Waiting for input...");

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Play selected - switch to gameplay state.");
        }
    }
}

public class SettingsState : GameState
{
    public override void Enter()
    {
        Debug.Log("Entering Settings State...");
    }

    public override void Update()
    {
        Debug.Log("Settings menu active...");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Settings State...");
    }
}

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance { get; private set; }
    private GameState currentState;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ChangeState(new MenuState());
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(GameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}


