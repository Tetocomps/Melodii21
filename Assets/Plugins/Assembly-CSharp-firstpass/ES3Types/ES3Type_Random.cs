using System;
using System.Collections;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "inext", "inextp", "SeedArray" })]
	public class ES3Type_Random : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3Type_Random()
			: base(typeof(Random))
		{
			Instance = this;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			Random objectContainingField = (Random)obj;
			writer.WritePrivateField("inext", objectContainingField);
			writer.WritePrivateField("inextp", objectContainingField);
			writer.WritePrivateField("SeedArray", objectContainingField);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			Random objectContainingField = (Random)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "inext":
						reader.SetPrivateField("inext", reader.Read<int>(), objectContainingField);
						break;
					case "inextp":
						reader.SetPrivateField("inextp", reader.Read<int>(), objectContainingField);
						break;
					case "SeedArray":
						reader.SetPrivateField("SeedArray", reader.Read<int[]>(), objectContainingField);
						break;
					default:
						reader.Skip();
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			Random random = new Random();
			ReadObject<T>(reader, random);
			return random;
		}
	}
}
