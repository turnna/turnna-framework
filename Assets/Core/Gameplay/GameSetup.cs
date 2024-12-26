using Assets.Core.Gameplay.ScriptableObjects;
using Assets.Core.Input.ScriptableObjects;
using Assets.Core.Utilities;
using Assets.Core.Utilities.SaveLoad;
using Assets.Core.Utilities.SaveLoad.ScriptableObjects;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Core.Gameplay
{
    public class GameSetup : MonoBehaviour
    {
        // Default filename/subfolder for saving persistent data
        private const string k_JsonFilename = "CoreSaveData.json";
        private const string k_JsonSubfolder = "Json";
        private const string k_CoreSaveDataSOName = "CoreSaveDataFromJson";

        [Header("Save Data")]
        [Tooltip("Game data for core gameplay")]
        [SerializeField] private CoreSaveDataSO m_CoreSaveData;

        [Tooltip("Event relayer for Input System actions")]
        private CoreInputReaderSO m_InputReader;

        [Header("Json Data")]
        [Tooltip("Json file for level data")]
        [SerializeField] private string m_JsonFilename;

        private GameDataSO m_GameData;

        [SerializeField] private GameObject m_PlayerPrefab;


        private void OnValidate()
        {
            if (m_JsonFilename == string.Empty)
            {
                m_JsonFilename = k_JsonFilename;
            }
        }


        public void Initialize(GameDataSO gameDataSO, CoreInputReaderSO inputReader)
        {
            m_InputReader = inputReader;
            m_GameData = gameDataSO;

            m_CoreSaveData = InitializeFromJson();

#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(m_CoreSaveData);
#endif


            // Check to see if all required fields in the Inspector exist
            NullRefChecker.Validate(this);
        }

        public CoreSaveDataSO InitializeFromJson()
        {
            // TODO: Load JSON file
            // Load JSON file
            // Initialize inputReader from JSON
            string loadedFile = SaveManager.LoadTextFile(m_JsonFilename, k_JsonSubfolder);

            CoreSaveDataSO tempLevelLayout = ScriptableObject.CreateInstance<CoreSaveDataSO>();
            tempLevelLayout.name = k_CoreSaveDataSOName;

            JsonUtility.FromJsonOverwrite(loadedFile, tempLevelLayout);
            return tempLevelLayout;
        }

        public void SetupLevel()
        {
            Instantiate(m_PlayerPrefab, Vector3.zero, Quaternion.identity);

        }

    }


}