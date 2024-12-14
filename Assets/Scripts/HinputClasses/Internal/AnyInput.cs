using System.Collections.Generic;
using System.Linq;

namespace HinputClasses.Internal
{
	public class AnyInput : GamepadPressable
	{
		private readonly List<Pressable> inputs;

		public AnyInput(string pressableName, Gamepad gamepad, bool isEnabled)
			: base(pressableName, gamepad, -1, isEnabled)
		{
			inputs = new List<Pressable>
			{
				gamepad.A,
				gamepad.B,
				gamepad.X,
				gamepad.Y,
				gamepad.leftBumper,
				gamepad.rightBumper,
				gamepad.leftTrigger,
				gamepad.rightTrigger,
				gamepad.back,
				gamepad.start,
				gamepad.leftStickClick,
				gamepad.rightStickClick,
				gamepad.leftStick.inPressedZone,
				gamepad.rightStick.inPressedZone,
				gamepad.dPad.inPressedZone
			};
		}

		protected override bool GetPressed()
		{
			return Enumerable.Any(inputs, (Pressable input) => input.simplePress.pressed);
		}
	}
}
