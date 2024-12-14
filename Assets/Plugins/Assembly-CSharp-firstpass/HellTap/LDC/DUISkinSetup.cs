using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DUISkinSetup
	{
		public DUI_LocalizedSkins localizedSkinsHD = new DUI_LocalizedSkins("HD");

		public DUI_LocalizedSkins localizedSkins = new DUI_LocalizedSkins();

		[NonSerialized]
		public GUIStyle forceFocusButton;

		[NonSerialized]
		public GUIStyle originalFocusButton;
	}
}
