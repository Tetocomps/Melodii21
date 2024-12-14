using System.Collections.Generic;
using HinputClasses.Internal;
using UnityEngine;

namespace HinputClasses
{
	public class Gamepad
	{
		private bool enableWhenConnected = true;

		protected Vibration vibration;

		public int index { get; protected set; }

		public string name { get; protected set; }

		public virtual string type
		{
			get
			{
				if (Input.GetJoystickNames().Length <= index)
				{
					return "";
				}
				return Input.GetJoystickNames()[index];
			}
		}

		public virtual bool isConnected => type != "";

		public bool isEnabled { get; protected set; }

		public Button A { get; protected set; }

		public Button B { get; protected set; }

		public Button X { get; protected set; }

		public Button Y { get; protected set; }

		public Button leftBumper { get; protected set; }

		public Button rightBumper { get; protected set; }

		public Button back { get; protected set; }

		public Button start { get; protected set; }

		public Button leftStickClick { get; protected set; }

		public Button rightStickClick { get; protected set; }

		public Trigger leftTrigger { get; private set; }

		public Trigger rightTrigger { get; private set; }

		public Stick leftStick { get; protected set; }

		public Stick rightStick { get; protected set; }

		public Stick dPad { get; protected set; }

		public Pressable anyInput { get; private set; }

		public List<Stick> sticks { get; private set; }

		public List<Pressable> buttons { get; private set; }

		public virtual float leftVibration => vibration.currentLeft;

		public virtual float rightVibration => vibration.currentRight;

		public void Enable()
		{
			isEnabled = true;
		}

		public void Disable()
		{
			buttons.ForEach(delegate(Pressable button)
			{
				button.Reset();
			});
			sticks.ForEach(delegate(Stick stick)
			{
				stick.Reset();
			});
			anyInput.Reset();
			StopVibration();
			isEnabled = false;
		}

		protected Gamepad()
		{
		}

		public Gamepad(int index)
		{
			this.index = index;
			name = "Gamepad" + index;
			isEnabled = false;
			enableWhenConnected = index < Settings.amountOfGamepads;
			A = new Button("A", this, 0, !Settings.disableA);
			B = new Button("B", this, 1, !Settings.disableB);
			X = new Button("X", this, 2, !Settings.disableX);
			Y = new Button("Y", this, 3, !Settings.disableY);
			leftBumper = new Button("LeftBumper", this, 4, !Settings.disableLeftBumper);
			rightBumper = new Button("RightBumper", this, 5, !Settings.disableRightBumper);
			back = new Button("Back", this, 8, !Settings.disableBack);
			start = new Button("Start", this, 9, !Settings.disableStart);
			leftStickClick = new Button("LeftStickClick", this, 10, !Settings.disableLeftStickClick);
			rightStickClick = new Button("RightStickClick", this, 11, !Settings.disableRightStickClick);
			leftStick = new Stick("LeftStick", this, 0, !Settings.disableLeftStick);
			rightStick = new Stick("RightStick", this, 1, !Settings.disableRightStick);
			dPad = new Stick("DPad", this, 2, !Settings.disableDPad);
			vibration = new Vibration(index);
			SetUp();
		}

		protected void SetUp()
		{
			leftTrigger = new Trigger("LeftTrigger", this, 6, !Settings.disableLeftTrigger);
			rightTrigger = new Trigger("RightTrigger", this, 7, !Settings.disableRightTrigger);
			anyInput = new AnyInput("AnyInput", this, !Settings.disableAnyInput);
			sticks = new List<Stick> { leftStick, rightStick, dPad };
			buttons = new List<Pressable>
			{
				A, B, X, Y, leftBumper, rightBumper, leftTrigger, rightTrigger, back, start,
				leftStickClick, rightStickClick
			};
		}

		public void Update()
		{
			if (UpdateIsRequired())
			{
				buttons.ForEach(delegate(Pressable button)
				{
					button.Update();
				});
				sticks.ForEach(delegate(Stick stick)
				{
					stick.Update();
				});
				anyInput.Update();
				vibration.Update();
			}
		}

		protected virtual bool UpdateIsRequired()
		{
			if (!isEnabled && enableWhenConnected && isConnected)
			{
				Enable();
				enableWhenConnected = false;
			}
			return isEnabled;
		}

		public virtual void Vibrate()
		{
			vibration.Vibrate(Settings.vibrationDefaultLeftIntensity, Settings.vibrationDefaultRightIntensity, Settings.vibrationDefaultDuration);
		}

		public virtual void Vibrate(float duration)
		{
			vibration.Vibrate(Settings.vibrationDefaultLeftIntensity, Settings.vibrationDefaultRightIntensity, duration);
		}

		public virtual void Vibrate(float leftIntensity, float rightIntensity)
		{
			vibration.Vibrate(leftIntensity, rightIntensity, Settings.vibrationDefaultDuration);
		}

		public virtual void Vibrate(float leftIntensity, float rightIntensity, float duration)
		{
			vibration.Vibrate(leftIntensity, rightIntensity, duration);
		}

		public virtual void Vibrate(AnimationCurve curve)
		{
			vibration.Vibrate(curve, curve);
		}

		public virtual void Vibrate(AnimationCurve leftCurve, AnimationCurve rightCurve)
		{
			vibration.Vibrate(leftCurve, rightCurve);
		}

		public virtual void Vibrate(VibrationPreset vibrationPreset)
		{
			vibration.Vibrate(vibrationPreset, 1f, 1f, 1f);
		}

		public virtual void Vibrate(VibrationPreset vibrationPreset, float duration)
		{
			vibration.Vibrate(vibrationPreset, 1f, 1f, duration);
		}

		public virtual void Vibrate(VibrationPreset vibrationPreset, float leftIntensity, float rightIntensity)
		{
			vibration.Vibrate(vibrationPreset, leftIntensity, rightIntensity, 1f);
		}

		public virtual void Vibrate(VibrationPreset vibrationPreset, float leftIntensity, float rightIntensity, float duration)
		{
			vibration.Vibrate(vibrationPreset, leftIntensity, rightIntensity, duration);
		}

		public virtual void VibrateAdvanced(float leftIntensity, float rightIntensity)
		{
			vibration.VibrateAdvanced(leftIntensity, rightIntensity);
		}

		public virtual void StopVibration()
		{
			vibration.StopVibration(0f);
		}

		public virtual void StopVibration(float duration)
		{
			vibration.StopVibration(duration);
		}
	}
}
