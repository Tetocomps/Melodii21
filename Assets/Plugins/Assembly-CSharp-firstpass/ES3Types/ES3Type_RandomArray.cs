using System;

namespace ES3Types
{
	public class ES3Type_RandomArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_RandomArray()
			: base(typeof(Random[]), ES3Type_Random.Instance)
		{
			Instance = this;
		}
	}
}
