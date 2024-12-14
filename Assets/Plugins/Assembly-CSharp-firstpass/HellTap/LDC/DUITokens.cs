using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DUITokens
	{
		public string name = "NewToken";

		public string value = "";

		public DUI_LocalizedValue localizedValue = new DUI_LocalizedValue();

		[NonSerialized]
		public bool showLocalizedValues;
	}
}
