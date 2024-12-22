using Assets.Core.Input.ScriptableObjects;
using Assets.Core.Utilities;
using UnityEngine;

namespace Assets.Core.Gameplay
{
    public class GameSetup : MonoBehaviour
    {
        [Tooltip("Event relayer for Input System actions")]
        private CoreInputReaderSO m_InputReader;

        public void Initialize(CoreInputReaderSO inputReader)
        {
            m_InputReader = inputReader;

            InitializeFromJson();

            // Check to see if all required fields in the Inspector exist
            NullRefChecker.Validate(this);
        }

        public void InitializeFromJson()
        {
            // TODO: Load JSON file
            // Load JSON file
            // Initialize inputReader from JSON
        }

    }


}