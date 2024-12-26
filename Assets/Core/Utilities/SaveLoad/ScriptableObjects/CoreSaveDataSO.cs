using System;
using Assets.Core.Utilities.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Core.Utilities.SaveLoad.ScriptableObjects
{
    [Serializable]
    public struct AudioSaveData
    {
        public float masterVolume;
        public float musicVolume;
        public float sfxVolume;
    }

    /// <summary>
    /// A data container defining the main save data for the game.
    /// Use the ExportToJson method to export a file that can be modded outside of Unity.
    /// </summary>
    [CreateAssetMenu(menuName = "Save Data/Core SaveData", fileName = "CoreSaveData")]
    public class CoreSaveDataSO : DescriptionSO
    {
        // The default JSON file name and enclosing folder
        private const string k_JsonFilename = "Default.json";
        private const string k_JsonSubfolder = "Core";


        // The JSON file name to export
        [Header("Export")]
        [Tooltip("Json file to write to Application persistent path")]
        [SerializeField] private string m_JsonFilename;

        // Properties
        public string JsonFilename => m_JsonFilename;

        // The main save data
        [Header("Audio Data")]
        [Tooltip("Default Audio Save Data")]
        [SerializeField] private AudioSaveData m_DefaultAudioSaveData;
        [Tooltip("Audio Save Data")]
        [SerializeField] public AudioSaveData AudioSaveData;

        // Sets a default name if jsonFilename left blank in the Inspector
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(m_JsonFilename))
                m_JsonFilename = k_JsonFilename;
        }

        public void OnEnable()
        {
            if (AudioSaveData.Equals(new AudioSaveData()))
            {
                AudioSaveData = m_DefaultAudioSaveData;
            }
        }

        // This exports a Json file to the Application PersistentPath and returns the string
        public string SaveToJson()
        {
            string json = SaveManager.GetSavePath(k_JsonSubfolder) + k_JsonFilename;
            SaveManager.Save(this, k_JsonFilename, k_JsonSubfolder);
            return json;
        }

        public void LoadFromJson()
        {
            if (!SaveManager.IsSaveFile(m_JsonFilename, k_JsonSubfolder))
            {
                Debug.LogWarning("No save file found. Using default values.");
                return;
            }

            // Load JSON file
            string loadedFile = SaveManager.LoadTextFile(m_JsonFilename, k_JsonSubfolder);
            JsonUtility.FromJsonOverwrite(loadedFile, this);
        }


    }
}