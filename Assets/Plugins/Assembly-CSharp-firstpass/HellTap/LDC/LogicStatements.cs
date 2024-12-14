using System;

namespace HellTap.LDC
{
	[Serializable]
	public class LogicStatements
	{
		public int token;

		public DS_LOGIC_OPERATOR theOperator;

		public string compare = "";

		public LogicStatementNavigation navigate;

		public int goToScreen = 1;

		public int goToScreenRandomRangeMin = 1;

		public int goToScreenRandomRangeMax = 2;

		public int goToScreenUsingToken;

		public bool endDialogAfterThis;

		public bool destroyAtEnd;

		public DS_LOGIC_TYPE logicType;

		public string ppKey = "ENTER_KEY";

		public DS_PLAYERPREF_LOGIC_OPERATOR ppOperator;

		public LogicStatementsExtra[] extraConditions = new LogicStatementsExtra[0];
	}
}
