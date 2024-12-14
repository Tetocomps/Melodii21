using UnityEngine;

public class GameMenuController : MonoBehaviour
{
	public GameObject menuCanvasObj;

	private float previousTimescale;

	private bool menuOpen;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !menuOpen)
		{
			ButtonToggleMenu();
		}
	}

	public void ButtonToggleMenu()
	{
		if (!menuOpen)
		{
			previousTimescale = Time.timeScale;
			Time.timeScale = 0f;
			menuCanvasObj.SetActive(value: true);
			menuOpen = true;
		}
		else
		{
			Time.timeScale = previousTimescale;
			menuOpen = false;
		}
	}

	public void DeletePlayerprefs()
	{
		PlayerPrefs.DeleteKey("graphicsPrefsSaved");
		PlayerPrefs.DeleteKey("FPSToggle");
		PlayerPrefs.DeleteKey("graphicsSlider");
		PlayerPrefs.DeleteKey("antiAliasSlider");
		PlayerPrefs.DeleteKey("shadowResolutionSlider");
		PlayerPrefs.DeleteKey("textureQualitySlider");
		PlayerPrefs.DeleteKey("anisotropicModeSlider");
		PlayerPrefs.DeleteKey("anisotropicLevelSlider");
		PlayerPrefs.DeleteKey("wantedResolutionX");
		PlayerPrefs.DeleteKey("wantedResolutionY");
		PlayerPrefs.DeleteKey("windowedModeToggle");
		PlayerPrefs.DeleteKey("vSyncToggle");
		PlayerPrefs.DeleteKey("audioPrefsSaved");
		PlayerPrefs.DeleteKey("mainVolumeF");
		PlayerPrefs.DeleteKey("fxVolumeF");
		PlayerPrefs.DeleteKey("musicVolumeF");
	}

	public void ButtonQuitGame()
	{
		Application.Quit();
	}
}
