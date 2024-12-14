using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LDC_Filemanagement
	{
		public bool enable;

		public bool loadOnAwake = true;

		public bool saveOnDestroy = true;

		public bool saveOnApplicationPause;

		public string savePrefix = "";
	}
}
