using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DUI_LocalizedSkins
	{
		public string english = "UI/DialogSkin - English";

		public string chinese = "UI/DialogSkin - Chinese";

		public string korean = "UI/DialogSkin - Korean";

		public string japanese = "UI/DialogSkin - Japanese";

		public string german = "UI/DialogSkin - German";

		public string french = "UI/DialogSkin - French";

		public string spanish = "UI/DialogSkin - Spanish";

		public string italian = "UI/DialogSkin - Italian";

		public string portuguese = "UI/DialogSkin - Portuguese";

		public string russian = "UI/DialogSkin - Russian";

		public DUI_LocalizedSkins()
		{
			new DUI_LocalizedSkins("");
		}

		public DUI_LocalizedSkins(string style)
		{
			if (style == "HD")
			{
				english = "UIHD/DialogSkinHD - English";
				chinese = "UIHD/DialogSkinHD - Chinese";
				korean = "UIHD/DialogSkinHD - Korean";
				japanese = "UIHD/DialogSkinHD - Japanese";
				german = "UIHD/DialogSkinHD - German";
				french = "UIHD/DialogSkinHD - French";
				spanish = "UIHD/DialogSkinHD - Spanish";
				italian = "UIHD/DialogSkinHD - Italian";
				portuguese = "UIHD/DialogSkinHD - Portuguese";
				russian = "UIHD/DialogSkinHD - Russian";
			}
			else
			{
				english = "UI/DialogSkin - English";
				chinese = "UI/DialogSkin - Chinese";
				korean = "UI/DialogSkin - Korean";
				japanese = "UI/DialogSkin - Japanese";
				german = "UI/DialogSkin - German";
				french = "UI/DialogSkin - French";
				spanish = "UI/DialogSkin - Spanish";
				italian = "UI/DialogSkin - Italian";
				portuguese = "UI/DialogSkin - Portuguese";
				russian = "UI/DialogSkin - Russian";
			}
		}
	}
}
