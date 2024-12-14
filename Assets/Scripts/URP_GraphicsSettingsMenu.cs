using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class URP_GraphicsSettingsMenu : MonoBehaviour
{
	public enum saveFormat
	{
		playerprefs = 0,
		iniFile = 1
	}

	private class MenuVariables
	{
		public int Qualitylevel;

		public int ResolutionX;

		public int ResolutionY;

		public bool WindowedMode;

		public bool VSync;

		public int TextureQuality;

		public int AnisotropicMode;

		public int AnisotropicLevel;

		public string Warning;
	}

	public saveFormat saveAs;

	[Tooltip("Check for IOS and Windows Store Apps.")]
	public bool usePersistentDatapath;

	[Header("THESE NEED TO BE DRAGGED IN")]
	public RenderPipelineAsset[] renderPipelines;

	[Space]
	public Slider qualityLevelSlider;

	public Slider textureQualitySlider;

	public Slider anisotropicModeSlider;

	public Slider anisotropicLevelSlider;

	public Text qualityText;

	public Text textureText;

	public Text anisotropicModeText;

	public Text anisotropicLevelText;

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

	private bool fullScreenMode;

	private bool toggleVSync;

	private float setTextQualDelay;

	private int wantedResX;

	private int wantedResY;

	private string saveFileDataPath;

	private Coroutine setTextQualityCoR;

	private MenuVariables saveVars;

	private MenuVariables DefaultSettings = new MenuVariables
	{
		Qualitylevel = 1,
		ResolutionX = 0,
		ResolutionY = 0,
		WindowedMode = false,
		VSync = false,
		TextureQuality = 3,
		AnisotropicMode = 1,
		AnisotropicLevel = 4,
		Warning = "Edit this file at your own risk!"
	};

	private void Start()
	{
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

	public void SetQuality()
	{
		int num = Mathf.RoundToInt(qualityLevelSlider.value);
		QualitySettings.SetQualityLevel(num, applyExpensiveChanges: true);
		GraphicsSettings.renderPipelineAsset = renderPipelines[num];
		qualityText.text = QualitySettings.names[num];
		SetWindowedMode();
		SetVSync();
		SetTextureQuality();
		SetAnisotropicFiltering();
		SetAnisotropicFilteringLevel();
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

	public void SetTextureQuality()
	{
		if (setTextQualDelay <= 0f)
		{
			setTextQualDelay = 1f;
			setTextQualityCoR = StartCoroutine(SetTextureQualityCoroutine());
		}
		else
		{
			setTextQualDelay = 1f;
		}
	}

	private IEnumerator SetTextureQualityCoroutine()
	{
		while (setTextQualDelay > 0f)
		{
			setTextQualDelay -= 0.6f;
			yield return new WaitForSecondsRealtime(0.2f);
		}
		switch (Mathf.RoundToInt(textureQualitySlider.value))
		{
		case 0:
			QualitySettings.masterTextureLimit = 3;
			textureText.text = "Eighth Res";
			break;
		case 1:
			QualitySettings.masterTextureLimit = 2;
			textureText.text = "Quarter Res";
			break;
		case 2:
			QualitySettings.masterTextureLimit = 1;
			textureText.text = "Half Res";
			break;
		case 3:
			QualitySettings.masterTextureLimit = 0;
			textureText.text = "Full Res";
			break;
		}
	}

	public void SetAnisotropicFiltering()
	{
		switch (Mathf.RoundToInt(anisotropicModeSlider.value))
		{
		case 0:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			anisotropicModeText.text = "Disabled";
			break;
		case 1:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			anisotropicModeText.text = "Enabled";
			break;
		case 2:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			anisotropicModeText.text = "ForceEnabled";
			break;
		}
	}

	public void SetAnisotropicFilteringLevel()
	{
		int num = Mathf.RoundToInt(anisotropicLevelSlider.value);
		Texture.SetGlobalAnisotropicFilteringLimits(num, num);
		anisotropicLevelText.text = num.ToString();
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
		GraphicsSettings.renderPipelineAsset = renderPipelines[num3];
		qualityText.text = QualitySettings.names[num3];
		SetVSync();
		SetWindowedMode();
		SetTextureQuality();
		SetAnisotropicFiltering();
		SetAnisotropicFilteringLevel();
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
			PlayerPrefs.SetInt("textureQualitySlider", Mathf.RoundToInt(textureQualitySlider.value));
			PlayerPrefs.SetInt("anisotropicModeSlider", Mathf.RoundToInt(anisotropicModeSlider.value));
			PlayerPrefs.SetInt("anisotropicLevelSlider", Mathf.RoundToInt(anisotropicLevelSlider.value));
			PlayerPrefs.SetInt("wantedResolutionX", wantedResX);
			PlayerPrefs.SetInt("wantedResolutionY", wantedResY);
			int num = 0;
			num = (vSyncToggle.isOn ? 1 : 0);
			PlayerPrefs.SetInt("vSyncToggle", num);
			num = (windowedModeToggle.isOn ? 1 : 0);
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
				TextureQuality = Mathf.RoundToInt(textureQualitySlider.value),
				AnisotropicMode = Mathf.RoundToInt(anisotropicModeSlider.value),
				AnisotropicLevel = Mathf.RoundToInt(anisotropicLevelSlider.value),
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
				textureQualitySlider.value = PlayerPrefs.GetInt("textureQualitySlider");
				anisotropicModeSlider.value = PlayerPrefs.GetInt("anisotropicModeSlider");
				anisotropicLevelSlider.value = PlayerPrefs.GetInt("anisotropicLevelSlider");
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
				anisotropicModeSlider.value = saveVars.AnisotropicMode;
				anisotropicLevelSlider.value = saveVars.AnisotropicLevel;
				textureQualitySlider.value = saveVars.TextureQuality;
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
		anisotropicModeSlider.value = DefaultSettings.AnisotropicMode;
		anisotropicLevelSlider.value = DefaultSettings.AnisotropicLevel;
		textureQualitySlider.value = DefaultSettings.TextureQuality;
		wantedResX = Screen.width;
		wantedResY = Screen.height;
		currentResolutionText.text = wantedResX + "x" + wantedResY;
		windowedModeToggle.isOn = DefaultSettings.WindowedMode;
		vSyncToggle.isOn = DefaultSettings.VSync;
		int num = Mathf.RoundToInt(qualityLevelSlider.value);
		QualitySettings.SetQualityLevel(num, applyExpensiveChanges: true);
		GraphicsSettings.renderPipelineAsset = renderPipelines[num];
		qualityText.text = QualitySettings.names[num];
		SetVSync();
		SetWindowedMode();
		SetTextureQuality();
		SetAnisotropicFiltering();
		SetAnisotropicFilteringLevel();
	}
}
