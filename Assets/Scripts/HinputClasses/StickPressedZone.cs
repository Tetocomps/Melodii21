using HinputClasses.Internal;

namespace HinputClasses
{
	public class StickPressedZone : StickPressable
	{
		public StickPressedZone(string pressableName, Stick stick)
			: base(pressableName, stick)
		{
		}

		protected override bool GetPressed()
		{
			return stick.distance > Settings.stickPressedZone;
		}
	}
}
