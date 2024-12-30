using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Game State/Start", fileName = "GameState_Start")]
public class GameStateStartSO : GameStateSO
{
    [Tooltip("Begin gameplay")]
    [SerializeField] private VoidEventChannelSO m_GameStarted;
    public override void OnStateEnter()
    {
        m_GameStarted.RaiseEvent();
    }

}