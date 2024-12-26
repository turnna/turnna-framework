public class AudioFXManager : Singleton<AudioFXManager>
{

    public void PlayAudioFX(AudioFX audioFX)
    {
        audioFX.PlayAudioFX();
    }
}