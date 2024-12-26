using Assets.Core.Utilities.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Core.Utilities.SaveLoad.ScriptableObjects
{
    /// <summary>
    /// A data container defining the main save data for the game.
    /// Use the ExportToJson method to export a file that can be modded outside of Unity.
    /// </summary>
    [CreateAssetMenu(menuName = "Save Data/Core SaveData", fileName = "CoreSaveData")]
    public class CoreSaveDataSO : DescriptionSO
    {
        // The default JSON file name and enclosing folder
        private const string k_JsonFilename = "CoreSaveData.json";
        private const string k_JsonSubfolder = "Json";

        // The JSON file name to export
        [Header("Export")]
        [Tooltip("Json file to write to Application persistent path")]
        [SerializeField] private string m_JsonFilename = "CoreSaveData.json";

        // Properties
        public string JsonFilename => m_JsonFilename;

        [SerializeField] private int m_test;

        // Sets a default name if jsonFilename left blank in the Inspector
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(m_JsonFilename))
                m_JsonFilename = k_JsonFilename;
        }

        // This exports a Json file to the Application PersistentPath and returns the string
        public string ExportToJson()
        {
            string json = SaveManager.GetSavePath(k_JsonSubfolder) + k_JsonFilename;
            SaveManager.Save(this, k_JsonFilename, k_JsonSubfolder);
            return json;
        }

    }
}