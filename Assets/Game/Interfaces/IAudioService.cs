public interface IAudioService
{
    void PlayMusic(AudioClip clip, bool loop = true);
    void StopMusic();
    void PlaySfx(AudioClip clip, float volumeScale = 1f);
    void SetMusicVolume(float volume01);
    void SetSfxVolume(float volume01);
    float GetMusicVolume();
    float GetSfxVolume();
}