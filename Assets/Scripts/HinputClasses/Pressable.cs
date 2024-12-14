using UnityEngine;

namespace HinputClasses
{
	public abstract class Pressable
	{
		public readonly Gamepad gamepad;

		private bool isPressed;

		private float lastPressStart;

		private float penultimatePressStart;

		public string name { get; protected set; }

		public bool isEnabled { get; private set; }

		public bool pressed => ((Press)this).pressed;

		public bool released => ((Press)this).released;

		public bool justPressed => ((Press)this).justPressed;

		public bool justReleased => ((Press)this).justReleased;

		public float pressDuration => ((Press)this).pressDuration;

		public float releaseDuration => ((Press)this).releaseDuration;

		public Press simplePress { get; }

		public Press doublePress { get; }

		public Press longPress { get; }

		public void Enable()
		{
			isEnabled = true;
		}

		public void Disable()
		{
			Reset();
			isEnabled = false;
		}

		public void Reset()
		{
			penultimatePressStart = 0f;
		}

		public static implicit operator bool(Pressable pressable)
		{
			return (Press)pressable;
		}

		public static implicit operator Press(Pressable pressable)
		{
			if (Settings.defaultPressType == Settings.DefaultPressTypes.LongPress)
			{
				return pressable.longPress;
			}
			if (Settings.defaultPressType == Settings.DefaultPressTypes.DoublePress)
			{
				return pressable.doublePress;
			}
			return pressable.simplePress;
		}

		protected Pressable(Gamepad gamepad, bool isEnabled)
		{
			this.gamepad = gamepad;
			this.isEnabled = isEnabled;
			simplePress = new Press(this);
			longPress = new Press(this);
			doublePress = new Press(this);
		}

		protected abstract bool GetPressed();

		public virtual void Update()
		{
			if (isEnabled)
			{
				bool flag = isPressed;
				isPressed = GetPressed();
				if (isPressed && !flag)
				{
					penultimatePressStart = lastPressStart;
					lastPressStart = Time.unscaledTime;
				}
				simplePress.Update(isPressed);
				longPress.Update(isPressed && Time.unscaledTime - lastPressStart > Settings.longPressDuration);
				doublePress.Update(isPressed && lastPressStart - penultimatePressStart < Settings.doublePressDuration);
			}
		}
	}
}
