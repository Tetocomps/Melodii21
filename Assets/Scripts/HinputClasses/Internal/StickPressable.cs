namespace HinputClasses.Internal
{
	public abstract class StickPressable : Pressable
	{
		public readonly Stick stick;

		protected StickPressable(string pressableName, Stick stick)
			: base(stick.gamepad, isEnabled: true)
		{
			this.stick = stick;
			base.name = stick.name + "_" + pressableName;
		}
	}
}
