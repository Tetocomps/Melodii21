using UnityEngine;

namespace SonicBloom.Koreo.Demos
{
	[AddComponentMenu("Koreographer/Demos/UI Message Setter")]
	public class UIMessageSetter : MonoBehaviour
	{
		[EventID]
		public string eventID;

		public GUIStyle style;

		private KoreographyEvent curTextEvent;

		private void Start()
		{
			Koreographer.Instance.RegisterForEventsWithTime(eventID, UpdateText);
		}

		private void OnDestroy()
		{
			if (Koreographer.Instance != null)
			{
				Koreographer.Instance.UnregisterForAllEvents(this);
			}
		}

		private void OnGUI()
		{
			if (curTextEvent != null)
			{
				GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), curTextEvent.GetTextValue(), style);
			}
		}

		private void UpdateText(KoreographyEvent evt, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
		{
			if (evt.HasTextPayload())
			{
				if (curTextEvent == null || (evt != curTextEvent && evt.StartSample > curTextEvent.StartSample))
				{
					curTextEvent = evt;
				}
				if (curTextEvent.EndSample < sampleTime)
				{
					curTextEvent = null;
				}
			}
		}
	}
}
