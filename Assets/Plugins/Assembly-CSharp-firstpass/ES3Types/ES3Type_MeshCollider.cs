using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "sharedMesh", "convex", "inflateMesh", "skinWidth", "enabled", "isTrigger", "contactOffset", "sharedMaterial" })]
	public class ES3Type_MeshCollider : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_MeshCollider()
			: base(typeof(MeshCollider))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MeshCollider meshCollider = (MeshCollider)obj;
			writer.WritePropertyByRef("sharedMesh", meshCollider.sharedMesh);
			writer.WriteProperty("convex", meshCollider.convex, ES3Type_bool.Instance);
			writer.WriteProperty("enabled", meshCollider.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("isTrigger", meshCollider.isTrigger, ES3Type_bool.Instance);
			writer.WriteProperty("contactOffset", meshCollider.contactOffset, ES3Type_float.Instance);
			writer.WriteProperty("material", meshCollider.sharedMaterial);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MeshCollider meshCollider = (MeshCollider)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "sharedMesh":
						meshCollider.sharedMesh = reader.Read<Mesh>(ES3Type_Mesh.Instance);
						break;
					case "convex":
						meshCollider.convex = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "enabled":
						meshCollider.enabled = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "isTrigger":
						meshCollider.isTrigger = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "contactOffset":
						meshCollider.contactOffset = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "material":
						meshCollider.sharedMaterial = reader.Read<PhysicMaterial>(ES3Type_PhysicMaterial.Instance);
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
