using UnityEngine;
using UnityEngine.UIElements;

namespace Core
{
    /// <summary>
    /// This class connects a UI Elements Button to a generic event channel.
    /// </summary>
    public abstract class ButtonGenericEventChannelBinder<T, K> : MonoBehaviour where T : GenericEventChannelSO<K>
    {
        [Header("UI Elements")]
        [Tooltip("The UI Toolkit document.")]
        [SerializeField] private UIDocument m_Document;
        [Tooltip("The name of the Button to query for.")]
        [SerializeField, Optional] private string m_ButtonID;

        [Header("Broadcast on Event Channel")]
        [Tooltip("The event channel to raise.")]
        [SerializeField] private T m_EventChannel;
        [Tooltip("The data to send with the event.")]
        [SerializeField] private K m_Data;
        [Space]
        [Tooltip("Cooldown window between button clicks.")]
        [SerializeField] private float m_Delay = 0.5f;

        private VisualElement m_Root;
        private Button m_Button;
        private float m_TimeToNextEvent;

        // Valid dependencies (m_Button or m_Document) and log an error if missing
        public virtual void Awake()
        {
            NullRefChecker.Validate(this);
            ValidateButton();
        }

        public virtual void Start()
        {
            m_Root = m_Document.rootVisualElement;
            m_Button = m_Root.Q<Button>(m_ButtonID);

            m_Button.clicked += RaiseEvent;

            // Alternatively, use the RegisterCallback method
            // m_Button.RegisterCallback<ClickEvent>(evt => RaiseEvent());
        }

        public virtual void OnDisable()
        {
            m_Button.clicked -= RaiseEvent;
        }

        public virtual void RaiseEvent()
        {
            if (Time.time < m_TimeToNextEvent)
                return;

            // Assuming the event channel has a method called RaiseEvent
            m_EventChannel.RaiseEvent(m_Data);
            m_TimeToNextEvent = Time.time + m_Delay;
        }

        public virtual void ValidateButton()
        {
            if (string.IsNullOrEmpty(m_ButtonID))
            {
                Debug.LogError("Missing assignment for field: m_ButtonID in object: " + this.gameObject, transform);
            }
        }
    }

}
