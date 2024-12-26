using Assets.Core.EventChannels.ScriptableObjects;
using Assets.Core.Utilities;
using Assets.Core.Utilities.SaveLoad.ScriptableObjects;
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

    public void OnEnable()
    {
        m_masterVolumeChanged.OnEventRaised += SetMasterVolume;
        m_musicVolumeChanged.OnEventRaised += SetMusicVolume;
        m_sfxVolumeChanged.OnEventRaised += SetSFXVolume;
    }

    public void OnDisable()
    {
        m_masterVolumeChanged.OnEventRaised -= SetMasterVolume;
        m_musicVolumeChanged.OnEventRaised -= SetMusicVolume;
        m_sfxVolumeChanged.OnEventRaised -= SetSFXVolume;
    }

    public AudioSaveData GetAudioSaveData()
    {
        return new AudioSaveData
        {
            masterVolume = MapDBToVolume(audioMixer.GetFloat("MasterVolume", out float masterVolume) ? masterVolume : -40f),
            musicVolume = MapDBToVolume(audioMixer.GetFloat("MusicVolume", out float musicVolume) ? musicVolume : -40f),
            sfxVolume = MapDBToVolume(audioMixer.GetFloat("SFXVolume", out float sfxVolume) ? sfxVolume : -40f)
        };
    }

    private void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", MapVolumeToDB(volume));
    }

    private void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", MapVolumeToDB(volume));
    }

    private void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", MapVolumeToDB(volume));
    }

    private float MapVolumeToDB(float volume)
    {
        return volume > 0 ? Mathf.Log10(volume) * 20f : -80f;
    }

    private float MapDBToVolume(float db)
    {
        return Mathf.Pow(10f, db / 20f);
    }


}