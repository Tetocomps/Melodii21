using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LDC_ThirdPartySetup
	{
		public LDC_ThirdPartySetup_RTVoice[] rtVoice = new LDC_ThirdPartySetup_RTVoice[1];

		public LDC_ThirdPartySetup()
		{
			rtVoice = new LDC_ThirdPartySetup_RTVoice[1];
			rtVoice[0] = new LDC_ThirdPartySetup_RTVoice();
			if (rtVoice[0] != null)
			{
				rtVoice[0].voiceName = "Default RT-Voice";
				rtVoice[0].cultureCode = "en";
				rtVoice[0].rate = 1f;
				rtVoice[0].macSetup = new LDC_ThirdPartySetup_RTVoice_Setup();
				rtVoice[0].macSetup.voiceID = "Alex";
				rtVoice[0].windowsSetup = new LDC_ThirdPartySetup_RTVoice_Setup();
				rtVoice[0].windowsSetup.voiceID = "Microsoft Zira Desktop";
			}
		}
	}
}
