using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "points", "pathCount", "paths", "density", "isTrigger", "usedByEffector", "offset", "sharedMaterial", "enabled" })]
	public class ES3Type_PolygonCollider2D : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_PolygonCollider2D()
			: base(typeof(PolygonCollider2D))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			PolygonCollider2D polygonCollider2D = (PolygonCollider2D)obj;
			writer.WriteProperty("points", polygonCollider2D.points, ES3Type_Vector2Array.Instance);
			writer.WriteProperty("pathCount", polygonCollider2D.pathCount, ES3Type_int.Instance);
			for (int i = 0; i < polygonCollider2D.pathCount; i++)
			{
				writer.WriteProperty("path" + i, polygonCollider2D.GetPath(i), ES3Type_Vector2Array.Instance);
			}
			if (polygonCollider2D.attachedRigidbody != null && polygonCollider2D.attachedRigidbody.useAutoMass)
			{
				writer.WriteProperty("density", polygonCollider2D.density, ES3Type_float.Instance);
			}
			writer.WriteProperty("isTrigger", polygonCollider2D.isTrigger, ES3Type_bool.Instance);
			writer.WriteProperty("usedByEffector", polygonCollider2D.usedByEffector, ES3Type_bool.Instance);
			writer.WriteProperty("offset", polygonCollider2D.offset, ES3Type_Vector2.Instance);
			writer.WriteProperty("sharedMaterial", polygonCollider2D.sharedMaterial);
			writer.WriteProperty("enabled", polygonCollider2D.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			PolygonCollider2D polygonCollider2D = (PolygonCollider2D)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "points":
						polygonCollider2D.points = reader.Read<Vector2[]>(ES3Type_Vector2Array.Instance);
						break;
					case "pathCount":
					{
						int num = reader.Read<int>(ES3Type_int.Instance);
						for (int i = 0; i < num; i++)
						{
							polygonCollider2D.SetPath(i, reader.ReadProperty<Vector2[]>(ES3Type_Vector2Array.Instance));
						}
						break;
					}
					case "density":
						polygonCollider2D.density = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "isTrigger":
						polygonCollider2D.isTrigger = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "usedByEffector":
						polygonCollider2D.usedByEffector = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "offset":
						polygonCollider2D.offset = reader.Read<Vector2>(ES3Type_Vector2.Instance);
						break;
					case "sharedMaterial":
						polygonCollider2D.sharedMaterial = reader.Read<PhysicsMaterial2D>(ES3Type_PhysicsMaterial2D.Instance);
						break;
					case "enabled":
						polygonCollider2D.enabled = reader.Read<bool>(ES3Type_bool.Instance);
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
