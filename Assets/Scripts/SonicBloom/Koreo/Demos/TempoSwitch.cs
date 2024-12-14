using UnityEngine;

namespace SonicBloom.Koreo.Demos
{
	[AddComponentMenu("Koreographer/Demos/Tempo Switch")]
	public class TempoSwitch : MonoBehaviour
	{
		public Behaviour[] quarterNoteGroup;

		public Behaviour[] eighthNoteGroup;

		private int lastQuarterNote;

		private int lastEighthNote = -1;

		private void Update()
		{
			int num = Mathf.FloorToInt(Koreographer.GetBeatTime());
			if (num != lastQuarterNote)
			{
				SwitchGroup(quarterNoteGroup, lastQuarterNote % 2 != 0);
				lastQuarterNote = num;
			}
			int num2 = Mathf.FloorToInt(Koreographer.GetBeatTime(null, 2));
			if (num2 != lastEighthNote)
			{
				SwitchGroup(eighthNoteGroup, lastEighthNote % 2 != 0);
				lastEighthNote = num2;
			}
		}

		private void SwitchGroup(Behaviour[] behaviours, bool bGroupOn)
		{
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].enabled = bGroupOn;
			}
		}
	}
}
