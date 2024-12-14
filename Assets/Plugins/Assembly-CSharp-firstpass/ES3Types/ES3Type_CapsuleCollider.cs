using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "center", "radius", "height", "direction", "enabled", "isTrigger", "contactOffset", "sharedMaterial" })]
	public class ES3Type_CapsuleCollider : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_CapsuleCollider()
			: base(typeof(CapsuleCollider))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CapsuleCollider capsuleCollider = (CapsuleCollider)obj;
			writer.WriteProperty("center", capsuleCollider.center, ES3Type_Vector3.Instance);
			writer.WriteProperty("radius", capsuleCollider.radius, ES3Type_float.Instance);
			writer.WriteProperty("height", capsuleCollider.height, ES3Type_float.Instance);
			writer.WriteProperty("direction", capsuleCollider.direction, ES3Type_int.Instance);
			writer.WriteProperty("enabled", capsuleCollider.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("isTrigger", capsuleCollider.isTrigger, ES3Type_bool.Instance);
			writer.WriteProperty("contactOffset", capsuleCollider.contactOffset, ES3Type_float.Instance);
			writer.WritePropertyByRef("material", capsuleCollider.sharedMaterial);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CapsuleCollider capsuleCollider = (CapsuleCollider)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "center":
						capsuleCollider.center = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "radius":
						capsuleCollider.radius = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "height":
						capsuleCollider.height = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "direction":
						capsuleCollider.direction = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "enabled":
						capsuleCollider.enabled = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "isTrigger":
						capsuleCollider.isTrigger = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "contactOffset":
						capsuleCollider.contactOffset = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "material":
						capsuleCollider.sharedMaterial = reader.Read<PhysicMaterial>();
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
