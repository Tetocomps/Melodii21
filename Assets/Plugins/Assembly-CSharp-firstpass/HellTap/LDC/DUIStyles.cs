using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DUIStyles
	{
		public DUIStyleList[] list = new DUIStyleList[0];

		public DUIStyles()
		{
			list = new DUIStyleList[3];
			list[0] = new DUIStyleList();
			list[1] = new DUIStyleList();
			list[2] = new DUIStyleList();
			if (list != null && list[0] != null)
			{
				list[0].name = "Normal";
			}
			if (list != null && list[1] != null)
			{
				list[1].name = "Bold";
				list[1].bold = true;
			}
			if (list != null && list[2] != null)
			{
				list[2].name = "Italic";
				list[2].italic = true;
			}
		}
	}
}
