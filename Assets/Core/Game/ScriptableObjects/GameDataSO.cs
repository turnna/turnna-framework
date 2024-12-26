using Assets.Core.Utilities;
using Assets.Core.Utilities.SaveLoad.ScriptableObjects;
using Assets.Core.Utilities.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Core.Gameplay.ScriptableObjects
{
    /// <summary>
    /// General game settings (ball and paddle speed, etc.). Adjust these to customize the gameplay.
    /// </summary>
    [CreateAssetMenu(menuName = "Gameplay/GameData", fileName = "GameData")]
    public class GameDataSO : DescriptionSO
    {
        [Header("Save Data")]
        [Tooltip("Game data for core gameplay")]
        [SerializeField] private CoreSaveDataSO m_CoreSaveData;

        private void OnEnable()
        {
            NullRefChecker.Validate(this);
        }

    }
}