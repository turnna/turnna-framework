using UnityEngine;
using UnityEditor;
using Assets.Core.Utilities.SaveLoad.ScriptableObjects;

namespace Assets.Core.Utilities.SaveLoad.Editors
{
    /// <summary>
    /// This adds an extra Save JSON button to the LevelLayoutSO Inspector to help the user
    /// export a JSON file.
    /// </summary>

    [CustomEditor(typeof(CoreSaveDataSO))]
    public class CoreSaveDataSOEditor : Editor
    {

        // Draws the LevelLayoutSO Inspector and then adds an extra Button for saving a JSON file.
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CoreSaveDataSO myCoreSaveDataSO = (CoreSaveDataSO)target;

            if (GUILayout.Button("Save JSON"))
            {
                string resultingString = myCoreSaveDataSO.ExportToJson();
            }
        }
    }
}
