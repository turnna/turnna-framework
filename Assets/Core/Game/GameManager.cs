using UnityEngine;

/// <summary>
/// This controls the flow of gameplay in the game. The GameManager notifies listeners of
/// game states. 
/// </summary>


[RequireComponent(typeof(GameSetup))]
public abstract class GameManager : MonoBehaviour
{
    [Tooltip("Starts the game automatically when loading scene")]
    [SerializeField] private bool m_AutoStart = true;
    [Tooltip("Required component for setup and initialization")]
    [SerializeField] private GameSetup m_GameSetup;
    [Tooltip("ScriptableObject for relaying input")]
    [SerializeField] private CoreInputReaderSO m_InputReader;
    [Tooltip("ScriptableObject for game data")]
    [SerializeField] private GameDataSO m_GameData;

    [Header("Broadcast on Event Channels")]
    [Tooltip("Begin gameplay")]
    [SerializeField] private VoidEventChannelSO m_GameStarted;
    [Tooltip("End gameplay")]
    [SerializeField] private VoidEventChannelSO m_GameEnded;
    [Tooltip("Notifies listeners to go back to main menu scene")]
    [SerializeField] private VoidEventChannelSO m_LastSceneUnloaded;
    [Tooltip("Notifies UIs to close all screens and go back to home screen")]
    [SerializeField] private VoidEventChannelSO m_HomeScreenShown;

    [Header("Listen to Event Channels")]
    [Tooltip("Notifies listeners to go back to main menu scene")]
    [SerializeField] private VoidEventChannelSO m_GameQuit;

    public virtual void OnEnable()
    {
        m_GameQuit.OnEventRaised += OnUnloadScene;
    }
    public virtual void OnDisable()
    {
        m_GameQuit.OnEventRaised -= OnUnloadScene;
    }

    // Gets the GameSetup component and initializes any necessary dependencies
    private void Awake()
    {
        Initialize();
    }

    // Plays the game automatically if m_AutoStart is enabled
    private void Start()
    {
        if (m_AutoStart)
            StartGame();
    }

    // Fills in the required GameSetup component if not assigned in the Inspector.
    public void Reset()
    {
        if (m_GameSetup == null)
            m_GameSetup = GetComponent<GameSetup>();
    }

    // Checks if we are missing any necessary components/assets/dependencies to play the game. Passes dependences
    // to the m_GameSetup and then sets up the walls, ball, and paddles.
    private void Initialize()
    {
        NullRefChecker.Validate(this);

        // Initialize the game 
        m_GameSetup.Initialize(m_GameData, m_InputReader); // TODO: async
        m_GameSetup.SetupLevel();

        // Enable gameplay input
        m_InputReader.EnableGameInput();
    }


    public virtual void StartGame()
    {
        m_GameStarted.RaiseEvent();
    }

    public virtual void EndGame()
    {
        m_GameEnded.RaiseEvent();
    }

    private void ResetGame()
    {
        StartGame();
    }

    private void PauseGame(bool state)
    {
        Time.timeScale = (state) ? 0 : 1;
    }

    private void OnUnloadScene()
    {
        // Disable game playinput
        m_InputReader.DisableGameInput();

        // Raise event to go back to main menu scene
        m_LastSceneUnloaded.RaiseEvent();
        m_HomeScreenShown.RaiseEvent();

    }


}
