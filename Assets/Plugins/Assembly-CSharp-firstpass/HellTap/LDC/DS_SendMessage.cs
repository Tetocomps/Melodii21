using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DS_SendMessage
	{
		public string findDestination = "";

		public GameObject destination;

		public string functionName = "NameOfFunction";

		public DS_SendMessageArg argType;

		public string stringArg = "";

		public float intArg;

		public float floatArg;

		public bool booleanArg;

		public GameObject goArg;

		public Transform transformArg;
	}
}
