using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Game State/Playing", fileName = "GameState_Playing")]
public class GameStatePlayingSO : GameStateSO
{
    [Tooltip("ScriptableObject for relaying input")]
    [SerializeField] private CoreInputReaderSO m_InputReader;

    public override void OnStateEnter()
    {
        // Enable gameplay input
        m_InputReader.EnableGameInput();
    }

    public override void OnStateExit()
    {
        // Disable gameplay input
        m_InputReader.DisableGameInput();
    }
}