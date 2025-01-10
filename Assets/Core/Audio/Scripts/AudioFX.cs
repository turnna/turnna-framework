using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFX : MonoBehaviour
{
    [Tooltip("Listen to Event Channels")]
    [SerializeField] private List<VoidEventChannelSO> m_StartAudioEventChannels;

    [Tooltip("Listen to Stop Event Channels")]
    [SerializeField] private List<VoidEventChannelSO> m_StopAudioEventChannels;

    private AudioSource m_AudioSource;

    public void OnEnable()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.outputAudioMixerGroup = AudioMixerManager.Instance.SFXAudioGroup;
        m_AudioSource.playOnAwake = false;

        foreach (var eventChannel in m_StartAudioEventChannels)
        {
            eventChannel.OnEventRaised += PlayAudioFX;
        }

        foreach (var eventChannel in m_StopAudioEventChannels)
        {
            eventChannel.OnEventRaised += StopAudioFX;
        }
    }

    public void OnDisable()
    {
        foreach (var eventChannel in m_StartAudioEventChannels)
        {
            eventChannel.OnEventRaised -= PlayAudioFX;
        }

        foreach (var eventChannel in m_StopAudioEventChannels)
        {
            eventChannel.OnEventRaised -= StopAudioFX;
        }
    }

    public void PlayAudioFX()
    {
        m_AudioSource.Play();
    }

    public void StopAudioFX()
    {
        m_AudioSource.Stop();
    }
}
