using UnityEngine;

namespace SonicBloom.Koreo.Demos
{
	[RequireComponent(typeof(Rigidbody))]
	[AddComponentMenu("Koreographer/Demos/Musical Impulse")]
	public class MusicalImpulse : MonoBehaviour
	{
		[EventID]
		public string eventID;

		public float jumpSpeed = 3f;

		private Rigidbody rigidbodyCom;

		private void Start()
		{
			Koreographer.Instance.RegisterForEvents(eventID, AddImpulse);
			rigidbodyCom = GetComponent<Rigidbody>();
		}

		private void OnDestroy()
		{
			if (Koreographer.Instance != null)
			{
				Koreographer.Instance.UnregisterForAllEvents(this);
			}
		}

		private void AddImpulse(KoreographyEvent evt)
		{
			Vector3 velocity = rigidbodyCom.velocity;
			velocity.y = jumpSpeed;
			rigidbodyCom.velocity = velocity;
		}
	}
}
