using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LogicStatementsExtra
	{
		public int token;

		public DS_LOGIC_OPERATOR theOperator;

		public string compare = "";

		public DS_LOGIC_TYPE logicType;

		public string ppKey = "ENTER_KEY";

		public DS_PLAYERPREF_LOGIC_OPERATOR ppOperator;
	}
}
