using System.Collections;
using System.Collections.Generic;
using Assets.Core.EventChannels.ScriptableObjects;
using Assets.Core.Utilities;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Core.EventChannels.Binders
{
    /// <summary>
    /// This class connects a UI Elements Slider to an event channel that takes a float parameter.
    /// </summary>
    public class SliderEventChannelBinder : MonoBehaviour
    {
        [Header("UI Elements")]
        [Tooltip("The UI Toolkit document.")]
        [SerializeField] private UIDocument m_Document;
        [Tooltip("The name of the Slider to query for.")]
        [SerializeField, Optional] private string m_SliderID;

        [Header("Broadcast on Event Channel")]
        [Tooltip("The event channel to raise.")]
        [SerializeField] private FloatEventChannelSO m_EventChannel;

        private VisualElement m_Root;
        private Slider m_Slider;

        // Valid dependencies (m_Slider or m_Document) and log an error if missing
        private void Awake()
        {
            NullRefChecker.Validate(this);
            ValidateSlider();
        }

        private void Start()
        {
            m_Root = m_Document.rootVisualElement;
            m_Slider = m_Root.Q<Slider>(m_SliderID);

            m_Slider.RegisterValueChangedCallback(evt => RaiseEvent(evt.newValue));
        }

        private void OnDisable()
        {
            m_Slider.UnregisterValueChangedCallback(evt => RaiseEvent(evt.newValue));
        }

        private void RaiseEvent(float value)
        {
            m_EventChannel.RaiseEvent(value);
        }

        private void ValidateSlider()
        {
            if (string.IsNullOrEmpty(m_SliderID))
            {
                Debug.LogError("Missing assignment for field: m_SliderID in object: " + this.gameObject, transform);
            }
        }
    }
}