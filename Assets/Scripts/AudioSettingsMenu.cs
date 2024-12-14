using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
	public AudioMixer masterMixer;

	public Slider mainVolumeSlider;

	public Slider fxVolumeSlider;

	public Slider musicVolumeSLider;

	private bool isMuted;

	private void Start()
	{
		LoadMenuVariables();
	}

	public void ToggleMute(bool toggleValue)
	{
		isMuted = toggleValue;
		if (isMuted)
		{
			masterMixer.SetFloat("mainVolume", -80f);
		}
		else
		{
			masterMixer.SetFloat("mainVolume", Mathf.Log(mainVolumeSlider.value) * 20f);
		}
	}

	public void SetMainVolume(float sliderValue)
	{
		if (!isMuted)
		{
			masterMixer.SetFloat("mainVolume", Mathf.Log(sliderValue) * 20f);
		}
	}

	public void SetFxVolume(float sliderValue)
	{
		masterMixer.SetFloat("fxVolume", Mathf.Log(sliderValue) * 20f);
	}

	public void SetMusicVolume(float sliderValue)
	{
		masterMixer.SetFloat("musicVolume", Mathf.Log(sliderValue) * 20f);
	}

	public void SaveMenuVariables()
	{
		PlayerPrefs.SetInt("audioPrefsSaved", 0);
		PlayerPrefs.SetFloat("mainVolumeF", mainVolumeSlider.value);
	}

	public void LoadMenuVariables()
	{
		if (PlayerPrefs.HasKey("audioPrefsSaved"))
		{
			mainVolumeSlider.value = PlayerPrefs.GetFloat("mainVolumeF");
		}
	}
}
