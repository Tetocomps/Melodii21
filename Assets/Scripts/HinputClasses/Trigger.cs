using HinputClasses.Internal;
using UnityEngine;

namespace HinputClasses
{
	public class Trigger : GamepadPressable
	{
		private readonly float initialValue;

		private bool hasBeenMoved;

		private float measuredPosition
		{
			get
			{
				if (Utils.os == Utils.OS.Mac)
				{
					return (Utils.GetAxis(Utils.os.ToString() + "_" + base.name) + 1f) / 2f;
				}
				return Utils.GetAxis(Utils.os.ToString() + "_" + base.name);
			}
		}

		public float position { get; private set; }

		public Trigger(string pressableName, Gamepad gamepad, int index, bool isEnabled)
			: base(pressableName, gamepad, index, isEnabled)
		{
			initialValue = measuredPosition;
		}

		public override void Update()
		{
			base.Update();
			position = GetPosition();
		}

		private float GetPosition()
		{
			if (!hasBeenMoved)
			{
				if (measuredPosition.IsEqualTo(initialValue))
				{
					return 0f;
				}
				hasBeenMoved = true;
			}
			if (Settings.triggerDeadZone.IsEqualTo(1f))
			{
				return 0f;
			}
			return Mathf.Clamp01((measuredPosition - Settings.triggerDeadZone) / (1f - Settings.triggerDeadZone));
		}

		protected override bool GetPressed()
		{
			return position >= Settings.triggerPressedZone;
		}
	}
}
