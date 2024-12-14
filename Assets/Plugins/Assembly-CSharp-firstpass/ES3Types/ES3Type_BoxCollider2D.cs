using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "size", "density", "isTrigger", "usedByEffector", "offset", "sharedMaterial", "enabled" })]
	public class ES3Type_BoxCollider2D : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_BoxCollider2D()
			: base(typeof(BoxCollider2D))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BoxCollider2D boxCollider2D = (BoxCollider2D)obj;
			writer.WriteProperty("size", boxCollider2D.size);
			if (boxCollider2D.attachedRigidbody != null && boxCollider2D.attachedRigidbody.useAutoMass)
			{
				writer.WriteProperty("density", boxCollider2D.density);
			}
			writer.WriteProperty("isTrigger", boxCollider2D.isTrigger);
			writer.WriteProperty("usedByEffector", boxCollider2D.usedByEffector);
			writer.WriteProperty("offset", boxCollider2D.offset);
			writer.WritePropertyByRef("sharedMaterial", boxCollider2D.sharedMaterial);
			writer.WriteProperty("enabled", boxCollider2D.enabled);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BoxCollider2D boxCollider2D = (BoxCollider2D)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "size":
						boxCollider2D.size = reader.Read<Vector2>();
						break;
					case "density":
						boxCollider2D.density = reader.Read<float>();
						break;
					case "isTrigger":
						boxCollider2D.isTrigger = reader.Read<bool>();
						break;
					case "usedByEffector":
						boxCollider2D.usedByEffector = reader.Read<bool>();
						break;
					case "offset":
						boxCollider2D.offset = reader.Read<Vector2>();
						break;
					case "sharedMaterial":
						boxCollider2D.sharedMaterial = reader.Read<PhysicsMaterial2D>();
						break;
					case "enabled":
						boxCollider2D.enabled = reader.Read<bool>();
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
