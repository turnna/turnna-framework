using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a state machine that manages transitions between different states.
/// </summary>
public abstract class StateMachine : MonoBehaviour
{
    /// <summary>
    /// The current state of the state machine.
    /// </summary>
    public IState CurrentState;

    /// <summary>
    /// A dictionary that holds all possible states of the state machine.
    /// </summary>
    public Dictionary<Type, IState> StateTable = new();

    /// <summary>
    /// Updates the current state.
    /// </summary>
    public virtual void Update()
    {
        CurrentState.OnStateUpdate();
    }

    /// <summary>
    /// Switches the state machine to a new state.
    /// </summary>
    /// <param name="newState">The new state to switch to.</param>
    public virtual void SwitchState(IState newState)
    {
        CurrentState?.OnStateExit();
        CurrentState = newState;
        CurrentState.OnStateEnter();
    }

    /// <summary>
    /// Switches the state machine to a new state by type.
    /// </summary>
    /// <param name="newStateType">The type of the new state to switch to.</param>
    public virtual void SwitchState(Type newStateType)
    {
        CurrentState?.OnStateExit();
        CurrentState = StateTable[newStateType];
        CurrentState.OnStateEnter();
    }
}