using HinputClasses.Internal;

namespace HinputClasses
{
	public class StickDirection : StickPressable
	{
		private float angle { get; }

		public StickDirection(string pressableName, float angle, Stick stick)
			: base(pressableName, stick)
		{
			this.angle = angle;
		}

		protected override bool GetPressed()
		{
			if (stick.PushedTowards(angle))
			{
				return stick.distance > Settings.stickPressedZone;
			}
			return false;
		}
	}
}
