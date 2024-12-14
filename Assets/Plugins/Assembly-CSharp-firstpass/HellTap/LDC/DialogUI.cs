using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HellTap.LDC
{
	public class DialogUI : MonoBehaviour
	{
		public static DUISTATUS status = DUISTATUS.ENDED;

		public static bool ended = true;

		public DUISTATUS debugStatus = DUISTATUS.ENDED;

		public static DialogUI dui;

		public static Component guiComponent;

		public static DialogController changeThreadDC = null;

		public static int changeThreadOverrideID = 0;

		public static string[] buttonNames = new string[1] { "" };

		public static bool[] buttons = new bool[1];

		public static int currentSelection = 0;

		public static bool updateFocus = false;

		public static Vector2 scrollPosition = Vector2.zero;

		public static bool isActive;

		[NonSerialized]
		public float alpha;

		[NonSerialized]
		public float fade;

		private float localDeltaTime = 0.01f;

		public static Texture2D portrait;

		public static string actorName = "Actor's Name";

		public static string dialogText = "This is my dialog text.";

		public static string unwrappedDialogText = "This is my dialog text.";

		public static string currentDialogText;

		public static DUICachedInjectorsForScreen injectors = new DUICachedInjectorsForScreen();

		public static DIALOGSTYLE dialogStyle;

		public static string customButton1;

		public static string customButton2;

		public static string[] multipleButtons;

		public static int dataEntryToken = 0;

		public static DS_DATA_FORMAT dataEntryFormat = DS_DATA_FORMAT.Text;

		public static int dataEntryCharacterLimit = 25;

		public static string dataEntryDefaultValue = string.Empty;

		public static string dataEntryString = string.Empty;

		public static DS_DATA_ANCHOR dataEntryAnchor = DS_DATA_ANCHOR.Bottom;

		public static bool passwordMatchToToken = false;

		public static string passwordAnswer;

		public static bool passwordCaseSensitive = false;

		public static bool passwordMask = false;

		public static bool hideNextButton = false;

		public static bool noPortraitFadeIn = false;

		public static bool noPortraitFadeOut = false;

		public static DialogScreen screen = null;

		public static float screenDuration;

		public static DialogCastActor portraitAnimation;

		public static Texture2D buttonIcon1;

		public static Texture2D buttonIcon2;

		public static Texture2D[] multipleButtonsIcon;

		public static DialogCastActor buttonIcon1Animation;

		public static DialogCastActor buttonIcon2Animation;

		public static DialogCastActor[] multipleButtonsIconAnimation;

		public static DIALOG_OVERRIDE_YESNO typeWriterOptions = DIALOG_OVERRIDE_YESNO.UseDefault;

		public static DIALOG_OVERRIDE_SCROLLING scrollingOptions = DIALOG_OVERRIDE_SCROLLING.UseDefault;

		public static bool setupTextField = false;

		public static Vector2 titleOffset = Vector2.zero;

		public static Vector2 titleSize = new Vector2(960f, 640f);

		public static Font overrideTitleFont = null;

		public static int titleFontSize = 0;

		public static Color titleColor = Color.white;

		public static TextAnchor titleAllignment = TextAnchor.UpperLeft;

		public static Vector2 subtitleOffset = Vector2.zero;

		public static Vector2 subtitleSize = new Vector2(960f, 640f);

		public static Font overrideSubtitleFont = null;

		public static int subtitleFontSize = 0;

		public static Color subtitleColor = Color.white;

		public static TextAnchor subtitleAllignment = TextAnchor.UpperLeft;

		public static bool hideDialogBackground = false;

		[NonSerialized]
		public float hideBackgroundSubtractor;

		public static Texture2D popupImage;

		public static int popupSizeX = 480;

		public static int popupSizeY = 240;

		public static int popupButtonSizeX = 280;

		public static int popupButtonSizeY = 128;

		public static int popupButtonSpacer = 32;

		public static float popupBackgroundAlpha = 1f;

		public static DialogCastActor popupImageAnimation;

		public static POPUP_OPTIONS popupOptions = POPUP_OPTIONS.OneButton;

		public static int IG_WindowSizeX = 960;

		public static int IG_WindowSizeY = 640;

		public static int IG_WindowOffsetX = 0;

		public static int IG_WindowOffsetY = 0;

		public static bool IG_WindowShowTitle = true;

		public static bool IG_WindowShowSubtitle = true;

		public static bool IG_AddSpaceBetweenSubtitleAndContent = false;

		public static bool IG_useXScrolling = false;

		public static bool IG_useYScrolling = false;

		public static bool IG_showPanelBG = true;

		public static float IG_BackgroundAlpha = 1f;

		public static Texture2D IG_Image;

		public static DialogCastActor IG_ImageAnimation;

		public static int IG_iconSizeX = 128;

		public static int IG_iconSizeY = 128;

		public static int IG_iconsPerRow = 6;

		public static int IG_IconSpacer = 48;

		public static int IG_AddInnerIconSpacing = 16;

		public static bool IG_showIconLabels = true;

		public static int IG_iconLabelSize = 32;

		public static bool IG_firstIconIsCloseButton = true;

		public static int IG_closeButtonSize = 100;

		public static bool IG_showButtonBackgrounds = true;

		public static TextAnchor IG_buttonAllignment = TextAnchor.MiddleCenter;

		public static ImagePosition IG_buttonImagePosition = ImagePosition.ImageAbove;

		public static IconGridButtons[] IG_buttons = new IconGridButtons[1];

		public static DUI_TransitionEffects transition = DUI_TransitionEffects.None;

		public DialogUIOptions options = new DialogUIOptions();

		[NonSerialized]
		public bool forceClose;

		[HideInInspector]
		public bool displayBackgroundLayers;

		[HideInInspector]
		public DialogUIBackgroundLayers[] bgLayers = new DialogUIBackgroundLayers[0];

		[HideInInspector]
		public bool displayActorLayers;

		[HideInInspector]
		public DialogUIActorLayers[] bgActors = new DialogUIActorLayers[0];

		[HideInInspector]
		public AudioSource speechSource;

		[HideInInspector]
		public AudioSource musicSource;

		[HideInInspector]
		public AudioSource sfx1Source;

		[HideInInspector]
		public AudioSource sfx2Source;

		[HideInInspector]
		public AudioSource sfx3Source;

		[HideInInspector]
		public AudioSource typewriterSource;

		[HideInInspector]
		public AudioSource buttonSource;

		[HideInInspector]
		public AudioSource focusSource;

		[HideInInspector]
		public DSAudioSetup musicSetup;

		[HideInInspector]
		public DSAudioSetup sfx1Setup;

		[HideInInspector]
		public DSAudioSetup sfx2Setup;

		[HideInInspector]
		public DSAudioSetup sfx3Setup;

		public DUITokens[] tokens = new DUITokens[0];

		[NonSerialized]
		public DUI_GTS globalTokenStatus;

		public static DUITokens[] globalTokens = new DUITokens[0];

		[NonSerialized]
		public DUITokenList[] alphabeticalTokenList = new DUITokenList[0];

		public DUIStyles styles = new DUIStyles();

		public LDC_Filemanagement fileManagement = new LDC_Filemanagement();

		public LDC_ThirdPartySetup thirdPartyTools = new LDC_ThirdPartySetup();

		private float asLastTime;

		private float asDeltaTime;

		private float asLiveScrollingSpeed = 1f;

		private bool liveInjectorsRunning;

		private bool twRunning;

		private float twLastTime;

		private float twDeltaTime;

		private float twTextLength;

		private int twLastTextLength;

		private bool twSkippedText;

		private float twCadenceDelay;

		private float twLiveTypewriterSpeed = 1f;

		private string twInjectTokenNow = string.Empty;

		private int twInjectTokenNowID = -1;

		private float twTokenTextIncrementer;

		private string twTokenTextTokenPrefix = string.Empty;

		private string twTokenTextTokenPostfix = string.Empty;

		private static string injectEndCode = string.Empty;

		private static int injectExtraOffset = 0;

		private static int currentCSI = 0;

		private static bool tokensFoundSoWeNeedToStopLoop = false;

		private const string _colorStart = "<color=#";

		private const string _colorEnd = ">";

		private static string _rartctncShadowHex = "";

		private const string _dollarChar = "$";

		private floatRef _tokenAsFloat = new floatRef();

		private string _updatedTokenValue = "";

		public static void PlayButonAudio()
		{
			if (dui.buttonSource != null)
			{
				dui.buttonSource.clip = dui.options.playAudioOnButton;
				dui.buttonSource.Play();
			}
		}

		public static void PlayFocusAudio()
		{
			if (dui.focusSource != null)
			{
				dui.focusSource.clip = dui.options.playAudioOnFocus;
				dui.focusSource.Play();
			}
		}

		public static void ResetStaticValues()
		{
			status = DUISTATUS.ENDED;
			changeThreadDC = null;
			changeThreadOverrideID = 0;
			portrait = null;
			portraitAnimation = null;
		}

		public void OnDestroy()
		{
			if (dui != null && dui.options.useGlobalTokens && dui.fileManagement.enable && dui.fileManagement.saveOnDestroy)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("LDC: Saving Tokens On Destroy");
				}
				SaveTokensToDisk();
			}
			ResetStaticValues();
			isActive = false;
			status = DUISTATUS.ENDED;
			ended = true;
			screenDuration = 0f;
			if (dui.options.stopAudioWhenDialogEnds && dui.gameObject.GetComponent<AudioSource>() != null)
			{
				dui.gameObject.GetComponent<AudioSource>().Stop();
			}
			forceClose = false;
			screen = null;
			portrait = null;
			portraitAnimation = null;
			actorName = string.Empty;
			dialogText = string.Empty;
			currentDialogText = string.Empty;
			alpha = 0f;
			fade = 0f;
		}

		public void OnApplicationPause(bool wasJustPaused)
		{
			if (wasJustPaused && Time.timeSinceLevelLoad > 1f && dui != null && dui.options.useGlobalTokens && dui.fileManagement.enable && dui.fileManagement.saveOnApplicationPause)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("LDC: Saving Tokens On Pause");
				}
				SaveTokensToDisk();
			}
		}

		public static string MakeSavePrefixSafe(string prefix)
		{
			if (prefix != "")
			{
				prefix = prefix.Replace(" ", "_");
				prefix = prefix.Replace("\"", string.Empty);
				prefix = prefix.Replace("/", string.Empty);
				prefix = prefix.Replace("\\", string.Empty);
				prefix = prefix.Replace("|", string.Empty);
				prefix = prefix.Replace(".", string.Empty);
				prefix = prefix.Replace("<", string.Empty);
				prefix = prefix.Replace(">", string.Empty);
				prefix = prefix.Replace(",", string.Empty);
				prefix = prefix.Replace("?", string.Empty);
				prefix = prefix.Replace(";", string.Empty);
				prefix = prefix.Replace(":", string.Empty);
				prefix = prefix.Replace("'", string.Empty);
				prefix = prefix.Replace("{", string.Empty);
				prefix = prefix.Replace("}", string.Empty);
				prefix = prefix.Replace("[", string.Empty);
				prefix = prefix.Replace("]", string.Empty);
				prefix = prefix.Replace("-", string.Empty);
				prefix = prefix.Replace("+", string.Empty);
				prefix = prefix.Replace("=", string.Empty);
				prefix = prefix.Replace("!", string.Empty);
				prefix = prefix.Replace("@", string.Empty);
				prefix = prefix.Replace("#", string.Empty);
				prefix = prefix.Replace("$", string.Empty);
				prefix = prefix.Replace("%", string.Empty);
				prefix = prefix.Replace("^", string.Empty);
				prefix = prefix.Replace("&", string.Empty);
				prefix = prefix.Replace("*", string.Empty);
				prefix = prefix.Replace("`", string.Empty);
				prefix = prefix.Replace("~", string.Empty);
				prefix = prefix.Replace("(", string.Empty);
				prefix = prefix.Replace(")", string.Empty);
				prefix += "_";
			}
			return prefix;
		}

		public static void SaveTokensToDisk()
		{
			string text = string.Empty;
			if (dui != null)
			{
				text = dui.fileManagement.savePrefix.ToUpper();
				text = MakeSavePrefixSafe(text);
			}
			if (dui != null && dui.options.useGlobalTokens && dui.fileManagement.enable && dui.tokens != null && dui.tokens.Length != 0)
			{
				if (PlayerPrefs.HasKey(text + "LDC_TOKENS_SIZE"))
				{
					PlayerPrefs.DeleteKey(text + "LDC_TOKENS_SIZE");
				}
				PlayerPrefs.SetInt(text + "LDC_TOKENS_SIZE", dui.tokens.Length);
				int num = 0;
				DUITokens[] array = dui.tokens;
				foreach (DUITokens dUITokens in array)
				{
					if (dUITokens != null)
					{
						if (PlayerPrefs.HasKey(text + "LDC_TOKENS_NAME_" + num))
						{
							PlayerPrefs.DeleteKey(text + "LDC_TOKENS_NAME_" + num);
						}
						if (PlayerPrefs.HasKey(text + "LDC_TOKENS_VALUE_" + num))
						{
							PlayerPrefs.DeleteKey(text + "LDC_TOKENS_VALUE_" + num);
						}
						PlayerPrefs.SetString(text + "LDC_TOKENS_NAME_" + num, dUITokens.name);
						PlayerPrefs.SetString(text + "LDC_TOKENS_VALUE_" + num, dUITokens.value);
					}
					num++;
				}
			}
			else if (dui != null && dui.fileManagement.enable)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("LDC: Couldn't save Tokens to PlayerPrefs. Make sure that you have enabled Global Tokens, and have at least 1 token setup in the DialogUI component!");
				}
			}
			else if (dui != null && !dui.fileManagement.enable && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("LDC: Couldn't save Tokens to PlayerPrefs. You need to enable \"File Management\" in DialogUI.");
			}
		}

		public static void LoadTokensFromDisk()
		{
			string text = string.Empty;
			if (dui != null)
			{
				text = dui.fileManagement.savePrefix.ToUpper();
				text = MakeSavePrefixSafe(text);
			}
			if (dui != null && dui.options.useGlobalTokens && dui.fileManagement.enable && PlayerPrefs.HasKey(text + "LDC_TOKENS_SIZE"))
			{
				int @int = PlayerPrefs.GetInt(text + "LDC_TOKENS_SIZE");
				if (@int <= 0)
				{
					return;
				}
				DUITokens[] array = new DUITokens[PlayerPrefs.GetInt(text + "LDC_TOKENS_SIZE")];
				if (array.Length != 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = new DUITokens();
						if (PlayerPrefs.HasKey(text + "LDC_TOKENS_NAME_" + i))
						{
							array[i].name = PlayerPrefs.GetString(text + "LDC_TOKENS_NAME_" + i);
						}
						if (PlayerPrefs.HasKey(text + "LDC_TOKENS_VALUE_" + i))
						{
							array[i].value = PlayerPrefs.GetString(text + "LDC_TOKENS_VALUE_" + i);
						}
					}
				}
				if (@int != dui.tokens.Length)
				{
					Debug.LogWarning("DIALOG UI: The number of tokens has changed since the last time it was saved! LDC will try to merge any matching values back into the current token list. " + @int + " tokens were loaded from disk but the current token list has " + dui.tokens.Length + ".");
					for (int j = 0; j < array.Length; j++)
					{
						for (int k = 0; k < dui.tokens.Length; k++)
						{
							if (array[j].name == dui.tokens[k].name)
							{
								dui.tokens[k].value = array[j].value;
							}
						}
					}
				}
				else
				{
					dui.tokens = array;
				}
				globalTokens = dui.tokens;
			}
			else if (dui != null && dui.fileManagement.enable)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("LDC: Couldn't load Tokens from PlayerPrefs. Make sure that you have enabled Global Tokens, or perhaps no tokens have been saved yet!");
				}
			}
			else if (dui != null && !dui.fileManagement.enable && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("LDC: Couldn't load Tokens from PlayerPrefs. You need to enable \"File Management\" in DialogUI.");
			}
		}

		public static void DeleteTokensFromDisk()
		{
			string text = string.Empty;
			if (dui != null)
			{
				text = dui.fileManagement.savePrefix.ToUpper();
				text = MakeSavePrefixSafe(text);
			}
			if (dui != null && dui.options.useGlobalTokens && dui.fileManagement.enable && PlayerPrefs.HasKey(text + "LDC_TOKENS_SIZE"))
			{
				if (PlayerPrefs.GetInt(text + "LDC_TOKENS_SIZE") <= 0)
				{
					return;
				}
				for (int i = 0; i < PlayerPrefs.GetInt(text + "LDC_TOKENS_SIZE"); i++)
				{
					if (PlayerPrefs.HasKey(text + "LDC_TOKENS_NAME_" + i))
					{
						PlayerPrefs.DeleteKey(text + "LDC_TOKENS_NAME_" + i);
					}
					if (PlayerPrefs.HasKey(text + "LDC_TOKENS_VALUE_" + i))
					{
						PlayerPrefs.DeleteKey(text + "LDC_TOKENS_VALUE_" + i);
					}
				}
				PlayerPrefs.DeleteKey(text + "LDC_TOKENS_SIZE");
			}
			else if (dui != null && dui.fileManagement.enable)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("LDC: Couldn't delete Tokens from PlayerPrefs. Make sure that you have enabled Global Tokens, or perhaps no tokens have been saved yet!");
				}
			}
			else if (dui != null && !dui.fileManagement.enable && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("LDC: Couldn't delete Tokens from PlayerPrefs. You need to enable \"File Management\" in DialogUI.");
			}
		}

		public static bool ParseTokenAsFloat(string stringToParse, floatRef destination)
		{
			try
			{
				destination.value = float.Parse(stringToParse);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void SetToken(string tokenToSet, string tokenValue)
		{
			if (tokenValue == null)
			{
				tokenValue = string.Empty;
			}
			if (dui != null)
			{
				bool flag = false;
				if (dui.tokens.Length != 0)
				{
					DUITokens[] array = dui.tokens;
					foreach (DUITokens dUITokens in array)
					{
						if (dUITokens.name == tokenToSet)
						{
							dUITokens.value = tokenValue;
							flag = true;
						}
					}
				}
				UpdateGlobalTokens();
				if (!flag && dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("DIALOG UI: (SetToken) The Token \"" + tokenToSet + "\" wasn't found and couldn't be set.");
				}
			}
			else if (dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("DIALOG UI: (SetToken) Couldn't set token because DialogUI.dui isn't ready yet. This usually happens when calling SetToken from the Awake() function, try using Start() instead!");
			}
		}

		public static void SetToken(string tokenToSet, float sentFloat)
		{
			string value = sentFloat.ToString();
			if (dui != null)
			{
				bool flag = false;
				if (dui.tokens.Length != 0)
				{
					DUITokens[] array = dui.tokens;
					foreach (DUITokens dUITokens in array)
					{
						if (dUITokens.name == tokenToSet)
						{
							dUITokens.value = value;
							flag = true;
						}
					}
				}
				UpdateGlobalTokens();
				if (!flag && dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("DIALOG UI: (SetToken) The Token \"" + tokenToSet + "\" wasn't found and couldn't be set.");
				}
			}
			else if (dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("DIALOG UI: (SetToken) Couldn't set token because DialogUI.dui isn't ready yet. This usually happens when calling SetToken from the Awake() function, try using Start() instead!");
			}
		}

		public static string GetToken(string tokenToGet)
		{
			if (dui != null)
			{
				bool flag = false;
				if (dui.tokens.Length != 0)
				{
					DUITokens[] array = dui.tokens;
					foreach (DUITokens dUITokens in array)
					{
						if (dUITokens.name == tokenToGet)
						{
							flag = true;
							return dUITokens.value;
						}
					}
				}
				if (!flag)
				{
					if (dui != null && dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("DIALOG UI: (GetToken) The Token \"" + tokenToGet + "\" wasn't found.");
					}
					return string.Empty;
				}
			}
			else if (dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("DIALOG UI: (GetToken) Couldn't set token because DialogUI.dui isn't ready yet. This usually happens when calling SetToken from the Awake() function, try using Start() instead!");
			}
			return string.Empty;
		}

		public static float GetTokenAsFloat(string tokenToGet)
		{
			if (dui != null)
			{
				bool flag = false;
				if (dui.tokens.Length != 0)
				{
					DUITokens[] array = dui.tokens;
					foreach (DUITokens dUITokens in array)
					{
						if (dUITokens.name == tokenToGet)
						{
							flag = true;
							floatRef floatRef2 = new floatRef();
							if (ParseTokenAsFloat(dUITokens.value, floatRef2))
							{
								return floatRef2.value;
							}
							if (dui != null && dui.options.debugSystemMessagesInConsole)
							{
								Debug.Log("DIALOG UI: (GetTokenAsFloat) Couldn't convert Token \"" + tokenToGet + "\" into a float. Returned 0.");
							}
							return 0f;
						}
					}
				}
				if (!flag)
				{
					if (dui != null && dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("DIALOG UI: (GetTokenAsFloat) The Token \"" + tokenToGet + "\" wasn't found.");
					}
					return 0f;
				}
			}
			else if (dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("DIALOG UI: (GetTokenAsFloat) Couldn't set token because DialogUI.dui isn't ready yet. This usually happens when calling SetToken from the Awake() function, try using Start() instead!");
			}
			return 0f;
		}

		public void TokenActions(DSTokenActions[] actions)
		{
			if (tokens.Length == 0)
			{
				return;
			}
			foreach (DSTokenActions dSTokenActions in actions)
			{
				if (dSTokenActions == null || dSTokenActions.index > tokens.Length - 1)
				{
					continue;
				}
				DUITokens dUITokens = tokens[dSTokenActions.index];
				floatRef floatRef2 = new floatRef();
				floatRef floatRef3 = new floatRef();
				bool flag = false;
				if (dSTokenActions.action == DSTokenActionType.Set)
				{
					dUITokens.value = dSTokenActions.argument;
				}
				else if (dSTokenActions.action == DSTokenActionType.Add)
				{
					if (!ParseTokenAsFloat(dUITokens.value, floatRef2))
					{
						if (dui != null && dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("Unable to parse '{0}'." + dUITokens.value);
						}
						flag = true;
					}
					if (!ParseTokenAsFloat(dSTokenActions.argument, floatRef3))
					{
						if (dui != null && dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("Unable to parse '{0}'." + dSTokenActions.argument);
						}
						flag = true;
					}
					if (!flag)
					{
						floatRef2.value += floatRef3.value;
						dUITokens.value = floatRef2.value.ToString();
					}
				}
				else
				{
					if (dSTokenActions.action != DSTokenActionType.Subtract)
					{
						continue;
					}
					if (!ParseTokenAsFloat(dUITokens.value, floatRef2))
					{
						if (dui != null && dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("Unable to parse '{0}'." + dUITokens.value);
						}
						flag = true;
					}
					if (!ParseTokenAsFloat(dSTokenActions.argument, floatRef3))
					{
						if (dui != null && dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("Unable to parse '{0}'." + dSTokenActions.argument);
						}
						flag = true;
					}
					if (!flag)
					{
						floatRef2.value -= floatRef3.value;
						dUITokens.value = floatRef2.value.ToString();
					}
				}
			}
			UpdateGlobalTokens();
		}

		public string[] GetTokenStringArray()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Clear();
			if (tokens.Length != 0)
			{
				DUITokens[] array = tokens;
				foreach (DUITokens dUITokens in array)
				{
					arrayList.Add(dUITokens.name);
				}
			}
			return arrayList.ToArray(typeof(string)) as string[];
		}

		public void SetupDialogTextEffects()
		{
			if (injectors != null && injectors.dialogTextInjectors != null && injectors.dialogTextInjectors.Length != 0)
			{
				DUICachedInjectors[] dialogTextInjectors = injectors.dialogTextInjectors;
				for (int i = 0; i < dialogTextInjectors.Length; i++)
				{
					dialogTextInjectors[i].typewriterEventActivated = false;
				}
			}
			asLiveScrollingSpeed = options.automaticScrollingSpeed * 32f;
			StopCoroutine(LiveInjectors());
			StartCoroutine(LiveInjectors());
			if (dialogText != string.Empty && ((dui.options.useTypeWriterEffectForText && typeWriterOptions == DIALOG_OVERRIDE_YESNO.UseDefault) || typeWriterOptions == DIALOG_OVERRIDE_YESNO.Yes))
			{
				currentDialogText = string.Empty;
				StopCoroutine("TypeWriterEffect");
				StartCoroutine("TypeWriterEffect");
			}
			if ((dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
			{
				StopCoroutine("AutoScrollEffect");
				StartCoroutine("AutoScrollEffect");
			}
		}

		public IEnumerator AutoScrollEffect()
		{
			asDeltaTime = 0f;
			asLastTime = Time.realtimeSinceStartup;
			Vector2 autoScrollingValue = dui.options.autoScrollingValue;
			autoScrollingValue.y = 0f;
			dui.options.autoScrollingValue = autoScrollingValue;
			Vector2 autoScrollingFixedValue = dui.options.autoScrollingFixedValue;
			autoScrollingFixedValue.y = 0f;
			dui.options.autoScrollingFixedValue = autoScrollingFixedValue;
			while (status == DUISTATUS.SHOW)
			{
				if ((dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
				{
					asDeltaTime = Time.realtimeSinceStartup - asLastTime;
					asLastTime = Time.realtimeSinceStartup;
					Vector2 autoScrollingValue2 = dui.options.autoScrollingValue;
					autoScrollingValue2.y = dui.options.autoScrollingFixedValue.y;
					autoScrollingValue2.y += asDeltaTime * asLiveScrollingSpeed;
					dui.options.autoScrollingValue = autoScrollingValue2;
					Vector2 autoScrollingFixedValue2 = dui.options.autoScrollingFixedValue;
					autoScrollingFixedValue2.y = dui.options.autoScrollingValue.y;
					dui.options.autoScrollingFixedValue = autoScrollingFixedValue2;
					if (dui.options.autoScrollingValue.y > dui.options.autoScrollingHeight)
					{
						Vector2 autoScrollingValue3 = dui.options.autoScrollingValue;
						autoScrollingValue3.y = dui.options.autoScrollingHeight;
						dui.options.autoScrollingValue = autoScrollingValue3;
						Vector2 autoScrollingFixedValue3 = dui.options.autoScrollingFixedValue;
						autoScrollingFixedValue3.y = dui.options.autoScrollingHeight;
						dui.options.autoScrollingFixedValue = autoScrollingFixedValue3;
					}
				}
				yield return null;
			}
			asLiveScrollingSpeed = options.automaticScrollingSpeed * 32f;
		}

		public IEnumerator LiveInjectors()
		{
			currentDialogText = string.Empty;
			liveInjectorsRunning = true;
			while (liveInjectorsRunning)
			{
				if (!ended)
				{
					actorName = InjectStylesIntoText(injectors.dialogTitle, injectors.dialogTitleInjectors, dui.fade, usingTypewriter: false, fromAPI: false);
					if (!twRunning)
					{
						currentDialogText = dialogText;
						currentDialogText = InjectStylesIntoText(currentDialogText, injectors.dialogTextInjectors, dui.fade, usingTypewriter: false, fromAPI: false);
					}
					if (dialogStyle == DIALOGSTYLE.OneButton || dialogStyle == DIALOGSTYLE.DataEntry || dialogStyle == DIALOGSTYLE.Password || dialogStyle == DIALOGSTYLE.Title || dialogStyle == DIALOGSTYLE.Popup)
					{
						customButton1 = InjectStylesIntoText(injectors.customButton1, injectors.customButton1Injectors, dui.fade, usingTypewriter: false, fromAPI: false);
					}
					if (dialogStyle == DIALOGSTYLE.TwoButtons || (dialogStyle == DIALOGSTYLE.Popup && popupOptions == POPUP_OPTIONS.TwoButtons))
					{
						customButton2 = InjectStylesIntoText(injectors.customButton2, injectors.customButton2Injectors, dui.fade, usingTypewriter: false, fromAPI: false);
					}
					if (dialogStyle == DIALOGSTYLE.MultipleButtons && injectors.multipleButtonEvaluatedInjectors != null && injectors.multipleButtonEvaluatedInjectors.Length != 0 && multipleButtons != null && injectors.multipleButtonEvaluatedInjectors.Length == multipleButtons.Length)
					{
						for (int i = 0; i < injectors.multipleButtonEvaluatedInjectors.Length; i++)
						{
							multipleButtons[i] = InjectStylesIntoText(injectors.multipleButtonsEvaluated[i], injectors.multipleButtonEvaluatedInjectors[i].injectors, dui.fade, usingTypewriter: false, fromAPI: false);
						}
					}
					if (dialogStyle == DIALOGSTYLE.IconGrid && injectors.iconGridEvaluatedInjectors != null && injectors.iconGridEvaluatedInjectors.Length != 0 && IG_buttons != null && IG_buttons.Length != 0 && injectors.iconGridEvaluatedInjectors.Length == IG_buttons.Length)
					{
						for (int j = 0; j < injectors.iconGridEvaluatedInjectors.Length; j++)
						{
							if (injectors.iconGridEvaluatedInjectors[j].title != null)
							{
								IG_buttons[j].title = InjectStylesIntoText(injectors.iconGridTitlesEvaluated[j], injectors.iconGridEvaluatedInjectors[j].title, dui.fade, usingTypewriter: false, fromAPI: false);
							}
							if (injectors.iconGridEvaluatedInjectors[j].label != null)
							{
								IG_buttons[j].label = InjectStylesIntoText(injectors.iconGridLabelsEvaluated[j], injectors.iconGridEvaluatedInjectors[j].label, dui.fade, usingTypewriter: false, fromAPI: false);
							}
							if (injectors.iconGridEvaluatedInjectors[j].failedLabel != null)
							{
								IG_buttons[j].failedLabel = InjectStylesIntoText(injectors.iconGridFailedLabelsEvaluated[j], injectors.iconGridEvaluatedInjectors[j].failedLabel, dui.fade, usingTypewriter: false, fromAPI: false);
							}
						}
					}
				}
				yield return null;
			}
		}

		public IEnumerator TypeWriterEffect()
		{
			twRunning = true;
			while (fade < 1f)
			{
				yield return 0;
			}
			if (dialogStyle == DIALOGSTYLE.NextButton || dialogStyle == DIALOGSTYLE.YesOrNo || dialogStyle == DIALOGSTYLE.OneButton || dialogStyle == DIALOGSTYLE.TwoButtons || dialogStyle == DIALOGSTYLE.Title || dialogStyle == DIALOGSTYLE.Popup || dialogStyle == DIALOGSTYLE.IconGrid)
			{
				if (typewriterSource != null && options.playTypeWriterAudio != null)
				{
					typewriterSource.clip = options.playTypeWriterAudio;
					typewriterSource.loop = true;
					typewriterSource.Play();
				}
				twDeltaTime = 0f;
				twLastTime = Time.realtimeSinceStartup;
				if (injectors != null && injectors.dialogTextInjectors != null && injectors.dialogTextInjectors.Length != 0)
				{
					DUICachedInjectors[] dialogTextInjectors = injectors.dialogTextInjectors;
					for (int i = 0; i < dialogTextInjectors.Length; i++)
					{
						dialogTextInjectors[i].typewriterEventActivated = false;
					}
				}
				twTextLength = 0f;
				twLiveTypewriterSpeed = options.typeWriterEffectSpeed;
				twLastTextLength = 0;
				twSkippedText = false;
				twInjectTokenNow = string.Empty;
				while (dialogText != string.Empty && twTextLength != (float)dialogText.Length)
				{
					if (twCadenceDelay > 0f)
					{
						while (twCadenceDelay > 0f)
						{
							twDeltaTime = Time.realtimeSinceStartup - twLastTime;
							twLastTime = Time.realtimeSinceStartup;
							twCadenceDelay -= twDeltaTime;
							currentDialogText = dialogText.Substring(0, Mathf.RoundToInt(twTextLength));
							currentDialogText = InjectStylesIntoText(currentDialogText, injectors.dialogTextInjectors, dui.fade, usingTypewriter: true, fromAPI: false);
							if (!twSkippedText && options.completeTypeWriterEffectOnClickOrTouch && currentDialogText != dialogText && (Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)))
							{
								twSkippedText = true;
								twTextLength = dialogText.Length - 1;
								twLastTextLength = (int)twTextLength - 1;
								if (injectors != null && injectors.dialogTextInjectors != null && injectors.dialogTextInjectors.Length != 0)
								{
									DUICachedInjectors[] dialogTextInjectors = injectors.dialogTextInjectors;
									for (int i = 0; i < dialogTextInjectors.Length; i++)
									{
										dialogTextInjectors[i].typewriterEventActivated = true;
									}
								}
								twCadenceDelay = 0f;
							}
							yield return 0;
						}
						twDeltaTime = 0f;
						twLastTime = Time.realtimeSinceStartup;
						twCadenceDelay = 0f;
						continue;
					}
					if (twInjectTokenNow != string.Empty && twInjectTokenNowID != -1)
					{
						twDeltaTime = Time.realtimeSinceStartup - twLastTime;
						twLastTime = Time.realtimeSinceStartup;
						if (twLiveTypewriterSpeed <= 0f)
						{
							twLiveTypewriterSpeed = options.typeWriterEffectSpeed;
						}
						twTokenTextIncrementer += twDeltaTime * 24f * twLiveTypewriterSpeed;
						if (twTokenTextIncrementer > (float)twInjectTokenNow.Length)
						{
							twTokenTextIncrementer = twInjectTokenNow.Length;
						}
						if (Mathf.Round(twTokenTextIncrementer) > 0f)
						{
							currentDialogText = twTokenTextTokenPrefix + twInjectTokenNow.Substring(0, Mathf.RoundToInt(twTokenTextIncrementer)) + twTokenTextTokenPostfix;
						}
						if (twInjectTokenNow.Length == Mathf.RoundToInt(twTokenTextIncrementer))
						{
							twInjectTokenNow = string.Empty;
							twInjectTokenNowID = -1;
							twTextLength = Mathf.Floor(twTextLength) + 2f;
							twLastTextLength = (int)twTextLength;
							twTextLength = Mathf.Clamp(twTextLength, 0f, dialogText.Length);
							yield return StartCoroutine(TypewriterDelay(1f));
							currentDialogText = dialogText.Substring(0, Mathf.RoundToInt(twTextLength));
							currentDialogText = InjectStylesIntoText(currentDialogText, injectors.dialogTextInjectors, dui.fade, usingTypewriter: true, fromAPI: false);
							twDeltaTime = 0f;
							twLastTime = Time.realtimeSinceStartup;
						}
						yield return 0;
						continue;
					}
					twDeltaTime = Time.realtimeSinceStartup - twLastTime;
					twLastTime = Time.realtimeSinceStartup;
					if (twLiveTypewriterSpeed <= 0f)
					{
						twLiveTypewriterSpeed = options.typeWriterEffectSpeed;
					}
					twTextLength += twDeltaTime * 24f * twLiveTypewriterSpeed;
					if (twTextLength > (float)(twLastTextLength + 1))
					{
						twTextLength = twLastTextLength + 1;
					}
					twLastTextLength = (int)twTextLength;
					twTextLength = Mathf.Clamp(twTextLength, 0f, dialogText.Length);
					currentDialogText = dialogText.Substring(0, Mathf.RoundToInt(twTextLength));
					currentDialogText = InjectStylesIntoText(currentDialogText, injectors.dialogTextInjectors, dui.fade, usingTypewriter: true, fromAPI: false);
					if (!twSkippedText && options.completeTypeWriterEffectOnClickOrTouch && currentDialogText != dialogText && ((DialogOnGUI.com != null && DialogOnGUI.com.renderMode == OnGuiRenderMode.Screen && (Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))) || (DialogOnGUI.com.renderMode == OnGuiRenderMode.Material && DialogWorldSpaceGUI.GetInputButtonDown())))
					{
						twSkippedText = true;
						twTextLength = dialogText.Length - 1;
						twLastTextLength = (int)twTextLength - 1;
						if (injectors != null && injectors.dialogTextInjectors != null && injectors.dialogTextInjectors.Length != 0)
						{
							DUICachedInjectors[] dialogTextInjectors = injectors.dialogTextInjectors;
							for (int i = 0; i < dialogTextInjectors.Length; i++)
							{
								dialogTextInjectors[i].typewriterEventActivated = true;
							}
						}
						twCadenceDelay = 0f;
					}
					yield return 0;
				}
			}
			if (typewriterSource != null && options.playTypeWriterAudio != null && typewriterSource.isPlaying)
			{
				typewriterSource.Stop();
			}
			twRunning = false;
		}

		public IEnumerator TypewriterDelay(float secondsToWait)
		{
			twDeltaTime = 0f;
			twLastTime = Time.realtimeSinceStartup;
			while (secondsToWait > 0f)
			{
				twDeltaTime = Time.realtimeSinceStartup - twLastTime;
				twLastTime = Time.realtimeSinceStartup;
				if (twLiveTypewriterSpeed <= 0f)
				{
					twLiveTypewriterSpeed = options.typeWriterEffectSpeed;
				}
				secondsToWait -= twDeltaTime * 24f * twLiveTypewriterSpeed;
				yield return null;
			}
			twDeltaTime = 0f;
			twLastTime = Time.realtimeSinceStartup;
		}

		public string InjectStylesIntoText(string text, DUICachedInjectors[] cachedInjectors, float textAlpha)
		{
			return InjectStylesIntoText(text, cachedInjectors, textAlpha, usingTypewriter: false, fromAPI: false);
		}

		public string InjectStylesIntoText(string text, DUICachedInjectors[] cachedInjectors, float textAlpha, bool usingTypewriter, bool fromAPI)
		{
			if (text != null && text.Length > 0 && cachedInjectors != null && cachedInjectors.Length != 0)
			{
				injectEndCode = string.Empty;
				injectExtraOffset = 0;
				currentCSI = 0;
				tokensFoundSoWeNeedToStopLoop = false;
				foreach (DUICachedInjectors dUICachedInjectors in cachedInjectors)
				{
					if (dUICachedInjectors != null)
					{
						if (!fromAPI && dUICachedInjectors.charIndex + injectExtraOffset <= text.Length - 1 + 1)
						{
							if (!dUICachedInjectors.isToken)
							{
								if (usingTypewriter && IsCadenceCode(dUICachedInjectors.injectorName))
								{
									if (!dUICachedInjectors.typewriterEventActivated)
									{
										twCadenceDelay = styles.list[dUICachedInjectors.injectorID].cadenceDelay;
										dUICachedInjectors.typewriterEventActivated = true;
									}
								}
								else if (usingTypewriter && IsTypeWriterSpeedCode(dUICachedInjectors.injectorName))
								{
									if (!dUICachedInjectors.typewriterEventActivated)
									{
										twLiveTypewriterSpeed = options.typeWriterEffectSpeed * styles.list[dUICachedInjectors.injectorID].typewriterSpeed;
										dUICachedInjectors.typewriterEventActivated = true;
									}
								}
								else if (IsScrollerSpeedCode(dUICachedInjectors.injectorName) && !dUICachedInjectors.typewriterEventActivated)
								{
									asLiveScrollingSpeed = options.automaticScrollingSpeed * 32f * styles.list[dUICachedInjectors.injectorID].scrollingSpeed;
									dUICachedInjectors.typewriterEventActivated = true;
								}
							}
							if (dUICachedInjectors.isToken && !dUICachedInjectors.typewriterEventActivated)
							{
								twTokenTextTokenPrefix = text.Substring(0, dUICachedInjectors.charIndex + injectExtraOffset);
								twTokenTextTokenPostfix = injectEndCode;
								twInjectTokenNow = tokens[dUICachedInjectors.injectorID].value;
								twInjectTokenNowID = dUICachedInjectors.injectorID;
								twTokenTextIncrementer = 0f;
								dUICachedInjectors.typewriterEventActivated = true;
								tokensFoundSoWeNeedToStopLoop = true;
							}
						}
						if (!tokensFoundSoWeNeedToStopLoop && dUICachedInjectors.charIndex + injectExtraOffset <= text.Length - 1)
						{
							if (dUICachedInjectors.isToken)
							{
								if (tokens != null && dUICachedInjectors.injectorID <= tokens.Length - 1 && tokens[dUICachedInjectors.injectorID] != null)
								{
									if (!usingTypewriter)
									{
										text = text.Insert(dUICachedInjectors.charIndex + injectExtraOffset, tokens[dUICachedInjectors.injectorID].value);
										injectExtraOffset -= dUICachedInjectors.injectorName.Length - tokens[dUICachedInjectors.injectorID].value.Length;
									}
									if (usingTypewriter && twInjectTokenNowID != dUICachedInjectors.charIndex && dUICachedInjectors.typewriterEventActivated)
									{
										text = text.Insert(dUICachedInjectors.charIndex + injectExtraOffset, tokens[dUICachedInjectors.injectorID].value);
										injectExtraOffset -= dUICachedInjectors.injectorName.Length - tokens[dUICachedInjectors.injectorID].value.Length;
									}
								}
							}
							else if (!dUICachedInjectors.isToken && styles != null && styles.list != null && dUICachedInjectors.injectorID <= styles.list.Length - 1 && styles.list[dUICachedInjectors.injectorID] != null)
							{
								if (injectEndCode + styles.list[dUICachedInjectors.injectorID].startCode != string.Empty)
								{
									text = text.Insert(dUICachedInjectors.charIndex + injectExtraOffset, injectEndCode + styles.list[dUICachedInjectors.injectorID].startCode);
									if (styles.list[dUICachedInjectors.injectorID].colorAction != 0)
									{
										if (styles.list[dUICachedInjectors.injectorID].colorAction == DUIStyleColorAction.SetTextColor)
										{
											text = text.Replace("<color=#XXXXXXXX>", "<color=#" + ColorToHex(styles.list[dUICachedInjectors.injectorID].textColor, textAlpha) + ">");
										}
										else if (styles.list[dUICachedInjectors.injectorID].colorAction == DUIStyleColorAction.FadeBetweenTwoTextColors)
										{
											text = text.Replace("<color=#XXXXXXXX>", "<color=#" + ColorToHex(Color.Lerp(styles.list[dUICachedInjectors.injectorID].textColor, styles.list[dUICachedInjectors.injectorID].altColor, Mathf.PingPong(Time.time * styles.list[dUICachedInjectors.injectorID].colorFadeSpeed, 1f)), textAlpha) + ">");
										}
									}
								}
								injectExtraOffset -= dUICachedInjectors.injectorName.Length - (injectEndCode + styles.list[dUICachedInjectors.injectorID].startCode).Length;
								injectEndCode = styles.list[dUICachedInjectors.injectorID].endCode;
							}
						}
					}
					currentCSI++;
				}
				if (injectEndCode != null && injectEndCode != string.Empty)
				{
					text += injectEndCode;
				}
			}
			return text;
		}

		public static bool IsCadenceCode(string s)
		{
			if (!(s == "@Wait10") && !(s == "@Wait20") && !(s == "@Wait30") && !(s == "@Wait40") && !(s == "@Wait50") && !(s == "@Wait60") && !(s == "@Wait70") && !(s == "@Wait80") && !(s == "@Wait90") && !(s == "@Wait100"))
			{
				switch (s)
				{
				case "@Wait100":
				case "@Wait200":
				case "@Wait300":
				case "@Wait400":
				case "@Wait500":
					break;
				default:
					return false;
				}
			}
			return true;
		}

		public static bool IsTypeWriterSpeedCode(string s)
		{
			switch (s)
			{
			case "@Type10":
			case "@Type20":
			case "@Type30":
			case "@Type40":
			case "@Type50":
			case "@Type60":
			case "@Type70":
			case "@Type80":
			case "@Type90":
			case "@Type100":
			case "@Type150":
			case "@Type200":
			case "@Type300":
			case "@Type400":
			case "@Type500":
				return true;
			default:
				return false;
			}
		}

		public static bool IsScrollerSpeedCode(string s)
		{
			switch (s)
			{
			case "@Scroll10":
			case "@Scroll20":
			case "@Scroll30":
			case "@Scroll40":
			case "@Scroll50":
			case "@Scroll60":
			case "@Scroll70":
			case "@Scroll80":
			case "@Scroll90":
			case "@Scroll100":
			case "@Scroll150":
			case "@Scroll200":
			case "@Scroll300":
			case "@Scroll400":
			case "@Scroll500":
				return true;
			default:
				return false;
			}
		}

		public static ReturnDUICachedInjectorsForScreen CalculateStyleInjectors(string theText, DUICachedInjectors[] theCachedStyleInjectors)
		{
			if (theText != null && theText.Length > 0 && dui != null)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Clear();
				int num = 0;
				for (int i = 0; i < theText.Length; i++)
				{
					if (theText[i] == '@' || theText[i] == '$')
					{
						arrayList.Add(num);
					}
					num++;
				}
				int[] array = arrayList.ToArray(typeof(int)) as int[];
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Clear();
				Vector2 vector = new Vector2(-1f, -1f);
				if (array != null && array.Length != 0)
				{
					int[] array2 = array;
					foreach (int num2 in array2)
					{
						if (theText[num2] == '$' && dui.alphabeticalTokenList != null && dui.alphabeticalTokenList.Length != 0)
						{
							DUITokenList[] array3 = dui.alphabeticalTokenList;
							foreach (DUITokenList dUITokenList in array3)
							{
								if (dUITokenList != null && dUITokenList.name != string.Empty && theText.Length >= num2 + (dUITokenList.name.Length + 1) && theText.Substring(num2, dUITokenList.name.Length + 1) == "$" + dUITokenList.name)
								{
									DUICachedInjectors dUICachedInjectors = new DUICachedInjectors();
									dUICachedInjectors.isToken = true;
									dUICachedInjectors.charIndex = num2;
									dUICachedInjectors.injectorID = dUITokenList.id;
									dUICachedInjectors.injectorName = "$" + dUITokenList.name;
									arrayList2.Add(dUICachedInjectors);
									if (vector.x <= (float)num2)
									{
										vector = new Vector2(num2, arrayList2.Count - 1);
									}
									break;
								}
							}
						}
						else
						{
							if (dui.styles == null || dui.styles.list == null || dui.styles.list.Length == 0)
							{
								continue;
							}
							int num3 = 0;
							DUIStyleList[] list = dui.styles.list;
							foreach (DUIStyleList dUIStyleList in list)
							{
								if (dUIStyleList != null && dUIStyleList.name != string.Empty && theText.Length >= num2 + (dUIStyleList.name.Length + 1) && theText.Substring(num2, dUIStyleList.name.Length + 1) == "@" + dUIStyleList.name)
								{
									DUICachedInjectors dUICachedInjectors2 = new DUICachedInjectors();
									dUICachedInjectors2.isToken = false;
									dUICachedInjectors2.charIndex = num2;
									dUICachedInjectors2.injectorID = num3;
									dUICachedInjectors2.injectorName = "@" + dUIStyleList.name;
									arrayList2.Add(dUICachedInjectors2);
									if (vector.x <= (float)num2)
									{
										vector = new Vector2(num2, arrayList2.Count - 1);
									}
									break;
								}
								num3++;
							}
						}
					}
				}
				if (vector.y >= 0f && (float)theText.Length == vector.x + (float)(arrayList2[(int)vector.y] as DUICachedInjectors).injectorName.Length)
				{
					theText += " ";
				}
				if (dui.styles != null && dui.styles.list != null && dui.styles.list.Length != 0)
				{
					DUIStyleList[] list = dui.styles.list;
					foreach (DUIStyleList dUIStyleList2 in list)
					{
						if (dUIStyleList2 != null && dUIStyleList2.name != string.Empty)
						{
							theText = theText.Replace("@" + dUIStyleList2.name, string.Empty);
						}
					}
				}
				if (dui.alphabeticalTokenList != null && dui.alphabeticalTokenList.Length != 0)
				{
					DUITokenList[] array3 = dui.alphabeticalTokenList;
					foreach (DUITokenList dUITokenList2 in array3)
					{
						if (dUITokenList2 != null && dUITokenList2.name != string.Empty)
						{
							theText = theText.Replace("$" + dUITokenList2.name, string.Empty);
						}
					}
				}
				theCachedStyleInjectors = arrayList2.ToArray(typeof(DUICachedInjectors)) as DUICachedInjectors[];
			}
			return new ReturnDUICachedInjectorsForScreen
			{
				injectors = theCachedStyleInjectors,
				theText = theText
			};
		}

		public static string ColorToHex(Color32 color)
		{
			return ColorToHex(color, (int)color.a);
		}

		public static string ColorToHex(Color32 color, float maxAlpha)
		{
			maxAlpha = Mathf.Clamp(maxAlpha, 0f, 1f);
			int num = color.a;
			if ((float)num > maxAlpha * 255f)
			{
				num = (int)(maxAlpha * 255f);
			}
			return (color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + num.ToString("X2")).ToLower();
		}

		public static string ReplaceAllRichTextColorToNewColor(string stringToChange, Color32 color)
		{
			string text = stringToChange;
			if (text.Length > 0)
			{
				_rartctncShadowHex = ColorToHex(new Color(0f, 0f, 0f, GUI.color.a));
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i] == '<' && i + 17 < text.Length && text.Substring(i, 8) == "<color=#")
					{
						stringToChange = stringToChange.Remove(i, 17);
						stringToChange = stringToChange.Insert(i, "<color=#" + _rartctncShadowHex + ">");
					}
				}
			}
			return stringToChange;
		}

		public string ApplyTokens(string source)
		{
			if (source != string.Empty && alphabeticalTokenList != null && alphabeticalTokenList.Length != 0 && tokens.Length != 0)
			{
				DUITokenList[] array = alphabeticalTokenList;
				foreach (DUITokenList dUITokenList in array)
				{
					if (dUITokenList.id >= tokens.Length)
					{
						continue;
					}
					DUITokens dUITokens = tokens[dUITokenList.id];
					if (dUITokens != null && dUITokens.name != string.Empty && dUITokens.value != string.Empty)
					{
						_tokenAsFloat.value = 0f;
						_updatedTokenValue = string.Empty;
						if (ParseTokenAsFloat(dUITokens.value, _tokenAsFloat))
						{
							_updatedTokenValue = _tokenAsFloat.value.ToString();
						}
						else
						{
							_updatedTokenValue = dUITokens.value;
						}
						if (source.Contains("$" + dUITokens.name))
						{
							source = source.Replace("$" + dUITokens.name, _updatedTokenValue);
						}
					}
				}
			}
			return source;
		}

		public static void UpdateGlobalTokens()
		{
			if (dui != null && dui.options.useGlobalTokens && dui.globalTokenStatus != 0)
			{
				globalTokens = dui.tokens;
			}
		}

		public void Awake()
		{
			ResetStaticValues();
			dui = this;
			if (options.useGlobalTokens)
			{
				if (dui.tokens.Length != 0 && globalTokens.Length == 0)
				{
					if (dui != null && dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("LDC: Initializing Global Tokens");
					}
					globalTokenStatus = DUI_GTS.Initialized;
					globalTokens = dui.tokens;
				}
				else if (globalTokens != null && globalTokens.Length == dui.tokens.Length)
				{
					globalTokenStatus = DUI_GTS.Synchronized;
					dui.tokens = globalTokens;
				}
				else
				{
					globalTokenStatus = DUI_GTS.None;
					if (dui != null && dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("LDC: (DialogUI) ERROR - Syncing Global Tokens Failed. Are there tokens setup in the DialogUI component?");
					}
				}
				if (options.useGlobalTokens && dui.fileManagement.loadOnAwake)
				{
					LoadTokensFromDisk();
				}
			}
			SetupAllInjectorSymbols();
			bgLayers = new DialogUIBackgroundLayers[10];
			for (int i = 0; i < bgLayers.Length; i++)
			{
				bgLayers[i] = new DialogUIBackgroundLayers();
			}
			bgActors = new DialogUIActorLayers[10];
			for (int j = 0; j < bgActors.Length; j++)
			{
				bgActors[j] = new DialogUIActorLayers();
			}
			if (GetComponent<AudioSource>() != null)
			{
				speechSource = GetComponent<AudioSource>();
			}
			GameObject gameObject = new GameObject("Dialog UI - Music Channel");
			gameObject.transform.parent = base.transform;
			musicSource = gameObject.AddComponent<AudioSource>();
			musicSource.loop = true;
			musicSource.playOnAwake = false;
			GameObject gameObject2 = new GameObject("Dialog UI - SFX Channel 1");
			gameObject2.transform.parent = base.transform;
			sfx1Source = gameObject2.AddComponent<AudioSource>();
			sfx1Source.loop = false;
			sfx1Source.playOnAwake = false;
			GameObject gameObject3 = new GameObject("Dialog UI - SFX Channel 2");
			gameObject3.transform.parent = base.transform;
			sfx2Source = gameObject3.AddComponent<AudioSource>();
			sfx2Source.loop = false;
			sfx2Source.playOnAwake = false;
			GameObject gameObject4 = new GameObject("Dialog UI - SFX Channel 3");
			gameObject4.transform.parent = base.transform;
			sfx3Source = gameObject4.AddComponent<AudioSource>();
			sfx3Source.loop = false;
			sfx3Source.playOnAwake = false;
			GameObject gameObject5 = new GameObject("Dialog UI - TypeWriter Channel");
			gameObject5.transform.parent = base.transform;
			typewriterSource = gameObject5.AddComponent<AudioSource>();
			typewriterSource.clip = options.playTypeWriterAudio;
			typewriterSource.loop = false;
			typewriterSource.playOnAwake = false;
			GameObject gameObject6 = new GameObject("Dialog UI - Button Channel");
			gameObject6.transform.parent = base.transform;
			buttonSource = gameObject6.AddComponent<AudioSource>();
			buttonSource.clip = options.playAudioOnButton;
			buttonSource.loop = false;
			buttonSource.playOnAwake = false;
			GameObject gameObject7 = new GameObject("Dialog UI - Focus Channel");
			gameObject7.transform.parent = base.transform;
			focusSource = gameObject7.AddComponent<AudioSource>();
			focusSource.clip = options.playAudioOnFocus;
			focusSource.loop = false;
			focusSource.playOnAwake = false;
			status = DUISTATUS.ENDED;
			base.transform.position = Vector3.zero;
			base.transform.rotation = Quaternion.identity;
			GameObject gameObject8 = new GameObject("Origin");
			if (gameObject8 != null)
			{
				gameObject8.transform.parent = base.transform;
			}
			if (options.fadeDuration < 0.1f)
			{
				options.fadeDuration = 0.1f;
				options.usePortraitFades = false;
				options.useButtonFades = false;
				options.useTextFades = false;
				options.usePortraitTransitions = false;
				options.useButtonTransitions = false;
			}
			if (options.backgroundFadeDuration < 0.1f)
			{
				options.backgroundFadeDuration = 0.1f;
			}
			if (options.backgroundFadeOverrideDuration < 0.1f)
			{
				options.backgroundFadeOverrideDuration = 0.1f;
			}
			if (options.ignoreAllDialogDuration)
			{
				options.hideAllSingleButtonsFromUI = false;
			}
			if (options.typeWriterEffectSpeed < 0.1f)
			{
				options.typeWriterEffectSpeed = 0.1f;
			}
			currentSelection = 0;
			updateFocus = false;
		}

		public void Start()
		{
			if (guiComponent == null && GetComponent<DialogOnGUI>() == null)
			{
				if (dui != null && dui.options.debugSystemMessagesInConsole)
				{
					Debug.Log("DialogUI: No GUI Component has been registered, creating default DialogOnGUI.");
				}
				base.gameObject.AddComponent<DialogOnGUI>();
			}
			else if (GetComponent<DialogOnGUI>() == null && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("DialogUI: Using " + guiComponent?.ToString() + " for GUI.");
			}
		}

		public void SetupAllInjectorSymbols()
		{
			if (tokens != null && tokens.Length != 0 && styles != null)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Clear();
				int num = 0;
				DUITokens[] array = tokens;
				foreach (DUITokens dUITokens in array)
				{
					if (dUITokens != null && dUITokens.name.Length > num)
					{
						num = dUITokens.name.Length;
					}
				}
				for (int num2 = num; num2 > 0; num2--)
				{
					array = tokens;
					foreach (DUITokens dUITokens2 in array)
					{
						if (dUITokens2 != null && dUITokens2.name.Length == num2)
						{
							DUITokenList dUITokenList = new DUITokenList();
							dUITokenList.name = dUITokens2.name;
							dUITokenList.id = API_GetTokenIndex(dUITokens2.name);
							arrayList.Add(dUITokenList);
						}
					}
				}
				alphabeticalTokenList = arrayList.ToArray(typeof(DUITokenList)) as DUITokenList[];
			}
			if (styles != null && styles.list != null && styles.list.Length != 0)
			{
				DUIStyleList[] array2 = new DUIStyleList[styles.list.Length + 44];
				for (int j = 0; j < styles.list.Length; j++)
				{
					array2[j] = styles.list[j];
				}
				array2[styles.list.Length - 1 + 1] = CreateCadenceInjectionStylePreset("Wait10", 0.1f);
				array2[styles.list.Length - 1 + 2] = CreateCadenceInjectionStylePreset("Wait20", 0.2f);
				array2[styles.list.Length - 1 + 3] = CreateCadenceInjectionStylePreset("Wait30", 0.3f);
				array2[styles.list.Length - 1 + 4] = CreateCadenceInjectionStylePreset("Wait40", 0.4f);
				array2[styles.list.Length - 1 + 5] = CreateCadenceInjectionStylePreset("Wait50", 0.5f);
				array2[styles.list.Length - 1 + 6] = CreateCadenceInjectionStylePreset("Wait60", 0.6f);
				array2[styles.list.Length - 1 + 7] = CreateCadenceInjectionStylePreset("Wait70", 0.7f);
				array2[styles.list.Length - 1 + 8] = CreateCadenceInjectionStylePreset("Wait80", 0.8f);
				array2[styles.list.Length - 1 + 9] = CreateCadenceInjectionStylePreset("Wait90", 0.9f);
				array2[styles.list.Length - 1 + 10] = CreateCadenceInjectionStylePreset("Wait100", 1f);
				array2[styles.list.Length - 1 + 11] = CreateCadenceInjectionStylePreset("Wait200", 1f);
				array2[styles.list.Length - 1 + 12] = CreateCadenceInjectionStylePreset("Wait300", 1f);
				array2[styles.list.Length - 1 + 13] = CreateCadenceInjectionStylePreset("Wait400", 1f);
				array2[styles.list.Length - 1 + 14] = CreateCadenceInjectionStylePreset("Wait500", 1f);
				array2[styles.list.Length - 1 + 15] = CreateTypeWriterSpeedStylePreset("Type10", 0.1f);
				array2[styles.list.Length - 1 + 16] = CreateTypeWriterSpeedStylePreset("Type20", 0.2f);
				array2[styles.list.Length - 1 + 17] = CreateTypeWriterSpeedStylePreset("Type30", 0.3f);
				array2[styles.list.Length - 1 + 18] = CreateTypeWriterSpeedStylePreset("Type40", 0.4f);
				array2[styles.list.Length - 1 + 19] = CreateTypeWriterSpeedStylePreset("Type50", 0.5f);
				array2[styles.list.Length - 1 + 20] = CreateTypeWriterSpeedStylePreset("Type60", 0.6f);
				array2[styles.list.Length - 1 + 21] = CreateTypeWriterSpeedStylePreset("Type70", 0.7f);
				array2[styles.list.Length - 1 + 22] = CreateTypeWriterSpeedStylePreset("Type80", 0.8f);
				array2[styles.list.Length - 1 + 23] = CreateTypeWriterSpeedStylePreset("Type90", 0.9f);
				array2[styles.list.Length - 1 + 24] = CreateTypeWriterSpeedStylePreset("Type100", 1f);
				array2[styles.list.Length - 1 + 25] = CreateTypeWriterSpeedStylePreset("Type150", 1.5f);
				array2[styles.list.Length - 1 + 26] = CreateTypeWriterSpeedStylePreset("Type200", 2f);
				array2[styles.list.Length - 1 + 27] = CreateTypeWriterSpeedStylePreset("Type300", 3f);
				array2[styles.list.Length - 1 + 28] = CreateTypeWriterSpeedStylePreset("Type400", 4f);
				array2[styles.list.Length - 1 + 29] = CreateTypeWriterSpeedStylePreset("Type500", 5f);
				array2[styles.list.Length - 1 + 30] = CreateScrollingSpeedStylePreset("Scroll10", 0.1f);
				array2[styles.list.Length - 1 + 31] = CreateScrollingSpeedStylePreset("Scroll20", 0.2f);
				array2[styles.list.Length - 1 + 32] = CreateScrollingSpeedStylePreset("Scroll30", 0.3f);
				array2[styles.list.Length - 1 + 33] = CreateScrollingSpeedStylePreset("Scroll40", 0.4f);
				array2[styles.list.Length - 1 + 34] = CreateScrollingSpeedStylePreset("Scroll50", 0.5f);
				array2[styles.list.Length - 1 + 35] = CreateScrollingSpeedStylePreset("Scroll60", 0.6f);
				array2[styles.list.Length - 1 + 36] = CreateScrollingSpeedStylePreset("Scroll70", 0.7f);
				array2[styles.list.Length - 1 + 37] = CreateScrollingSpeedStylePreset("Scroll80", 0.8f);
				array2[styles.list.Length - 1 + 38] = CreateScrollingSpeedStylePreset("Scroll90", 0.9f);
				array2[styles.list.Length - 1 + 39] = CreateScrollingSpeedStylePreset("Scroll100", 1f);
				array2[styles.list.Length - 1 + 40] = CreateScrollingSpeedStylePreset("Scroll150", 1.5f);
				array2[styles.list.Length - 1 + 41] = CreateScrollingSpeedStylePreset("Scroll200", 2f);
				array2[styles.list.Length - 1 + 42] = CreateScrollingSpeedStylePreset("Scroll300", 3f);
				array2[styles.list.Length - 1 + 43] = CreateScrollingSpeedStylePreset("Scroll400", 4f);
				array2[styles.list.Length - 1 + 44] = CreateScrollingSpeedStylePreset("Scroll500", 5f);
				styles.list = array2;
			}
			if (styles != null && styles.list != null && styles.list.Length != 0)
			{
				ArrayList arrayList2 = new ArrayList();
				arrayList2.Clear();
				int num3 = 0;
				DUIStyleList[] list = styles.list;
				foreach (DUIStyleList dUIStyleList in list)
				{
					if (dUIStyleList != null && dUIStyleList.name.Length > num3)
					{
						num3 = dUIStyleList.name.Length;
					}
				}
				for (int num4 = num3; num4 > 0; num4--)
				{
					list = styles.list;
					foreach (DUIStyleList dUIStyleList2 in list)
					{
						if (dUIStyleList2 != null && dUIStyleList2.name.Length == num4)
						{
							arrayList2.Add(dUIStyleList2);
						}
					}
				}
				styles.list = arrayList2.ToArray(typeof(DUIStyleList)) as DUIStyleList[];
			}
			CreateStyleInjectorCode();
		}

		public void CreateStyleInjectorCode()
		{
			if (styles == null || styles.list == null || styles.list.Length == 0)
			{
				return;
			}
			DUIStyleList[] list = styles.list;
			foreach (DUIStyleList dUIStyleList in list)
			{
				if (dUIStyleList != null)
				{
					dUIStyleList.startCode = string.Empty;
					dUIStyleList.endCode = string.Empty;
					if (dUIStyleList.bold)
					{
						dUIStyleList.startCode += "<b>";
					}
					if (dUIStyleList.italic)
					{
						dUIStyleList.startCode += "<i>";
					}
					if (dUIStyleList.fontSize > 0)
					{
						dUIStyleList.startCode = dUIStyleList.startCode + "<size=" + dUIStyleList.fontSize + ">";
					}
					if (dUIStyleList.colorAction != 0)
					{
						dUIStyleList.startCode += "<color=#XXXXXXXX>";
					}
					if (dUIStyleList.colorAction != 0)
					{
						dUIStyleList.endCode += "</color>";
					}
					if (dUIStyleList.fontSize > 0)
					{
						dUIStyleList.endCode += "</size>";
					}
					if (dUIStyleList.italic)
					{
						dUIStyleList.endCode += "</i>";
					}
					if (dUIStyleList.bold)
					{
						dUIStyleList.endCode += "</b>";
					}
				}
			}
		}

		public DUIStyleList CreateCadenceInjectionStylePreset(string name, float delay)
		{
			return new DUIStyleList
			{
				name = name,
				cadenceDelay = delay
			};
		}

		public DUIStyleList CreateTypeWriterSpeedStylePreset(string name, float speed)
		{
			return new DUIStyleList
			{
				name = name,
				typewriterSpeed = speed
			};
		}

		public DUIStyleList CreateScrollingSpeedStylePreset(string name, float speed)
		{
			return new DUIStyleList
			{
				name = name,
				scrollingSpeed = speed
			};
		}

		public void LocalizeTokens()
		{
			if (options.useGlobalTokens && globalTokenStatus == DUI_GTS.Synchronized)
			{
				return;
			}
			if (tokens.Length != 0)
			{
				DUITokens[] array = tokens;
				foreach (DUITokens dUITokens in array)
				{
					if (dUITokens == null || !(dUITokens.name != string.Empty))
					{
						continue;
					}
					if (DialogLocalization.language == "English")
					{
						if (dUITokens.localizedValue.english != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.english;
						}
					}
					else if (DialogLocalization.language == "Chinese")
					{
						if (dUITokens.localizedValue.chinese != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.chinese;
						}
					}
					else if (DialogLocalization.language == "Korean")
					{
						if (dUITokens.localizedValue.korean != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.korean;
						}
					}
					else if (DialogLocalization.language == "Japanese")
					{
						if (dUITokens.localizedValue.japanese != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.japanese;
						}
					}
					else if (DialogLocalization.language == "German")
					{
						if (dUITokens.localizedValue.german != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.german;
						}
					}
					else if (DialogLocalization.language == "French")
					{
						if (dUITokens.localizedValue.french != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.french;
						}
					}
					else if (DialogLocalization.language == "Spanish")
					{
						if (dUITokens.localizedValue.spanish != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.spanish;
						}
					}
					else if (DialogLocalization.language == "Italian")
					{
						if (dUITokens.localizedValue.italian != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.italian;
						}
					}
					else if (DialogLocalization.language == "Portuguese")
					{
						if (dUITokens.localizedValue.portuguese != string.Empty)
						{
							dUITokens.value = dUITokens.localizedValue.portuguese;
						}
					}
					else if (DialogLocalization.language == "Russian" && dUITokens.localizedValue.russian != string.Empty)
					{
						dUITokens.value = dUITokens.localizedValue.russian;
					}
				}
			}
			UpdateGlobalTokens();
		}

		public void Update()
		{
			localDeltaTime = Time.deltaTime;
			if (forceClose)
			{
				status = DUISTATUS.FORCECLOSE;
			}
			if (status == DUISTATUS.FORCECLOSE || forceClose)
			{
				screen = null;
				screenDuration = 0f;
				if (fade > 0f)
				{
					fade -= Time.deltaTime;
				}
				else if (alpha > 0f)
				{
					alpha -= Time.deltaTime / options.backgroundFadeDuration;
				}
				else if (alpha <= 0f && fade <= 0f)
				{
					isActive = false;
					status = DUISTATUS.ENDED;
					ended = true;
					screenDuration = 0f;
					forceClose = false;
					screen = null;
					portrait = null;
					portraitAnimation = null;
					actorName = string.Empty;
					dialogText = string.Empty;
					currentDialogText = string.Empty;
					alpha = 0f;
					fade = 0f;
					if (liveInjectorsRunning)
					{
						StopCoroutine(LiveInjectors());
						liveInjectorsRunning = false;
					}
					if (dui.options.stopAudioWhenDialogEnds && dui.gameObject.GetComponent<AudioSource>() != null)
					{
						dui.gameObject.GetComponent<AudioSource>().Stop();
					}
				}
			}
			else
			{
				if (isActive && alpha < 1f)
				{
					alpha += Time.deltaTime / options.backgroundFadeDuration;
				}
				else if (!isActive && alpha > 0f && fade <= 0f)
				{
					alpha -= Time.deltaTime / options.backgroundFadeDuration;
				}
				if (alpha <= 0f && fade <= 0f && status == DUISTATUS.ENDED)
				{
					ended = true;
					if (dui.options.stopAudioWhenDialogEnds && dui.gameObject.GetComponent<AudioSource>() != null)
					{
						dui.gameObject.GetComponent<AudioSource>().Stop();
					}
				}
				else
				{
					ended = false;
				}
				if (status == DUISTATUS.SHOW)
				{
					if (alpha >= 1f && fade < 1f)
					{
						fade += Time.deltaTime / options.fadeDuration;
					}
					if ((dialogStyle == DIALOGSTYLE.NextButton || dialogStyle == DIALOGSTYLE.OneButton || dialogStyle == DIALOGSTYLE.Title) && screen != null && !options.ignoreAllDialogDuration)
					{
						if (screenDuration > 0f && alpha >= 1f && fade >= 1f)
						{
							screenDuration -= Time.deltaTime;
						}
						else if (screenDuration <= 0f && alpha >= 1f && fade >= 1f && !forceClose)
						{
							screen.Skip();
						}
					}
				}
				else if (status == DUISTATUS.FADEOUT)
				{
					if (fade > 0f)
					{
						fade -= Time.deltaTime / options.fadeDuration;
						if (speechSource != null && options.fadeOutAudioVolumeWithScreens)
						{
							speechSource.volume = Mathf.Clamp((int)fade, 0, 1);
						}
						if (options.useTypeWriterEffectForText)
						{
							currentDialogText = dialogText;
						}
					}
					else
					{
						status = DUISTATUS.WAITFORSCREEN;
						if ((speechSource != null && options.fadeOutAudioVolumeWithScreens) || options.stopAudioWhenScreenEnds)
						{
							speechSource.Stop();
						}
					}
				}
				if (!isActive && fade > 0f)
				{
					fade -= Time.deltaTime / options.fadeDuration;
					if (options.useTypeWriterEffectForText && dialogStyle != DIALOGSTYLE.Title)
					{
						currentDialogText = dialogText;
					}
					if (speechSource != null && options.fadeOutAudioVolumeWithScreens)
					{
						speechSource.volume = Mathf.Clamp((int)fade, 0, 1);
					}
				}
			}
			if (hideDialogBackground)
			{
				if (hideBackgroundSubtractor < 1f)
				{
					hideBackgroundSubtractor += Time.deltaTime / options.backgroundFadeOverrideDuration;
				}
				else
				{
					hideBackgroundSubtractor = 1f;
				}
			}
			else if (hideBackgroundSubtractor > 0f)
			{
				hideBackgroundSubtractor -= Time.deltaTime / options.backgroundFadeOverrideDuration;
			}
			else
			{
				hideBackgroundSubtractor = 0f;
			}
			if (Application.isEditor)
			{
				debugStatus = status;
			}
			alpha = Mathf.Clamp(alpha, 0f, 1f);
			fade = Mathf.Clamp(fade, 0f, 1f);
		}

		public void StopScreenNow()
		{
			screenDuration = 0f;
			status = DUISTATUS.FORCECLOSE;
			forceClose = true;
		}

		public IEnumerator PlayAudio(string filePathToLoad, float pitch)
		{
			yield return new WaitForSeconds(dui.options.fadeDuration);
			if (dui != null && dui.speechSource != null)
			{
				AudioClip audioClip = Resources.Load(options.audioFilepathPrefix + filePathToLoad) as AudioClip;
				if (audioClip != null)
				{
					dui.speechSource.pitch = pitch;
					dui.speechSource.clip = audioClip;
					dui.speechSource.volume = 1f;
					dui.speechSource.Play();
				}
			}
		}

		public IEnumerator SetupAudio(int id, DSAudioSetup setup)
		{
			switch (id)
			{
			case 0:
				musicSetup = setup;
				musicSetup = SetupAudioHelper(musicSetup);
				if (musicSetup.action == DSAudioAction.FadeInAndPlay)
				{
					StopCoroutine("AudioFadeIn");
					yield return StartCoroutine(AudioFadeIn(musicSetup));
				}
				else if (musicSetup.action == DSAudioAction.FadeOut)
				{
					StopCoroutine("AudioFadeOut");
					yield return StartCoroutine(AudioFadeOut(musicSetup));
				}
				break;
			case 1:
				sfx1Setup = setup;
				sfx1Setup = SetupAudioHelper(sfx1Setup);
				if (sfx1Setup.action == DSAudioAction.FadeInAndPlay)
				{
					StopCoroutine("AudioFadeIn");
					yield return StartCoroutine(AudioFadeIn(sfx1Setup));
				}
				else if (sfx1Setup.action == DSAudioAction.FadeOut)
				{
					StopCoroutine("AudioFadeOut");
					yield return StartCoroutine(AudioFadeOut(sfx1Setup));
				}
				break;
			case 2:
				sfx2Setup = setup;
				sfx2Setup = SetupAudioHelper(sfx2Setup);
				if (sfx2Setup.action == DSAudioAction.FadeInAndPlay)
				{
					StopCoroutine("AudioFadeIn");
					yield return StartCoroutine(AudioFadeIn(sfx2Setup));
				}
				else if (sfx2Setup.action == DSAudioAction.FadeOut)
				{
					StopCoroutine("AudioFadeOut");
					yield return StartCoroutine(AudioFadeOut(sfx2Setup));
				}
				break;
			case 3:
				sfx3Setup = setup;
				sfx3Setup = SetupAudioHelper(sfx3Setup);
				if (sfx3Setup.action == DSAudioAction.FadeInAndPlay)
				{
					StopCoroutine("AudioFadeIn");
					yield return StartCoroutine(AudioFadeIn(sfx3Setup));
				}
				else if (sfx3Setup.action == DSAudioAction.FadeOut)
				{
					StopCoroutine("AudioFadeOut");
					yield return StartCoroutine(AudioFadeOut(sfx3Setup));
				}
				break;
			}
		}

		public DSAudioSetup SetupAudioHelper(DSAudioSetup setup)
		{
			if (setup.action == DSAudioAction.Stop)
			{
				setup.source.Stop();
				setup.source.clip = null;
				setup.action = DSAudioAction.None;
			}
			else if (setup.action == DSAudioAction.Play || setup.action == DSAudioAction.FadeInAndPlay)
			{
				if (setup.useAudioPath && setup.playFromPath != null)
				{
					setup.clip = Resources.Load(options.audioFilepathPrefix + setup.playFromPath) as AudioClip;
					if (setup.clip == null)
					{
						if (dui != null && dui.options.debugSystemMessagesInConsole)
						{
							Debug.Log("DIALOG UI: Couldn't Play Audio. No file was located at \"" + options.audioFilepathPrefix + setup.playFromPath + "\"");
						}
						setup.action = DSAudioAction.None;
						setup.source.Stop();
						setup.clip = null;
					}
				}
				else if (!setup.useAudioPath && setup.clip == null)
				{
					if (dui != null && dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("DIALOG UI: Couldn't play Audio. No AudioClip was set up.");
					}
					setup.action = DSAudioAction.None;
					setup.source.Stop();
					setup.clip = null;
				}
				if (setup.clip != null)
				{
					if (setup.action == DSAudioAction.FadeInAndPlay)
					{
						setup.currentVolume = 0.001f;
						setup.source.volume = 0.001f;
						setup.source.clip = setup.clip;
						setup.source.pitch = setup.pitch;
						setup.source.loop = setup.loop;
						setup.source.Play();
					}
					else if (setup.action == DSAudioAction.Play)
					{
						setup.currentVolume = setup.volume;
						setup.source.clip = setup.clip;
						setup.source.volume = setup.volume;
						setup.source.pitch = setup.pitch;
						setup.source.loop = setup.loop;
						setup.source.Play();
					}
				}
			}
			return setup;
		}

		public IEnumerator AudioFadeIn(DSAudioSetup setup)
		{
			yield return null;
			if (setup == null)
			{
				yield break;
			}
			while (setup != null && setup.action == DSAudioAction.FadeInAndPlay && setup.source.clip != null && setup.source.volume < setup.volume)
			{
				setup.source.volume += Time.deltaTime / setup.fadeDuration;
				if (setup.action == DSAudioAction.FadeInAndPlay && setup.source.volume >= setup.volume)
				{
					setup.action = DSAudioAction.None;
				}
				yield return null;
			}
		}

		public IEnumerator AudioFadeOut(DSAudioSetup setup)
		{
			yield return null;
			if (setup == null)
			{
				yield break;
			}
			while (setup != null && setup.action == DSAudioAction.FadeOut && setup.source.clip != null && setup.source.volume > 0.1f)
			{
				setup.source.volume -= Time.deltaTime / setup.fadeDuration;
				if (setup.action == DSAudioAction.FadeOut && setup.source.volume <= 0.1f)
				{
					setup.source.Stop();
					setup.source.volume = 0.001f;
					setup.action = DSAudioAction.None;
					setup.clip = null;
				}
				yield return null;
			}
		}

		public string LocalizeYesButton()
		{
			if (DialogLocalization.language == "English")
			{
				return "Yes";
			}
			if (DialogLocalization.language == "Chinese")
			{
				return "是";
			}
			if (DialogLocalization.language == "Korean")
			{
				return "예\u0098\u0088";
			}
			if (DialogLocalization.language == "Japanese")
			{
				return "はい";
			}
			if (DialogLocalization.language == "German")
			{
				return "Ja";
			}
			if (DialogLocalization.language == "French")
			{
				return "Oui";
			}
			if (DialogLocalization.language == "Spanish")
			{
				return "Sí";
			}
			if (DialogLocalization.language == "Italian")
			{
				return "Sì";
			}
			if (DialogLocalization.language == "Portuguese")
			{
				return "Sim";
			}
			if (DialogLocalization.language == "Russian")
			{
				return "да";
			}
			return "Yes";
		}

		public string LocalizeNoButton()
		{
			if (DialogLocalization.language == "English")
			{
				return "No";
			}
			if (DialogLocalization.language == "Chinese")
			{
				return "没有";
			}
			if (DialogLocalization.language == "Korean")
			{
				return "아니\u008b\u0088";
			}
			if (DialogLocalization.language == "Japanese")
			{
				return "ノー";
			}
			if (DialogLocalization.language == "German")
			{
				return "Nein";
			}
			if (DialogLocalization.language == "French")
			{
				return "Aucun";
			}
			if (DialogLocalization.language == "Spanish")
			{
				return "No";
			}
			if (DialogLocalization.language == "Italian")
			{
				return "No";
			}
			if (DialogLocalization.language == "Portuguese")
			{
				return "Não";
			}
			if (DialogLocalization.language == "Russian")
			{
				return "нет";
			}
			return "No";
		}

		public string LocalizeNextButton()
		{
			if (DialogLocalization.language == "English")
			{
				return "Next";
			}
			if (DialogLocalization.language == "Chinese")
			{
				return "继续";
			}
			if (DialogLocalization.language == "Korean")
			{
				return "다음";
			}
			if (DialogLocalization.language == "Japanese")
			{
				return "次の";
			}
			if (DialogLocalization.language == "German")
			{
				return "Weiter";
			}
			if (DialogLocalization.language == "French")
			{
				return "Next";
			}
			if (DialogLocalization.language == "Spanish")
			{
				return "Próximo";
			}
			if (DialogLocalization.language == "Italian")
			{
				return "Seguente";
			}
			if (DialogLocalization.language == "Portuguese")
			{
				return "Próximo";
			}
			if (DialogLocalization.language == "Russian")
			{
				return "следующий";
			}
			return "Next";
		}

		public void API_ChangeLanguageLocal(DS_SetNewLanguage action)
		{
			ChangeLanguage(action, updateGUISkin: true);
		}

		public static void API_ChangeLanguage(DS_SetNewLanguage action, bool updateGUISkin)
		{
			ChangeLanguage(action, updateGUISkin);
		}

		public static void ChangeLanguage(DS_SetNewLanguage action, bool updateGUISkin)
		{
			if (DialogLocalization.com != null && action != 0)
			{
				if (action == DS_SetNewLanguage.AutoDetect)
				{
					DialogLocalization.com.Localize();
				}
				else if (action == DS_SetNewLanguage.English)
				{
					DialogLocalization.language = "English";
				}
				else if (action == DS_SetNewLanguage.Chinese && DialogLocalization.com.languages.chinese)
				{
					DialogLocalization.language = "Chinese";
				}
				else if (action == DS_SetNewLanguage.Korean && DialogLocalization.com.languages.korean)
				{
					DialogLocalization.language = "Korean";
				}
				else if (action == DS_SetNewLanguage.Japanese && DialogLocalization.com.languages.japanese)
				{
					DialogLocalization.language = "Japanese";
				}
				else if (action == DS_SetNewLanguage.Spanish && DialogLocalization.com.languages.spanish)
				{
					DialogLocalization.language = "Spanish";
				}
				else if (action == DS_SetNewLanguage.Italian && DialogLocalization.com.languages.italian)
				{
					DialogLocalization.language = "Italian";
				}
				else if (action == DS_SetNewLanguage.German && DialogLocalization.com.languages.german)
				{
					DialogLocalization.language = "German";
				}
				else if (action == DS_SetNewLanguage.French && DialogLocalization.com.languages.french)
				{
					DialogLocalization.language = "French";
				}
				else if (action == DS_SetNewLanguage.Portuguese && DialogLocalization.com.languages.portuguese)
				{
					DialogLocalization.language = "Portuguese";
				}
				else if (action == DS_SetNewLanguage.Russian && DialogLocalization.com.languages.russian)
				{
					DialogLocalization.language = "Russian";
				}
				else
				{
					DialogLocalization.language = "English";
				}
				if (DialogLocalization.com.detectionMode == LDC_LanguageDetectionMode.UsingPlayerPrefsKey && DialogLocalization.com.detectUsingPlayerPrefsKey != string.Empty)
				{
					if (PlayerPrefs.HasKey(DialogLocalization.com.detectUsingPlayerPrefsKey))
					{
						PlayerPrefs.DeleteKey(DialogLocalization.com.detectUsingPlayerPrefsKey);
					}
					PlayerPrefs.SetString(DialogLocalization.com.detectUsingPlayerPrefsKey, DialogLocalization.language);
				}
				DialogScreen[] array = UnityEngine.Object.FindObjectsOfType(typeof(DialogScreen)) as DialogScreen[];
				if (array.Length != 0)
				{
					DialogScreen[] array2 = array;
					foreach (DialogScreen dialogScreen in array2)
					{
						if (dialogScreen != null)
						{
							dialogScreen.Localize();
						}
					}
				}
				if (updateGUISkin && DialogOnGUI.com != null)
				{
					DialogOnGUI.com.Start();
					Resources.UnloadUnusedAssets();
				}
			}
			else if (DialogLocalization.com == null && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("LDC: DialogLocalization.com doesn't exist yet. Note you cannot change Languages On Awake().");
			}
		}

		public void API_ChangeLanguageLocal(int action)
		{
			ChangeLanguage(action, updateGUISkin: true);
		}

		public static void API_ChangeLanguage(int action, bool updateGUISkin)
		{
			ChangeLanguage(action, updateGUISkin);
		}

		public static void ChangeLanguage(int action, bool updateGUISkin)
		{
			if (DialogLocalization.com != null)
			{
				if (action == 0)
				{
					DialogLocalization.com.Localize();
				}
				else if (action == 1)
				{
					DialogLocalization.language = "English";
				}
				else if (action == 2 && DialogLocalization.com.languages.chinese)
				{
					DialogLocalization.language = "Chinese";
				}
				else if (action == 3 && DialogLocalization.com.languages.korean)
				{
					DialogLocalization.language = "Korean";
				}
				else if (action == 4 && DialogLocalization.com.languages.japanese)
				{
					DialogLocalization.language = "Japanese";
				}
				else if (action == 5 && DialogLocalization.com.languages.spanish)
				{
					DialogLocalization.language = "Spanish";
				}
				else if (action == 6 && DialogLocalization.com.languages.italian)
				{
					DialogLocalization.language = "Italian";
				}
				else if (action == 7 && DialogLocalization.com.languages.german)
				{
					DialogLocalization.language = "German";
				}
				else if (action == 8 && DialogLocalization.com.languages.french)
				{
					DialogLocalization.language = "French";
				}
				else if (action == 9 && DialogLocalization.com.languages.portuguese)
				{
					DialogLocalization.language = "Portuguese";
				}
				else if (action == 10 && DialogLocalization.com.languages.russian)
				{
					DialogLocalization.language = "Russian";
				}
				else
				{
					DialogLocalization.language = "English";
				}
				if (DialogLocalization.com.detectionMode == LDC_LanguageDetectionMode.UsingPlayerPrefsKey && DialogLocalization.com.detectUsingPlayerPrefsKey != string.Empty)
				{
					if (PlayerPrefs.HasKey(DialogLocalization.com.detectUsingPlayerPrefsKey))
					{
						PlayerPrefs.DeleteKey(DialogLocalization.com.detectUsingPlayerPrefsKey);
					}
					PlayerPrefs.SetString(DialogLocalization.com.detectUsingPlayerPrefsKey, DialogLocalization.language);
				}
				DialogScreen[] array = UnityEngine.Object.FindObjectsOfType(typeof(DialogScreen)) as DialogScreen[];
				if (array.Length != 0)
				{
					DialogScreen[] array2 = array;
					foreach (DialogScreen dialogScreen in array2)
					{
						if (dialogScreen != null)
						{
							dialogScreen.Localize();
						}
					}
				}
				if (updateGUISkin && DialogOnGUI.com != null)
				{
					DialogOnGUI.com.Start();
					Resources.UnloadUnusedAssets();
				}
			}
			else if (DialogLocalization.com == null && dui != null && dui.options.debugSystemMessagesInConsole)
			{
				Debug.Log("LDC: DialogLocalization.com doesn't exist yet. Note you cannot change Languages On Awake().");
			}
		}

		public static void API_LoadLevel(string level)
		{
			if (Application.isPlaying)
			{
				if (level != string.Empty && dui != null)
				{
					dui.StopCoroutine("API_CreateDialogCoroutine");
					dui.StopCoroutine("API_PlayDialogCoroutine");
					dui.StopCoroutine("API_LoadLevelCoroutine");
					dui.StartCoroutine("API_LoadLevelCoroutine", level);
				}
				else
				{
					Debug.Log("DialogUI API (API_LoadLevelCoroutine): No Level was setup to be loaded!");
				}
			}
		}

		public IEnumerator API_LoadLevelCoroutine(string level)
		{
			while (!ended)
			{
				yield return null;
			}
			if (ended && level != string.Empty)
			{
				SceneManager.LoadScene(level, LoadSceneMode.Single);
			}
		}

		public static void API_CreateDialogNow(GameObject go)
		{
			API_CreateDialogNow(go, -1);
		}

		public static void API_CreateDialogNow(GameObject go, int overrideStartID)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (go != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(go);
				if (overrideStartID != -1 && gameObject != null && gameObject.GetComponent<DialogController>() != null)
				{
					gameObject.GetComponent<DialogController>().startID = overrideStartID;
				}
			}
			else
			{
				Debug.Log("DialogUI API (API_CreateDialogNow): No GameObject was sent to be created!");
			}
		}

		public static void API_CreateDialog(GameObject go)
		{
			API_CreateDialog(go, -1);
		}

		public static void API_CreateDialog(GameObject go, int overrideStartID)
		{
			if (Application.isPlaying)
			{
				if (go != null && dui != null)
				{
					LDC_CreateDialog lDC_CreateDialog = new LDC_CreateDialog();
					lDC_CreateDialog.go = go;
					lDC_CreateDialog.overrideStartID = overrideStartID;
					dui.StopCoroutine("API_CreateDialogCoroutine");
					dui.StopCoroutine("API_PlayDialogCoroutine");
					dui.StopCoroutine("API_LoadLevelCoroutine");
					dui.StartCoroutine("API_CreateDialogCoroutine", lDC_CreateDialog);
				}
				else
				{
					Debug.Log("DialogUI API (API_CreateDialog): No GameObject was sent to be created!");
				}
			}
		}

		public IEnumerator API_CreateDialogCoroutine(LDC_CreateDialog arg)
		{
			while (!ended)
			{
				yield return null;
			}
			if (ended && arg != null && arg.go != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(arg.go);
				if (arg.overrideStartID != -1 && gameObject != null && gameObject.GetComponent<DialogController>() != null)
				{
					gameObject.GetComponent<DialogController>().startID = arg.overrideStartID;
				}
			}
		}

		public static void API_PlayDialogNow(GameObject go)
		{
			if (go != null && go.GetComponent<DialogController>() != null)
			{
				DialogController component = go.GetComponent<DialogController>();
				if (component != null)
				{
					API_PlayDialogNow(component);
				}
			}
			else
			{
				Debug.Log("LDC API: This GameObject doesn't have a DialogController.");
			}
		}

		public static void API_PlayDialogNow(DialogController dc)
		{
			if (Application.isPlaying && dc != null)
			{
				dc.Play();
			}
		}

		public static void API_PlayDialog(GameObject go)
		{
			if (go != null && go.GetComponent<DialogController>() != null)
			{
				DialogController component = go.GetComponent<DialogController>();
				if (component != null)
				{
					API_PlayDialog(component);
				}
			}
			else
			{
				Debug.Log("LDC API: This GameObject doesn't have a DialogController.");
			}
		}

		public static void API_PlayDialog(DialogController dc)
		{
			if (Application.isPlaying && dc != null)
			{
				dui.StopCoroutine("API_CreateDialogCoroutine");
				dui.StopCoroutine("API_PlayDialogCoroutine");
				dui.StopCoroutine("API_LoadLevelCoroutine");
				dui.StartCoroutine("API_PlayDialogCoroutine", dc);
			}
		}

		public IEnumerator API_PlayDialogCoroutine(DialogController dc)
		{
			while (!ended)
			{
				yield return null;
			}
			if (ended && dc != null)
			{
				dc.Play();
			}
		}

		public static void API_SetToken(string tokenToSet, string tokenValue)
		{
			if (Application.isPlaying)
			{
				SetToken(tokenToSet, tokenValue);
			}
		}

		public static void API_SetToken(string tokenToSet, float sentFloat)
		{
			if (Application.isPlaying)
			{
				SetToken(tokenToSet, sentFloat);
			}
		}

		public static string API_GetTokenAsString(string tokenToGet)
		{
			if (Application.isPlaying)
			{
				return GetToken(tokenToGet);
			}
			return string.Empty;
		}

		public static float API_GetTokenAsFloat(string tokenToGet)
		{
			if (Application.isPlaying)
			{
				return GetTokenAsFloat(tokenToGet);
			}
			return 0f;
		}

		public static int API_GetTokenIndex(string nameOfToken)
		{
			if (dui != null && dui.tokens.Length != 0)
			{
				int num = 0;
				DUITokens[] array = dui.tokens;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].name == nameOfToken)
					{
						return num;
					}
					num++;
				}
				Debug.LogWarning("DIALOG UI: (ERROR) Couldn't find Index of token because no token matched the name: " + nameOfToken);
				return -1;
			}
			Debug.LogWarning("DIALOG UI: (ERROR) Couldn't find Index of token because DialogUI.dui doesn't exist yet or no tokens have been setup.");
			return -1;
		}

		public static void API_SaveTokensToDisk()
		{
			SaveTokensToDisk();
		}

		public static void API_LoadTokensFromDisk()
		{
			LoadTokensFromDisk();
		}

		public static void API_DeleteTokensFromDisk()
		{
			DeleteTokensFromDisk();
		}

		public static void API_SetTokenSavePrefix(string prefix)
		{
			if (dui != null)
			{
				dui.fileManagement.savePrefix = prefix;
			}
			else
			{
				Debug.Log("LDC Error - Couldn't set save prefix because DialogUI.dui isn't available.");
			}
		}

		public static void API_StopAllDialogs()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			GameObject[] array = GameObject.FindGameObjectsWithTag("DialogController");
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject != null) || !(gameObject.GetComponent<DialogController>() != null))
				{
					continue;
				}
				DialogController component = gameObject.GetComponent<DialogController>();
				Debug.Log("LDC: (DialogUI) telling another DialogController to stop -> object to stop is called " + component.gameObject.name);
				if (!(component != null) || component.status == DCSTATUS.ENDED)
				{
					continue;
				}
				component.status = DCSTATUS.ENDED;
				component.currentScreen = null;
				component.currentID = 0;
				DialogScreen[] components = component.gameObject.GetComponents<DialogScreen>();
				foreach (DialogScreen dialogScreen in components)
				{
					if (dialogScreen != null)
					{
						dialogScreen.isActive = false;
					}
				}
				if (dui != null)
				{
					dui.StopScreenNow();
				}
				if (component.autoPlay)
				{
					Debug.Log("LDC: (DialogUI) Destroying DialogController of name: " + component.gameObject);
					UnityEngine.Object.Destroy(component.gameObject);
				}
			}
		}

		public static string API_TextInjector(string text)
		{
			return API_TextInjector(text, 1f);
		}

		public static string API_TextInjector(string text, float textAlpha)
		{
			if (dui != null)
			{
				DUICachedInjectors[] theCachedStyleInjectors = new DUICachedInjectors[0];
				ReturnDUICachedInjectorsForScreen returnDUICachedInjectorsForScreen = CalculateStyleInjectors(text, theCachedStyleInjectors);
				return dui.InjectStylesIntoText(returnDUICachedInjectorsForScreen.theText, returnDUICachedInjectorsForScreen.injectors, textAlpha, usingTypewriter: false, fromAPI: true);
			}
			return text;
		}

		public static GameObject API_DialogCreate()
		{
			GameObject obj = new GameObject
			{
				name = "New LDC Dialog"
			};
			DialogController dialogController = obj.AddComponent<DialogController>();
			if (dialogController != null)
			{
				dialogController.autoPlay = true;
				dialogController.startAfterXSeconds = 1f;
			}
			return obj;
		}

		public static GameObject API_DialogCreate(bool isAutoPlay, float howManySeconds)
		{
			GameObject obj = new GameObject
			{
				name = "New LDC Dialog"
			};
			DialogController dialogController = obj.AddComponent<DialogController>();
			if (dialogController != null)
			{
				dialogController.startAfterXSeconds = Mathf.Clamp((int)howManySeconds, 1, 9999999);
				if (isAutoPlay)
				{
					dialogController.autoPlay = true;
				}
			}
			return obj;
		}

		public static GameObject API_DialogCreate(bool isAutoPlay, float howManySeconds, string gameObjectName)
		{
			GameObject obj = new GameObject
			{
				name = gameObjectName
			};
			DialogController dialogController = obj.AddComponent<DialogController>();
			if (dialogController != null)
			{
				dialogController.startAfterXSeconds = Mathf.Clamp((int)howManySeconds, 1, 9999999);
				if (isAutoPlay)
				{
					dialogController.autoPlay = true;
				}
			}
			return obj;
		}

		public static DialogScreen API_DialogAddNextScreen(GameObject go, int dialogID, Texture2D portrait, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, string audioFilePath, float secondsToDisplay, bool hideNextButton, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, int nextID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.NextButton;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnNext = nextID;
				dialogScreen.navigation.secondsToDisplay = secondsToDisplay;
				dialogScreen.navigation.hideNextButton = hideNextButton;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddOneButtonScreen(GameObject go, int dialogID, Texture2D portrait, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, string audioFilePath, float secondsToDisplay, bool hideNextButton, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabel, int nextID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.OneButton;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.customButton1 = buttonLabel;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnNext = nextID;
				dialogScreen.navigation.secondsToDisplay = secondsToDisplay;
				dialogScreen.navigation.hideNextButton = hideNextButton;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddYesNoScreen(GameObject go, int dialogID, Texture2D portrait, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, int yesID, int noID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.YesOrNo;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnYes = yesID;
				dialogScreen.navigation.screenToLoadOnNo = noID;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddTwoButtonScreen(GameObject go, int dialogID, Texture2D portrait, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabelRight, string buttonLabelLeft, int yesID, int noID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.TwoButtons;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.customButton1 = buttonLabelRight;
				dialogScreen.screen.customButton2 = buttonLabelLeft;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnYes = yesID;
				dialogScreen.navigation.screenToLoadOnNo = noID;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddMultipleButtonScreen(GameObject go, int dialogID, Texture2D portrait, string title, string dialogText, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string[] multipleButtons, int[] multipleButtonsID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null && multipleButtons.Length != 0 && multipleButtons.Length == multipleButtonsID.Length)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.MultipleButtons;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.multipleButtons = multipleButtons;
				dialogScreen.navigation.multipleButtons = multipleButtonsID;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			Debug.Log("LDC ERROR: Couldnt Add Multiple Button Screen because the button label and ID array lengths don't match (or were empty)! This screen was skipped!");
			return null;
		}

		public static DialogScreen API_DialogAddPasswordScreen(GameObject go, int dialogID, Texture2D portrait, string title, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabel, string password, DS_DATA_ANCHOR position, bool passwordCaseSensitive, bool usePasswordMask, int correctID, int wrongID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.Password;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.portrait = portrait;
				dialogScreen.screen.customButton1 = buttonLabel;
				dialogScreen.screen.passwordMatchToToken = false;
				dialogScreen.screen.passwordAnswer = password;
				dialogScreen.screen.dataEntryAnchor = position;
				dialogScreen.screen.passwordCaseSensitive = passwordCaseSensitive;
				dialogScreen.screen.passwordMask = usePasswordMask;
				dialogScreen.navigation.screenToLoadOnYes = correctID;
				dialogScreen.navigation.screenToLoadOnNo = wrongID;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
				dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddDataEntryScreen(GameObject go, int dialogID, Texture2D portrait, string title, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, bool noPortraitFadeIn, bool noPortraitFadeOut, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabel, string tokenNameToSet, DS_DATA_ANCHOR position, DS_DATA_FORMAT dataFormat, int characterLimit, string defaultValue, int nextID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			if (API_GetTokenIndex(tokenNameToSet) >= 0)
			{
				DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
				if (dialogScreen != null)
				{
					dialogScreen.dialogID = dialogID;
					dialogScreen.screen.dialogStyle = DIALOGSTYLE.DataEntry;
					dialogScreen.screen.actorName = title;
					dialogScreen.screen.soundToLoad = audioFilePath;
					dialogScreen.screen.portrait = portrait;
					dialogScreen.screen.customButton1 = buttonLabel;
					dialogScreen.screen.dataEntryToken = API_GetTokenIndex(tokenNameToSet);
					dialogScreen.screen.dataEntryAnchor = position;
					dialogScreen.screen.dataEntryFormat = dataFormat;
					dialogScreen.screen.dataEntryCharacterLimit = characterLimit;
					dialogScreen.screen.dataEntryDefaultValue = defaultValue;
					dialogScreen.navigation.screenToLoadOnNext = nextID;
					dialogScreen.navigation.endDialogAfterThis = endAfterThis;
					dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
					dialogScreen.navigation.noPortraitFadeIn = noPortraitFadeIn;
					dialogScreen.navigation.noPortraitFadeOut = noPortraitFadeOut;
					dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
					dialogScreen.actions.callbacksAtStart = callbacksAtStart;
					dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
					dialogScreen.actions.actionAtStart = actionCallbackAtStart;
					dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
					if (navigationCallback != null && navigationCallback.Length == 3)
					{
						dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
						dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
						dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
					}
					dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
					dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
					return dialogScreen;
				}
			}
			else
			{
				Debug.LogWarning("DIALOG UI: (ERROR) Data Entry Screen couldn't be created and was skipped.");
			}
			return null;
		}

		public static DialogScreen API_DialogAddTitleScreen(GameObject go, int dialogID, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, Vector2 titleOffset, Vector2 subtitleOffset, Color titleColor, Color subtitleColor, Vector2 titleSize, Vector2 subtitleSize, Font overrideTitleFont, Font overrideSubtitleFont, int titleFontSize, int subtitleFontSize, TextAnchor titleAllignment, TextAnchor subtitleAllignment, string audioFilePath, float secondsToDisplay, bool hideNextButton, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabel, int nextID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.Title;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.customButton1 = buttonLabel;
				dialogScreen.screen.titleOffset = titleOffset;
				dialogScreen.screen.subtitleOffset = subtitleOffset;
				dialogScreen.screen.titleColor = titleColor;
				dialogScreen.screen.subtitleColor = subtitleColor;
				dialogScreen.screen.titleSize = titleSize;
				dialogScreen.screen.subtitleSize = subtitleSize;
				dialogScreen.screen.overrideTitleFont = overrideTitleFont;
				dialogScreen.screen.overrideSubtitleFont = overrideSubtitleFont;
				dialogScreen.screen.titleSize = titleSize;
				dialogScreen.screen.subtitleSize = subtitleSize;
				dialogScreen.screen.titleAllignment = titleAllignment;
				dialogScreen.screen.subtitleAllignment = subtitleAllignment;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnNext = nextID;
				dialogScreen.navigation.secondsToDisplay = secondsToDisplay;
				dialogScreen.navigation.hideNextButton = hideNextButton;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = false;
				dialogScreen.navigation.noPortraitFadeOut = false;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddPopupScreen(GameObject go, int dialogID, string title, string dialogText, DIALOG_OVERRIDE_YESNO typeWriterOptions, DIALOG_OVERRIDE_SCROLLING scrollingOptions, Vector2 popupSize, Texture2D popupImage, float popupBackgroundAlpha, POPUP_OPTIONS popupOptions, string audioFilePath, float secondsToDisplay, bool hideNextButton, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, string buttonLabel1, string buttonLabel2, int buttonOneNextID, int buttonTwoNextID, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
			if (dialogScreen != null)
			{
				dialogScreen.dialogID = dialogID;
				dialogScreen.screen.dialogStyle = DIALOGSTYLE.Popup;
				dialogScreen.screen.actorName = title;
				dialogScreen.screen.dialogText = dialogText;
				dialogScreen.screen.soundToLoad = audioFilePath;
				dialogScreen.screen.customButton1 = buttonLabel1;
				dialogScreen.screen.customButton2 = buttonLabel2;
				dialogScreen.screen.popupSizeX = (int)Mathf.Round(popupSize.x);
				dialogScreen.screen.popupSizeY = (int)Mathf.Round(popupSize.y);
				dialogScreen.screen.popupImage = popupImage;
				dialogScreen.screen.popupBackgroundAlpha = popupBackgroundAlpha;
				dialogScreen.screen.popupOptions = popupOptions;
				dialogScreen.screen.typeWriterOptions = typeWriterOptions;
				dialogScreen.screen.scrollingOptions = scrollingOptions;
				dialogScreen.navigation.screenToLoadOnNext = buttonOneNextID;
				dialogScreen.navigation.screenToLoadOnYes = buttonOneNextID;
				dialogScreen.navigation.screenToLoadOnNo = buttonTwoNextID;
				dialogScreen.navigation.secondsToDisplay = secondsToDisplay;
				dialogScreen.navigation.hideNextButton = hideNextButton;
				dialogScreen.navigation.endDialogAfterThis = endAfterThis;
				dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
				dialogScreen.navigation.noPortraitFadeIn = false;
				dialogScreen.navigation.noPortraitFadeOut = false;
				dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
				dialogScreen.actions.callbacksAtStart = callbacksAtStart;
				dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
				dialogScreen.actions.actionAtStart = actionCallbackAtStart;
				dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
				if (navigationCallback != null && navigationCallback.Length == 3)
				{
					dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
					dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
					dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
				}
				dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
				dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
				return dialogScreen;
			}
			return null;
		}

		public static DialogScreen API_DialogAddIconGridScreen(GameObject go, int dialogID, string title, string subtitle, DIALOG_OVERRIDE_YESNO typeWriterOptions, IconGridWindowOptions windowOptions, IconGridLayout iconLayout, IconGridButtons[] buttons, string audioFilePath, bool hideDialogBackground, bool endAfterThis, bool destroyAfterThis, DIALOG_OVERRIDE_TRANSITION screenTransitionIn, DIALOG_OVERRIDE_TRANSITION screenTransitionOut, UnityEvent callbacksAtStart, UnityEvent callbacksAtEnd, Action actionCallbackAtStart, Action actionCallbackAtEnd, string[] navigationCallback)
		{
			if (windowOptions != null && iconLayout != null && buttons != null && buttons.Length != 0)
			{
				DialogScreen dialogScreen = go.AddComponent<DialogScreen>();
				if (dialogScreen != null)
				{
					dialogScreen.dialogID = dialogID;
					dialogScreen.screen.dialogStyle = DIALOGSTYLE.IconGrid;
					dialogScreen.screen.actorName = title;
					dialogScreen.screen.dialogText = subtitle;
					dialogScreen.screen.soundToLoad = audioFilePath;
					dialogScreen.screen.IG_WindowSizeX = windowOptions.IG_WindowSizeX;
					dialogScreen.screen.IG_WindowSizeY = windowOptions.IG_WindowSizeY;
					dialogScreen.screen.IG_WindowOffsetX = windowOptions.IG_WindowOffsetX;
					dialogScreen.screen.IG_WindowOffsetY = windowOptions.IG_WindowOffsetY;
					dialogScreen.screen.IG_useXScrolling = windowOptions.IG_useXScrolling;
					dialogScreen.screen.IG_useYScrolling = windowOptions.IG_useYScrolling;
					dialogScreen.screen.IG_WindowShowTitle = windowOptions.IG_WindowShowTitle;
					dialogScreen.screen.IG_WindowShowSubtitle = windowOptions.IG_WindowShowSubtitle;
					dialogScreen.screen.IG_AddSpaceBetweenSubtitleAndContent = windowOptions.IG_AddSpaceBetweenSubtitleAndContent;
					dialogScreen.screen.IG_showPanelBG = windowOptions.IG_showPanelBG;
					dialogScreen.screen.IG_BackgroundAlpha = windowOptions.IG_BackgroundAlpha;
					dialogScreen.screen.IG_iconSizeX = iconLayout.IG_iconSizeX;
					dialogScreen.screen.IG_iconSizeY = iconLayout.IG_iconSizeY;
					dialogScreen.screen.IG_iconsPerRow = iconLayout.IG_iconsPerRow;
					dialogScreen.screen.IG_IconSpacer = iconLayout.IG_IconSpacer;
					dialogScreen.screen.IG_AddInnerIconSpacing = iconLayout.IG_AddInnerIconSpacing;
					dialogScreen.screen.IG_showIconLabels = iconLayout.IG_showIconLabels;
					dialogScreen.screen.IG_iconLabelSize = iconLayout.IG_iconLabelSize;
					dialogScreen.screen.IG_firstIconIsCloseButton = iconLayout.IG_firstIconIsCloseButton;
					dialogScreen.screen.IG_closeButtonSize = iconLayout.IG_closeButtonSize;
					dialogScreen.screen.IG_showButtonBackgrounds = iconLayout.IG_showButtonBackgrounds;
					dialogScreen.screen.IG_buttonAllignment = iconLayout.IG_buttonAllignment;
					dialogScreen.screen.IG_buttonImagePosition = iconLayout.IG_buttonImagePosition;
					dialogScreen.screen.IG_buttons = buttons;
					dialogScreen.screen.typeWriterOptions = typeWriterOptions;
					dialogScreen.navigation.endDialogAfterThis = endAfterThis;
					dialogScreen.navigation.destroyAtEnd = destroyAfterThis;
					dialogScreen.navigation.hideDialogBackground = hideDialogBackground;
					dialogScreen.actions.callbacksAtStart = callbacksAtStart;
					dialogScreen.actions.callbacksAtEnd = callbacksAtEnd;
					dialogScreen.actions.actionAtStart = actionCallbackAtStart;
					dialogScreen.actions.actionAtEnd = actionCallbackAtEnd;
					if (navigationCallback != null && navigationCallback.Length == 3)
					{
						dialogScreen.navigation.navigationCallbackGOName = navigationCallback[0];
						dialogScreen.navigation.navigationCallbackFunctionName = navigationCallback[1];
						dialogScreen.navigation.navigationCallbackArg = navigationCallback[2];
					}
					dialogScreen.navigation.screenTransitionIn = screenTransitionIn;
					dialogScreen.navigation.screenTransitionOut = screenTransitionOut;
					return dialogScreen;
				}
			}
			return null;
		}
	}
}
