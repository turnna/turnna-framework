using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioFX", menuName = "Audio/AudioFX")]
public class AudioFXSO : ScriptableObject
{
    [Header("Event Channels")]
    [Tooltip("Listen event channels to play audio.")]
    [SerializeField] private List<VoidEventChannelSO> m_ListenEventChannels;

    [Header("Audio Clips")]
    [Tooltip("Audio clips to play.")]
    [SerializeField] private AudioClip m_AudioClips;

    [Header("GameObject with Audio Source")]
    [Tooltip("The GameObject with the AudioSource component.")]
    [SerializeField] private GameObject m_AudioSourceGameObject;

    public void OnEnable()
    {
        foreach (var eventChannel in m_ListenEventChannels)
        {
            eventChannel.OnEventRaised += PlayAudio;
        }
    }

    public void OnDisable()
    {
        foreach (var eventChannel in m_ListenEventChannels)
        {
            eventChannel.OnEventRaised -= PlayAudio;
        }
    }

    private void PlayAudio()
    {
        if (m_AudioSourceGameObject == null)
        {
            Debug.LogError("Missing assignment for field: m_AudioSourceGameObject in object: " + this.name, this);
            return;
        }

        if (m_AudioClips == null)
        {
            Debug.LogError("Missing assignment for field: m_AudioClips in object: " + this.name, this);
            return;
        }

        var audioSource = m_AudioSourceGameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Missing AudioSource component on GameObject: " + m_AudioSourceGameObject.name, m_AudioSourceGameObject);
            return;
        }

        audioSource.PlayOneShot(m_AudioClips);
    }

}