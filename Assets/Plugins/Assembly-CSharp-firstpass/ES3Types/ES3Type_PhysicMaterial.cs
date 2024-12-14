using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "dynamicFriction", "staticFriction", "bounciness", "frictionCombine", "bounceCombine" })]
	public class ES3Type_PhysicMaterial : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3Type_PhysicMaterial()
			: base(typeof(PhysicMaterial))
		{
			Instance = this;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			PhysicMaterial physicMaterial = (PhysicMaterial)obj;
			writer.WriteProperty("dynamicFriction", physicMaterial.dynamicFriction, ES3Type_float.Instance);
			writer.WriteProperty("staticFriction", physicMaterial.staticFriction, ES3Type_float.Instance);
			writer.WriteProperty("bounciness", physicMaterial.bounciness, ES3Type_float.Instance);
			writer.WriteProperty("frictionCombine", physicMaterial.frictionCombine);
			writer.WriteProperty("bounceCombine", physicMaterial.bounceCombine);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			PhysicMaterial physicMaterial = (PhysicMaterial)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "dynamicFriction":
						physicMaterial.dynamicFriction = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "staticFriction":
						physicMaterial.staticFriction = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "bounciness":
						physicMaterial.bounciness = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "frictionCombine":
						physicMaterial.frictionCombine = reader.Read<PhysicMaterialCombine>();
						break;
					case "bounceCombine":
						physicMaterial.bounceCombine = reader.Read<PhysicMaterialCombine>();
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
			PhysicMaterial physicMaterial = new PhysicMaterial();
			ReadObject<T>(reader, physicMaterial);
			return physicMaterial;
		}
	}
}
