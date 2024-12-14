using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsMenu : MonoBehaviour
{
	public enum saveFormat
	{
		playerprefs = 0,
		iniFile = 1
	}

	private class MenuVariables
	{
		public int Qualitylevel;

		public bool ShowFPS;

		public int ResolutionX;

		public int ResolutionY;

		public bool WindowedMode;

		public bool VSync;

		public string Warning;
	}

	public saveFormat saveAs;

	[Tooltip("Check for IOS and Windows Store Apps.")]
	public bool usePersistentDatapath;

	[Header("THESE NEED TO BE DRAGGED IN")]
	public Slider qualityLevelSlider;

	public Text qualityText;

	public GameObject resolutionsPanel;

	public GameObject resButtonPrefab;

	public GameObject menuTransform;

	public Text currentResolutionText;

	public Toggle windowedModeToggle;

	public Toggle vSyncToggle;

	private GameObject resolutionsPanelParent;

	private Resolution[] resolutions;

	private bool setMenu;

	private bool openMenu;

	private bool showFPS;

	private bool fullScreenMode;

	private bool toggleVSync;

	private const float fpsMeasurePeriod = 0.2f;

	private float fpsNextPeriod;

	private float setTextQualDelay;

	private int fpsAccumulator;

	private int currentFps;

	private int wantedResX;

	private int wantedResY;

	private string saveFileDataPath;

	private Coroutine setTextQualityCoR;

	private MenuVariables saveVars;

	private MenuVariables DefaultSettings = new MenuVariables
	{
		Qualitylevel = 3,
		ResolutionX = 0,
		ResolutionY = 0,
		WindowedMode = true,
		VSync = true,
		Warning = "Edit this file at your own risk!"
	};

	private void Start()
	{
		fpsNextPeriod = Time.realtimeSinceStartup + 0.2f;
		resolutionsPanelParent = resolutionsPanel.transform.parent.parent.gameObject;
		if (!usePersistentDatapath)
		{
			saveFileDataPath = Application.dataPath + "/QualitySettings.ini";
		}
		else
		{
			saveFileDataPath = Application.persistentDataPath + "/QualitySettings.ini";
		}
		SetValues();
	}

	private void Update()
	{
	}

	public void SetQuality()
	{
		int num = Mathf.RoundToInt(qualityLevelSlider.value);
		QualitySettings.SetQualityLevel(num, applyExpensiveChanges: true);
		qualityText.text = QualitySettings.names[num];
		SetWindowedMode();
		SetVSync();
	}

	public void SetWindowedMode()
	{
		if (windowedModeToggle.isOn)
		{
			fullScreenMode = false;
		}
		else
		{
			fullScreenMode = true;
		}
		Screen.SetResolution(wantedResX, wantedResY, fullScreenMode);
	}

	public void SetVSync()
	{
		if (vSyncToggle.isOn)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
	}

	private void SetValues()
	{
		qualityLevelSlider.maxValue = QualitySettings.names.Length - 1;
		resolutions = Screen.resolutions;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			if (resolutions[i].width != num && resolutions[i].height != num2)
			{
				GameObject obj = Object.Instantiate(resButtonPrefab);
				obj.GetComponentInChildren<Text>().text = resolutions[i].width + "x" + resolutions[i].height;
				int index = i;
				obj.GetComponent<Button>().onClick.AddListener(delegate
				{
					SetResolution(index);
				});
				obj.transform.SetParent(resolutionsPanel.transform, worldPositionStays: false);
				num = resolutions[i].width;
				num2 = resolutions[i].height;
			}
		}
		LoadMenuVariables();
		int num3 = Mathf.RoundToInt(qualityLevelSlider.value);
		QualitySettings.SetQualityLevel(num3, applyExpensiveChanges: true);
		qualityText.text = QualitySettings.names[num3];
		SetVSync();
		SetWindowedMode();
	}

	public void SetResolution(int index)
	{
		wantedResX = resolutions[index].width;
		wantedResY = resolutions[index].height;
		Screen.SetResolution(wantedResX, wantedResY, fullScreenMode);
		currentResolutionText.text = wantedResX + "x" + wantedResY;
	}

	public void ShowResolutionOptions()
	{
		resolutionsPanelParent.SetActive(!resolutionsPanelParent.activeSelf);
	}

	public void SaveMenuVariables()
	{
		if (saveAs == saveFormat.playerprefs)
		{
			PlayerPrefs.SetInt("graphicsPrefsSaved", 0);
			PlayerPrefs.SetInt("graphicsSlider", Mathf.RoundToInt(qualityLevelSlider.value));
			PlayerPrefs.SetInt("wantedResolutionX", wantedResX);
			PlayerPrefs.SetInt("wantedResolutionY", wantedResY);
			int num = 0;
			if (vSyncToggle.isOn)
			{
				num = 1;
			}
			else
			{
				num = 0;
				PlayerPrefs.SetInt("vSyncToggle", num);
			}
			if (windowedModeToggle.isOn)
			{
				num = 1;
				return;
			}
			num = 0;
			PlayerPrefs.SetInt("windowedModeToggle", num);
		}
		else if (saveAs == saveFormat.iniFile)
		{
			saveVars = new MenuVariables
			{
				Qualitylevel = Mathf.RoundToInt(qualityLevelSlider.value),
				ResolutionX = wantedResX,
				ResolutionY = wantedResY,
				WindowedMode = windowedModeToggle.isOn,
				VSync = vSyncToggle.isOn,
				Warning = "Edit this file at your own risk!"
			};
			string contents = JsonUtility.ToJson(saveVars, prettyPrint: true);
			File.WriteAllText(saveFileDataPath, contents);
			contents = null;
			saveVars = null;
		}
	}

	private void LoadMenuVariables()
	{
		if (saveAs == saveFormat.playerprefs)
		{
			if (PlayerPrefs.HasKey("graphicsPrefsSaved"))
			{
				qualityLevelSlider.value = PlayerPrefs.GetInt("graphicsSlider");
				wantedResX = PlayerPrefs.GetInt("wantedResolutionX");
				wantedResY = PlayerPrefs.GetInt("wantedResolutionY");
				currentResolutionText.text = wantedResX + "x" + wantedResY;
				if (PlayerPrefs.GetInt("windowedModeToggle") == 1)
				{
					windowedModeToggle.isOn = true;
				}
				else
				{
					windowedModeToggle.isOn = false;
				}
				if (PlayerPrefs.GetInt("vSyncToggle") == 1)
				{
					vSyncToggle.isOn = true;
				}
				else
				{
					vSyncToggle.isOn = false;
				}
			}
			else
			{
				wantedResX = Screen.width;
				wantedResY = Screen.height;
				currentResolutionText.text = Screen.width + "x" + Screen.height;
			}
		}
		else if (saveAs == saveFormat.iniFile)
		{
			if (File.Exists(saveFileDataPath))
			{
				string json = File.ReadAllText(saveFileDataPath);
				saveVars = JsonUtility.FromJson<MenuVariables>(json);
				qualityLevelSlider.value = saveVars.Qualitylevel;
				wantedResX = saveVars.ResolutionX;
				wantedResY = saveVars.ResolutionY;
				currentResolutionText.text = wantedResX + "x" + wantedResY;
				windowedModeToggle.isOn = saveVars.WindowedMode;
				vSyncToggle.isOn = saveVars.VSync;
				json = null;
				saveVars = null;
			}
			else
			{
				wantedResX = Screen.width;
				wantedResY = Screen.height;
				currentResolutionText.text = Screen.width + "x" + Screen.height;
			}
		}
	}

	public void ResetToDefault()
	{
		qualityLevelSlider.value = DefaultSettings.Qualitylevel;
		wantedResX = Screen.width;
		wantedResY = Screen.height;
		currentResolutionText.text = wantedResX + "x" + wantedResY;
		windowedModeToggle.isOn = DefaultSettings.WindowedMode;
		vSyncToggle.isOn = DefaultSettings.VSync;
		int num = Mathf.RoundToInt(qualityLevelSlider.value);
		QualitySettings.SetQualityLevel(num, applyExpensiveChanges: true);
		qualityText.text = QualitySettings.names[num];
		SetVSync();
		SetWindowedMode();
	}
}
