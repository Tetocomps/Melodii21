using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "center", "radius", "enabled", "isTrigger", "contactOffset", "sharedMaterial" })]
	public class ES3Type_SphereCollider : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_SphereCollider()
			: base(typeof(SphereCollider))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SphereCollider sphereCollider = (SphereCollider)obj;
			writer.WriteProperty("center", sphereCollider.center, ES3Type_Vector3.Instance);
			writer.WriteProperty("radius", sphereCollider.radius, ES3Type_float.Instance);
			writer.WriteProperty("enabled", sphereCollider.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("isTrigger", sphereCollider.isTrigger, ES3Type_bool.Instance);
			writer.WriteProperty("contactOffset", sphereCollider.contactOffset, ES3Type_float.Instance);
			writer.WritePropertyByRef("material", sphereCollider.sharedMaterial);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SphereCollider sphereCollider = (SphereCollider)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "center":
						sphereCollider.center = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "radius":
						sphereCollider.radius = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "enabled":
						sphereCollider.enabled = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "isTrigger":
						sphereCollider.isTrigger = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "contactOffset":
						sphereCollider.contactOffset = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "material":
						sphereCollider.sharedMaterial = reader.Read<PhysicMaterial>();
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
	}
}
