using System.Collections.Generic;
using System.Linq;

namespace HinputClasses.Internal
{
	public class AnyGamepadButton : Button
	{
		private readonly List<Pressable> buttons;

		public AnyGamepadButton(string pressableName, Gamepad gamepad, int index, bool isEnabled)
			: base(pressableName, gamepad, index, isEnabled)
		{
			buttons = Enumerable.ToList(Enumerable.Select(Hinput.gamepad, (Gamepad g) => g.buttons[index]));
		}

		protected override bool GetPressed()
		{
			return Enumerable.Any(buttons, (Pressable button) => button.simplePress.pressed);
		}
	}
}
