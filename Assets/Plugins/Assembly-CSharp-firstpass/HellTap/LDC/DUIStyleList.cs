using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DUIStyleList
	{
		public string name = "NewStyle";

		[NonSerialized]
		public float cadenceDelay;

		[NonSerialized]
		public float typewriterSpeed = 1f;

		[NonSerialized]
		public float scrollingSpeed;

		public bool bold;

		public bool italic;

		public int fontSize;

		public DUIStyleColorAction colorAction;

		public Color32 textColor = Color.white;

		public Color32 altColor = Color.grey;

		public float colorFadeSpeed = 1f;

		[NonSerialized]
		public bool isEnabled;

		[NonSerialized]
		public string startCode = "";

		[NonSerialized]
		public string endCode = "";
	}
}
