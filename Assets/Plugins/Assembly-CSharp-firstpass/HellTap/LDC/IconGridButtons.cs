using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class IconGridButtons
	{
		public string title = "Button Title";

		public string label = "Label";

		public string failedLabel = "Unavailable";

		public Font overrideFont;

		public bool localizeTitle;

		public DS_LocalizedTokenArgument localizedTitle = new DS_LocalizedTokenArgument();

		public bool requiresLogic;

		public LogicStatements logicStatements = new LogicStatements();

		public LDC_IFLOGICFAILS ifLogicFails = LDC_IFLOGICFAILS.DisableButton;

		public LDC_IFLOGICSUCCEEDS ifLogicSucceeds;

		[NonSerialized]
		public bool logicFailed;

		public Texture2D buttonIcon;

		public Vector2 animatedButtonIcon = new Vector2(-1f, -1f);

		public static DialogCastActor dca;

		public Rect currentRect;

		public int nextID;
	}
}
