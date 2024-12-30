using UnityEngine;

public abstract class GameStateSO : ScriptableObject, IState
{
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnStateUpdate() { }

    protected GameManager m_GameManager;
    public void Initialize(GameManager gameManager)
    {
        m_GameManager = gameManager;
    }

}