using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "bounciness", "friction" })]
	public class ES3Type_PhysicsMaterial2D : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3Type_PhysicsMaterial2D()
			: base(typeof(PhysicsMaterial2D))
		{
			Instance = this;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			PhysicsMaterial2D physicsMaterial2D = (PhysicsMaterial2D)obj;
			writer.WriteProperty("bounciness", physicsMaterial2D.bounciness, ES3Type_float.Instance);
			writer.WriteProperty("friction", physicsMaterial2D.friction, ES3Type_float.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			PhysicsMaterial2D physicsMaterial2D = (PhysicsMaterial2D)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "bounciness":
						physicsMaterial2D.bounciness = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "friction":
						physicsMaterial2D.friction = reader.Read<float>(ES3Type_float.Instance);
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
			PhysicsMaterial2D physicsMaterial2D = new PhysicsMaterial2D();
			ReadObject<T>(reader, physicsMaterial2D);
			return physicsMaterial2D;
		}
	}
}
