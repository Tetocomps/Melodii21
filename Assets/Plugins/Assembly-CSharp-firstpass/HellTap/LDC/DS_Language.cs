using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DS_Language
	{
		public string actorName = "";

		public string dialogText = "";

		public bool changeAudio;

		public string soundToLoad = "";

		public float soundPitch = 1f;

		public string customButton1 = "";

		public string customButton2 = "";

		public string[] multipleButtons = new string[3] { "", "", "" };

		public string dataEntryDefaultValue = "";

		public string passwordAnswer = "";

		public string[] logicStatementCompare;
	}
}
