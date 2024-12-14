namespace HinputClasses.Internal
{
	public class Axis
	{
		private enum AT
		{
			None = 0,
			Axis = 1,
			Buttons = 2
		}

		private readonly string axisFullName;

		private readonly string positiveButtonFullName;

		private readonly string negativeButtonFullName;

		private AT AxisType;

		public Axis(string axisFullName, string positiveButtonFullName, string negativeButtonFullName)
		{
			this.axisFullName = axisFullName;
			this.positiveButtonFullName = positiveButtonFullName;
			this.negativeButtonFullName = negativeButtonFullName;
			if (Utils.os == Utils.OS.Windows)
			{
				AxisType = AT.Axis;
			}
			if (Utils.os == Utils.OS.Mac)
			{
				AxisType = AT.Buttons;
			}
		}

		public Axis(string axisFullName)
		{
			this.axisFullName = axisFullName;
			positiveButtonFullName = "";
			negativeButtonFullName = "";
			AxisType = AT.Axis;
		}

		public float GetPosition()
		{
			if (AxisType == AT.Axis)
			{
				return GetAxisValue();
			}
			if (AxisType == AT.Buttons)
			{
				return GetButtonValue();
			}
			float num = GetAxisValue();
			if (num.IsNotEqualTo(0f))
			{
				AxisType = AT.Axis;
			}
			else
			{
				num = GetButtonValue();
				if (num.IsNotEqualTo(0f))
				{
					AxisType = AT.Buttons;
				}
			}
			return num;
		}

		private float GetAxisValue()
		{
			return Utils.GetAxis(axisFullName, logError: false);
		}

		private float GetButtonValue()
		{
			float num = 0f;
			if (Utils.GetButton(positiveButtonFullName))
			{
				num += 1f;
			}
			if (Utils.GetButton(negativeButtonFullName))
			{
				num -= 1f;
			}
			return num;
		}
	}
}
