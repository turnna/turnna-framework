using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public struct GameStateEventChannel
{
    public VoidEventChannelSO eventChannel;
    public GameStateSO gameState;
}

/// <summary>
/// This controls the flow of gameplay in the game. The GameManager notifies listeners of
/// game states. 
/// </summary>
// [RequireComponent(typeof(GameSetup))]
public abstract class GameManager : StateMachine<GameStateSO>
{
    // [Tooltip("Required component for setup and initialization")]
    // [SerializeField] private GameSetup m_GameSetup;

    [Header("Game State")]
    [Tooltip("Game states to manage")]
    [SerializeField] private List<GameStateEventChannel> m_GameStates;
    // public GameSetup GameSetup => m_GameSetup;

    public virtual void OnEnable()
    {
        foreach (GameStateEventChannel state in m_GameStates)
        {
            if (state.eventChannel)
            {
                state.eventChannel.OnEventRaised = () => SwitchState(state.gameState); // TODO: finding why can't use += -= here
            }
        }
    }
    public virtual void OnDisable()
    {
        foreach (GameStateEventChannel state in m_GameStates)
        {
            if (state.eventChannel)
            {
                state.eventChannel.OnEventRaised = null; // TODO: finding why can't use += -= here
            }
        }
    }

    // Gets the GameSetup component and initializes any necessary dependencies
    public void Awake()
    {
        // Add all game states to the state table
        foreach (GameStateEventChannel state in m_GameStates)
        {
            NullRefChecker.Validate(state.gameState);
            state.gameState.Initialize(this);
            StateTable.Add(state.gameState.GetType(), state.gameState);
        }
        SwitchState(StateTable[typeof(GameStateInitializeSO)]);
    }


    public void Start()
    {
        SwitchState(StateTable[typeof(GameStateStartSO)]);

        // TODO: add auto play feature
        SwitchState(StateTable[typeof(GameStatePlayingSO)]);
    }


}
