using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DSPlayerPrefsActions
	{
		public DSPlayerPrefsActionType action;

		public string key = "ENTER_KEY";

		public string stringArg = "";

		public float floatArg;

		public int intArg;
	}
}
