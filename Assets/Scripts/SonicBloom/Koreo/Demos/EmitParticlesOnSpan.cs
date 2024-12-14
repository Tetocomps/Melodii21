using UnityEngine;

namespace SonicBloom.Koreo.Demos
{
	[RequireComponent(typeof(ParticleSystem))]
	[AddComponentMenu("Koreographer/Demos/Emit Particles On Span")]
	public class EmitParticlesOnSpan : MonoBehaviour
	{
		[EventID]
		public string eventID;

		public float particlesPerBeat = 100f;

		private ParticleSystem particleCom;

		private int lastEmitFrame = -1;

		private void Start()
		{
			particleCom = GetComponent<ParticleSystem>();
			Koreographer.Instance.RegisterForEvents(eventID, OnParticleControlEvent);
		}

		private void OnDestroy()
		{
			if (Koreographer.Instance != null)
			{
				Koreographer.Instance.UnregisterForAllEvents(this);
			}
		}

		private void OnParticleControlEvent(KoreographyEvent evt)
		{
			if (Time.frameCount != lastEmitFrame)
			{
				int count = (int)(particlesPerBeat * Koreographer.GetBeatTimeDelta());
				particleCom.Emit(count);
				lastEmitFrame = Time.frameCount;
			}
		}
	}
}
