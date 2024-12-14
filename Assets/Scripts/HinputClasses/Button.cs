using HinputClasses.Internal;

namespace HinputClasses
{
	public class Button : GamepadPressable
	{
		public Button(string pressableName, Gamepad gamepad, int index, bool isEnabled)
			: base(pressableName, gamepad, index, isEnabled)
		{
		}

		protected override bool GetPressed()
		{
			try
			{
				return Utils.GetButton(Utils.os.ToString() + "_" + base.name);
			}
			catch
			{
			}
			return false;
		}
	}
}
