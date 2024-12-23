using Assets.Core.EventChannels.ScriptableObjects;
using Assets.Core.Utilities;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : Singleton<AudioMixerManager>
{
    [Header("Listen to audio Event Channels")]
    [SerializeField] private FloatEventChannelSO m_masterVolumeChanged;
    [SerializeField] private FloatEventChannelSO m_musicVolumeChanged;
    [SerializeField] private FloatEventChannelSO m_sfxVolumeChanged;

    [Header("Audio Mixer")]
    [SerializeField] public AudioMixer audioMixer;

    // Audio Mixer Groups
    public AudioMixerGroup MasterAudioGroup => audioMixer.FindMatchingGroups("Master")[0];
    public AudioMixerGroup MusicAudioGroup => audioMixer.FindMatchingGroups("Master/Music")[0];
    public AudioMixerGroup SFXAudioGroup => audioMixer.FindMatchingGroups("Master/SFX")[0];

    private void OnEnable()
    {
        m_masterVolumeChanged.OnEventRaised += SetMasterVolume;
        m_musicVolumeChanged.OnEventRaised += SetMusicVolume;
        m_sfxVolumeChanged.OnEventRaised += SetSFXVolume;
    }

    private void OnDisable()
    {
        m_masterVolumeChanged.OnEventRaised -= SetMasterVolume;
        m_musicVolumeChanged.OnEventRaised -= SetMusicVolume;
        m_sfxVolumeChanged.OnEventRaised -= SetSFXVolume;
    }



    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume > 0 ? Mathf.Log10(volume) * 20f : -80f);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume > 0 ? Mathf.Log10(volume) * 20f : -80f);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume > 0 ? Mathf.Log10(volume) * 20f : -80f);
    }
}