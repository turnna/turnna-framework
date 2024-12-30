using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Game State/Pause", fileName = "GameState_Pause")]
public class GameStatePauseSO : GameStateSO
{

    [Tooltip("Notifies UIs to show pause menu")]
    [SerializeField] private VoidEventChannelSO m_PauseMenuShown;
    [Tooltip("Notifies UIs to show game screen")]
    [SerializeField] private VoidEventChannelSO m_GameScreenShown;

    public override void OnStateEnter()
    {
        // Raise event to show pause menu
        m_PauseMenuShown.RaiseEvent();

        // TODO: Add time scale to pause the game
    }

    public override void OnStateExit()
    {
        // Raise event to hide pause menu
        m_GameScreenShown.RaiseEvent();
    }
}
