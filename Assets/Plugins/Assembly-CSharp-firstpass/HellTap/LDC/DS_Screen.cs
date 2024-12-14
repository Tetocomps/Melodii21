using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DS_Screen
	{
		public DIALOGSTYLE dialogStyle;

		public string actorName = "";

		public string dialogText = "";

		public Texture2D portrait;

		public string soundToLoad = "";

		public float soundPitch = 1f;

		public bool soundFlag;

		public bool portraitFlag;

		public string customButton1 = "OK";

		public string customButton2 = "Cancel";

		public string[] multipleButtons = new string[3] { "Option 1", "Option 2", "Option 3" };

		public DIALOG_OVERRIDE_YESNO typeWriterOptions;

		public DIALOG_OVERRIDE_SCROLLING scrollingOptions;

		public Texture2D buttonIcon1;

		public Texture2D buttonIcon2;

		public Texture2D[] multipleButtonsIcon = new Texture2D[3];

		[NonSerialized]
		public Texture2D[] multipleButtonsIconEvaluated = new Texture2D[3];

		public Vector2 animatedButtonIcon1 = new Vector2(-1f, -1f);

		public Vector2 animatedButtonIcon2 = new Vector2(-1f, -1f);

		public Vector2[] animatedMultipleButtonsIcon = new Vector2[3]
		{
			new Vector2(-1f, -1f),
			new Vector2(-1f, -1f),
			new Vector2(-1f, -1f)
		};

		[NonSerialized]
		public Vector2[] animatedMultipleButtonsIconEvaluated = new Vector2[3]
		{
			new Vector2(-1f, -1f),
			new Vector2(-1f, -1f),
			new Vector2(-1f, -1f)
		};

		public Vector2 titleOffset = new Vector2(64f, 64f);

		public Vector2 subtitleOffset = new Vector2(64f, 128f);

		public Vector2 titleSize = new Vector2(960f, 640f);

		public int titleFontSize;

		public TextAnchor titleAllignment;

		public Color titleColor = Color.white;

		public Font overrideTitleFont;

		public Color subtitleColor = Color.white;

		public Vector2 subtitleSize = new Vector2(960f, 640f);

		public int subtitleFontSize;

		public TextAnchor subtitleAllignment;

		public Font overrideSubtitleFont;

		[NonSerialized]
		public string[] multipleButtonsEvaluated = new string[3] { "Option 1", "Option 2", "Option 3" };

		public bool[] multipleRequiresLogic = new bool[3];

		public LogicStatements[] multipleLogic = new LogicStatements[3];

		public int dataEntryToken;

		public DS_DATA_FORMAT dataEntryFormat;

		public int dataEntryCharacterLimit = 25;

		public string dataEntryDefaultValue = "";

		public DS_DATA_ANCHOR dataEntryAnchor = DS_DATA_ANCHOR.Bottom;

		public bool passwordMatchToToken;

		public string passwordAnswer = "";

		public bool passwordCaseSensitive;

		public bool passwordMask;

		public LogicStatements[] logicStatements = new LogicStatements[0];

		public Vector2 animatedPortrait = new Vector2(-1f, -1f);

		public Texture2D popupImage;

		public int popupSizeX = 1024;

		public int popupSizeY = 600;

		public int popupButtonSizeX = 280;

		public int popupButtonSizeY = 128;

		public int popupButtonSpacer = 32;

		public float popupBackgroundAlpha = 1f;

		public Vector2 popupImageAnim = new Vector2(-1f, -1f);

		public POPUP_OPTIONS popupOptions;

		public int IG_WindowSizeX = 1474;

		public int IG_WindowSizeY = 1024;

		public int IG_WindowOffsetX;

		public int IG_WindowOffsetY;

		public bool IG_useXScrolling;

		public bool IG_useYScrolling;

		public bool IG_WindowShowTitle = true;

		public bool IG_WindowShowSubtitle = true;

		public bool IG_AddSpaceBetweenSubtitleAndContent;

		public bool IG_showPanelBG = true;

		public float IG_BackgroundAlpha = 1f;

		public int IG_iconSizeX = 150;

		public int IG_iconSizeY = 150;

		public int IG_iconsPerRow = 4;

		public int IG_IconSpacer = 48;

		public int IG_AddInnerIconSpacing = 16;

		public bool IG_showIconLabels = true;

		public int IG_iconLabelSize = 32;

		public bool IG_firstIconIsCloseButton = true;

		public int IG_closeButtonSize = 100;

		public bool IG_showButtonBackgrounds = true;

		public TextAnchor IG_buttonAllignment = TextAnchor.MiddleCenter;

		public ImagePosition IG_buttonImagePosition = ImagePosition.ImageOnly;

		public IconGridButtons[] IG_buttons = new IconGridButtons[1];

		public IconGridButtons[] IG_buttonsEvaluated = new IconGridButtons[1];
	}
}
