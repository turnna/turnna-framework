using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GameState", fileName = "GameState_Initialize")]
public class GameStateInitializeSO : GameStateSO
{
    [Tooltip("Required component for setup and initialization")]
    [SerializeField] private GameSetup m_GameSetup;

    [Tooltip("ScriptableObject for game data")]
    [SerializeField] private GameDataSO m_GameData;

    [Tooltip("ScriptableObject for relaying input")]
    [SerializeField] private CoreInputReaderSO m_InputReader;

    public override void OnStateEnter()
    {
        // Initialize the game 
        m_GameSetup.Initialize(m_GameData, m_InputReader);
        m_GameSetup.SetupLevel();

    }

}