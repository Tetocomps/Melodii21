using UnityEngine;

namespace SonicBloom.Koreo.Demos
{
	[AddComponentMenu("Koreographer/Demos/Cube Scaler")]
	public class CubeScaler : MonoBehaviour
	{
		[EventID]
		public string eventID;

		public float minScale = 0.5f;

		public float maxScale = 1.5f;

		private void Start()
		{
			Koreographer.Instance.RegisterForEventsWithTime(eventID, AdjustScale);
		}

		private void OnDestroy()
		{
			if (Koreographer.Instance != null)
			{
				Koreographer.Instance.UnregisterForAllEvents(this);
			}
		}

		private void AdjustScale(KoreographyEvent evt, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
		{
			if (evt.HasCurvePayload())
			{
				float valueOfCurveAtTime = evt.GetValueOfCurveAtTime(sampleTime);
				base.transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, valueOfCurveAtTime);
			}
		}
	}
}
