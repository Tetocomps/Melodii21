using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class IconGridLayout
	{
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
	}
}
