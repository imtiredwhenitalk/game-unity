using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	[SerializeField] private Slider musicVolumeSlider;

	void Start()
	{
		float currentVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
		musicVolumeSlider.value = currentVolume;

		musicVolumeSlider.onValueChanged.AddListener(OnMusicSliderChanged);
	}

	private void OnMusicSliderChanged(float value)
	{
		MusicManager.Instance.SetVolume(value);
	}
}