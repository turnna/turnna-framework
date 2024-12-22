using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Core.Utilities;
using Assets.Core.EventChannels.ScriptableObjects;
using UnityEditor;

namespace Assets.Core.SceneManagement.Scripts
{
    /// <summary>
    /// Use this basic helper for loading scenes by name, index, etc.
    /// 
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        // Fields
        [Header("Listen to Event Channels")]
        [Tooltip("Loads a scene by its Scene path string")]
        [SerializeField, Optional] private SceneFieldChannelSO m_LoadPathEventChannel;
        [Tooltip("Reloads the current scene")]
        [SerializeField, Optional] private VoidEventChannelSO m_ReloadEventChannel;
        [Tooltip("Loads the next scene by index in the Build Settings")]
        [SerializeField, Optional] private VoidEventChannelSO m_LoadNextEventChannel;

        [Tooltip("Unloads the last scene, stops gameplay")]
        [SerializeField, Optional] private VoidEventChannelSO m_LastSceneUnloaded;

        // Default loaded scene that serves as the entry point and does not unload
        private Scene m_BootstrapScene;

        // The previously loaded scene
        private Scene m_LastLoadedScene;

        public Scene BootstrapScene => m_BootstrapScene;

        private void OnEnable()
        {
            if (m_LoadPathEventChannel != null)
                m_LoadPathEventChannel.OnEventRaised += LoadSceneBySceneField;

            if (m_ReloadEventChannel != null)
                m_ReloadEventChannel.OnEventRaised += ReloadScene;

            if (m_LastSceneUnloaded != null)
                m_LastSceneUnloaded.OnEventRaised += UnloadScene;
        }

        private void OnDisable()
        {
            if (m_LoadPathEventChannel != null)
                m_LoadPathEventChannel.OnEventRaised -= LoadSceneBySceneField;

            if (m_ReloadEventChannel != null)
                m_ReloadEventChannel.OnEventRaised -= ReloadScene;

            if (m_LastSceneUnloaded != null)
                m_LastSceneUnloaded.OnEventRaised -= UnloadScene;
        }

        // Event-handling methods
        public void LoadSceneBySceneField(SceneField scene)
        {
            StartCoroutine(LoadScene(scene));
        }

        public void UnloadScene()
        {
            StartCoroutine(UnloadLastScene());
        }

        // Reload the current scene
        public void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        // Load the next scene by index in the Build Settings
        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        // Load a scene by its index number (non-additively)
        public void LoadScene(int buildIndex)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(buildIndex);

            if (string.IsNullOrEmpty(scenePath))
            {
                Debug.LogError("SceneLoader.LoadScene: invalid sceneBuildIndex");
                return;
            }

            SceneManager.LoadScene(scenePath);
        }


        // Coroutine to unload the previous scene and then load a new scene by scene path string
        private IEnumerator LoadScene(SceneField scene)
        {
            if (string.IsNullOrEmpty(scene))
            {
                Debug.LogError("SceneLoader: Invalid scene name");
                yield break;
            }

            yield return UnloadLastScene();
            yield return LoadSceneAsync(scene);
        }

        // Coroutine to load a scene asynchronously by scene path string in Additive mode,
        // keeps the original scene as the active scene.
        private IEnumerator LoadSceneAsync(SceneField scene)
        {
            //Debug.Log("System IO path = " + Path.GetFileName(scenePath));

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {
                float progress = asyncLoad.progress;
                yield return null;
            }

            m_LastLoadedScene = SceneManager.GetSceneByName(scene);
            SceneManager.SetActiveScene(m_LastLoadedScene);
        }


        // Unloads the previously loaded scene if it's not the bootstrap scene
        private IEnumerator UnloadLastScene()
        {
            if (m_LastLoadedScene != m_BootstrapScene)
                yield return UnloadScene(m_LastLoadedScene);
        }

        // Coroutine to unload a specific Scene asynchronously
        private IEnumerator UnloadScene(Scene scene)
        {
            if (!m_LastLoadedScene.IsValid())
                yield break;

            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(scene);

            while (!asyncUnload.isDone)
            {
                yield return null;
            }
        }

    }
}

