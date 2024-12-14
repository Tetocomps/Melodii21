using System;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public abstract class ES3UnityObjectType : ES3ObjectType
	{
		public ES3UnityObjectType(Type type)
			: base(type)
		{
			isValueType = false;
			isES3TypeUnityObject = true;
		}

		protected abstract void WriteUnityObject(object obj, ES3Writer writer);

		protected abstract void ReadUnityObject<T>(ES3Reader reader, object obj);

		protected abstract object ReadUnityObject<T>(ES3Reader reader);

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			WriteObject(obj, writer, ES3.ReferenceMode.ByRefAndValue);
		}

		public virtual void WriteObject(object obj, ES3Writer writer, ES3.ReferenceMode mode)
		{
			if (WriteUsingDerivedType(obj, writer, mode))
			{
				return;
			}
			UnityEngine.Object @object = obj as UnityEngine.Object;
			if (obj != null && @object == null)
			{
				throw new ArgumentException("Only types of UnityEngine.Object can be written with this method, but argument given is type of " + obj.GetType());
			}
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			if (mode != ES3.ReferenceMode.ByValue)
			{
				if (current == null)
				{
					throw new InvalidOperationException("An Easy Save 3 Manager is required to load references. To add one to your scene, exit playmode and go to Assets > Easy Save 3 > Add Manager to Scene");
				}
				writer.WriteRef(@object);
				if (mode == ES3.ReferenceMode.ByRef)
				{
					return;
				}
			}
			WriteUnityObject(@object, writer);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			if (current != null)
			{
				foreach (string property in reader.Properties)
				{
					if (property == "_ES3Ref")
					{
						current.Add((UnityEngine.Object)obj, reader.Read_ref());
						continue;
					}
					reader.overridePropertiesName = property;
					break;
				}
			}
			ReadUnityObject<T>(reader, obj);
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			if (current == null)
			{
				return ReadUnityObject<T>(reader);
			}
			long id = -1L;
			UnityEngine.Object @object = null;
			foreach (string property in reader.Properties)
			{
				if (property == "_ES3Ref")
				{
					if (current == null)
					{
						throw new InvalidOperationException("An Easy Save 3 Manager is required to load references. To add one to your scene, exit playmode and go to Assets > Easy Save 3 > Add Manager to Scene");
					}
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
					@object = (UnityEngine.Object)ReadUnityObject<T>(reader);
					current.Add(@object, id);
				}
				break;
			}
			ReadUnityObject<T>(reader, @object);
			return @object;
		}

		protected bool WriteUsingDerivedType(object obj, ES3Writer writer, ES3.ReferenceMode mode)
		{
			Type type = obj.GetType();
			if (type != base.type)
			{
				writer.WriteType(type);
				ES3Type orCreateES3Type = ES3TypeMgr.GetOrCreateES3Type(type);
				if (orCreateES3Type is ES3UnityObjectType)
				{
					((ES3UnityObjectType)orCreateES3Type).WriteObject(obj, writer, mode);
				}
				else
				{
					orCreateES3Type.Write(obj, writer);
				}
				return true;
			}
			return false;
		}
	}
}
