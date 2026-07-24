using UnityEngine;
using UnityEngine.Audio;

namespace Game.Core
{
    public class AudioManager : MonoBehaviour, IAudioService
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Mixer (опціонально, для плавної гучності в dB)")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string musicVolumeParam = "MusicVolume";
        [SerializeField] private string sfxVolumeParam = "SfxVolume";

        private const string MUSIC_VOLUME_KEY = "Audio_MusicVolume";
        private const string SFX_VOLUME_KEY = "Audio_SfxVolume";

        private float musicVolume = 0.75f;
        private float sfxVolume = 0.75f;

        private void Awake()
        {
            musicSource.loop = true;

            musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.75f);
            sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0.75f);

            ApplyMusicVolume();
            ApplySfxVolume();
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null) return;
            if (musicSource.clip == clip && musicSource.isPlaying) return;

            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        public void StopMusic() => musicSource.Stop();

        public void PlaySfx(AudioClip clip, float volumeScale = 1f)
        {
            if (clip == null) return;
            sfxSource.PlayOneShot(clip, volumeScale);
        }

        public void SetMusicVolume(float volume01)
        {
            musicVolume = Mathf.Clamp01(volume01);
            ApplyMusicVolume();
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, musicVolume);
            PlayerPrefs.Save();
        }

        public void SetSfxVolume(float volume01)
        {
            sfxVolume = Mathf.Clamp01(volume01);
            ApplySfxVolume();
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, sfxVolume);
            PlayerPrefs.Save();
        }

        public float GetMusicVolume() => musicVolume;
        public float GetSfxVolume() => sfxVolume;

        private void ApplyMusicVolume()
        {
            if (audioMixer != null)
            {
                // Логарифмічна шкала для мікшера (dB), 0.0001 щоб уникнути log(0)
                float dB = Mathf.Log10(Mathf.Max(musicVolume, 0.0001f)) * 20f;
                audioMixer.SetFloat(musicVolumeParam, dB);
            }
            else
            {
                musicSource.volume = musicVolume;
            }
        }

        private void ApplySfxVolume()
        {
            if (audioMixer != null)
            {
                float dB = Mathf.Log10(Mathf.Max(sfxVolume, 0.0001f)) * 20f;
                audioMixer.SetFloat(sfxVolumeParam, dB);
            }
            else
            {
                sfxSource.volume = sfxVolume;
            }
        }
    }
}