using System;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public abstract class ES3ScriptableObjectType : ES3UnityObjectType
	{
		public ES3ScriptableObjectType(Type type)
			: base(type)
		{
		}

		protected abstract void WriteScriptableObject(object obj, ES3Writer writer);

		protected abstract void ReadScriptableObject<T>(ES3Reader reader, object obj);

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
			ScriptableObject scriptableObject = obj as ScriptableObject;
			if (obj != null && scriptableObject == null)
			{
				throw new ArgumentException("Only types of UnityEngine.ScriptableObject can be written with this method, but argument given is type of " + obj.GetType());
			}
			if (ES3ReferenceMgrBase.Current != null)
			{
				writer.WriteRef(scriptableObject);
			}
			WriteScriptableObject(scriptableObject, writer);
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
			ReadScriptableObject<T>(reader, obj);
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			throw new NotImplementedException();
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			long id = -1L;
			UnityEngine.Object @object = null;
			foreach (string property in reader.Properties)
			{
				if (property == "_ES3Ref" && current != null)
				{
					id = reader.Read_ref();
					@object = current.Get(id, type);
					if (@object != null)
					{
						break;
					}
					continue;
				}
				reader.overridePropertiesName = property;
				if (@object == null)
				{
					@object = ScriptableObject.CreateInstance(type);
					if (current != null)
					{
						current.Add(@object, id);
					}
				}
				break;
			}
			ReadScriptableObject<T>(reader, @object);
			return @object;
		}
	}
}
