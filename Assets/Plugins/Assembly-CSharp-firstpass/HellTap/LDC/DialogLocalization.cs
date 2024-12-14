using UnityEngine;

namespace HellTap.LDC
{
	public class DialogLocalization : MonoBehaviour
	{
		public static DialogLocalization com;

		public static string language = "English";

		public LDC_LanguageDetectionMode detectionMode;

		private bool buildTemplate = true;

		public string detectUsingPlayerPrefsKey = "LDC_LANGUAGE";

		public LDC_DebugLanguage debugLanguage;

		public LanguageEnabler languages;

		public void Awake()
		{
			com = this;
			if (detectUsingPlayerPrefsKey == "")
			{
				detectUsingPlayerPrefsKey = "LDC_LANGUAGE";
			}
			if (buildTemplate)
			{
				SaveLanguages();
			}
			else
			{
				LoadLanguages();
			}
			Localize();
			Debug.Log("LDC: (DialogLocalization) Current Language = " + language);
		}

		public void Localize()
		{
			if (detectionMode == LDC_LanguageDetectionMode.DetectSystemLanguage)
			{
				language = Application.systemLanguage.ToString();
			}
			else if (detectionMode == LDC_LanguageDetectionMode.UsingPlayerPrefsKey)
			{
				if (PlayerPrefs.HasKey(detectUsingPlayerPrefsKey))
				{
					language = PlayerPrefs.GetString(detectUsingPlayerPrefsKey);
				}
				else
				{
					Debug.Log("LDC: (DialogLocalization) Localization Key '" + detectUsingPlayerPrefsKey + "' doesn't exist. Creating it now using English as the default language.");
					PlayerPrefs.SetString(detectUsingPlayerPrefsKey, "English");
					language = "English";
				}
			}
			if (Application.isEditor && debugLanguage != 0)
			{
				language = debugLanguage.ToString();
			}
			language = LanguageCodeToString(language);
		}

		public string LanguageCodeToString(string code)
		{
			if (!Application.isEditor)
			{
				Debug.Log("LDC (DialogLocalization) - Converting Language Code: " + code);
			}
			if (code.ToLower() == "en" || code.ToLower() == "eng" || code.ToLower() == "english")
			{
				return "English";
			}
			if (code.ToLower() == "zh" || code.ToLower() == "zho" || code.ToLower() == "chi" || code.ToLower() == "zh-hans" || code.ToLower() == "zho +" || code.ToLower() == "zho+" || code.ToLower() == "zh_rcn" || code.ToLower() == "zh_rtw" || code.ToLower() == "chinese" || code.ToLower() == "中国的")
			{
				if (languages.chinese)
				{
					return "Chinese";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "ko" || code.ToLower() == "kor" || code.ToLower() == "kur" || code.ToLower() == "kua" || code.ToLower() == "korean" || code.ToLower() == "한국의")
			{
				if (languages.korean)
				{
					return "Korean";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "ja" || code.ToLower() == "jpn" || code.ToLower() == "japanese" || code.ToLower() == "日本の")
			{
				if (languages.japanese)
				{
					return "Japanese";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "gsw" || code.ToLower() == "de" || code.ToLower() == "deu" || code.ToLower() == "ger" || code.ToLower() == "german" || code.ToLower() == "deutsch")
			{
				if (languages.german)
				{
					return "German";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "fr" || code.ToLower() == "fra" || code.ToLower() == "fre" || code.ToLower() == "french" || code.ToLower() == "français")
			{
				if (languages.french)
				{
					return "French";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "spa" || code.ToLower() == "es" || code.ToLower() == "spanish" || code.ToLower() == "español")
			{
				if (languages.spanish)
				{
					return "Spanish";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "ita" || code.ToLower() == "it" || code.ToLower() == "italian" || code.ToLower() == "italiano")
			{
				if (languages.italian)
				{
					return "Italian";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "pt" || code.ToLower() == "portuguese" || code.ToLower() == "português")
			{
				if (languages.portuguese)
				{
					return "Portuguese";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			if (code.ToLower() == "ru" || code.ToLower() == "ua" || code.ToLower() == "russian" || code.ToLower() == "русский")
			{
				if (languages.russian)
				{
					return "Russian";
				}
				Debug.Log(code.ToLower() + " localization not supported, reverting to English");
				return "English";
			}
			Debug.Log("The language code '" + code + "' was not recognised. Reverting to English.");
			return "English";
		}

		public void SaveLanguages()
		{
			if (!Application.isEditor)
			{
				Debug.Log("LDC (DialogLocalization) - SaveLanguages() - Configuring Localizations..");
			}
			if (PlayerPrefs.HasKey("LANGUAGES_ENGLISH"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_ENGLISH");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for English");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_SPANISH"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_SPANISH");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Spanish");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_ITALIAN"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_ITALIAN");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Italian");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_GERMAN"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_GERMAN");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for German");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_FRENCH"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_FRENCH");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for French");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_CHINESE"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_CHINESE");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Chinese");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_KOREAN"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_KOREAN");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Korean");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_JAPANESE"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_JAPANESE");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Japanese");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_PORTUGUESE"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_PORTUGUESE");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Portuguese");
				}
			}
			if (PlayerPrefs.HasKey("LANGUAGES_RUSSIAN"))
			{
				PlayerPrefs.DeleteKey("LANGUAGES_RUSSIAN");
				if (!Application.isEditor)
				{
					Debug.Log("Deleting Localization Entry for Russian");
				}
			}
			if (languages.english)
			{
				SaveBool("LANGUAGES_ENGLISH", languages.english);
			}
			if (languages.spanish)
			{
				SaveBool("LANGUAGES_SPANISH", languages.spanish);
			}
			if (languages.italian)
			{
				SaveBool("LANGUAGES_ITALIAN", languages.italian);
			}
			if (languages.german)
			{
				SaveBool("LANGUAGES_GERMAN", languages.german);
			}
			if (languages.french)
			{
				SaveBool("LANGUAGES_FRENCH", languages.french);
			}
			if (languages.chinese)
			{
				SaveBool("LANGUAGES_CHINESE", languages.chinese);
			}
			if (languages.korean)
			{
				SaveBool("LANGUAGES_KOREAN", languages.korean);
			}
			if (languages.japanese)
			{
				SaveBool("LANGUAGES_JAPANESE", languages.japanese);
			}
			if (languages.portuguese)
			{
				SaveBool("LANGUAGES_PORTUGUESE", languages.portuguese);
			}
			if (languages.russian)
			{
				SaveBool("LANGUAGES_RUSSIAN", languages.russian);
			}
		}

		public void LoadLanguages()
		{
			if (PlayerPrefs.HasKey("LANGUAGES_ENGLISH"))
			{
				languages.english = LoadBool("LANGUAGES_ENGLISH");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: English Enabled: " + languages.english);
				}
			}
			else
			{
				languages.english = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_SPANISH"))
			{
				languages.spanish = LoadBool("LANGUAGES_SPANISH");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Spanish Enabled: " + languages.spanish);
				}
			}
			else
			{
				languages.spanish = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_ITALIAN"))
			{
				languages.spanish = LoadBool("LANGUAGES_ITALIAN");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Italian Enabled: " + languages.italian);
				}
			}
			else
			{
				languages.italian = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_GERMAN"))
			{
				languages.german = LoadBool("LANGUAGES_GERMAN");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: German Enabled: " + languages.german);
				}
			}
			else
			{
				languages.german = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_FRENCH"))
			{
				languages.french = LoadBool("LANGUAGES_FRENCH");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: French Enabled: " + languages.french);
				}
			}
			else
			{
				languages.french = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_CHINESE"))
			{
				languages.chinese = LoadBool("LANGUAGES_CHINESE");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Chinese Enabled: " + languages.chinese);
				}
			}
			else
			{
				languages.chinese = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_KOREAN"))
			{
				languages.korean = LoadBool("LANGUAGES_KOREAN");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Korean Enabled: " + languages.korean);
				}
			}
			else
			{
				languages.korean = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_JAPANESE"))
			{
				languages.japanese = LoadBool("LANGUAGES_JAPANESE");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Japanese Enabled: " + languages.japanese);
				}
			}
			else
			{
				languages.japanese = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_PORTUGUESE"))
			{
				languages.portuguese = LoadBool("LANGUAGES_PORTUGUESE");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Portuguese Enabled: " + languages.portuguese);
				}
			}
			else
			{
				languages.portuguese = false;
			}
			if (PlayerPrefs.HasKey("LANGUAGES_RUSSIAN"))
			{
				languages.russian = LoadBool("LANGUAGES_RUSSIAN");
				if (!Application.isEditor && !Application.isEditor)
				{
					Debug.Log("LDC (DialogLocalization) - Localization: Russian Enabled: " + languages.russian);
				}
			}
			else
			{
				languages.russian = false;
			}
		}

		public static void SaveBool(string name, bool value)
		{
			PlayerPrefs.SetInt(name, value ? 1 : 0);
		}

		public static bool LoadBool(string name)
		{
			if (PlayerPrefs.GetInt(name) != 1)
			{
				return false;
			}
			return true;
		}
	}
}
