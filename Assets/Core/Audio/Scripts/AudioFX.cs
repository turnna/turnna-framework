using System;
using System.Collections.Generic;
using Assets.Core.EventChannels.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;

namespace Assets.Core.Audio.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioFX : MonoBehaviour
    {
        [Tooltip("Listen to Event Channels")]
        [SerializeField] private List<VoidEventChannelSO> m_EventChannels;

        private AudioSource m_AudioSource;

        public void OnEnable()
        {
            m_AudioSource = GetComponent<AudioSource>();
            m_AudioSource.outputAudioMixerGroup = AudioMixerManager.Instance.SFXAudioGroup;
            m_AudioSource.playOnAwake = false;

            foreach (var eventChannel in m_EventChannels)
            {
                eventChannel.OnEventRaised += PlayAudioFX;
            }
        }

        public void OnDisable()
        {
            foreach (var eventChannel in m_EventChannels)
            {
                eventChannel.OnEventRaised -= PlayAudioFX;
            }
        }

        public void PlayAudioFX()
        {
            Debug.Log("Playing AudioFX");
            m_AudioSource.Play();
        }
    }

}