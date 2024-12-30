using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GameState", fileName = "GameState_Start")]
public class GameStateStartSO : GameStateSO
{
    // TODO: add auto play feature

    [Tooltip("Begin gameplay")]
    [SerializeField] private VoidEventChannelSO m_GameStarted;
    public override void OnStateEnter()
    {
        m_GameStarted.RaiseEvent();
    }

    public override void OnStateExit()
    {
        m_GameManager.SwitchState(m_GameManager.StateTable[typeof(GameStatePlayingSO)]);
    }
}