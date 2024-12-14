using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DialogUIOptions
	{
		[Header("Transition Options")]
		public float fadeDuration = 0.75f;

		public float backgroundFadeDuration = 0.75f;

		public float backgroundFadeOverrideDuration = 0.333f;

		public bool usePortraitFades = true;

		public bool useButtonFades = true;

		public bool useTextFades = true;

		public bool usePortraitTransitions = true;

		public bool useButtonTransitions = true;

		public DUI_TransitionEffects defaultScreenTransition;

		[Header("Interface Options")]
		public bool drawTitleTextShadows = true;

		public bool drawBodyTextShadows;

		public bool hideBackgroundFromUI;

		public bool hideChoicePanelFromUI;

		public bool hideAllTextFromUI;

		public bool hideAllTitleTextFromUI;

		public bool hideAllBodyTextFromUI;

		public bool hideAllSingleButtonsFromUI;

		public bool ignoreAllDialogDuration;

		public bool ResizeTextIfNoPortraitsAreSetup = true;

		public bool fadeOutAudioVolumeWithScreens = true;

		public bool stopAudioWhenScreenEnds = true;

		public bool stopAudioWhenDialogEnds = true;

		public bool makeAutoscrollNextScreensManualOnTap;

		[Header("Scrollable Text Options")]
		public DIALOG_SCROLLING scrollableDialogText = DIALOG_SCROLLING.AutomaticScrolling;

		public float automaticScrollingSpeed = 1f;

		public float scrollableTextExtraFooterSpace = 32f;

		[NonSerialized]
		public float autoScrollingHeight;

		public Vector2 autoScrollingValue = Vector2.zero;

		[NonSerialized]
		public Vector2 autoScrollingFixedValue = Vector2.zero;

		[Header("Typewriter Effect Options")]
		public bool useTypeWriterEffectForText = true;

		public float typeWriterEffectSpeed = 1f;

		public bool completeTypeWriterEffectOnClickOrTouch = true;

		[Header("Audio Options")]
		public AudioClip playTypeWriterAudio;

		public AudioClip playAudioOnButton;

		public AudioClip playAudioOnFocus;

		[Header("Input Controls")]
		public KeyCode[] selectGuiWithTheseKeycodes = new KeyCode[2]
		{
			KeyCode.KeypadEnter,
			KeyCode.Return
		};

		public KeyCode[] focusNextGuiWithTheseKeycodes = new KeyCode[3]
		{
			KeyCode.DownArrow,
			KeyCode.RightArrow,
			KeyCode.Tab
		};

		public KeyCode[] focusPreviousGuiWithTheseKeycodes = new KeyCode[2]
		{
			KeyCode.UpArrow,
			KeyCode.LeftArrow
		};

		public LDCInputAxes[] focusGuiWithTheseAxes = new LDCInputAxes[0];

		[Header("Storage Options")]
		public bool useGlobalTokens;

		public string audioFilepathPrefix = "Audio/";

		[Header("Debug Verbosity")]
		public bool debugSystemMessagesInConsole = true;

		public bool debugActionMessagesInConsole = true;

		public bool debugLogicMessagesInConsole = true;

		[NonSerialized]
		public float focusButonTimeOut;
	}
}
