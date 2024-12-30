using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Game State/Initialize", fileName = "GameState_Initialize")]
public class GameStateInitializeSO : GameStateSO
{
    [Tooltip("ScriptableObject for game data")]
    [SerializeField] private GameDataSO m_GameData;

    [Tooltip("ScriptableObject for relaying input")]
    [SerializeField] private CoreInputReaderSO m_InputReader;

    public override void OnStateEnter()
    {
        // Initialize the game 
        GameManager.GameSetup.Initialize(m_GameData, m_InputReader);
        GameManager.GameSetup.SetupLevel();

    }

}