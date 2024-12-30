using UnityEngine;

/// <summary>
/// This controls the flow of gameplay in the game. The GameManager notifies listeners of
/// game states. 
/// </summary>


[RequireComponent(typeof(GameSetup))]
public abstract class GameManager : StateMachine
{
    [Header("Listen to Event Channels")]
    [Tooltip("Notifies listeners to go back to main menu scene")]
    [SerializeField] private VoidEventChannelSO m_GameQuit;

    [Header("Game State")]
    [Tooltip("Game states for the game")]
    [SerializeField] private GameStateSO[] m_GameStates;

    public virtual void OnEnable()
    {
        m_GameQuit.OnEventRaised += OnGameQuit;
    }
    public virtual void OnDisable()
    {
        m_GameQuit.OnEventRaised -= OnGameQuit;
    }

    // Gets the GameSetup component and initializes any necessary dependencies
    private void Awake()
    {
        // Add all game states to the state table
        foreach (GameStateSO state in m_GameStates)
        {
            state.Initialize(this);
            StateTable.Add(state.GetType(), state);
        }

        SwitchState(StateTable[typeof(GameStateInitializeSO)]);
    }

    private void Start()
    {
        SwitchState(StateTable[typeof(GameStateStartSO)]);
    }
    private void OnGameQuit()
    {
        SwitchState(StateTable[typeof(GameStateQuitSO)]);
    }

}
