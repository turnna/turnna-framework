using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GameState", fileName = "GameState_Quit")]
public class GameStateQuitSO : GameStateSO
{
    [Tooltip("Notifies listeners to go back to main menu scene")]
    [SerializeField] private VoidEventChannelSO m_LastSceneUnloaded;
    [Tooltip("Notifies UIs to close all screens and go back to home screen")]
    [SerializeField] private VoidEventChannelSO m_HomeScreenShown;

    public override void OnStateEnter()
    {
        // Raise event to go back to main menu scene
        m_LastSceneUnloaded.RaiseEvent();
        m_HomeScreenShown.RaiseEvent();
    }

}
