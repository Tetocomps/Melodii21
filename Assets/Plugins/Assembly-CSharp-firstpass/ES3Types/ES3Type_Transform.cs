using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "localPosition", "localRotation", "localScale", "parent" })]
	public class ES3Type_Transform : ES3ComponentType
	{
		public static int countRead;

		public static ES3Type Instance;

		public ES3Type_Transform()
			: base(typeof(Transform))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Transform transform = (Transform)obj;
			writer.WritePropertyByRef("parent", transform.parent);
			writer.WriteProperty("localPosition", transform.localPosition);
			writer.WriteProperty("localRotation", transform.localRotation);
			writer.WriteProperty("localScale", transform.localScale);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Transform transform = (Transform)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "parent":
						transform.SetParent(reader.Read<Transform>());
						break;
					case "localPosition":
						transform.localPosition = reader.Read<Vector3>();
						break;
					case "localRotation":
						transform.localRotation = reader.Read<Quaternion>();
						break;
					case "localScale":
						transform.localScale = reader.Read<Vector3>();
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
