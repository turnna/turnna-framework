using System.Collections;
using System.Collections.Generic;
using Assets.Core.EventChannels.ScriptableObjects;
using Assets.Core.Input.ScriptableObjects;
using Assets.Core.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


namespace Assets.Core.Input.Binders
{
    /// <summary>
    /// This class connects a UI Elements Button to an event channel that takes no parameters.
    /// </summary>
    public class InputVoidEventChannelBinder : MonoBehaviour
    {

        [SerializeField] private CoreInputReaderSO m_inputReader;


        [Header("Broadcast on Event Channel")]
        [Tooltip("The event channel to raise.")]
        [SerializeField] private VoidEventChannelSO m_EventChannel;
        [Space]
        [Tooltip("Cooldown window between input.")]
        [SerializeField] private float m_Delay = 0.5f;

        private float m_TimeToNextEvent;

        // Valid dependencies (m_Button or m_Document) and log an error if missing
        private void Awake()
        {
            NullRefChecker.Validate(this);
        }

        private void Start()
        {
            m_inputReader.Escape += RaiseEvent;
        }

        private void OnDisable()
        {
            m_inputReader.Escape -= RaiseEvent;
        }

        private void RaiseEvent()
        {
            if (Time.time < m_TimeToNextEvent)
                return;

            m_EventChannel.RaiseEvent();
            m_TimeToNextEvent = Time.time + m_Delay;
        }


    }
}
