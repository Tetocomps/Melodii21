using UnityEngine;

namespace HinputClasses
{
	public class Press
	{
		public Pressable button;

		public Gamepad gamepad;

		private int lastPressedFrame = -1;

		private int lastReleasedFrame = -1;

		private float lastPressed = float.NegativeInfinity;

		private float lastReleased = float.NegativeInfinity;

		public bool pressed { get; private set; }

		public bool released => !pressed;

		public bool justPressed
		{
			get
			{
				if (pressed)
				{
					return lastPressedFrame - lastReleasedFrame == 1;
				}
				return false;
			}
		}

		public bool justReleased
		{
			get
			{
				if (released)
				{
					return lastReleasedFrame - lastPressedFrame == 1;
				}
				return false;
			}
		}

		public float pressDuration => Mathf.Max(lastPressed - lastReleased, 0f);

		public float releaseDuration => Mathf.Max(lastReleased - lastPressed, 0f);

		public static implicit operator bool(Press press)
		{
			if (Settings.defaultPressFeature == Settings.DefaultPressFeatures.JustReleased)
			{
				return press.justReleased;
			}
			if (Settings.defaultPressFeature == Settings.DefaultPressFeatures.Released)
			{
				return press.released;
			}
			if (Settings.defaultPressFeature == Settings.DefaultPressFeatures.JustPressed)
			{
				return press.justPressed;
			}
			return press.pressed;
		}

		public Press(Pressable button)
		{
			this.button = button;
			gamepad = button.gamepad;
		}

		public void Update(bool isPressed)
		{
			pressed = isPressed;
			if (pressed)
			{
				lastPressedFrame = Time.frameCount;
				lastPressed = Time.time;
			}
			else
			{
				lastReleasedFrame = Time.frameCount;
				lastReleased = Time.time;
			}
		}
	}
}
