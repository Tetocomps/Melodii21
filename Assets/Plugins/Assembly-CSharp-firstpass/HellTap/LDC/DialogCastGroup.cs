using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DialogCastGroup
	{
		public string name = "New Group";

		[NonSerialized]
		public bool open;

		public DialogCastActor[] actors = new DialogCastActor[0];
	}
}
