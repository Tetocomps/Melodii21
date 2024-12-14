namespace HinputClasses.Internal
{
	public abstract class GamepadPressable : Pressable
	{
		public readonly int index;

		protected GamepadPressable(string pressableName, Gamepad gamepad, int index, bool isEnabled)
			: base(gamepad, isEnabled)
		{
			this.index = index;
			base.name = gamepad.name + "_" + pressableName;
		}
	}
}
