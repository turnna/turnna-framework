using UnityEngine;

public abstract class GameStateSO : ScriptableObject, IState
{
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnStateUpdate() { }

    protected GameManager GameManager;
    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

}