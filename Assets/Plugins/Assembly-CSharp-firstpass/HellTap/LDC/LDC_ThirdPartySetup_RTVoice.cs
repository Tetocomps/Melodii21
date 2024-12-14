using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LDC_ThirdPartySetup_RTVoice
	{
		public string voiceName = "Give This Voice A Name";

		public string cultureCode = "en";

		public float rate = 1f;

		public bool onlyUseVoiceInEditor;

		public bool playWhenNoDialogAudioExists = true;

		public LDC_ThirdPartySetup_RTVoice_Setup macSetup = new LDC_ThirdPartySetup_RTVoice_Setup();

		public LDC_ThirdPartySetup_RTVoice_Setup windowsSetup = new LDC_ThirdPartySetup_RTVoice_Setup();
	}
}
