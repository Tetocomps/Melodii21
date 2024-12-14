using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DSTokenActions
	{
		public int index;

		public DSTokenActionType action;

		public string argument = "";

		public bool localize;

		public DS_LocalizedTokenArgument localizedArgument;
	}
}
