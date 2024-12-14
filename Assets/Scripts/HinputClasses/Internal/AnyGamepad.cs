using System.Linq;
using UnityEngine;

namespace HinputClasses.Internal
{
	public class AnyGamepad : Gamepad
	{
		public override string type => "AnyGamepad";

		public override bool isConnected => Enumerable.Any(Hinput.gamepad, (Gamepad gamepad) => gamepad.isConnected);

		public override float leftVibration => -1f;

		public override float rightVibration => -1f;

		public AnyGamepad()
		{
			base.index = -1;
			base.name = "AnyGamepad";
			base.isEnabled = !Settings.disableAnyGamepad;
			base.A = new AnyGamepadButton("A", this, 0, !Settings.disableA);
			base.B = new AnyGamepadButton("B", this, 1, !Settings.disableB);
			base.X = new AnyGamepadButton("X", this, 2, !Settings.disableX);
			base.Y = new AnyGamepadButton("Y", this, 3, !Settings.disableY);
			base.leftBumper = new AnyGamepadButton("LeftBumper", this, 4, !Settings.disableLeftBumper);
			base.rightBumper = new AnyGamepadButton("RightBumper", this, 5, !Settings.disableRightBumper);
			base.back = new AnyGamepadButton("Back", this, 8, !Settings.disableBack);
			base.start = new AnyGamepadButton("Start", this, 9, !Settings.disableStart);
			base.leftStickClick = new AnyGamepadButton("LeftStickClick", this, 10, !Settings.disableLeftStickClick);
			base.rightStickClick = new AnyGamepadButton("RightStickClick", this, 11, !Settings.disableRightStickClick);
			base.leftStick = new AnyGamepadStick("LeftStick", this, 0);
			base.rightStick = new AnyGamepadStick("RightStick", this, 1);
			base.dPad = new AnyGamepadStick("DPad", this, 2);
			vibration = new Vibration(-1);
			SetUp();
		}

		protected override bool UpdateIsRequired()
		{
			return base.isEnabled;
		}

		public override void Vibrate()
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate();
			});
		}

		public override void Vibrate(float duration)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(duration);
			});
		}

		public override void Vibrate(float leftIntensity, float rightIntensity)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(leftIntensity, rightIntensity);
			});
		}

		public override void Vibrate(float leftIntensity, float rightIntensity, float duration)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(leftIntensity, rightIntensity, duration);
			});
		}

		public override void Vibrate(AnimationCurve curve)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(curve);
			});
		}

		public override void Vibrate(AnimationCurve leftCurve, AnimationCurve rightCurve)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(leftCurve, rightCurve);
			});
		}

		public override void Vibrate(VibrationPreset vibrationPreset)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(vibrationPreset);
			});
		}

		public override void Vibrate(VibrationPreset vibrationPreset, float duration)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(vibrationPreset, duration);
			});
		}

		public override void Vibrate(VibrationPreset vibrationPreset, float leftIntensity, float rightIntensity)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(vibrationPreset, leftIntensity, rightIntensity);
			});
		}

		public override void Vibrate(VibrationPreset vibrationPreset, float leftIntensity, float rightIntensity, float duration)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Vibrate(vibrationPreset, leftIntensity, rightIntensity, duration);
			});
		}

		public override void VibrateAdvanced(float leftIntensity, float rightIntensity)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.VibrateAdvanced(leftIntensity, rightIntensity);
			});
		}

		public override void StopVibration()
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.StopVibration();
			});
		}

		public override void StopVibration(float duration)
		{
			Enumerable.ToList(Enumerable.Take(Hinput.gamepad, 4)).ForEach(delegate(Gamepad gamepad)
			{
				gamepad.StopVibration(duration);
			});
		}
	}
}
