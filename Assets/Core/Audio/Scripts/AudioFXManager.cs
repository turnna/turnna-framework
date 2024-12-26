using System.Collections.Generic;
using Assets.Core.Audio.Scripts;
using UnityEngine;

public class AudioFXManager : Singleton<AudioFXManager>
{

    public void PlayAudioFX(AudioFX audioFX)
    {
        audioFX.PlayAudioFX();
    }
}