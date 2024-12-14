using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DS_Navigation
	{
		public bool endFlag;

		public float secondsToDisplay = 3f;

		public bool hideNextButton;

		public bool hideDialogBackground;

		public int screenToLoadOnNext;

		public int screenToLoadOnYes;

		public int screenToLoadOnNo;

		public int[] multipleButtons = new int[3];

		[NonSerialized]
		public int[] multipleButtonsEvaluated = new int[3];

		public string navigationCallbackGOName = "";

		public string navigationCallbackFunctionName = "";

		public string navigationCallbackArg = "";

		public LogicStatementNavigation logicDefaultNavigate;

		public int logicDefaultNavigation = 1;

		public int logicDefaultGoToScreenRandomRangeMin = 1;

		public int logicDefaultGoToScreenRandomRangeMax = 2;

		public int logicDefaultGoToScreenUsingToken;

		public bool noPortraitFadeIn;

		public bool noPortraitFadeOut;

		public DIALOG_OVERRIDE_TRANSITION screenTransitionIn;

		public DIALOG_OVERRIDE_TRANSITION screenTransitionOut;

		public bool endDialogAfterThis;

		public bool destroyAtEnd;

		public GameObject instantiateDialogPrefabAtEnd;

		public string findAndPlayOtherDialogAtEnd = "";

		public bool useDifferentStartID;

		public int newStartID;

		public bool restartLevelAtEnd;

		public string loadLevelAtEnd = "";
	}
}
