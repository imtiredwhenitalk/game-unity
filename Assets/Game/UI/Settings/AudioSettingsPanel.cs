using UnityEngine;
using UnityEngine.UI;
using Game.Core;

namespace Game.UI
{
    public class AudioSettingsPanel : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private IAudioService audioService;

        private void Start()
        {
            audioService = ServiceLocator.Get<IAudioService>(); // або через DI-контейнер

            musicSlider.value = audioService.GetMusicVolume();
            sfxSlider.value = audioService.GetSfxVolume();

            musicSlider.onValueChanged.AddListener(audioService.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(audioService.SetSfxVolume);
        }
    }
}