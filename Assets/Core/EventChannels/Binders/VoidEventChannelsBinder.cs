using UnityEngine;

/// <summary>
/// This class binds two VoidEventChannelSO objects together. When an event is raised on the listen event channel,
/// it will broadcast the event on the broadcast event channel after a specified delay.
/// </summary>
public class EventChannelsBinder : MonoBehaviour
{

    [Header("Listen to Event Channel")]
    [Tooltip("The event channel to listen to.")]
    [SerializeField] private VoidEventChannelSO m_listenEventChannel;



    [Header("Broadcast on Event Channel")]
    [Tooltip("The event channel to raise.")]
    [SerializeField] private VoidEventChannelSO m_broadCastEventChannel;
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
        m_listenEventChannel.OnEventRaised += RaiseEvent;
    }

    private void OnDisable()
    {
        m_listenEventChannel.OnEventRaised -= RaiseEvent;
    }

    private void RaiseEvent()
    {
        if (Time.time < m_TimeToNextEvent)
            return;

        m_broadCastEventChannel.RaiseEvent();
        m_TimeToNextEvent = Time.time + m_Delay;
    }


}

