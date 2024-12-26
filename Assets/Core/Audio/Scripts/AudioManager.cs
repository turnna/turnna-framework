using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Listen to event channels")]
    [SerializeField] private VoidEventChannelSO m_SaveSettings;

    [Header("Broadcast to audio Event Channels")]
    [SerializeField] private FloatEventChannelSO m_masterVolumeChanged;
    [SerializeField] private FloatEventChannelSO m_musicVolumeChanged;
    [SerializeField] private FloatEventChannelSO m_sfxVolumeChanged;

    [Header("Core Save Data")]

    [SerializeField] private CoreSaveDataSO m_CoreSaveData;

    public void OnEnable()
    {
        // Subscribe to the event channel
        m_SaveSettings.OnEventRaised += SaveAudioSettings;
    }
    public void OnDisable()
    {
        // Unsubscribe from the event channel
        m_SaveSettings.OnEventRaised -= SaveAudioSettings;
    }


    public void Start()
    {
        // Load the audio settings from the CoreSaveDataSO
        m_CoreSaveData.LoadFromJson();
        m_masterVolumeChanged.RaiseEvent(m_CoreSaveData.AudioSaveData.masterVolume);
        m_musicVolumeChanged.RaiseEvent(m_CoreSaveData.AudioSaveData.musicVolume);
        m_sfxVolumeChanged.RaiseEvent(m_CoreSaveData.AudioSaveData.sfxVolume);
    }


    public void SaveAudioSettings()
    {
        // Overwrite the audio settings in the CoreSaveDataSO
        m_CoreSaveData.AudioSaveData = AudioMixerManager.Instance.GetAudioSaveData();

        m_CoreSaveData.SaveToJson();
    }
}

