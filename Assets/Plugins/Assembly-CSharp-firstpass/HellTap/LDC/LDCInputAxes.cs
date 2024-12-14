using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LDCInputAxes
	{
		public string axis = "Horizontal";

		public bool invert;

		public LDCInputAxes()
		{
			axis = "New Axis";
			invert = false;
		}

		public LDCInputAxes(string axisName, bool invertAxis = false)
		{
			axis = axisName;
			invert = invertAxis;
		}
	}
}
