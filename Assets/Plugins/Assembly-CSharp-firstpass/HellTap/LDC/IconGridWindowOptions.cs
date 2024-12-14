using System;

namespace HellTap.LDC
{
	[Serializable]
	public class IconGridWindowOptions
	{
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
	}
}
