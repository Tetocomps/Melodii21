using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "center", "size", "enabled", "isTrigger", "contactOffset", "sharedMaterial" })]
	public class ES3Type_BoxCollider : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_BoxCollider()
			: base(typeof(BoxCollider))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BoxCollider boxCollider = (BoxCollider)obj;
			writer.WriteProperty("center", boxCollider.center);
			writer.WriteProperty("size", boxCollider.size);
			writer.WriteProperty("enabled", boxCollider.enabled);
			writer.WriteProperty("isTrigger", boxCollider.isTrigger);
			writer.WriteProperty("contactOffset", boxCollider.contactOffset);
			writer.WritePropertyByRef("material", boxCollider.sharedMaterial);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BoxCollider boxCollider = (BoxCollider)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "center":
						boxCollider.center = reader.Read<Vector3>();
						break;
					case "size":
						boxCollider.size = reader.Read<Vector3>();
						break;
					case "enabled":
						boxCollider.enabled = reader.Read<bool>();
						break;
					case "isTrigger":
						boxCollider.isTrigger = reader.Read<bool>();
						break;
					case "contactOffset":
						boxCollider.contactOffset = reader.Read<float>();
						break;
					case "material":
						boxCollider.sharedMaterial = reader.Read<PhysicMaterial>();
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
