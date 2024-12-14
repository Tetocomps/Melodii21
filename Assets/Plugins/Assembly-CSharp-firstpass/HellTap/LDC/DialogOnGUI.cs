using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace HellTap.LDC
{
	public class DialogOnGUI : MonoBehaviour
	{
		public static DialogOnGUI com;

		private float originalWidth = 1920f;

		private float originalHeight = 1280f;

		private Vector3 scale;

		private Matrix4x4 svMat;

		private Matrix4x4 lastUsedMatrix;

		private float fitScale;

		private Vector3 fitScaleOffset = Vector3.zero;

		[NonSerialized]
		public GUISkin skin;

		public OnGuiRenderMode renderMode;

		public OnGuiScaleMode scalingMethod;

		public OnGuiScaleAnchor scalingAnchor = OnGuiScaleAnchor.Bottom;

		public float scaleToFitBackgroundWidener = 1.5f;

		public Material renderToMaterial;

		private bool _usingRenderTextures;

		private RenderTexture _guiRenderTexture;

		private RenderTexture _tempRenderTexture;

		private bool _guiRenderTextureCreated;

		private bool _guiRecreateRenderTextureNow;

		private Color clearRenderTextureColor = new Color(0f, 0f, 0f, 0f);

		public bool scaleTransition;

		public bool rotateTransition;

		public bool alwaysUseHiDef;

		public bool useHiDefOnMobileBuilds;

		public bool useHiDefOnWebBuilds;

		public bool useHiDefOnFlashBuilds;

		public bool useHiDefOnMetroBuilds = true;

		public bool useHiDefOnStandaloneBuilds = true;

		public bool useHiDefOnConsoleBuilds = true;

		private bool useHD;

		public DUISkinSetup skins = new DUISkinSetup();

		private Rect titleRect;

		private Rect titleRectShadow;

		private Rect subtitleRect;

		private Rect subtitleRectShadow;

		private float lastTime;

		private float guiDeltaTime;

		private bool updateDialogStylesTextSizes;

		public Camera newUICam;

		public DUI_TransitionEffects transitionEffect;

		public DUI_TransitionEffects oldTransition;

		private Vector3 positionVec = Vector3.zero;

		private float matrixScreenWidener = 1f;

		public float touchScrollMultiplierX = 1f;

		public float touchScrollMultiplierY = 1f;

		public bool manualTouchScrolling;

		private int fuIndex;

		private Rect fullScreenRect = new Rect(0f, 0f, 960f, 640f);

		private float transitionMatrixRotationAngle;

		public int depth;

		private Vector2 _srtScrollDelta = Vector2.zero;

		private Color _tempColor = Color.white;

		private const string _strNewLine = "\n";

		private string _visibleDataEntryString = string.Empty;

		private Rect _dataEntryCharButtonRect;

		private bool _inputCharacterShiftDown;

		private readonly string[] inputCharactersRow1 = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

		private readonly string[] inputCharactersRow2 = new string[10] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p" };

		private readonly string[] inputCharactersRow3 = new string[10] { "a", "s", "d", "f", "g", "h", "j", "k", "l", "@" };

		private readonly string[] inputCharactersRow4 = new string[10] { "z", "x", "c", "v", "b", "n", "m", "_", "-", "." };

		private readonly string[] inputCharacterOptions = new string[3] { "Shift", "Space", "Delete" };

		private readonly string[] inputCharactersRow2Shift = new string[10] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };

		private readonly string[] inputCharactersRow3Shift = new string[10] { "A", "S", "D", "F", "G", "H", "J", "K", "L", "@" };

		private readonly string[] inputCharactersRow4Shift = new string[10] { "Z", "X", "C", "V", "B", "N", "M", "_", "-", "." };

		private const string _stringShift = "Shift";

		private const string _stringSubmit = "Submit";

		private const string _stringDelete = "Delete";

		private const string _stringSpace = "Space";

		private const string _stringSpaceChar = " ";

		private bool usingFocusControl;

		private GUIStyle usingFocusStyle;

		private bool inputKeyBlocker;

		private Rect bgRect;

		private Rect portraitRect;

		private Rect actorRect;

		private Rect actorRectShadow;

		private Rect dialogRect;

		private Rect dialogRectShadow;

		private Rect yesRect;

		private Rect noRect;

		private Rect skipRect;

		private int verticalOffset;

		private Rect textFieldRect;

		private Rect dataEntryButton;

		private Vector2 buttonOffset = new Vector2(0f, 0f);

		private GUIContent dynamicGUIContent = new GUIContent();

		private GUIContent dynamicGUIContent2 = new GUIContent();

		private GUIContent dynamicGUIContentMultiple = new GUIContent();

		private Rect dataEntryBorderRect;

		private Rect dataEntryTitleRect;

		private Rect dataEntryTitleRectShadow;

		private Rect passwordBorderRect;

		private Rect passwordTitleRect;

		private Rect passwordTitleRectShadow;

		private Rect passwordTextFieldRect;

		private Rect passwordButton;

		private Rect popupImageBGRect;

		private Rect popupTitle;

		private Rect popupTitleShadow;

		private Rect popupText;

		private Rect popupTextShadow;

		private Rect popupButtonRect;

		private Rect popupButtonRect2;

		private int IG_HeaderHeight;

		private int IG_NumberOfIconsMinusClose;

		private int IG_NumberOfRows = 1;

		private int IG_CurrentIcon;

		private int IG_Spacer;

		private int IG_ContentSizeX;

		private int IG_ContentSizeY;

		private Rect iconGridBGRect;

		private Rect IG_ActualScrollRect;

		private Rect iconGridICRect;

		private Rect IG_TitleRect;

		private Rect IG_SubtitleRect;

		private Rect IG_TitleRectShadow;

		private Rect IG_SubtitleRectShadow;

		private Rect IG_Close_Btn;

		private Rect IG_Btn;

		private Rect IG_Btn_Label;

		private GUIStyle IG_ModifiedButtonStyle = new GUIStyle();

		private Rect IG_vrButtonRect;

		private Rect IG_vrButtonRightSpacerRect;

		private Rect IG_vrButtonBottomSpacerRect;

		private GUIStyle originalVerticalScrollbar = new GUIStyle();

		private GUIStyle titleStyleOverride = new GUIStyle();

		private GUIStyle subtitleStyleOverride = new GUIStyle();

		private GUIStyle subtitleShadowStyle = new GUIStyle();

		public Rect theAutoScrollRect;

		private Rect theShadowScrollRect;

		private Rect focusScrollRect;

		private Vector2 destinationScrollViewMove;

		public float SmoothScrollViewMoveTimeOut;

		private Vector2 portraitSize = new Vector2(512f, 512f);

		private Vector2 portraitOffset = new Vector2(0f, 0f);

		private GUIStyle _ldcGuiButtonNewStyle = new GUIStyle();

		private int _lastCachedButtonIndex = -1;

		private bool _simulatedMouseIsOverRect;

		private Vector2 lastFrameDialogUIScrollPosition = Vector2.zero;

		private Vector2 currentScrollPositionDelta = Vector2.zero;

		private Vector2 positionOnMouseDown = Vector2.zero;

		private Vector2 positionOnMouseUp = Vector2.zero;

		private bool mousePressInProgress;

		private bool invalidateCurrentMousePress;

		public void Awake()
		{
			com = this;
			DialogUI.guiComponent = this;
			updateDialogStylesTextSizes = false;
		}

		public bool UseHDSkins()
		{
			bool result = false;
			if (useHiDefOnStandaloneBuilds)
			{
				result = true;
			}
			if (alwaysUseHiDef)
			{
				result = true;
			}
			return result;
		}

		public void Start()
		{
			DialogUI.dui.LocalizeTokens();
			useHD = UseHDSkins();
			if (useHD && !updateDialogStylesTextSizes)
			{
				updateDialogStylesTextSizes = true;
				if (DialogUI.dui != null && DialogUI.dui.styles != null && DialogUI.dui.styles.list != null && DialogUI.dui.styles.list.Length != 0)
				{
					DUIStyleList[] list = DialogUI.dui.styles.list;
					foreach (DUIStyleList dUIStyleList in list)
					{
						if (dUIStyleList != null && dUIStyleList.fontSize > 0)
						{
							dUIStyleList.fontSize = (int)Mathf.Round(dUIStyleList.fontSize * 2);
						}
					}
					DialogUI.dui.CreateStyleInjectorCode();
				}
			}
			if (DialogLocalization.language == "English")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.english) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.english) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Chinese")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.chinese) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.chinese) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Korean")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.korean) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.korean) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Japanese")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.japanese) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.japanese) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "German")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.german) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.german) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "French")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.french) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.french) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Spanish")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.spanish) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.spanish) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Italian")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.italian) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.italian) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Portuguese")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.portuguese) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.portuguese) as GUISkin;
				}
			}
			else if (DialogLocalization.language == "Russian")
			{
				if (useHD)
				{
					skin = Resources.Load(skins.localizedSkinsHD.russian) as GUISkin;
				}
				else
				{
					skin = Resources.Load(skins.localizedSkins.russian) as GUISkin;
				}
			}
			if (skin == null)
			{
				Debug.Log("LDC: (DialogUI) ERROR -> There was a problem loading localized skin for language: " + DialogLocalization.language);
			}
			UpdateForceFocusButton();
		}

		public float LDC_UnclampedLerp(float a, float b, float t)
		{
			t = Mathf.Clamp01(t);
			return t * b + (1f - t) * a;
		}

		public void Update()
		{
			_usingRenderTextures = renderMode == OnGuiRenderMode.Material;
			if (_usingRenderTextures && _guiRenderTextureCreated && ((_guiRenderTexture != null && Math.Abs(_guiRenderTexture.width - Screen.width) > 1) || Math.Abs(_guiRenderTexture.height - Screen.height) > 1))
			{
				Debug.Log("LDC: Screen size was changed -> Recreating World Space RenderTextures!");
				_guiRecreateRenderTextureNow = true;
			}
			if (DialogUI.dui != null && DialogUI.dui.fade >= 1f)
			{
				DoButtonFocus();
			}
			if (!DialogUI.ended && DialogUI.dialogStyle == DIALOGSTYLE.IconGrid && Input.touchCount > 0)
			{
				if (Input.touches[0].phase == TouchPhase.Moved)
				{
					lastFrameDialogUIScrollPosition = DialogUI.scrollPosition;
					Vector2 scrollPosition = DialogUI.scrollPosition;
					scrollPosition.x -= Input.touches[0].deltaPosition.x * touchScrollMultiplierX;
					scrollPosition.y += Input.touches[0].deltaPosition.y * touchScrollMultiplierY;
					DialogUI.scrollPosition = scrollPosition;
					currentScrollPositionDelta = DialogUI.scrollPosition - lastFrameDialogUIScrollPosition;
				}
				else
				{
					currentScrollPositionDelta = Vector2.zero;
				}
			}
			else if (!DialogUI.ended && DialogUI.dialogStyle == DIALOGSTYLE.Popup && ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.ManualScrollingWithVerticalBar && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.ManualScrollingWithVerticalBar) && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
			{
				Vector2 autoScrollingValue = DialogUI.dui.options.autoScrollingValue;
				autoScrollingValue.x -= Input.touches[0].deltaPosition.x * touchScrollMultiplierX;
				autoScrollingValue.y += Input.touches[0].deltaPosition.y * touchScrollMultiplierY;
				DialogUI.dui.options.autoScrollingValue = autoScrollingValue;
			}
			if (!DialogUI.ended && DialogUI.dialogStyle == DIALOGSTYLE.NextButton && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.ManualScrollingWithVerticalBar && Input.touchCount > 0)
			{
				if (Input.touches[0].phase == TouchPhase.Began && MatrixTouchContainsCustomMatrix(dialogRect, lastUsedMatrix, new Vector2(Input.touches[0].position.x, (float)Screen.height - Input.touches[0].position.y)))
				{
					manualTouchScrolling = true;
				}
				else if (Input.touches[0].phase == TouchPhase.Moved && manualTouchScrolling)
				{
					Vector2 autoScrollingValue2 = DialogUI.dui.options.autoScrollingValue;
					autoScrollingValue2.y += Input.touches[0].deltaPosition.y * touchScrollMultiplierY;
					DialogUI.dui.options.autoScrollingValue = autoScrollingValue2;
				}
				else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
				{
					manualTouchScrolling = false;
				}
			}
			else
			{
				manualTouchScrolling = false;
			}
			MobileInputIconGridHelper();
			matrixScreenWidener = 1f;
			if (scalingMethod == OnGuiScaleMode.ScaleToFit && scaleToFitBackgroundWidener > 1f)
			{
				matrixScreenWidener = scaleToFitBackgroundWidener;
			}
			if (!(DialogUI.dui != null))
			{
				return;
			}
			transitionEffect = DialogUI.transition;
			if (transitionEffect != oldTransition)
			{
				oldTransition = transitionEffect;
				ResetTransitionMovement();
			}
			if (transitionEffect == DUI_TransitionEffects.PushLeft)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, (float)(-Screen.width) * matrixScreenWidener, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					if (positionVec.x < 0f)
					{
						positionVec.x = (float)Screen.width * matrixScreenWidener;
					}
					positionVec.x = LDC_UnclampedLerp(positionVec.x, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushRight)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, (float)Screen.width * matrixScreenWidener, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					if (positionVec.x > 0f)
					{
						positionVec.x = (float)(-Screen.width) * matrixScreenWidener;
					}
					positionVec.x = LDC_UnclampedLerp(positionVec.x, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushUp)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, -Screen.height, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					if (positionVec.y < 0f)
					{
						positionVec.y = Screen.height;
					}
					positionVec.y = LDC_UnclampedLerp(positionVec.y, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushDown)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, Screen.height, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					if (positionVec.y > 0f)
					{
						positionVec.y = 0f - originalHeight;
					}
					positionVec.y = LDC_UnclampedLerp(positionVec.y, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.InAndOutFromLeft)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, (float)(-Screen.width) * matrixScreenWidener, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.InAndOutFromRight)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, (float)Screen.width * matrixScreenWidener, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					positionVec.x = LDC_UnclampedLerp(positionVec.x, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.InAndOutFromTop)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, -Screen.height, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, 0f, DialogUI.dui.fade);
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.InAndOutFromBottom)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, Screen.height, 1f - DialogUI.dui.fade);
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					positionVec.y = LDC_UnclampedLerp(positionVec.y, 0f, DialogUI.dui.fade);
				}
			}
		}

		public void ResetTransitionMovement()
		{
			positionVec = Vector3.zero;
			if (transitionEffect == DUI_TransitionEffects.PushLeft || transitionEffect == DUI_TransitionEffects.InAndOutFromLeft)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = 0f;
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					positionVec.x = (float)(-Screen.width) * matrixScreenWidener;
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushRight || transitionEffect == DUI_TransitionEffects.InAndOutFromRight)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.y = 0f;
					positionVec.x = 0f;
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.y = 0f;
					positionVec.x = (float)Screen.width * matrixScreenWidener;
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushUp || transitionEffect == DUI_TransitionEffects.InAndOutFromTop)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = 0f;
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					positionVec.y = -Screen.height;
				}
			}
			else if (transitionEffect == DUI_TransitionEffects.PushDown || transitionEffect == DUI_TransitionEffects.InAndOutFromBottom)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					positionVec.x = 0f;
					positionVec.y = 0f;
				}
				else if (DialogUI.status == DUISTATUS.SHOW)
				{
					positionVec.x = 0f;
					positionVec.y = Screen.height;
				}
			}
		}

		public void FixedUpdate()
		{
			if (DialogUI.portraitAnimation != null)
			{
				DoDialogCastAnimationUpdate(DialogUI.portraitAnimation);
			}
			if (DialogUI.dui.displayBackgroundLayers && DialogUI.dui.bgLayers.Length != 0)
			{
				DialogUIBackgroundLayers[] bgLayers = DialogUI.dui.bgLayers;
				foreach (DialogUIBackgroundLayers dialogUIBackgroundLayers in bgLayers)
				{
					if (dialogUIBackgroundLayers.anim != null)
					{
						DoDialogCastAnimationUpdate(dialogUIBackgroundLayers.anim);
					}
					if (dialogUIBackgroundLayers.display == DUI_LAYER_STATUS.FadeIn)
					{
						if (dialogUIBackgroundLayers.opacity < 1f)
						{
							dialogUIBackgroundLayers.opacity += Time.deltaTime / DialogUI.dui.options.fadeDuration;
							continue;
						}
						dialogUIBackgroundLayers.opacity = 1f;
						dialogUIBackgroundLayers.display = DUI_LAYER_STATUS.Show;
					}
					else if (dialogUIBackgroundLayers.display == DUI_LAYER_STATUS.FadeOut)
					{
						if (dialogUIBackgroundLayers.opacity > 0f)
						{
							dialogUIBackgroundLayers.opacity -= Time.deltaTime / DialogUI.dui.options.fadeDuration;
							continue;
						}
						dialogUIBackgroundLayers.opacity = 0f;
						dialogUIBackgroundLayers.display = DUI_LAYER_STATUS.Hide;
						dialogUIBackgroundLayers.tex = null;
					}
				}
			}
			if (DialogUI.dui.displayActorLayers && DialogUI.dui.bgActors.Length != 0)
			{
				fuIndex = 0;
				DialogUIActorLayers[] bgActors = DialogUI.dui.bgActors;
				foreach (DialogUIActorLayers dialogUIActorLayers in bgActors)
				{
					if (dialogUIActorLayers.anim != null)
					{
						DoDialogCastAnimationUpdate(dialogUIActorLayers.anim);
					}
					if (dialogUIActorLayers.display == DUI_LAYER_STATUS.FadeIn)
					{
						if (dialogUIActorLayers.opacity < 1f)
						{
							dialogUIActorLayers.opacity += Time.deltaTime / DialogUI.dui.options.fadeDuration;
						}
						else
						{
							dialogUIActorLayers.opacity = 1f;
							dialogUIActorLayers.display = DUI_LAYER_STATUS.Show;
						}
					}
					else if (dialogUIActorLayers.display == DUI_LAYER_STATUS.FadeOut)
					{
						if (dialogUIActorLayers.opacity > 0f)
						{
							dialogUIActorLayers.opacity -= Time.deltaTime / DialogUI.dui.options.fadeDuration;
						}
						else
						{
							dialogUIActorLayers.opacity = 0f;
							dialogUIActorLayers.display = DUI_LAYER_STATUS.Hide;
							dialogUIActorLayers.tex = null;
						}
					}
					if (dialogUIActorLayers.motion == DUI_ACTOR_MOTION.Static || dialogUIActorLayers.display == DUI_LAYER_STATUS.Show)
					{
						dialogUIActorLayers.motionRect = dialogUIActorLayers.rect;
					}
					else
					{
						dialogUIActorLayers.motionRect = CalculateMotionRect(dialogUIActorLayers.rect, dialogUIActorLayers.motion, dialogUIActorLayers.opacity);
					}
					if (useHD)
					{
						Rect motionRect = DialogUI.dui.bgActors[fuIndex].motionRect;
						motionRect.x = DialogUI.dui.bgActors[fuIndex].motionRect.x * 2f;
						DialogUI.dui.bgActors[fuIndex].motionRect = motionRect;
						Rect motionRect2 = DialogUI.dui.bgActors[fuIndex].motionRect;
						motionRect2.y = DialogUI.dui.bgActors[fuIndex].motionRect.y * 2f;
						DialogUI.dui.bgActors[fuIndex].motionRect = motionRect2;
						Rect motionRect3 = DialogUI.dui.bgActors[fuIndex].motionRect;
						motionRect3.width = DialogUI.dui.bgActors[fuIndex].motionRect.width * 2f;
						DialogUI.dui.bgActors[fuIndex].motionRect = motionRect3;
						Rect motionRect4 = DialogUI.dui.bgActors[fuIndex].motionRect;
						motionRect4.height = DialogUI.dui.bgActors[fuIndex].motionRect.height * 2f;
						DialogUI.dui.bgActors[fuIndex].motionRect = motionRect4;
					}
					fuIndex++;
				}
			}
			if (DialogUI.buttonIcon1Animation != null)
			{
				DoDialogCastAnimationUpdate(DialogUI.buttonIcon1Animation);
			}
			if (DialogUI.buttonIcon2Animation != null)
			{
				DoDialogCastAnimationUpdate(DialogUI.buttonIcon2Animation);
			}
			if (DialogUI.multipleButtonsIconAnimation != null && DialogUI.multipleButtonsIconAnimation.Length != 0)
			{
				DialogCastActor[] multipleButtonsIconAnimation = DialogUI.multipleButtonsIconAnimation;
				foreach (DialogCastActor dialogCastActor in multipleButtonsIconAnimation)
				{
					if (dialogCastActor != null)
					{
						DoDialogCastAnimationUpdate(dialogCastActor);
					}
				}
			}
			if (DialogUI.popupImageAnimation != null)
			{
				DoDialogCastAnimationUpdate(DialogUI.popupImageAnimation);
			}
			if (DialogUI.IG_buttons == null || DialogUI.IG_buttons.Length == 0)
			{
				return;
			}
			IconGridButtons[] iG_buttons = DialogUI.IG_buttons;
			for (int i = 0; i < iG_buttons.Length; i++)
			{
				if (iG_buttons[i] != null && IconGridButtons.dca != null)
				{
					DoDialogCastAnimationUpdate(IconGridButtons.dca);
				}
			}
		}

		public Rect CalculateMotionRect(Rect theRect, DUI_ACTOR_MOTION motion, float fade)
		{
			switch (motion)
			{
			case DUI_ACTOR_MOTION.Left:
				theRect.x = theRect.x - 256f + 256f * fade;
				break;
			case DUI_ACTOR_MOTION.Right:
				theRect.x = theRect.x + 256f - 256f * fade;
				break;
			case DUI_ACTOR_MOTION.Top:
				theRect.y = theRect.y - 256f + 256f * fade;
				break;
			case DUI_ACTOR_MOTION.Bottom:
				theRect.y = theRect.y + 256f - 256f * fade;
				break;
			}
			return theRect;
		}

		public void DoBackgroundUI()
		{
			if (useHD)
			{
				fullScreenRect = new Rect(0f, 0f, 1920f, 1280f);
			}
			if (!DialogUI.dui.displayBackgroundLayers || DialogUI.dui.bgLayers.Length == 0)
			{
				return;
			}
			DialogUIBackgroundLayers[] bgLayers = DialogUI.dui.bgLayers;
			foreach (DialogUIBackgroundLayers dialogUIBackgroundLayers in bgLayers)
			{
				if (dialogUIBackgroundLayers.display != DUI_LAYER_STATUS.Hide)
				{
					Color color = GUI.color;
					color.a = dialogUIBackgroundLayers.opacity;
					GUI.color = color;
				}
				if (dialogUIBackgroundLayers.anim != null && dialogUIBackgroundLayers.tex != null)
				{
					GUI.DrawTexture(fullScreenRect, DoDialogCastAnimation(dialogUIBackgroundLayers.anim, dialogUIBackgroundLayers.tex), dialogUIBackgroundLayers.scale, alphaBlend: true);
				}
				else if (dialogUIBackgroundLayers.tex != null)
				{
					GUI.DrawTexture(fullScreenRect, dialogUIBackgroundLayers.tex, dialogUIBackgroundLayers.scale, alphaBlend: true);
				}
			}
		}

		public void DoActorUI()
		{
			if (!DialogUI.dui.displayActorLayers || DialogUI.dui.bgActors.Length == 0)
			{
				return;
			}
			DialogUIActorLayers[] bgActors = DialogUI.dui.bgActors;
			foreach (DialogUIActorLayers dialogUIActorLayers in bgActors)
			{
				if (dialogUIActorLayers.display != DUI_LAYER_STATUS.Hide)
				{
					Color color = GUI.color;
					color.a = dialogUIActorLayers.opacity;
					GUI.color = color;
				}
				if (dialogUIActorLayers.anim != null && dialogUIActorLayers.tex != null)
				{
					GUI.DrawTexture(dialogUIActorLayers.motionRect, DoDialogCastAnimation(dialogUIActorLayers.anim, dialogUIActorLayers.tex), dialogUIActorLayers.scale, alphaBlend: true);
				}
				else if (dialogUIActorLayers.tex != null)
				{
					GUI.DrawTexture(dialogUIActorLayers.motionRect, dialogUIActorLayers.tex, dialogUIActorLayers.scale, alphaBlend: true);
				}
			}
		}

		public void UpdateForceFocusButton()
		{
			if (skin != null)
			{
				skins.originalFocusButton = new GUIStyle(skin.button);
				skins.forceFocusButton = new GUIStyle(skin.button);
				skins.forceFocusButton.normal.background = skin.button.focused.background;
				skins.forceFocusButton.normal.textColor = skin.button.focused.textColor;
				skins.forceFocusButton.hover.background = skin.button.focused.background;
				skins.forceFocusButton.hover.textColor = skin.button.focused.textColor;
				skins.forceFocusButton.active.background = skin.button.focused.background;
				skins.forceFocusButton.active.textColor = skin.button.focused.textColor;
			}
		}

		public void SetupGUIMatrix()
		{
			if (useHD)
			{
				originalWidth = 1920f;
				originalHeight = 1280f;
			}
			else
			{
				originalWidth = 960f;
				originalHeight = 640f;
			}
			if (scalingMethod == OnGuiScaleMode.StretchToFill)
			{
				scale.x = (float)Screen.width / originalWidth;
				scale.y = (float)Screen.height / originalHeight;
				scale.z = 1f;
				svMat = GUI.matrix;
				fitScaleOffset = Vector3.zero;
				MatrixEffects();
				GUI.matrix = Matrix4x4.TRS(fitScaleOffset, Quaternion.identity, scale);
			}
			else if (scalingMethod == OnGuiScaleMode.ScaleToFit)
			{
				fitScale = Mathf.Min((float)Screen.width / originalWidth, (float)Screen.height / originalHeight);
				scale.x = originalWidth * fitScale / originalWidth;
				scale.y = originalHeight * fitScale / originalHeight;
				scale.z = 1f;
				svMat = GUI.matrix;
				fitScaleOffset.x = (float)Screen.width - originalWidth * fitScale;
				fitScaleOffset.y = (float)Screen.height - originalHeight * fitScale;
				fitScaleOffset.z = 0f;
				if (scalingAnchor == OnGuiScaleAnchor.Center)
				{
					fitScaleOffset.x *= 0.5f;
					fitScaleOffset.y *= 0.5f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.Left)
				{
					fitScaleOffset.x *= 0f;
					fitScaleOffset.y *= 0.5f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.Right)
				{
					fitScaleOffset.x *= 1f;
					fitScaleOffset.y *= 0.5f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.Top)
				{
					fitScaleOffset.x *= 0.5f;
					fitScaleOffset.y *= 0f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.Bottom)
				{
					fitScaleOffset.x *= 0.5f;
					fitScaleOffset.y *= 1f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.TopLeft)
				{
					fitScaleOffset.x *= 0f;
					fitScaleOffset.y *= 0f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.TopRight)
				{
					fitScaleOffset.x *= 1f;
					fitScaleOffset.y *= 0f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.BottomLeft)
				{
					fitScaleOffset.x *= 0f;
					fitScaleOffset.y *= 1f;
				}
				else if (scalingAnchor == OnGuiScaleAnchor.BottomRight)
				{
					fitScaleOffset.x *= 1f;
					fitScaleOffset.y *= 1f;
				}
				MatrixEffects();
				GUI.matrix = Matrix4x4.TRS(fitScaleOffset, Quaternion.identity, scale);
			}
			else if (scalingMethod == OnGuiScaleMode.OverScale)
			{
				fitScale = Mathf.Max((float)Screen.width / originalWidth, (float)Screen.height / originalHeight);
				scale.x = originalWidth * fitScale / originalWidth;
				scale.y = originalHeight * fitScale / originalHeight;
				scale.z = 1f;
				svMat = GUI.matrix;
				fitScaleOffset.x = (float)Screen.width - originalWidth * fitScale;
				fitScaleOffset.y = (float)Screen.height - originalHeight * fitScale;
				fitScaleOffset.z = 0f;
				MatrixEffects();
				GUI.matrix = Matrix4x4.TRS(fitScaleOffset, Quaternion.identity, scale);
			}
			DoMatrixRotation();
			lastUsedMatrix = GUI.matrix;
		}

		public void MatrixEffects()
		{
			if (transitionEffect == DUI_TransitionEffects.BarnDoors || transitionEffect == DUI_TransitionEffects.Eyelids || transitionEffect == DUI_TransitionEffects.Popup || transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.ZoomHorizontal || transitionEffect == DUI_TransitionEffects.ZoomVertical || transitionEffect == DUI_TransitionEffects.Spin || transitionEffect == DUI_TransitionEffects.SpinPopup || transitionEffect == DUI_TransitionEffects.SpinZoom)
			{
				if (DialogUI.dui.fade <= 0f)
				{
					if (transitionEffect == DUI_TransitionEffects.BarnDoors || transitionEffect == DUI_TransitionEffects.Popup || transitionEffect == DUI_TransitionEffects.SpinPopup)
					{
						fitScaleOffset.x = 0f;
						scale.x = 1E-07f;
					}
					if (transitionEffect == DUI_TransitionEffects.Eyelids || transitionEffect == DUI_TransitionEffects.Popup || transitionEffect == DUI_TransitionEffects.SpinPopup)
					{
						fitScaleOffset.y = 0f;
						scale.y = 1E-07f;
					}
					if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomHorizontal || transitionEffect == DUI_TransitionEffects.ZoomVertical)
					{
						if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomHorizontal)
						{
							fitScaleOffset.x -= (float)Screen.width * 0.5f - (float)Screen.width * 0.5f * 1E-07f;
							scale.x = scale.x * 2f - scale.x * 1E-07f;
						}
						if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomVertical)
						{
							fitScaleOffset.y -= (float)Screen.height * 0.5f - (float)Screen.height * 0.5f * 1E-07f;
							scale.y = scale.y * 2f - scale.y * 1E-07f;
						}
					}
				}
				else if (DialogUI.dui.fade > 0f && DialogUI.dui.fade < 1f)
				{
					if (transitionEffect == DUI_TransitionEffects.BarnDoors || transitionEffect == DUI_TransitionEffects.Popup || transitionEffect == DUI_TransitionEffects.SpinPopup)
					{
						fitScaleOffset.x += (float)Screen.width * 0.5f - (float)Screen.width * 0.5f * DialogUI.dui.fade;
						scale.x *= DialogUI.dui.fade;
					}
					if (transitionEffect == DUI_TransitionEffects.Eyelids || transitionEffect == DUI_TransitionEffects.Popup || transitionEffect == DUI_TransitionEffects.SpinPopup)
					{
						fitScaleOffset.y += (float)Screen.height * 0.5f - (float)Screen.height * 0.5f * DialogUI.dui.fade;
						scale.y *= DialogUI.dui.fade;
					}
					if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomHorizontal || transitionEffect == DUI_TransitionEffects.ZoomVertical)
					{
						if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomHorizontal)
						{
							fitScaleOffset.x -= (float)Screen.width * 0.5f - (float)Screen.width * 0.5f * DialogUI.dui.fade;
							scale.x = scale.x * 2f - scale.x * DialogUI.dui.fade;
						}
						if (transitionEffect == DUI_TransitionEffects.Zoom || transitionEffect == DUI_TransitionEffects.SpinZoom || transitionEffect == DUI_TransitionEffects.ZoomVertical)
						{
							fitScaleOffset.y -= (float)Screen.height * 0.5f - (float)Screen.height * 0.5f * DialogUI.dui.fade;
							scale.y = scale.y * 2f - scale.y * DialogUI.dui.fade;
						}
					}
				}
			}
			fitScaleOffset += positionVec;
		}

		public void DoMatrixRotation()
		{
			if (transitionEffect == DUI_TransitionEffects.Spin || transitionEffect == DUI_TransitionEffects.SpinPopup || transitionEffect == DUI_TransitionEffects.SpinZoom)
			{
				if (DialogUI.status == DUISTATUS.FADEOUT)
				{
					transitionMatrixRotationAngle = 360 * Mathf.Clamp((int)(1f - DialogUI.dui.fade), 0, 1);
				}
				else
				{
					transitionMatrixRotationAngle = 360 * Mathf.Clamp((int)DialogUI.dui.fade, 0, 1);
				}
				GUIUtility.RotateAroundPivot(transitionMatrixRotationAngle, new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
			}
		}

		public void EndGUIMatrix()
		{
			GUI.matrix = svMat;
			GUI.color = Color.white;
		}

		public void OnGUI()
		{
			if (_usingRenderTextures)
			{
				StartRenderTextures();
			}
			guiDeltaTime = Time.realtimeSinceStartup - lastTime;
			lastTime = Time.realtimeSinceStartup;
			GUI.depth = depth;
			if (DialogUI.dui.alpha > 0f)
			{
				SetupGUIMatrix();
				DoBackgroundUI();
				DoActorUI();
				DoDialogUI();
				DoFocusControl();
				EndGUIMatrix();
				if (!_usingRenderTextures && newUICam != null && Event.current.type == EventType.Repaint)
				{
					newUICam.Render();
				}
			}
			if (_usingRenderTextures)
			{
				EndRenderTextures();
			}
		}

		private void StartRenderTextures()
		{
			if (!_guiRenderTextureCreated || _guiRecreateRenderTextureNow)
			{
				_guiRenderTexture = new RenderTexture(Screen.width, Screen.height, 24);
				_guiRenderTextureCreated = true;
				_guiRecreateRenderTextureNow = false;
				if (renderToMaterial != null)
				{
					renderToMaterial.mainTexture = _guiRenderTexture;
				}
				else
				{
					Debug.LogError("LDC ERROR: A GUI Rendering Material has not been assigned in the DialogOnGUI component! This is required for Material rendering.");
				}
			}
			if (DialogWorldSpaceGUI.SimulatedMouseIsWithinScreen() && (Event.current.isMouse || Event.current.type == EventType.ScrollWheel))
			{
				Event.current.Use();
				return;
			}
			if (DialogUI.dialogStyle == DIALOGSTYLE.IconGrid && DialogWorldSpaceGUI.com.inputMode != 0)
			{
				_srtScrollDelta = DialogWorldSpaceGUI.GetInputScrollDelta();
				_srtScrollDelta.y *= -1f;
				DialogUI.scrollPosition += _srtScrollDelta;
			}
			_tempRenderTexture = RenderTexture.active;
			if (Event.current.type == EventType.Repaint)
			{
				RenderTexture.active = _guiRenderTexture;
				GL.Clear(clearDepth: false, clearColor: true, clearRenderTextureColor);
			}
		}

		private void EndRenderTextures()
		{
			if (Event.current.type == EventType.Repaint)
			{
				RenderTexture.active = _tempRenderTexture;
			}
		}

		private void SetGUIColorAlpha(float alpha)
		{
			_tempColor = GUI.color;
			_tempColor.a = alpha;
			GUI.color = _tempColor;
		}

		public void CheckPasswordVR()
		{
			CheckDataEntryVR();
		}

		public void CheckDataEntryVR()
		{
			if (_usingRenderTextures && DialogWorldSpaceGUI.com.useScreenKeyboardForDataEntry && DialogUI.buttonNames.Length <= 2)
			{
				_inputCharacterShiftDown = false;
				DialogUI.buttonNames = ConcatArrays<string>(new string[1] { "Submit" }, inputCharactersRow1, inputCharactersRow2, inputCharactersRow3, inputCharactersRow4, inputCharacterOptions);
				DialogUI.buttons = new bool[DialogUI.buttonNames.Length];
			}
		}

		private void DoDataEntryVR()
		{
			GUI.color = Color.white;
			if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
			{
				SetGUIColorAlpha(DialogUI.dui.fade);
			}
			else
			{
				SetGUIColorAlpha(1f);
			}
			dataEntryBorderRect = default(Rect);
			if (!useHD)
			{
				dataEntryBorderRect = new Rect(80f, 5f, 800f, 564f);
			}
			else
			{
				dataEntryBorderRect = new Rect(160f, 10f, 1600f, 1128f);
			}
			dataEntryTitleRect = dataEntryBorderRect;
			if (!useHD)
			{
				dataEntryTitleRect.y += 10f;
			}
			else
			{
				dataEntryTitleRect.y += 20f;
			}
			dataEntryTitleRectShadow = dataEntryTitleRect;
			if (!useHD)
			{
				dataEntryTitleRect.x += 1f;
				dataEntryTitleRect.x += 1f;
			}
			else
			{
				dataEntryTitleRect.y += 2f;
				dataEntryTitleRect.y += 2f;
			}
			GUI.Box(dataEntryBorderRect, string.Empty, skin.customStyles[3]);
			DoStyleAndShadow(dataEntryTitleRect, dataEntryTitleRectShadow, skin.customStyles[4], DialogUI.actorName, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
			textFieldRect = dataEntryBorderRect;
			if (!useHD)
			{
				textFieldRect.width -= 20f;
				textFieldRect.x += 10f;
				textFieldRect.y += 60f;
				textFieldRect.width -= 138f;
				textFieldRect.height = 48f;
			}
			else
			{
				textFieldRect.width -= 40f;
				textFieldRect.x += 20f;
				textFieldRect.y += 120f;
				textFieldRect.width -= 276f;
				textFieldRect.height = 96f;
			}
			dataEntryButton = textFieldRect;
			if (!useHD)
			{
				dataEntryButton.width = 128f;
				dataEntryButton.x += textFieldRect.width + 10f;
			}
			else
			{
				dataEntryButton.width = 256f;
				dataEntryButton.x += textFieldRect.width + 20f;
			}
			if (DialogUI.dataEntryString == null)
			{
				return;
			}
			GUI.Label(textFieldRect, DialogUI.dataEntryString, skin.customStyles[5]);
			DialogUI.dataEntryString = DialogUI.dataEntryString.Replace("\n", string.Empty);
			floatRef destination = new floatRef();
			if (DialogUI.dataEntryFormat == DS_DATA_FORMAT.Number && !DialogUI.ParseTokenAsFloat(DialogUI.dataEntryString, destination))
			{
				if (DialogUI.dataEntryDefaultValue != string.Empty)
				{
					DialogUI.dataEntryString = DialogUI.dataEntryDefaultValue;
				}
				else
				{
					DialogUI.dataEntryString = "0";
				}
			}
			if (DialogUI.dataEntryString.Length > DialogUI.dataEntryCharacterLimit)
			{
				DialogUI.dataEntryString = DialogUI.dataEntryString.Substring(0, DialogUI.dataEntryString.Length);
			}
			GUI.SetNextControlName(DialogUI.buttonNames[0]);
			dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
			if (LDC_GUIButton(dataEntryButton, dynamicGUIContent, 0) || DialogUI.buttons[0])
			{
				if (DialogUI.dui.tokens.Length != 0 && DialogUI.dataEntryToken < DialogUI.dui.tokens.Length)
				{
					DialogUI.dui.tokens[DialogUI.dataEntryToken].value = DialogUI.dataEntryString;
				}
				else
				{
					Debug.Log("LDC: (DialogUI) Couldn't set Token (with ID: " + DialogUI.dataEntryToken + " ) from Data Entry DialogUI.screen because the token could not be found.");
				}
				if (DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.screen.Skip();
				}
			}
			if (!useHD)
			{
				_dataEntryCharButtonRect = new Rect(0f, dataEntryBorderRect.y, 80f, 80f);
				_dataEntryCharButtonRect.y += 160f;
			}
			else
			{
				_dataEntryCharButtonRect = new Rect(0f, dataEntryBorderRect.y, 160f, 160f);
				_dataEntryCharButtonRect.y += 320f;
			}
			DoDataEntryKeyboard(DialogUI.dataEntryCharacterLimit);
		}

		private void DoPasswordVR()
		{
			GUI.color = Color.white;
			if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
			{
				SetGUIColorAlpha(DialogUI.dui.fade);
			}
			else
			{
				SetGUIColorAlpha(1f);
			}
			passwordBorderRect = default(Rect);
			if (!useHD)
			{
				passwordBorderRect = new Rect(80f, 5f, 800f, 564f);
			}
			else
			{
				passwordBorderRect = new Rect(160f, 10f, 1600f, 1128f);
			}
			passwordTitleRect = passwordBorderRect;
			if (!useHD)
			{
				passwordTitleRect.y += 10f;
			}
			else
			{
				passwordTitleRect.y += 20f;
			}
			passwordTitleRectShadow = passwordTitleRect;
			if (!useHD)
			{
				passwordTitleRect.x += 1f;
				passwordTitleRect.x += 1f;
			}
			else
			{
				passwordTitleRect.y += 2f;
				passwordTitleRect.y += 2f;
			}
			GUI.Box(passwordBorderRect, string.Empty, skin.customStyles[3]);
			DoStyleAndShadow(passwordTitleRect, passwordTitleRectShadow, skin.customStyles[4], DialogUI.actorName, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
			textFieldRect = passwordBorderRect;
			if (!useHD)
			{
				textFieldRect.width -= 20f;
				textFieldRect.x += 10f;
				textFieldRect.y += 60f;
				textFieldRect.width -= 138f;
				textFieldRect.height = 48f;
			}
			else
			{
				textFieldRect.width -= 40f;
				textFieldRect.x += 20f;
				textFieldRect.y += 120f;
				textFieldRect.width -= 276f;
				textFieldRect.height = 96f;
			}
			passwordButton = textFieldRect;
			if (!useHD)
			{
				passwordButton.width = 128f;
				passwordButton.x += textFieldRect.width + 10f;
			}
			else
			{
				passwordButton.width = 256f;
				passwordButton.x += textFieldRect.width + 20f;
			}
			if (DialogUI.dataEntryString == null)
			{
				return;
			}
			_visibleDataEntryString = DialogUI.dataEntryString;
			if (DialogUI.passwordMask)
			{
				_visibleDataEntryString = string.Empty;
				for (int i = 0; i < DialogUI.dataEntryString.Length; i++)
				{
					_visibleDataEntryString += "*";
				}
			}
			GUI.Label(textFieldRect, _visibleDataEntryString, skin.customStyles[5]);
			DialogUI.dataEntryString = DialogUI.dataEntryString.Replace("\n", string.Empty);
			if (DialogUI.dataEntryString.Length > 255)
			{
				DialogUI.dataEntryString = DialogUI.dataEntryString.Substring(0, 255);
			}
			GUI.SetNextControlName(DialogUI.buttonNames[0]);
			dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
			if ((LDC_GUIButton(passwordButton, dynamicGUIContent, 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
			{
				if (DialogUI.passwordMatchToToken && DialogUI.dui.tokens.Length != 0 && DialogUI.dataEntryToken < DialogUI.dui.tokens.Length)
				{
					if (DialogUI.dui.tokens[DialogUI.dataEntryToken].value == DialogUI.dataEntryString || (!DialogUI.passwordCaseSensitive && DialogUI.dui.tokens[DialogUI.dataEntryToken].value.ToLower() == DialogUI.dataEntryString.ToLower()))
					{
						if (DialogUI.dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("LDC: (DialogUI) The Token Matches - Password Match Successful");
						}
						DialogUI.screen.Yes();
					}
					else
					{
						if (DialogUI.dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("LDC: (DialogUI) The Token does NOT match - Password Match Failed");
						}
						DialogUI.screen.No();
					}
				}
				else if (!DialogUI.passwordMatchToToken)
				{
					if (DialogUI.dataEntryString == DialogUI.passwordAnswer || (!DialogUI.passwordCaseSensitive && DialogUI.dataEntryString.ToLower() == DialogUI.passwordAnswer.ToLower()))
					{
						if (DialogUI.dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("LDC: (DialogUI) The String Matches - Password Match Successful");
						}
						DialogUI.screen.Yes();
					}
					else
					{
						if (DialogUI.dui.options.debugLogicMessagesInConsole)
						{
							Debug.Log("LDC: (DialogUI) The String does NOT match - Password Match Failed");
						}
						DialogUI.screen.No();
					}
				}
				else
				{
					Debug.Log("LDC: (DialogUI) Password Screen Error - This token is probably not setup correctly. Will default as a password failure.");
					DialogUI.screen.No();
				}
			}
			if (!useHD)
			{
				_dataEntryCharButtonRect = new Rect(0f, passwordBorderRect.y, 80f, 80f);
				_dataEntryCharButtonRect.y += 160f;
			}
			else
			{
				_dataEntryCharButtonRect = new Rect(0f, passwordBorderRect.y, 160f, 160f);
				_dataEntryCharButtonRect.y += 320f;
			}
			DoDataEntryKeyboard(255);
		}

		private void DoDataEntryKeyboard(int maxCharacters)
		{
			for (int i = 1; i < DialogUI.buttonNames.Length; i++)
			{
				if (!useHD)
				{
					_dataEntryCharButtonRect.x += 80f;
				}
				else
				{
					_dataEntryCharButtonRect.x += 160f;
				}
				GUI.SetNextControlName(DialogUI.buttonNames[i]);
				dynamicGUIContent.text = DialogUI.buttonNames[i];
				dynamicGUIContent.image = null;
				dynamicGUIContent.tooltip = DialogUI.buttonNames[i];
				if ((LDC_GUIButton(_dataEntryCharButtonRect, dynamicGUIContent, i) || DialogUI.buttons[i]) && DialogUI.dui.fade >= 1f)
				{
					DialogUI.buttons[i] = false;
					if (DialogUI.buttonNames[i] == "Shift")
					{
						if (_inputCharacterShiftDown)
						{
							DialogUI.buttonNames = ConcatArrays<string>(new string[1] { "Submit" }, inputCharactersRow1, inputCharactersRow2, inputCharactersRow3, inputCharactersRow4, inputCharacterOptions);
							_inputCharacterShiftDown = false;
						}
						else
						{
							DialogUI.buttonNames = ConcatArrays<string>(new string[1] { "Submit" }, inputCharactersRow1, inputCharactersRow2Shift, inputCharactersRow3Shift, inputCharactersRow4Shift, inputCharacterOptions);
							_inputCharacterShiftDown = true;
						}
						DialogUI.buttons = new bool[DialogUI.buttonNames.Length];
					}
					else if (DialogUI.buttonNames[i] == "Delete")
					{
						if (DialogUI.dataEntryString.Length > 0)
						{
							DialogUI.dataEntryString = DialogUI.dataEntryString.Substring(0, DialogUI.dataEntryString.Length - 1);
						}
					}
					else if (DialogUI.buttonNames[i] == "Space")
					{
						DialogUI.dataEntryString += " ";
						if (DialogUI.dataEntryString.Length > maxCharacters)
						{
							DialogUI.dataEntryString = DialogUI.dataEntryString.Substring(0, maxCharacters);
						}
					}
					else
					{
						DialogUI.dataEntryString += DialogUI.buttonNames[i];
						if (DialogUI.dataEntryString.Length > maxCharacters)
						{
							DialogUI.dataEntryString = DialogUI.dataEntryString.Substring(0, maxCharacters);
						}
					}
				}
				switch (i)
				{
				case 10:
				case 20:
				case 30:
					if (!useHD)
					{
						_dataEntryCharButtonRect.y += 80f;
						_dataEntryCharButtonRect.x = 0f;
					}
					else
					{
						_dataEntryCharButtonRect.y += 160f;
						_dataEntryCharButtonRect.x = 0f;
					}
					break;
				case 40:
					if (!useHD)
					{
						_dataEntryCharButtonRect.y += 80f;
						_dataEntryCharButtonRect.x = 0f;
						_dataEntryCharButtonRect.width = 160f;
					}
					else
					{
						_dataEntryCharButtonRect.y += 160f;
						_dataEntryCharButtonRect.x = 0f;
						_dataEntryCharButtonRect.width = 320f;
					}
					break;
				case 41:
					if (!useHD)
					{
						_dataEntryCharButtonRect.x += 80f;
						_dataEntryCharButtonRect.width = 480f;
					}
					else
					{
						_dataEntryCharButtonRect.x += 160f;
						_dataEntryCharButtonRect.width = 960f;
					}
					break;
				case 42:
					if (!useHD)
					{
						_dataEntryCharButtonRect.x += 400f;
						_dataEntryCharButtonRect.width = 160f;
					}
					else
					{
						_dataEntryCharButtonRect.x += 800f;
						_dataEntryCharButtonRect.width = 320f;
					}
					break;
				}
			}
		}

		public T[] ConcatArrays<T>(params T[][] list)
		{
			T[] array = new T[Enumerable.Sum(list, (T[] a) => a.Length)];
			int num = 0;
			for (int i = 0; i < list.Length; i++)
			{
				list[i].CopyTo(array, num);
				num += list[i].Length;
			}
			return array;
		}

		public void DoFocusControl()
		{
			if (DialogUI.dui.options.selectGuiWithTheseKeycodes.Length > 1 && (DialogUI.dui.options.focusNextGuiWithTheseKeycodes.Length != 0 || DialogUI.dui.options.focusPreviousGuiWithTheseKeycodes.Length != 0) && DialogUI.currentSelection >= 0)
			{
				GUI.FocusControl(DialogUI.buttonNames[DialogUI.currentSelection]);
				usingFocusControl = true;
			}
			else
			{
				usingFocusControl = false;
			}
		}

		public void DoButtonFocus()
		{
			if (_usingRenderTextures && (DialogWorldSpaceGUI.com.inputMode == DialogWorldSpaceGUI.InputMode.Transform || DialogWorldSpaceGUI.com.inputMode == DialogWorldSpaceGUI.InputMode.Disabled))
			{
				DialogUI.currentSelection = -1;
			}
			else
			{
				if (DialogUI.ended || DialogUI.buttonNames.Length == 0 || ((!_usingRenderTextures || !DialogWorldSpaceGUI.com.useScreenKeyboardForDataEntry) && (DialogUI.dialogStyle == DIALOGSTYLE.Password || DialogUI.dialogStyle == DIALOGSTYLE.DataEntry)))
				{
					return;
				}
				if (DialogUI.buttonNames.Length > 1)
				{
					if (InputKeyWasPressed(DialogUI.dui.options.focusNextGuiWithTheseKeycodes))
					{
						DialogUI.currentSelection++;
						DialogUI.PlayFocusAudio();
						FocusUpdateScrollViews();
					}
					else if (InputKeyWasPressed(DialogUI.dui.options.focusPreviousGuiWithTheseKeycodes))
					{
						DialogUI.currentSelection--;
						DialogUI.PlayFocusAudio();
						FocusUpdateScrollViews();
					}
					else if (!inputKeyBlocker && DialogUI.dui.options.focusGuiWithTheseAxes != null && DialogUI.dui.options.focusGuiWithTheseAxes.Length != 0)
					{
						for (int i = 0; i < DialogUI.dui.options.focusGuiWithTheseAxes.Length; i++)
						{
							if (DialogUI.dui.options.focusGuiWithTheseAxes[i] != null)
							{
								float num = 1f;
								if (DialogUI.dui.options.focusGuiWithTheseAxes[i].invert)
								{
									num = -1f;
								}
								if (Input.GetAxis(DialogUI.dui.options.focusGuiWithTheseAxes[i].axis) * num < -0.5f)
								{
									DialogUI.currentSelection--;
									DialogUI.PlayFocusAudio();
									FocusUpdateScrollViews();
									StopCoroutine("TempBlockInputKeys");
									StartCoroutine("TempBlockInputKeys", 0.15f);
									break;
								}
								if (Input.GetAxis(DialogUI.dui.options.focusGuiWithTheseAxes[i].axis) * num > 0.5f)
								{
									DialogUI.currentSelection++;
									DialogUI.PlayFocusAudio();
									FocusUpdateScrollViews();
									StopCoroutine("TempBlockInputKeys");
									StartCoroutine("TempBlockInputKeys", 0.15f);
									break;
								}
							}
						}
					}
				}
				if (DialogUI.currentSelection < 0)
				{
					DialogUI.currentSelection = DialogUI.buttonNames.Length - 1;
					FocusUpdateScrollViews();
				}
				else if (DialogUI.currentSelection > DialogUI.buttonNames.Length - 1)
				{
					DialogUI.currentSelection = 0;
					FocusUpdateScrollViews();
				}
				if (_usingRenderTextures && DialogUI.currentSelection > 0 && !inputKeyBlocker && InputKeyWasPressed(DialogUI.dui.options.selectGuiWithTheseKeycodes) && (DialogUI.dialogStyle == DIALOGSTYLE.Password || DialogUI.dialogStyle == DIALOGSTYLE.DataEntry))
				{
					StopCoroutine("TempBlockInputKeys");
					StartCoroutine("TempBlockInputKeys", 0.1f);
					DialogUI.buttons[DialogUI.currentSelection] = true;
					DialogUI.PlayButonAudio();
				}
				else if (!inputKeyBlocker && InputKeyWasPressed(DialogUI.dui.options.selectGuiWithTheseKeycodes))
				{
					StopCoroutine("TempBlockInputKeys");
					StartCoroutine("TempBlockInputKeys", 1f);
					DialogUI.buttons[DialogUI.currentSelection] = true;
					DialogUI.PlayButonAudio();
				}
			}
		}

		public IEnumerator TempBlockInputKeys(float duration)
		{
			inputKeyBlocker = true;
			float counter = duration;
			while (counter > 0f)
			{
				counter -= Time.deltaTime;
				yield return null;
			}
			inputKeyBlocker = false;
		}

		public bool InputKeyWasPressed(KeyCode[] inputs)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				if (Input.GetKeyUp(inputs[i]))
				{
					return true;
				}
			}
			return false;
		}

		public void DoDialogUI()
		{
			if (skin != null)
			{
				GUI.skin = skin;
			}
			if (skin != null && skin.customStyles.Length >= 10 && skin.customStyles[9] != null)
			{
				buttonOffset = skin.customStyles[9].contentOffset;
			}
			if (!DialogUI.dui.options.hideBackgroundFromUI)
			{
				SetGUIColorAlpha(DialogUI.dui.alpha - DialogUI.dui.hideBackgroundSubtractor);
				if (!useHD)
				{
					bgRect = new Rect(0f, 481f, 960f, 160f);
					if (scalingMethod == OnGuiScaleMode.ScaleToFit && scaleToFitBackgroundWidener > 1f)
					{
						bgRect = new Rect(480f - 960f * scaleToFitBackgroundWidener * 0.5f, 481f, 960f * scaleToFitBackgroundWidener, 160f);
					}
				}
				else
				{
					bgRect = new Rect(0f, 962f, 1920f, 320f);
					if (scalingMethod == OnGuiScaleMode.ScaleToFit && scaleToFitBackgroundWidener > 1f)
					{
						bgRect = new Rect(960f - 1920f * scaleToFitBackgroundWidener * 0.5f, 962f, 1920f * scaleToFitBackgroundWidener, 320f);
					}
				}
				GUI.Label(bgRect, string.Empty, skin.customStyles[2]);
			}
			if (!DialogUI.dui.options.hideAllTextFromUI && DialogUI.dialogStyle != DIALOGSTYLE.MultipleButtons && DialogUI.dialogStyle != DIALOGSTYLE.DataEntry && DialogUI.dialogStyle != DIALOGSTYLE.Password && DialogUI.dialogStyle != DIALOGSTYLE.Title && DialogUI.dialogStyle != DIALOGSTYLE.Popup && DialogUI.dialogStyle != DIALOGSTYLE.IconGrid)
			{
				if (!useHD)
				{
					actorRect = new Rect(266f, 465f, 500f, 50f);
				}
				else
				{
					actorRect = new Rect(532f, 930f, 1000f, 100f);
				}
				if (DialogUI.dui.options.ResizeTextIfNoPortraitsAreSetup && DialogUI.portrait == null)
				{
					if (!useHD)
					{
						actorRect.x = 20f;
						actorRect.width += 246f;
					}
					else
					{
						actorRect.x = 40f;
						actorRect.width += 492f;
					}
				}
				actorRectShadow = actorRect;
				if (!useHD)
				{
					actorRectShadow.x += 1f;
					actorRectShadow.y += 1f;
				}
				else
				{
					actorRectShadow.x += 2f;
					actorRectShadow.y += 2f;
				}
				DoStyleAndShadow(actorRect, actorRectShadow, skin.customStyles[1], DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
				if (!DialogUI.dui.options.hideAllBodyTextFromUI)
				{
					if (!useHD)
					{
						dialogRect = new Rect(266f, 515f, 500f, 125f);
					}
					else
					{
						dialogRect = new Rect(532f, 1030f, 1000f, 250f);
					}
					if (DialogUI.dui.options.ResizeTextIfNoPortraitsAreSetup && DialogUI.portrait == null)
					{
						if (!useHD)
						{
							dialogRect.x = 20f;
							dialogRect.width += 246f;
						}
						else
						{
							dialogRect.x = 40f;
							dialogRect.width += 492f;
						}
					}
					dialogRectShadow = dialogRect;
					if (!useHD)
					{
						dialogRectShadow.x += 1f;
						dialogRectShadow.y += 1f;
					}
					else
					{
						dialogRectShadow.x += 2f;
						dialogRectShadow.y += 2f;
					}
					if (DialogUI.dialogStyle == DIALOGSTYLE.YesOrNo || DialogUI.dialogStyle == DIALOGSTYLE.TwoButtons)
					{
						if (!useHD)
						{
							dialogRect.width = 340f;
							dialogRectShadow.width = 340f;
						}
						else
						{
							dialogRect.width = 680f;
							dialogRectShadow.width = 680f;
						}
					}
					if (DialogUI.dui.options.drawBodyTextShadows)
					{
						GUI.color = Color.black;
						if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						GUI.Label(dialogRectShadow, DialogUI.ReplaceAllRichTextColorToNewColor(DialogUI.currentDialogText, new Color32(0, 0, 0, (byte)GUI.color.a)), skin.customStyles[0]);
					}
					if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.Off && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.Off)
					{
						GUI.color = Color.white;
						if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						GUI.Label(dialogRect, DialogUI.currentDialogText, skin.customStyles[0]);
					}
					else
					{
						originalVerticalScrollbar = GUI.skin.verticalScrollbar;
						if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
						{
							GUI.skin.verticalScrollbar = GUIStyle.none;
						}
						GUILayout.BeginArea(dialogRect);
						if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
						{
							DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingFixedValue, GUIStyle.none, GUILayout.Width(dialogRect.width), GUILayout.Height(dialogRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
							if (DialogUI.dialogStyle == DIALOGSTYLE.NextButton && DialogUI.dui.options.makeAutoscrollNextScreensManualOnTap && ((MatrixMouseContains(dialogRect) && Input.GetMouseButtonDown(0)) || MatrixTouchContains(dialogRect)))
							{
								DialogUI.scrollingOptions = DIALOG_OVERRIDE_SCROLLING.ManualScrollingWithVerticalBar;
							}
						}
						else
						{
							DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingValue, GUIStyle.none, GUILayout.Width(dialogRect.width), GUILayout.Height(dialogRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
						}
						if (DialogUI.dui.options.drawBodyTextShadows)
						{
							GUI.color = Color.black;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUILayout.Label(DialogUI.ReplaceAllRichTextColorToNewColor(DialogUI.currentDialogText, new Color32(0, 0, 0, (byte)GUI.color.a)), skin.customStyles[0]);
							theShadowScrollRect = GUILayoutUtility.GetLastRect();
							if (!useHD)
							{
								theShadowScrollRect.x -= 1f;
								theShadowScrollRect.y -= 1f;
							}
							else
							{
								theShadowScrollRect.x -= 2f;
								theShadowScrollRect.y -= 2f;
							}
							GUI.color = Color.white;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUI.Label(theShadowScrollRect, DialogUI.currentDialogText, skin.customStyles[0]);
						}
						else
						{
							GUI.color = Color.white;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUILayout.Label(DialogUI.currentDialogText, skin.customStyles[0]);
						}
						theAutoScrollRect = GUILayoutUtility.GetLastRect();
						DialogUI.dui.options.autoScrollingHeight = theAutoScrollRect.height - (dialogRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace);
						GUILayout.EndScrollView();
						GUILayout.EndArea();
						GUI.skin.verticalScrollbar = originalVerticalScrollbar;
					}
				}
			}
			if (DialogUI.dialogStyle == DIALOGSTYLE.NextButton)
			{
				if (!DialogUI.dui.options.hideAllSingleButtonsFromUI && !DialogUI.hideNextButton)
				{
					if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					if (DialogUI.dui.options.useButtonTransitions)
					{
						if (DialogUI.dui.fade >= 1f)
						{
							if (!useHD)
							{
								skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
							}
							else
							{
								skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
							}
						}
						else if (!useHD)
						{
							skipRect = new Rect(buttonOffset.x + 800f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							skipRect = new Rect(buttonOffset.x + 1600f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
					GUI.SetNextControlName(DialogUI.buttonNames[0]);
					if ((LDC_GUIButton(skipRect, DialogUI.dui.LocalizeNextButton(), 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
					{
						DialogUI.screen.Skip();
						DialogUI.buttons[0] = false;
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.YesOrNo)
			{
				if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (DialogUI.dui.options.useButtonTransitions)
				{
					if (DialogUI.dui.fade >= 1f)
					{
						if (!useHD)
						{
							yesRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							yesRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						yesRect = new Rect(buttonOffset.x + 800f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						yesRect = new Rect(buttonOffset.x + 1600f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
				}
				else if (!useHD)
				{
					yesRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
				}
				else
				{
					yesRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
				}
				GUI.SetNextControlName(DialogUI.buttonNames[0]);
				if ((LDC_GUIButton(yesRect, DialogUI.dui.LocalizeYesButton(), 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.buttons[0] = false;
					DialogUI.screen.Yes();
				}
				if (DialogUI.dui.options.useButtonTransitions)
				{
					if (DialogUI.dui.fade >= 1f)
					{
						if (!useHD)
						{
							noRect = new Rect(buttonOffset.x + 640f, buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							noRect = new Rect(buttonOffset.x + 1280f, buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						noRect = new Rect(buttonOffset.x + 640f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						noRect = new Rect(buttonOffset.x + 1280f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
				}
				else if (!useHD)
				{
					noRect = new Rect(buttonOffset.x + 640f, buttonOffset.y + 640f - 100f, 140f, 64f);
				}
				else
				{
					noRect = new Rect(buttonOffset.x + 1280f, buttonOffset.y + 1280f - 200f, 280f, 128f);
				}
				GUI.SetNextControlName(DialogUI.buttonNames[1]);
				if ((LDC_GUIButton(noRect, DialogUI.dui.LocalizeNoButton(), 1) || DialogUI.buttons[1]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.buttons[1] = false;
					DialogUI.screen.No();
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.OneButton)
			{
				if (!DialogUI.dui.options.hideAllSingleButtonsFromUI && !DialogUI.hideNextButton)
				{
					if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					if (DialogUI.dui.options.useButtonTransitions)
					{
						if (DialogUI.dui.fade >= 1f)
						{
							if (!useHD)
							{
								skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
							}
							else
							{
								skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
							}
						}
						else if (!useHD)
						{
							skipRect = new Rect(buttonOffset.x + 800f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							skipRect = new Rect(buttonOffset.x + 1600f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
					GUI.SetNextControlName(DialogUI.buttonNames[0]);
					dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
					if ((LDC_GUIButton(skipRect, dynamicGUIContent, 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
					{
						DialogUI.buttons[0] = false;
						DialogUI.screen.Skip();
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.TwoButtons)
			{
				if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (DialogUI.dui.options.useButtonTransitions)
				{
					if (DialogUI.dui.fade >= 1f)
					{
						if (!useHD)
						{
							yesRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							yesRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						yesRect = new Rect(buttonOffset.x + 800f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						yesRect = new Rect(buttonOffset.x + 1600f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
				}
				else if (!useHD)
				{
					yesRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
				}
				else
				{
					yesRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
				}
				GUI.SetNextControlName(DialogUI.buttonNames[0]);
				dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
				if ((LDC_GUIButton(yesRect, dynamicGUIContent, 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.buttons[0] = false;
					DialogUI.screen.Yes();
				}
				if (DialogUI.dui.options.useButtonTransitions)
				{
					if (DialogUI.dui.fade >= 1f)
					{
						if (!useHD)
						{
							noRect = new Rect(buttonOffset.x + 640f, buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							noRect = new Rect(buttonOffset.x + 1280f, buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						noRect = new Rect(buttonOffset.x + 640f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						noRect = new Rect(buttonOffset.x + 1280f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
				}
				else if (!useHD)
				{
					noRect = new Rect(buttonOffset.x + 640f, buttonOffset.y + 640f - 100f, 140f, 64f);
				}
				else
				{
					noRect = new Rect(buttonOffset.x + 1280f, buttonOffset.y + 1280f - 200f, 280f, 128f);
				}
				GUI.SetNextControlName(DialogUI.buttonNames[1]);
				dynamicGUIContent2 = new GUIContent(DialogUI.customButton2, DoDialogCastAnimation(DialogUI.buttonIcon2Animation, DialogUI.buttonIcon2));
				if ((LDC_GUIButton(noRect, dynamicGUIContent2, 1) || DialogUI.buttons[1]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.buttons[1] = false;
					DialogUI.screen.No();
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.MultipleButtons)
			{
				int num = 0;
				num = (useHD ? (DialogUI.multipleButtons.Length * 136) : (DialogUI.multipleButtons.Length * 68));
				if (!DialogUI.dui.options.hideChoicePanelFromUI)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
					if (!useHD)
					{
						bgRect = new Rect(buttonOffset.x + 256f, buttonOffset.y + 640f - (float)(82 + num), 690f, 62 + num);
					}
					else
					{
						bgRect = new Rect(buttonOffset.x + 512f, buttonOffset.y + 1280f - (float)(164 + num), 1380f, 124 + num);
					}
					if (DialogUI.actorName == string.Empty || DialogUI.dui.options.hideAllTextFromUI || DialogUI.dui.options.hideAllTitleTextFromUI)
					{
						if (!useHD)
						{
							bgRect.height = num + 20;
							bgRect.y += 40f;
						}
						else
						{
							bgRect.height = num + 40;
							bgRect.y += 80f;
						}
					}
					if (DialogUI.portrait == null)
					{
						if (!useHD)
						{
							bgRect.x -= 246f;
							bgRect.width += 246f;
						}
						else
						{
							bgRect.x -= 492f;
							bgRect.width += 492f;
						}
					}
					GUI.Box(bgRect, string.Empty, skin.customStyles[3]);
				}
				DoPortrait();
				if (!DialogUI.dui.options.hideAllTitleTextFromUI)
				{
					if (!useHD)
					{
						actorRect = new Rect(buttonOffset.x + 276f, buttonOffset.y + 640f - (float)(72 + num), 650f, 50f);
					}
					else
					{
						actorRect = new Rect(buttonOffset.x + 552f, buttonOffset.y + 1280f - (float)(144 + num), 1300f, 100f);
					}
					if (DialogUI.portrait == null)
					{
						if (!useHD)
						{
							actorRect.x -= 246f;
							actorRect.width += 246f;
						}
						else
						{
							actorRect.x -= 492f;
							actorRect.width += 492f;
						}
					}
					actorRectShadow = actorRect;
					if (!useHD)
					{
						actorRectShadow.x += 1f;
						actorRectShadow.y += 1f;
					}
					else
					{
						actorRectShadow.x += 2f;
						actorRectShadow.y += 2f;
					}
					DoStyleAndShadow(actorRect, actorRectShadow, skin.customStyles[4], DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
				}
				if (DialogUI.multipleButtons.Length != 0)
				{
					int num2 = 0;
					string[] multipleButtons = DialogUI.multipleButtons;
					foreach (string text in multipleButtons)
					{
						if (text == null)
						{
							continue;
						}
						if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						if (!useHD)
						{
							verticalOffset = num2 * 68;
						}
						else
						{
							verticalOffset = num2 * 136;
						}
						if (!useHD)
						{
							skipRect = new Rect(buttonOffset.x + 276f, buttonOffset.y + (float)(640 - (22 + num)) + (float)verticalOffset, 650f, 48f);
						}
						else
						{
							skipRect = new Rect(buttonOffset.x + 552f, buttonOffset.y + (float)(1280 - (44 + num)) + (float)verticalOffset, 1300f, 96f);
						}
						if (DialogUI.portrait == null)
						{
							if (!useHD)
							{
								skipRect.x -= 246f;
								skipRect.width += 246f;
							}
							else
							{
								skipRect.x -= 492f;
								skipRect.width += 492f;
							}
						}
						GUI.SetNextControlName(DialogUI.buttonNames[num2]);
						dynamicGUIContentMultiple = new GUIContent(text, DoDialogCastAnimation(DialogUI.multipleButtonsIconAnimation[num2], DialogUI.multipleButtonsIcon[num2]));
						if ((LDC_GUIButton(skipRect, dynamicGUIContentMultiple, num2) || DialogUI.buttons[num2]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
						{
							DialogUI.buttons[num2] = false;
							DialogUI.screen.MultipleChoiceNext(num2);
						}
						num2++;
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.DataEntry)
			{
				if (_usingRenderTextures && DialogWorldSpaceGUI.com.useScreenKeyboardForDataEntry)
				{
					DoDataEntryVR();
				}
				else
				{
					GUI.color = Color.white;
					if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					dataEntryBorderRect = default(Rect);
					if (!useHD)
					{
						dataEntryBorderRect = new Rect(80f, 50f, 800f, 120f);
					}
					else
					{
						dataEntryBorderRect = new Rect(160f, 100f, 1600f, 240f);
					}
					if (DialogUI.dataEntryAnchor == DS_DATA_ANCHOR.Middle)
					{
						if (!useHD)
						{
							dataEntryBorderRect.y = 320f - dataEntryBorderRect.height / 2f;
						}
						else
						{
							dataEntryBorderRect.y = 640f - dataEntryBorderRect.height / 2f;
						}
					}
					else if (DialogUI.dataEntryAnchor == DS_DATA_ANCHOR.Bottom)
					{
						if (!useHD)
						{
							dataEntryBorderRect.y = 640f - (dataEntryBorderRect.height + 50f);
						}
						else
						{
							dataEntryBorderRect.y = 1280f - (dataEntryBorderRect.height + 100f);
						}
					}
					dataEntryTitleRect = dataEntryBorderRect;
					if (!useHD)
					{
						dataEntryTitleRect.y += 10f;
					}
					else
					{
						dataEntryTitleRect.y += 20f;
					}
					dataEntryTitleRectShadow = dataEntryTitleRect;
					if (!useHD)
					{
						dataEntryTitleRect.x += 1f;
						dataEntryTitleRect.x += 1f;
					}
					else
					{
						dataEntryTitleRect.y += 2f;
						dataEntryTitleRect.y += 2f;
					}
					GUI.Box(dataEntryBorderRect, string.Empty, skin.customStyles[3]);
					DoStyleAndShadow(dataEntryTitleRect, dataEntryTitleRectShadow, skin.customStyles[4], DialogUI.actorName, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
					textFieldRect = dataEntryBorderRect;
					if (!useHD)
					{
						textFieldRect.width -= 20f;
						textFieldRect.x += 10f;
						textFieldRect.y += 60f;
						textFieldRect.width -= 138f;
						textFieldRect.height = 48f;
					}
					else
					{
						textFieldRect.width -= 40f;
						textFieldRect.x += 20f;
						textFieldRect.y += 120f;
						textFieldRect.width -= 276f;
						textFieldRect.height = 96f;
					}
					dataEntryButton = textFieldRect;
					if (!useHD)
					{
						dataEntryButton.width = 128f;
						dataEntryButton.x += textFieldRect.width + 10f;
					}
					else
					{
						dataEntryButton.width = 256f;
						dataEntryButton.x += textFieldRect.width + 20f;
					}
					if (DialogUI.dataEntryString != null)
					{
						bool flag = false;
						if (Event.current.type == EventType.KeyDown && DialogUI.dui.options.selectGuiWithTheseKeycodes.Length != 0)
						{
							KeyCode[] selectGuiWithTheseKeycodes = DialogUI.dui.options.selectGuiWithTheseKeycodes;
							foreach (KeyCode keyCode in selectGuiWithTheseKeycodes)
							{
								if (Event.current.keyCode == keyCode)
								{
									flag = true;
									break;
								}
							}
						}
						GUI.SetNextControlName(DialogUI.buttonNames[0]);
						DialogUI.dataEntryString = GUI.TextField(textFieldRect, DialogUI.dataEntryString, DialogUI.dataEntryCharacterLimit, skin.customStyles[5]);
						DialogUI.dataEntryString = DialogUI.dataEntryString.Replace("\n", string.Empty);
						floatRef destination = new floatRef();
						if (DialogUI.dataEntryFormat == DS_DATA_FORMAT.Number && !DialogUI.ParseTokenAsFloat(DialogUI.dataEntryString, destination))
						{
							if (DialogUI.dataEntryDefaultValue != string.Empty)
							{
								DialogUI.dataEntryString = DialogUI.dataEntryDefaultValue;
							}
							else
							{
								DialogUI.dataEntryString = "0";
							}
						}
						if (DialogUI.setupTextField && DialogUI.dui.fade >= 0.1f)
						{
							DialogUI.setupTextField = false;
							if (GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl) is TextEditor textEditor)
							{
								textEditor.MoveCursorToPosition(new Vector2(5555f, 5555f));
							}
						}
						GUI.SetNextControlName(DialogUI.buttonNames[1]);
						dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
						if (LDC_GUIButton(dataEntryButton, dynamicGUIContent, usingFocusControl ? skins.forceFocusButton : skins.originalFocusButton, 0) || flag)
						{
							if (DialogUI.dui.tokens.Length != 0 && DialogUI.dataEntryToken < DialogUI.dui.tokens.Length)
							{
								DialogUI.dui.tokens[DialogUI.dataEntryToken].value = DialogUI.dataEntryString;
							}
							else
							{
								Debug.Log("LDC: (DialogUI) Couldn't set Token (with ID: " + DialogUI.dataEntryToken + " ) from Data Entry DialogUI.screen because the token could not be found.");
							}
							if (DialogUI.dui.fade >= 1f && DialogUI.screen != null)
							{
								DialogUI.screen.Skip();
							}
						}
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.Password)
			{
				if (_usingRenderTextures && DialogWorldSpaceGUI.com.useScreenKeyboardForDataEntry)
				{
					DoPasswordVR();
				}
				else
				{
					GUI.color = Color.white;
					if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					passwordBorderRect = default(Rect);
					if (!useHD)
					{
						passwordBorderRect = new Rect(80f, 50f, 800f, 120f);
					}
					else
					{
						passwordBorderRect = new Rect(160f, 100f, 1600f, 240f);
					}
					if (DialogUI.dataEntryAnchor == DS_DATA_ANCHOR.Middle)
					{
						if (!useHD)
						{
							passwordBorderRect.y = 320f - passwordBorderRect.height / 2f;
						}
						else
						{
							passwordBorderRect.y = 640f - passwordBorderRect.height / 2f;
						}
					}
					else if (DialogUI.dataEntryAnchor == DS_DATA_ANCHOR.Bottom)
					{
						if (!useHD)
						{
							passwordBorderRect.y = 640f - (passwordBorderRect.height + 50f);
						}
						else
						{
							passwordBorderRect.y = 1280f - (passwordBorderRect.height + 100f);
						}
					}
					passwordTitleRect = passwordBorderRect;
					if (!useHD)
					{
						passwordTitleRect.y += 10f;
					}
					else
					{
						passwordTitleRect.y += 20f;
					}
					passwordTitleRectShadow = passwordTitleRect;
					if (!useHD)
					{
						passwordTitleRectShadow.x += 1f;
						passwordTitleRectShadow.x += 1f;
					}
					else
					{
						passwordTitleRectShadow.y += 2f;
						passwordTitleRectShadow.y += 2f;
					}
					GUI.Box(passwordBorderRect, string.Empty, skin.customStyles[3]);
					DoStyleAndShadow(passwordTitleRect, passwordTitleRectShadow, skin.customStyles[4], DialogUI.actorName, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
					passwordTextFieldRect = passwordBorderRect;
					if (!useHD)
					{
						passwordTextFieldRect.width -= 20f;
						passwordTextFieldRect.x += 10f;
						passwordTextFieldRect.y += 60f;
						passwordTextFieldRect.width -= 138f;
						passwordTextFieldRect.height = 48f;
					}
					else
					{
						passwordTextFieldRect.width -= 40f;
						passwordTextFieldRect.x += 20f;
						passwordTextFieldRect.y += 120f;
						passwordTextFieldRect.width -= 276f;
						passwordTextFieldRect.height = 96f;
					}
					passwordButton = passwordTextFieldRect;
					if (!useHD)
					{
						passwordButton.width = 128f;
						passwordButton.x += passwordTextFieldRect.width + 10f;
					}
					else
					{
						passwordButton.width = 256f;
						passwordButton.x += passwordTextFieldRect.width + 20f;
					}
					if (DialogUI.dataEntryString != null)
					{
						bool flag2 = false;
						if (Event.current.type == EventType.KeyDown && DialogUI.dui.options.selectGuiWithTheseKeycodes.Length != 0)
						{
							KeyCode[] selectGuiWithTheseKeycodes = DialogUI.dui.options.selectGuiWithTheseKeycodes;
							foreach (KeyCode keyCode2 in selectGuiWithTheseKeycodes)
							{
								if (Event.current.keyCode == keyCode2)
								{
									flag2 = true;
									break;
								}
							}
						}
						GUI.SetNextControlName(DialogUI.buttonNames[0]);
						if (DialogUI.passwordMask)
						{
							DialogUI.dataEntryString = GUI.PasswordField(passwordTextFieldRect, DialogUI.dataEntryString, '*', 255, skin.customStyles[5]);
						}
						else
						{
							DialogUI.dataEntryString = GUI.TextField(passwordTextFieldRect, DialogUI.dataEntryString, 255, skin.customStyles[5]);
						}
						DialogUI.dataEntryString = DialogUI.dataEntryString.Replace("\n", string.Empty);
						if (DialogUI.setupTextField && DialogUI.dui.fade >= 0.1f)
						{
							DialogUI.setupTextField = false;
							if (GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl) is TextEditor textEditor2)
							{
								textEditor2.MoveCursorToPosition(new Vector2(5555f, 5555f));
							}
						}
						GUI.SetNextControlName(DialogUI.buttonNames[1]);
						dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
						if ((LDC_GUIButton(passwordButton, dynamicGUIContent, usingFocusControl ? skins.forceFocusButton : skins.originalFocusButton, 0) || flag2) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
						{
							if (DialogUI.passwordMatchToToken && DialogUI.dui.tokens.Length != 0 && DialogUI.dataEntryToken < DialogUI.dui.tokens.Length)
							{
								if (DialogUI.dui.tokens[DialogUI.dataEntryToken].value == DialogUI.dataEntryString || (!DialogUI.passwordCaseSensitive && DialogUI.dui.tokens[DialogUI.dataEntryToken].value.ToLower() == DialogUI.dataEntryString.ToLower()))
								{
									Debug.Log("LDC: (DialogUI) The Token Matches - Password Match Successful");
									DialogUI.screen.Yes();
								}
								else
								{
									Debug.Log("LDC: (DialogUI) The Token does NOT match - Password Match Failed");
									DialogUI.screen.No();
								}
							}
							else if (!DialogUI.passwordMatchToToken)
							{
								if (DialogUI.dataEntryString == DialogUI.passwordAnswer || (!DialogUI.passwordCaseSensitive && DialogUI.dataEntryString.ToLower() == DialogUI.passwordAnswer.ToLower()))
								{
									Debug.Log("LDC: (DialogUI) The String Matches - Password Match Successful");
									DialogUI.screen.Yes();
								}
								else
								{
									Debug.Log("LDC: (DialogUI) The String does NOT match - Password Match Failed");
									DialogUI.screen.No();
								}
							}
							else
							{
								Debug.Log("LDC: (DialogUI) Password Screen Error - This token is probably not setup correctly. Will default as a password failure.");
								DialogUI.screen.No();
							}
						}
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.Title)
			{
				GUI.color = DialogUI.titleColor;
				if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (useHD)
				{
					titleRect = new Rect(DialogUI.titleOffset.x * 2f, DialogUI.titleOffset.y * 2f, DialogUI.titleSize.x * 2f, DialogUI.titleSize.y * 2f);
					titleRectShadow = titleRect;
					titleRectShadow.x += 2f;
					titleRectShadow.y += 2f;
					subtitleRect = new Rect(DialogUI.subtitleOffset.x * 2f, DialogUI.subtitleOffset.y * 2f, DialogUI.subtitleSize.x * 2f, DialogUI.subtitleSize.y * 2f);
					subtitleRectShadow = subtitleRect;
					subtitleRectShadow.x += 2f;
					subtitleRectShadow.y += 2f;
				}
				else
				{
					titleRect = new Rect(DialogUI.titleOffset.x, DialogUI.titleOffset.y, DialogUI.titleSize.x, DialogUI.titleSize.y);
					titleRectShadow = titleRect;
					titleRectShadow.x += 1f;
					titleRectShadow.y += 1f;
					subtitleRect = new Rect(DialogUI.subtitleOffset.x, DialogUI.subtitleOffset.y, DialogUI.subtitleSize.x, DialogUI.subtitleSize.y);
					subtitleRectShadow = subtitleRect;
					subtitleRectShadow.x += 1f;
					subtitleRectShadow.y += 1f;
				}
				titleStyleOverride = new GUIStyle(skin.customStyles[8]);
				subtitleStyleOverride = new GUIStyle(skin.customStyles[7]);
				if (DialogUI.overrideTitleFont != null)
				{
					titleStyleOverride.font = DialogUI.overrideTitleFont;
				}
				if (DialogUI.titleFontSize > 0 && DialogUI.titleFontSize > 0)
				{
					titleStyleOverride.fontSize = DialogUI.titleFontSize;
					if (useHD)
					{
						titleStyleOverride.fontSize *= 2;
					}
				}
				titleStyleOverride.alignment = DialogUI.titleAllignment;
				if (DialogUI.overrideSubtitleFont != null)
				{
					subtitleStyleOverride.font = DialogUI.overrideSubtitleFont;
				}
				if (DialogUI.subtitleFontSize > 0 && DialogUI.subtitleFontSize > 0)
				{
					subtitleStyleOverride.fontSize = DialogUI.subtitleFontSize;
					if (useHD)
					{
						subtitleStyleOverride.fontSize *= 2;
					}
				}
				subtitleStyleOverride.alignment = DialogUI.subtitleAllignment;
				if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.Off && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.Off)
				{
					DoStyleAndShadow(titleRect, titleRectShadow, titleStyleOverride, DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
					GUI.color = DialogUI.subtitleColor;
					subtitleStyleOverride.normal.textColor = DialogUI.subtitleColor;
					DoStyleAndShadow(subtitleRect, subtitleRectShadow, subtitleStyleOverride, DialogUI.currentDialogText, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
				}
				else if (!DialogUI.dui.options.hideAllTextFromUI)
				{
					DoStyleAndShadow(titleRect, titleRectShadow, titleStyleOverride, DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
					originalVerticalScrollbar = GUI.skin.verticalScrollbar;
					if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
					{
						GUI.skin.verticalScrollbar = GUIStyle.none;
					}
					GUILayout.BeginArea(subtitleRect);
					if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
					{
						DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingFixedValue, GUIStyle.none, GUILayout.Width(subtitleRect.width), GUILayout.Height(subtitleRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
					}
					else
					{
						DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingValue, GUIStyle.none, GUILayout.Width(subtitleRect.width), GUILayout.Height(subtitleRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
					}
					if (DialogUI.dui.options.drawBodyTextShadows)
					{
						GUI.color = Color.black;
						if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						if (!DialogUI.dui.options.hideAllBodyTextFromUI)
						{
							GUILayout.Label(DialogUI.ReplaceAllRichTextColorToNewColor(DialogUI.currentDialogText, new Color32(0, 0, 0, (byte)GUI.color.a)), subtitleStyleOverride);
						}
						else
						{
							SetGUIColorAlpha(0f);
							GUILayout.Label(DialogUI.currentDialogText, subtitleStyleOverride);
							GUI.color = Color.black;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
						}
						theShadowScrollRect = GUILayoutUtility.GetLastRect();
						if (!useHD)
						{
							theShadowScrollRect.x -= 1f;
							theShadowScrollRect.y -= 1f;
						}
						else
						{
							theShadowScrollRect.x -= 2f;
							theShadowScrollRect.y -= 2f;
						}
						GUI.color = DialogUI.subtitleColor;
						if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						if (!DialogUI.dui.options.hideAllBodyTextFromUI)
						{
							GUI.Label(theShadowScrollRect, DialogUI.currentDialogText, subtitleStyleOverride);
						}
					}
					else
					{
						GUI.color = DialogUI.subtitleColor;
						if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
						{
							SetGUIColorAlpha(DialogUI.dui.fade);
						}
						else
						{
							SetGUIColorAlpha(1f);
						}
						if (!DialogUI.dui.options.hideAllBodyTextFromUI)
						{
							GUILayout.Label(DialogUI.currentDialogText, subtitleStyleOverride);
						}
						else
						{
							SetGUIColorAlpha(0f);
							GUILayout.Label(DialogUI.currentDialogText, subtitleStyleOverride);
							GUI.color = DialogUI.subtitleColor;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
						}
					}
					theAutoScrollRect = GUILayoutUtility.GetLastRect();
					DialogUI.dui.options.autoScrollingHeight = theAutoScrollRect.height - (subtitleRect.height - DialogUI.dui.options.scrollableTextExtraFooterSpace);
					GUILayout.EndScrollView();
					GUILayout.EndArea();
					GUI.skin.verticalScrollbar = originalVerticalScrollbar;
				}
				if (!DialogUI.dui.options.hideAllSingleButtonsFromUI && !DialogUI.hideNextButton)
				{
					GUI.color = Color.white;
					if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					if (DialogUI.dui.options.useButtonTransitions)
					{
						if (DialogUI.dui.fade >= 1f)
						{
							if (!useHD)
							{
								skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
							}
							else
							{
								skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
							}
						}
						else if (!useHD)
						{
							skipRect = new Rect(buttonOffset.x + 800f + 255f * (1f - DialogUI.dui.fade), buttonOffset.y + 640f - 100f, 140f, 64f);
						}
						else
						{
							skipRect = new Rect(buttonOffset.x + 1600f + 510f * (1f - DialogUI.dui.fade), buttonOffset.y + 1280f - 200f, 280f, 128f);
						}
					}
					else if (!useHD)
					{
						skipRect = new Rect(buttonOffset.x + 800f, buttonOffset.y + 640f - 100f, 140f, 64f);
					}
					else
					{
						skipRect = new Rect(buttonOffset.x + 1600f, buttonOffset.y + 1280f - 200f, 280f, 128f);
					}
					GUI.SetNextControlName(DialogUI.buttonNames[0]);
					dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
					if ((LDC_GUIButton(skipRect, dynamicGUIContent, 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
					{
						DialogUI.buttons[0] = false;
						DialogUI.screen.Skip();
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.Popup)
			{
				GUI.color = Color.white;
				if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (!useHD)
				{
					popupImageBGRect = new Rect(480 - DialogUI.popupSizeX / 4, 320 - DialogUI.popupSizeY / 4, DialogUI.popupSizeX / 2, DialogUI.popupSizeY / 2);
				}
				else
				{
					popupImageBGRect = new Rect(960 - DialogUI.popupSizeX / 2, 640 - DialogUI.popupSizeY / 2, DialogUI.popupSizeX, DialogUI.popupSizeY);
				}
				popupTitle = popupImageBGRect;
				popupTitleShadow = popupTitle;
				if (!useHD)
				{
					popupTitleShadow.x += 2f;
					popupTitleShadow.y += 2f;
				}
				else
				{
					popupTitleShadow.x += 1f;
					popupTitleShadow.y += 1f;
				}
				if (!useHD)
				{
					popupButtonRect = new Rect(popupImageBGRect.x + popupImageBGRect.width - ((float)DialogUI.popupButtonSizeX * 0.5f + (float)DialogUI.popupButtonSpacer * 0.5f), popupImageBGRect.y + popupImageBGRect.height - ((float)DialogUI.popupButtonSizeY * 0.5f + (float)DialogUI.popupButtonSpacer * 0.5f), (float)DialogUI.popupButtonSizeX * 0.5f, (float)DialogUI.popupButtonSizeY * 0.5f);
				}
				else
				{
					popupButtonRect = new Rect(popupImageBGRect.x + popupImageBGRect.width - (float)(DialogUI.popupButtonSizeX + DialogUI.popupButtonSpacer), popupImageBGRect.y + popupImageBGRect.height - (float)(DialogUI.popupButtonSizeY + DialogUI.popupButtonSpacer), DialogUI.popupButtonSizeX, DialogUI.popupButtonSizeY);
				}
				popupButtonRect2 = popupButtonRect;
				if (!useHD)
				{
					popupButtonRect2.x -= (float)DialogUI.popupButtonSizeX * 0.5f + (float)DialogUI.popupButtonSpacer * 0.5f;
				}
				else
				{
					popupButtonRect2.x -= DialogUI.popupButtonSizeX + DialogUI.popupButtonSpacer;
				}
				popupText = popupTitle;
				if (!useHD)
				{
					popupText.y += 56f;
					popupText.height -= 48f + (popupButtonRect.height + 32f);
				}
				else
				{
					popupText.y += 112f;
					popupText.height -= 96f + (popupButtonRect.height + 64f);
				}
				popupTextShadow = popupText;
				if (!useHD)
				{
					popupTextShadow.x += 2f;
					popupTextShadow.y += 2f;
				}
				else
				{
					popupTextShadow.x += 1f;
					popupTextShadow.y += 1f;
				}
				GUI.Box(popupImageBGRect, string.Empty, skin.customStyles[10]);
				if (DialogUI.popupImage != null)
				{
					if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade * DialogUI.popupBackgroundAlpha);
					}
					else
					{
						SetGUIColorAlpha(1f * DialogUI.popupBackgroundAlpha);
					}
					GUI.DrawTexture(popupImageBGRect, DoDialogCastAnimation(DialogUI.popupImageAnimation, DialogUI.popupImage));
				}
				if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				DoStyleAndShadow(popupTitle, popupTitleShadow, skin.customStyles[11], DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
				if (!DialogUI.dui.options.hideAllBodyTextFromUI)
				{
					if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.Off && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.Off)
					{
						DoStyleAndShadow(popupText, popupTextShadow, skin.customStyles[12], DialogUI.currentDialogText, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
					}
					else
					{
						originalVerticalScrollbar = GUI.skin.verticalScrollbar;
						if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
						{
							GUI.skin.verticalScrollbar = GUIStyle.none;
						}
						GUILayout.BeginArea(popupText);
						if ((DialogUI.dui.options.scrollableDialogText == DIALOG_SCROLLING.AutomaticScrolling && DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.UseDefault) || DialogUI.scrollingOptions == DIALOG_OVERRIDE_SCROLLING.AutomaticScrolling)
						{
							DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingFixedValue, GUIStyle.none, GUILayout.Width(popupText.width), GUILayout.Height(popupText.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
						}
						else
						{
							DialogUI.dui.options.autoScrollingValue = GUILayout.BeginScrollView(DialogUI.dui.options.autoScrollingValue, GUIStyle.none, GUILayout.Width(popupText.width), GUILayout.Height(popupText.height - DialogUI.dui.options.scrollableTextExtraFooterSpace));
						}
						if (DialogUI.dui.options.drawBodyTextShadows)
						{
							GUI.color = Color.black;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUILayout.Label(DialogUI.ReplaceAllRichTextColorToNewColor(DialogUI.currentDialogText, new Color32(0, 0, 0, (byte)GUI.color.a)), skin.customStyles[12]);
							theShadowScrollRect = GUILayoutUtility.GetLastRect();
							if (!useHD)
							{
								theShadowScrollRect.x -= 1f;
								theShadowScrollRect.y -= 1f;
							}
							else
							{
								theShadowScrollRect.x -= 2f;
								theShadowScrollRect.y -= 2f;
							}
							GUI.color = Color.white;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUI.Label(theShadowScrollRect, DialogUI.currentDialogText, skin.customStyles[12]);
						}
						else
						{
							GUI.color = Color.white;
							if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
							{
								SetGUIColorAlpha(DialogUI.dui.fade);
							}
							else
							{
								SetGUIColorAlpha(1f);
							}
							GUILayout.Label(DialogUI.currentDialogText, skin.customStyles[12]);
						}
						theAutoScrollRect = GUILayoutUtility.GetLastRect();
						DialogUI.dui.options.autoScrollingHeight = theAutoScrollRect.height - (popupText.height - DialogUI.dui.options.scrollableTextExtraFooterSpace);
						GUILayout.EndScrollView();
						GUILayout.EndArea();
						GUI.skin.verticalScrollbar = originalVerticalScrollbar;
					}
				}
				GUI.SetNextControlName(DialogUI.buttonNames[0]);
				dynamicGUIContent = new GUIContent(DialogUI.customButton1, DoDialogCastAnimation(DialogUI.buttonIcon1Animation, DialogUI.buttonIcon1));
				if ((LDC_GUIButton(popupButtonRect, dynamicGUIContent, 0) || DialogUI.buttons[0]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
				{
					DialogUI.buttons[0] = false;
					if (DialogUI.popupOptions == POPUP_OPTIONS.OneButton)
					{
						DialogUI.screen.Skip();
					}
					else if (DialogUI.popupOptions == POPUP_OPTIONS.TwoButtons)
					{
						DialogUI.screen.Yes();
					}
				}
				if (DialogUI.popupOptions == POPUP_OPTIONS.TwoButtons)
				{
					GUI.SetNextControlName(DialogUI.buttonNames[1]);
					dynamicGUIContent = new GUIContent(DialogUI.customButton2, DoDialogCastAnimation(DialogUI.buttonIcon2Animation, DialogUI.buttonIcon2));
					if ((LDC_GUIButton(popupButtonRect2, dynamicGUIContent, 1) || DialogUI.buttons[1]) && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
					{
						DialogUI.buttons[1] = false;
						DialogUI.screen.No();
					}
				}
			}
			else if (DialogUI.dialogStyle == DIALOGSTYLE.IconGrid)
			{
				GUI.color = Color.white;
				if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (!useHD)
				{
					iconGridBGRect = new Rect(480f - (float)DialogUI.IG_WindowSizeX * 0.25f + (float)DialogUI.IG_WindowOffsetX * 0.5f, 320f - (float)DialogUI.IG_WindowSizeY * 0.25f + (float)DialogUI.IG_WindowOffsetY * 0.5f, (float)DialogUI.IG_WindowSizeX * 0.5f, (float)DialogUI.IG_WindowSizeY * 0.5f);
				}
				else
				{
					iconGridBGRect = new Rect(960f - (float)DialogUI.IG_WindowSizeX * 0.5f + (float)DialogUI.IG_WindowOffsetX, 640f - (float)DialogUI.IG_WindowSizeY * 0.5f + (float)DialogUI.IG_WindowOffsetY, DialogUI.IG_WindowSizeX, DialogUI.IG_WindowSizeY);
				}
				IG_NumberOfIconsMinusClose = DialogUI.IG_buttons.Length;
				if (DialogUI.IG_firstIconIsCloseButton)
				{
					IG_NumberOfIconsMinusClose--;
				}
				IG_NumberOfRows = IG_NumberOfIconsMinusClose / DialogUI.IG_iconsPerRow;
				if (IG_NumberOfIconsMinusClose % DialogUI.IG_iconsPerRow > 0)
				{
					IG_NumberOfRows++;
				}
				if (IG_NumberOfRows < 1)
				{
					IG_NumberOfRows = 1;
				}
				IG_Spacer = DialogUI.IG_IconSpacer;
				if (!useHD)
				{
					IG_Spacer = (int)((float)IG_Spacer * 0.5f);
				}
				IG_ContentSizeX = DialogUI.IG_iconSizeX * DialogUI.IG_iconsPerRow + (DialogUI.IG_iconsPerRow + 1) * IG_Spacer;
				if (DialogUI.IG_showIconLabels)
				{
					IG_ContentSizeY = IG_Spacer + (DialogUI.IG_iconSizeY + DialogUI.IG_iconLabelSize) * IG_NumberOfRows + IG_NumberOfRows * IG_Spacer;
				}
				else
				{
					IG_ContentSizeY = IG_Spacer + DialogUI.IG_iconSizeY * IG_NumberOfRows + IG_NumberOfRows * IG_Spacer;
				}
				if (useHD)
				{
					IG_ContentSizeX -= (int)((float)((DialogUI.IG_iconsPerRow + 1) * IG_Spacer) * 0.5f);
					IG_ContentSizeY -= (int)((float)(IG_NumberOfRows * IG_Spacer) * 0.5f);
				}
				IG_HeaderHeight = 0;
				if (DialogUI.IG_WindowShowTitle)
				{
					IG_TitleRect = iconGridBGRect;
					if (skin.customStyles[13] != null && skin.customStyles[13].fixedHeight > 0f)
					{
						IG_TitleRect.height = skin.customStyles[13].fixedHeight;
						IG_HeaderHeight += (int)skin.customStyles[13].fixedHeight;
					}
					else if (!useHD)
					{
						IG_TitleRect.height = 55f;
						IG_HeaderHeight += 55;
					}
					else
					{
						IG_TitleRect.height = 110f;
						IG_HeaderHeight += 110;
					}
					IG_TitleRectShadow = IG_TitleRect;
					if (!useHD)
					{
						IG_TitleRectShadow.x += 1f;
						IG_TitleRectShadow.y += 1f;
					}
					else
					{
						IG_TitleRectShadow.x += 2f;
						IG_TitleRectShadow.y += 2f;
					}
				}
				if (DialogUI.IG_WindowShowSubtitle)
				{
					IG_SubtitleRect = IG_TitleRect;
					if (!DialogUI.IG_WindowShowTitle)
					{
						IG_SubtitleRect = iconGridBGRect;
					}
					if (skin.customStyles[14] != null && skin.customStyles[14].fixedHeight > 0f)
					{
						IG_SubtitleRect.height = skin.customStyles[14].fixedHeight;
						IG_SubtitleRect.y += IG_TitleRect.height;
						IG_HeaderHeight += (int)skin.customStyles[14].fixedHeight;
					}
					else if (!useHD)
					{
						IG_SubtitleRect.height = 36f;
						if (DialogUI.IG_WindowShowTitle)
						{
							IG_SubtitleRect.y += IG_TitleRect.height;
						}
						IG_HeaderHeight += 36;
					}
					else
					{
						IG_SubtitleRect.height = 72f;
						if (DialogUI.IG_WindowShowTitle)
						{
							IG_SubtitleRect.y += IG_TitleRect.height;
						}
						IG_HeaderHeight += 72;
					}
					IG_SubtitleRectShadow = IG_SubtitleRect;
					if (!useHD)
					{
						IG_SubtitleRectShadow.x += 1f;
						IG_SubtitleRectShadow.y += 1f;
					}
					else
					{
						IG_SubtitleRectShadow.x += 2f;
						IG_SubtitleRectShadow.y += 2f;
					}
				}
				IG_ActualScrollRect = iconGridBGRect;
				if (IG_HeaderHeight > 0)
				{
					IG_ActualScrollRect.y += IG_HeaderHeight;
					IG_ActualScrollRect.height -= IG_HeaderHeight;
				}
				if (DialogUI.IG_AddSpaceBetweenSubtitleAndContent)
				{
					IG_ActualScrollRect.y += IG_Spacer;
					IG_ActualScrollRect.height -= IG_Spacer;
				}
				if (!useHD)
				{
					iconGridICRect = new Rect(0f, IG_HeaderHeight, IG_ContentSizeX, IG_ContentSizeY);
				}
				else
				{
					iconGridICRect = new Rect(0f, IG_HeaderHeight, IG_ContentSizeX * 2, IG_ContentSizeY * 2);
				}
				if (DialogUI.IG_showPanelBG)
				{
					GUI.Box(iconGridBGRect, string.Empty, skin.customStyles[10]);
				}
				if (DialogUI.popupImage != null)
				{
					if (DialogUI.dui.options.useButtonFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade * DialogUI.IG_BackgroundAlpha);
					}
					else
					{
						SetGUIColorAlpha(1f * DialogUI.IG_BackgroundAlpha);
					}
					GUI.DrawTexture(iconGridBGRect, DoDialogCastAnimation(DialogUI.popupImageAnimation, DialogUI.popupImage));
				}
				if (DialogUI.IG_WindowShowTitle)
				{
					DoStyleAndShadow(IG_TitleRect, IG_TitleRectShadow, skin.customStyles[13], DialogUI.actorName, DialogUI.dui.options.drawTitleTextShadows, DialogUI.dui.options.hideAllTitleTextFromUI);
				}
				if (DialogUI.IG_WindowShowSubtitle)
				{
					DoStyleAndShadow(IG_SubtitleRect, IG_SubtitleRectShadow, skin.customStyles[14], DialogUI.currentDialogText, DialogUI.dui.options.drawBodyTextShadows, DialogUI.dui.options.hideAllBodyTextFromUI);
				}
				if (DialogUI.IG_buttons != null && DialogUI.IG_buttons.Length != 0)
				{
					IG_CurrentIcon = 0;
					if (!DialogUI.IG_showButtonBackgrounds)
					{
						IG_ModifiedButtonStyle = new GUIStyle(skin.button);
						IG_ModifiedButtonStyle.normal.background = null;
						IG_ModifiedButtonStyle.hover.background = null;
						IG_ModifiedButtonStyle.active.background = null;
						IG_ModifiedButtonStyle.focused.background = null;
						IG_ModifiedButtonStyle.imagePosition = DialogUI.IG_buttonImagePosition;
						IG_ModifiedButtonStyle.alignment = DialogUI.IG_buttonAllignment;
						if (DialogUI.IG_AddInnerIconSpacing > 0)
						{
							IG_ModifiedButtonStyle.padding.left += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.right += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.top += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.bottom += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
						}
					}
					else
					{
						IG_ModifiedButtonStyle = new GUIStyle(skin.button);
						IG_ModifiedButtonStyle.imagePosition = DialogUI.IG_buttonImagePosition;
						IG_ModifiedButtonStyle.alignment = DialogUI.IG_buttonAllignment;
						if (DialogUI.IG_AddInnerIconSpacing > 0)
						{
							IG_ModifiedButtonStyle.padding.left += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.right += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.top += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
							IG_ModifiedButtonStyle.padding.bottom += (int)(useHD ? ((float)DialogUI.IG_AddInnerIconSpacing) : ((float)DialogUI.IG_AddInnerIconSpacing * 0.5f));
						}
					}
					if (DialogUI.IG_firstIconIsCloseButton)
					{
						if (!useHD)
						{
							IG_Close_Btn = new Rect(iconGridBGRect.x + iconGridBGRect.width - ((float)skin.customStyles[10].margin.right + (float)DialogUI.IG_closeButtonSize * 0.5f), iconGridBGRect.y + (float)skin.customStyles[10].margin.top, (float)DialogUI.IG_closeButtonSize * 0.5f, (float)DialogUI.IG_closeButtonSize * 0.5f);
						}
						else
						{
							IG_Close_Btn = new Rect(iconGridBGRect.x + iconGridBGRect.width - (float)(skin.customStyles[10].margin.right + DialogUI.IG_closeButtonSize), iconGridBGRect.y + (float)skin.customStyles[10].margin.top, DialogUI.IG_closeButtonSize, DialogUI.IG_closeButtonSize);
						}
						if (DialogUI.IG_buttons[IG_CurrentIcon].overrideFont != null)
						{
							IG_ModifiedButtonStyle.font = DialogUI.IG_buttons[IG_CurrentIcon].overrideFont;
						}
						else
						{
							IG_ModifiedButtonStyle.font = skin.button.font;
						}
						GUI.enabled = !DialogUI.IG_buttons[IG_CurrentIcon].logicFailed;
						GUI.SetNextControlName(DialogUI.buttonNames[IG_CurrentIcon]);
						dynamicGUIContentMultiple = new GUIContent(DialogUI.IG_buttons[IG_CurrentIcon].title, DoDialogCastAnimation(IconGridButtons.dca, DialogUI.IG_buttons[IG_CurrentIcon].buttonIcon));
						if ((LDC_GUIButton(IG_Close_Btn, dynamicGUIContentMultiple, IG_ModifiedButtonStyle, 0) || DialogUI.buttons[IG_CurrentIcon]) && !DialogUI.IG_buttons[IG_CurrentIcon].logicFailed && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
						{
							DialogUI.buttons[IG_CurrentIcon] = false;
							DialogUI.screen.IconGridNext(IG_CurrentIcon);
						}
						GUI.enabled = true;
						IG_CurrentIcon = 1;
					}
					if (DialogUI.scrollPosition.y > iconGridICRect.height - IG_ActualScrollRect.height)
					{
						DialogUI.scrollPosition.y = iconGridICRect.height - IG_ActualScrollRect.height;
					}
					if (DialogUI.scrollPosition.y < 0f)
					{
						DialogUI.scrollPosition.y = 0f;
					}
					if (DialogUI.scrollPosition.x > iconGridICRect.width - IG_ActualScrollRect.width)
					{
						DialogUI.scrollPosition.x = iconGridICRect.width - IG_ActualScrollRect.width;
					}
					if (DialogUI.scrollPosition.x < 0f)
					{
						DialogUI.scrollPosition.x = 0f;
					}
					DialogUI.scrollPosition = GUI.BeginScrollView(IG_ActualScrollRect, DialogUI.scrollPosition, iconGridICRect, DialogUI.IG_useXScrolling, DialogUI.IG_useYScrolling);
					for (int j = 0; j < IG_NumberOfRows; j++)
					{
						for (int k = 0; k < DialogUI.IG_iconsPerRow; k++)
						{
							if (IG_CurrentIcon < DialogUI.IG_buttons.Length)
							{
								if (!useHD)
								{
									IG_Btn = new Rect(IG_Spacer + k * DialogUI.IG_iconSizeX + k * IG_Spacer, IG_HeaderHeight + IG_Spacer + j * (DialogUI.IG_iconSizeY + DialogUI.IG_iconLabelSize) + j * IG_Spacer, DialogUI.IG_iconSizeX, DialogUI.IG_iconSizeY);
								}
								else
								{
									IG_Btn = new Rect(IG_Spacer + k * DialogUI.IG_iconSizeX * 2 + k * IG_Spacer, IG_HeaderHeight + IG_Spacer + j * (DialogUI.IG_iconSizeY + DialogUI.IG_iconLabelSize) * 2 + j * IG_Spacer, DialogUI.IG_iconSizeX * 2, DialogUI.IG_iconSizeY * 2);
								}
								if (DialogUI.IG_buttons[IG_CurrentIcon].overrideFont != null)
								{
									IG_ModifiedButtonStyle.font = DialogUI.IG_buttons[IG_CurrentIcon].overrideFont;
								}
								else
								{
									IG_ModifiedButtonStyle.font = skin.button.font;
								}
								if (DialogUI.IG_showIconLabels)
								{
									IG_Btn_Label = IG_Btn;
									IG_Btn_Label.y += IG_Btn.height;
									IG_Btn_Label.height += DialogUI.IG_iconLabelSize;
									if (DialogUI.IG_buttons[IG_CurrentIcon].logicFailed)
									{
										SetGUIColorAlpha(DialogUI.dui.fade * 0.5f);
									}
									if (!DialogUI.dui.options.hideAllTextFromUI && !DialogUI.dui.options.hideAllBodyTextFromUI)
									{
										GUI.Label(IG_Btn_Label, DialogUI.IG_buttons[IG_CurrentIcon].logicFailed ? DialogUI.IG_buttons[IG_CurrentIcon].failedLabel : DialogUI.IG_buttons[IG_CurrentIcon].label, skin.customStyles[15]);
									}
									if (DialogUI.IG_buttons[IG_CurrentIcon].logicFailed)
									{
										SetGUIColorAlpha(DialogUI.dui.fade);
									}
								}
								DialogUI.IG_buttons[IG_CurrentIcon].currentRect = IG_Btn;
								IG_vrButtonRect = IG_Btn;
								IG_vrButtonRect.x += IG_ActualScrollRect.x;
								IG_vrButtonRect.y += IG_ActualScrollRect.y - iconGridICRect.y;
								IG_vrButtonRect.x -= DialogUI.scrollPosition.x;
								IG_vrButtonRect.y -= DialogUI.scrollPosition.y;
								IG_vrButtonRightSpacerRect = IG_vrButtonRect;
								IG_vrButtonRightSpacerRect.x += IG_vrButtonRect.width;
								IG_vrButtonBottomSpacerRect = IG_vrButtonRect;
								IG_vrButtonBottomSpacerRect.y += IG_vrButtonRect.height;
								GUI.enabled = !DialogUI.IG_buttons[IG_CurrentIcon].logicFailed;
								GUI.SetNextControlName(DialogUI.buttonNames[IG_CurrentIcon]);
								dynamicGUIContentMultiple = new GUIContent(DialogUI.IG_buttons[IG_CurrentIcon].title, DoDialogCastAnimation(IconGridButtons.dca, DialogUI.IG_buttons[IG_CurrentIcon].buttonIcon));
								if ((LDC_GUIButton(IG_Btn, dynamicGUIContentMultiple, IG_ModifiedButtonStyle, IG_ActualScrollRect, IG_vrButtonRect, IG_vrButtonRightSpacerRect, IG_vrButtonBottomSpacerRect, IG_CurrentIcon) || DialogUI.buttons[IG_CurrentIcon]) && !DialogUI.IG_buttons[IG_CurrentIcon].logicFailed && DialogUI.dui.fade >= 1f && DialogUI.screen != null)
								{
									DialogUI.buttons[IG_CurrentIcon] = false;
									DialogUI.screen.IconGridNext(IG_CurrentIcon);
								}
								GUI.enabled = true;
							}
							IG_CurrentIcon++;
						}
					}
					GUI.EndScrollView();
				}
			}
			if (DialogUI.portrait != null && DialogUI.dialogStyle != DIALOGSTYLE.MultipleButtons && DialogUI.dialogStyle != DIALOGSTYLE.DataEntry && DialogUI.dialogStyle != DIALOGSTYLE.Password && DialogUI.dialogStyle != DIALOGSTYLE.Popup)
			{
				DoPortrait();
			}
		}

		public void DoStyleAndShadow(Rect R, Rect SR, GUIStyle OGS, string textToDisplay, bool drawShadows, bool hideText)
		{
			if (drawShadows)
			{
				if (OGS.normal.background != null)
				{
					GUI.color = Color.white;
					GUI.contentColor = Color.white;
					if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					GUI.Label(R, string.Empty, OGS);
				}
				if (!DialogUI.dui.options.hideAllTextFromUI && !hideText)
				{
					GUI.contentColor = Color.black;
					if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
					{
						SetGUIColorAlpha(DialogUI.dui.fade);
					}
					else
					{
						SetGUIColorAlpha(1f);
					}
					subtitleShadowStyle = new GUIStyle(OGS);
					if (DialogUI.dui.options.drawBodyTextShadows)
					{
						subtitleShadowStyle.normal.background = null;
					}
					GUI.Label(SR, DialogUI.ReplaceAllRichTextColorToNewColor(textToDisplay, new Color32(0, 0, 0, (byte)GUI.color.a)), subtitleShadowStyle);
					GUI.contentColor = Color.white;
					GUI.Label(R, textToDisplay, subtitleShadowStyle);
				}
			}
			else
			{
				GUI.color = Color.white;
				if (DialogUI.dui.options.useTextFades || DialogUI.dui.alpha < 1f)
				{
					SetGUIColorAlpha(DialogUI.dui.fade);
				}
				else
				{
					SetGUIColorAlpha(1f);
				}
				if (!DialogUI.dui.options.hideAllTextFromUI && !hideText)
				{
					GUI.Label(R, textToDisplay, OGS);
				}
				else
				{
					GUI.Label(R, string.Empty, OGS);
				}
			}
		}

		public void FocusUpdateScrollViews()
		{
			if (DialogUI.dialogStyle == DIALOGSTYLE.IconGrid && DialogUI.IG_buttons != null && DialogUI.currentSelection >= 0 && DialogUI.IG_buttons.Length > DialogUI.currentSelection && DialogUI.IG_buttons[DialogUI.currentSelection] != null)
			{
				focusScrollRect = DialogUI.IG_buttons[DialogUI.currentSelection].currentRect;
				destinationScrollViewMove.x = focusScrollRect.x - (float)IG_Spacer - iconGridICRect.x;
				destinationScrollViewMove.y = focusScrollRect.y - (iconGridICRect.y + (float)IG_Spacer);
				StopCoroutine("SmoothScrollViewMove");
				StartCoroutine("SmoothScrollViewMove", destinationScrollViewMove);
			}
		}

		public IEnumerator SmoothScrollViewMove(Vector2 newPosition)
		{
			SmoothScrollViewMoveTimeOut = 2f;
			if (!DialogUI.ended && DialogUI.dialogStyle == DIALOGSTYLE.IconGrid)
			{
				while (SmoothScrollViewMoveTimeOut > 0f && ((DialogUI.IG_firstIconIsCloseButton && DialogUI.currentSelection > 0 && DialogUI.scrollPosition != destinationScrollViewMove) || (!DialogUI.IG_firstIconIsCloseButton && DialogUI.scrollPosition != destinationScrollViewMove)))
				{
					SmoothScrollViewMoveTimeOut -= Time.deltaTime;
					DialogUI.scrollPosition = Vector2.MoveTowards(DialogUI.scrollPosition, destinationScrollViewMove, Mathf.Max(iconGridICRect.width, iconGridICRect.height) * (Time.deltaTime * 1.5f));
					yield return null;
				}
			}
		}

		public void DoPortrait()
		{
			if (skin.customStyles.Length >= 7 && skin.customStyles[6] != null)
			{
				portraitSize = new Vector2(skin.customStyles[6].fixedWidth, skin.customStyles[6].fixedHeight);
				portraitOffset = skin.customStyles[6].contentOffset;
			}
			else if (!useHD)
			{
				portraitSize = new Vector2(256f, 256f);
			}
			else
			{
				portraitSize = new Vector2(512f, 512f);
			}
			if (DialogUI.noPortraitFadeIn && DialogUI.status == DUISTATUS.SHOW)
			{
				SetGUIColorAlpha(1f);
				if (!useHD)
				{
					portraitRect = new Rect(portraitOffset.x, 640f - (portraitSize.y - 1f), portraitSize.x, portraitSize.y);
				}
				else
				{
					portraitRect = new Rect(portraitOffset.x, 1280f - (portraitSize.y - 2f), portraitSize.x, portraitSize.y);
				}
				if (DialogUI.portraitAnimation != null && DialogUI.portrait != null)
				{
					GUI.DrawTexture(portraitRect, DoDialogCastAnimation(DialogUI.portraitAnimation, DialogUI.portrait), ScaleMode.StretchToFill, alphaBlend: true);
				}
				else if (DialogUI.portrait != null)
				{
					GUI.DrawTexture(portraitRect, DialogUI.portrait, ScaleMode.StretchToFill, alphaBlend: true);
				}
				return;
			}
			if (DialogUI.noPortraitFadeOut && (DialogUI.status == DUISTATUS.FADEOUT || DialogUI.status == DUISTATUS.WAITFORSCREEN))
			{
				SetGUIColorAlpha(1f);
				if (!useHD)
				{
					portraitRect = new Rect(portraitOffset.x, 640f - (portraitSize.y - 1f), portraitSize.x, portraitSize.y);
				}
				else
				{
					portraitRect = new Rect(portraitOffset.x, 1280f - (portraitSize.y - 1f), portraitSize.x, portraitSize.y);
				}
				if (DialogUI.portraitAnimation != null && DialogUI.portrait != null)
				{
					GUI.DrawTexture(portraitRect, DoDialogCastAnimation(DialogUI.portraitAnimation, DialogUI.portrait), ScaleMode.StretchToFill, alphaBlend: true);
				}
				else if (DialogUI.portrait != null)
				{
					GUI.DrawTexture(portraitRect, DialogUI.portrait, ScaleMode.StretchToFill, alphaBlend: true);
				}
				return;
			}
			if (DialogUI.dui.options.usePortraitFades || DialogUI.dui.alpha < 1f)
			{
				SetGUIColorAlpha(DialogUI.dui.fade);
			}
			else
			{
				SetGUIColorAlpha(1f);
			}
			if (DialogUI.dui.options.usePortraitTransitions)
			{
				if (DialogUI.dui.fade >= 1f)
				{
					if (!useHD)
					{
						portraitRect = new Rect(portraitOffset.x - (portraitSize.x - 1f) * 0f, portraitOffset.y + (640f - (portraitSize.y - 1f)), portraitSize.x, portraitSize.y);
					}
					else
					{
						portraitRect = new Rect(portraitOffset.x - (portraitSize.x - 1f) * 0f, portraitOffset.y + (1280f - (portraitSize.y - 1f)), portraitSize.x, portraitSize.y);
					}
				}
				else if (!useHD)
				{
					portraitRect = new Rect(portraitOffset.x - (portraitSize.x - 1f) * (1f - DialogUI.dui.fade), portraitOffset.y + (640f - (portraitSize.y - 1f)), portraitSize.x, portraitSize.y);
				}
				else
				{
					portraitRect = new Rect(portraitOffset.x - (portraitSize.x - 1f) * (1f - DialogUI.dui.fade), portraitOffset.y + (1280f - (portraitSize.y - 1f)), portraitSize.x, portraitSize.y);
				}
			}
			else if (!useHD)
			{
				portraitRect = new Rect(portraitOffset.x, 640f - (portraitSize.y - 1f), portraitSize.x, portraitSize.y);
			}
			else
			{
				portraitRect = new Rect(portraitOffset.x, 1280f - (portraitSize.y - 1f), portraitSize.x, portraitSize.y);
			}
			if (DialogUI.portraitAnimation != null && DialogUI.portrait != null)
			{
				GUI.DrawTexture(portraitRect, DoDialogCastAnimation(DialogUI.portraitAnimation, DialogUI.portrait), ScaleMode.StretchToFill, alphaBlend: true);
			}
			else if (DialogUI.portrait != null)
			{
				GUI.DrawTexture(portraitRect, DialogUI.portrait, ScaleMode.StretchToFill, alphaBlend: true);
			}
		}

		public Texture2D DoDialogCastAnimation(DialogCastActor anim, Texture2D backupTex)
		{
			if (anim != null && anim.animated && anim.frames[anim.currentFrame] != null)
			{
				return anim.frames[anim.currentFrame];
			}
			return backupTex;
		}

		public void DoDialogCastAnimationUpdate(DialogCastActor anim)
		{
			if (anim != null && anim.animated)
			{
				anim.timer += Time.deltaTime;
				if (anim.timer >= anim.animationSpeed)
				{
					anim.currentFrame++;
					anim.timer = 0f;
				}
				if (anim.currentFrame > anim.frames.Length - 1)
				{
					anim.currentFrame = Mathf.Clamp(anim.loopToFrame, 0, anim.frames.Length - 1);
				}
			}
		}

		public bool LDC_GUIButton(Rect r, string s, int buttonIndex)
		{
			if (_usingRenderTextures)
			{
				_simulatedMouseIsOverRect = DialogWorldSpaceGUI.SimulatedMouseIsWithinRect(r, lastUsedMatrix);
				_ldcGuiButtonNewStyle = new GUIStyle(GUI.skin.button);
				if (DialogUI.currentSelection == buttonIndex && !_simulatedMouseIsOverRect)
				{
					_ldcGuiButtonNewStyle.normal = GUI.skin.button.focused;
					GUI.Label(r, s, _ldcGuiButtonNewStyle);
				}
				else if (_simulatedMouseIsOverRect)
				{
					if (!DialogWorldSpaceGUI.GetInputButton() && !DialogWorldSpaceGUI.GetInputButtonUp())
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.hover;
						GUI.Label(r, s, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonDown())
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, s, _ldcGuiButtonNewStyle);
						_lastCachedButtonIndex = buttonIndex;
					}
					else if (DialogWorldSpaceGUI.GetInputButton() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, s, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonUp() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, s, _ldcGuiButtonNewStyle);
						if (Event.current.type == EventType.Layout)
						{
							_lastCachedButtonIndex = -1;
							DialogUI.PlayButonAudio();
							return true;
						}
					}
					else
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.hover;
						GUI.Label(r, s, _ldcGuiButtonNewStyle);
					}
				}
				else
				{
					GUI.Label(r, s, GUI.skin.button);
				}
			}
			else if (GUI.Button(r, s))
			{
				DialogUI.PlayButonAudio();
				return true;
			}
			return false;
		}

		public bool LDC_GUIButton(Rect r, GUIContent c, int buttonIndex)
		{
			if (_usingRenderTextures)
			{
				_simulatedMouseIsOverRect = DialogWorldSpaceGUI.SimulatedMouseIsWithinRect(r, lastUsedMatrix);
				_ldcGuiButtonNewStyle = new GUIStyle(GUI.skin.button);
				if (DialogUI.currentSelection == buttonIndex && !_simulatedMouseIsOverRect)
				{
					_ldcGuiButtonNewStyle.normal = GUI.skin.button.focused;
					GUI.Label(r, c, _ldcGuiButtonNewStyle);
				}
				else if (_simulatedMouseIsOverRect)
				{
					if (!DialogWorldSpaceGUI.GetInputButton() && !DialogWorldSpaceGUI.GetInputButtonUp())
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonDown())
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						_lastCachedButtonIndex = buttonIndex;
					}
					else if (DialogWorldSpaceGUI.GetInputButton() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonUp() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						if (Event.current.type == EventType.Layout)
						{
							_lastCachedButtonIndex = -1;
							DialogUI.PlayButonAudio();
							return true;
						}
					}
					else
					{
						_ldcGuiButtonNewStyle.normal = GUI.skin.button.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
				}
				else
				{
					GUI.Label(r, c, GUI.skin.button);
				}
			}
			else if (GUI.Button(r, c))
			{
				DialogUI.PlayButonAudio();
				return true;
			}
			return false;
		}

		public bool LDC_GUIButton(Rect r, GUIContent c, GUIStyle s, int buttonIndex)
		{
			if (_usingRenderTextures)
			{
				_simulatedMouseIsOverRect = DialogWorldSpaceGUI.SimulatedMouseIsWithinRect(r, lastUsedMatrix);
				_ldcGuiButtonNewStyle = new GUIStyle(s);
				if (DialogUI.currentSelection == buttonIndex && !_simulatedMouseIsOverRect)
				{
					_ldcGuiButtonNewStyle.normal = s.focused;
					GUI.Label(r, c, _ldcGuiButtonNewStyle);
				}
				else if (_simulatedMouseIsOverRect)
				{
					if (!DialogWorldSpaceGUI.GetInputButton() && !DialogWorldSpaceGUI.GetInputButtonUp())
					{
						_ldcGuiButtonNewStyle.normal = s.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonDown())
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						_lastCachedButtonIndex = buttonIndex;
					}
					else if (DialogWorldSpaceGUI.GetInputButton() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonUp() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						if (Event.current.type == EventType.Layout)
						{
							_lastCachedButtonIndex = -1;
							DialogUI.PlayButonAudio();
							return true;
						}
					}
					else
					{
						_ldcGuiButtonNewStyle.normal = s.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
				}
				else
				{
					GUI.Label(r, c, s);
				}
			}
			else if (GUI.Button(r, c, s))
			{
				DialogUI.PlayButonAudio();
				return true;
			}
			return false;
		}

		public bool LDC_GUIButton(Rect r, GUIContent c, GUIStyle s, Rect svRect, Rect vrButtonRect, Rect blockSpacerRectWidth, Rect blockSpacerRectHeight, int buttonIndex)
		{
			if (_usingRenderTextures)
			{
				_simulatedMouseIsOverRect = DialogWorldSpaceGUI.SimulatedMouseIsWithinAScrollViewRect(vrButtonRect, blockSpacerRectWidth, blockSpacerRectHeight, svRect, lastUsedMatrix);
				_ldcGuiButtonNewStyle = new GUIStyle(s);
				if (DialogUI.currentSelection == buttonIndex && !_simulatedMouseIsOverRect)
				{
					_ldcGuiButtonNewStyle.normal = s.focused;
					GUI.Label(r, c, _ldcGuiButtonNewStyle);
				}
				else if (_simulatedMouseIsOverRect)
				{
					if (!DialogWorldSpaceGUI.GetInputButton() && !DialogWorldSpaceGUI.GetInputButtonUp())
					{
						_ldcGuiButtonNewStyle.normal = s.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonDown())
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						_lastCachedButtonIndex = buttonIndex;
					}
					else if (DialogWorldSpaceGUI.GetInputButton() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
					else if (DialogWorldSpaceGUI.GetInputButtonUp() && _lastCachedButtonIndex == buttonIndex)
					{
						_ldcGuiButtonNewStyle.normal = s.active;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
						if (Event.current.type == EventType.Layout)
						{
							_lastCachedButtonIndex = -1;
							DialogUI.PlayButonAudio();
							return true;
						}
					}
					else
					{
						_ldcGuiButtonNewStyle.normal = s.hover;
						GUI.Label(r, c, _ldcGuiButtonNewStyle);
					}
				}
				else
				{
					GUI.Label(r, c, s);
				}
			}
			else if (GUI.Button(r, c, s))
			{
				DialogUI.PlayButonAudio();
				return true;
			}
			return false;
		}

		public void MobileInputIconGridHelper()
		{
			if (Input.GetMouseButtonDown(0))
			{
				positionOnMouseDown = Input.mousePosition;
				mousePressInProgress = true;
				invalidateCurrentMousePress = false;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				positionOnMouseUp = Input.mousePosition;
				mousePressInProgress = false;
			}
			else if (!Input.GetMouseButton(0))
			{
				mousePressInProgress = false;
				invalidateCurrentMousePress = false;
			}
		}

		public bool MatrixMouseContains(Rect theRect)
		{
			Vector2[] polyPoints = TransformRect(theRect, GUI.matrix);
			if (ContainsPoint(polyPoints, new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)))
			{
				return true;
			}
			return false;
		}

		public bool MatrixTouchContains(Rect theRect)
		{
			Vector2[] polyPoints = TransformRect(theRect, GUI.matrix);
			if (Input.touchCount >= 1 && ContainsPoint(polyPoints, new Vector2(Input.touches[0].position.x, (float)Screen.height - Input.touches[0].position.y)))
			{
				return true;
			}
			return false;
		}

		public bool MatrixTouchContainsCustomMatrix(Rect theRect, Matrix4x4 matrix, Vector2 v2PointToTest)
		{
			Vector2[] polyPoints = TransformRect(theRect, matrix);
			if (ContainsPoint(polyPoints, v2PointToTest))
			{
				return true;
			}
			return false;
		}

		public Vector2[] TransformRect(Rect rect, Matrix4x4 matrix)
		{
			ArrayList arrayList = new ArrayList();
			Vector3 zero = Vector3.zero;
			zero = matrix.MultiplyPoint3x4(new Vector3(rect.x, rect.y, 1f));
			arrayList.Add(new Vector2(zero.x, zero.y));
			zero = matrix.MultiplyPoint3x4(new Vector3(rect.x + rect.width, rect.y, 1f));
			arrayList.Add(new Vector2(zero.x, zero.y));
			zero = matrix.MultiplyPoint3x4(new Vector3(rect.x + rect.width, rect.y + rect.height, 1f));
			arrayList.Add(new Vector2(zero.x, zero.y));
			zero = matrix.MultiplyPoint3x4(new Vector3(rect.x, rect.y + rect.height, 1f));
			arrayList.Add(new Vector2(zero.x, zero.y));
			return arrayList.ToArray(typeof(Vector2)) as Vector2[];
		}

		public bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			int num = polyPoints.Length - 1;
			bool flag = false;
			int num2 = 0;
			while (num2 < polyPoints.Length)
			{
				if (((polyPoints[num2].y <= p.y && p.y < polyPoints[num].y) || (polyPoints[num].y <= p.y && p.y < polyPoints[num2].y)) && p.x < (polyPoints[num].x - polyPoints[num2].x) * (p.y - polyPoints[num2].y) / (polyPoints[num].y - polyPoints[num2].y) + polyPoints[num2].x)
				{
					flag = !flag;
				}
				num = num2++;
			}
			return flag;
		}
	}
}
