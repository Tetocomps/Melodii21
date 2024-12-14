using System;
using System.Collections;
using System.Collections.Generic;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "layer", "isStatic", "tag", "name", "hideFlags", "children", "components" })]
	public class ES3Type_GameObject : ES3UnityObjectType
	{
		private const string prefabPropertyName = "es3Prefab";

		private const string transformPropertyName = "transformID";

		public static ES3Type Instance;

		public bool saveChildren;

		public ES3Type_GameObject()
			: base(typeof(GameObject))
		{
			Instance = this;
		}

		public override void WriteObject(object obj, ES3Writer writer, ES3.ReferenceMode mode)
		{
			if (WriteUsingDerivedType(obj, writer))
			{
				return;
			}
			GameObject gameObject = (GameObject)obj;
			if (mode != ES3.ReferenceMode.ByValue)
			{
				writer.WriteRef(gameObject);
				if (mode == ES3.ReferenceMode.ByRef)
				{
					return;
				}
				ES3Prefab component = gameObject.GetComponent<ES3Prefab>();
				if (component != null)
				{
					writer.WriteProperty("es3Prefab", component, ES3Type_ES3PrefabInternal.Instance);
				}
				writer.WriteProperty("transformID", ES3ReferenceMgrBase.Current.Add(gameObject.transform));
			}
			ES3AutoSave component2 = gameObject.GetComponent<ES3AutoSave>();
			writer.WriteProperty("layer", gameObject.layer, ES3Type_int.Instance);
			writer.WriteProperty("tag", gameObject.tag, ES3Type_string.Instance);
			writer.WriteProperty("name", gameObject.name, ES3Type_string.Instance);
			writer.WriteProperty("hideFlags", gameObject.hideFlags);
			writer.WriteProperty("active", gameObject.activeSelf);
			if ((component2 == null && saveChildren) || (component2 != null && component2.saveChildren))
			{
				writer.WriteProperty("children", GetChildren(gameObject), ES3.ReferenceMode.ByRefAndValue);
			}
			ES3AutoSave component3 = gameObject.GetComponent<ES3AutoSave>();
			List<Component> list;
			if (component3 != null && component3.componentsToSave != null && component3.componentsToSave.Count > 0)
			{
				list = component3.componentsToSave;
			}
			else
			{
				list = new List<Component>();
				Component[] components = gameObject.GetComponents<Component>();
				foreach (Component component4 in components)
				{
					if (component4 != null && ES3TypeMgr.GetES3Type(component4.GetType()) != null)
					{
						list.Add(component4);
					}
				}
			}
			writer.WriteProperty("components", list, ES3.ReferenceMode.ByRefAndValue);
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			UnityEngine.Object @object = null;
			ES3ReferenceMgrBase current = ES3ReferenceMgrBase.Current;
			long id = 0L;
			while (!(current == null))
			{
				string text = ReadPropertyName(reader);
				switch (text)
				{
				case "__type":
					return ES3TypeMgr.GetOrCreateES3Type(reader.ReadType()).Read<T>(reader);
				case "_ES3Ref":
					id = reader.Read_ref();
					@object = current.Get(id, suppressWarnings: true);
					continue;
				case "transformID":
				{
					long id2 = reader.Read_ref();
					if (@object == null)
					{
						@object = CreateNewGameObject(current, id);
					}
					current.Add(((GameObject)@object).transform, id2);
					continue;
				}
				case "es3Prefab":
					if (@object != null || ES3ReferenceMgrBase.Current == null)
					{
						reader.ReadInto<GameObject>(@object);
						continue;
					}
					@object = reader.Read<GameObject>(ES3Type_ES3PrefabInternal.Instance);
					ES3ReferenceMgrBase.Current.Add(@object, id);
					continue;
				}
				if (text == null)
				{
					if (@object == null)
					{
						return CreateNewGameObject(current, id);
					}
					return @object;
				}
				reader.overridePropertiesName = text;
				if (@object == null)
				{
					@object = CreateNewGameObject(current, id);
				}
				ReadInto<T>(reader, @object);
				return @object;
			}
			throw new InvalidOperationException("An Easy Save 3 Manager is required to load references. To add one to your scene, exit playmode and go to Assets > Easy Save 3 > Add Manager to Scene");
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			GameObject gameObject = (GameObject)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "_ES3Ref":
						ES3ReferenceMgrBase.Current.Add(gameObject, reader.Read_ref());
						break;
					case "layer":
						gameObject.layer = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "tag":
						gameObject.tag = reader.Read<string>(ES3Type_string.Instance);
						break;
					case "name":
						gameObject.name = reader.Read<string>(ES3Type_string.Instance);
						break;
					case "hideFlags":
						gameObject.hideFlags = reader.Read<HideFlags>();
						break;
					case "active":
						gameObject.SetActive(reader.Read<bool>(ES3Type_bool.Instance));
						break;
					case "children":
						reader.Read<GameObject[]>();
						break;
					case "components":
						ReadComponents(reader, gameObject);
						break;
					default:
						reader.Skip();
						break;
					case "prefab":
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

		private void ReadComponents(ES3Reader reader, GameObject go)
		{
			if (reader.StartReadCollection())
			{
				return;
			}
			List<Component> list = new List<Component>(go.GetComponents<Component>());
			while (reader.StartReadCollectionItem())
			{
				if (reader.StartReadObject())
				{
					return;
				}
				Type type = null;
				while (true)
				{
					string text = ReadPropertyName(reader);
					switch (text)
					{
					case "__type":
						break;
					case "_ES3Ref":
					{
						if (type == null)
						{
							throw new InvalidOperationException("Cannot load Component because no type data has been stored with it, so it's not possible to determine it's type");
						}
						long id = reader.Read_ref();
						Component component = list.Find((Component x) => x.GetType() == type);
						if (component != null)
						{
							if (ES3ReferenceMgrBase.Current != null)
							{
								ES3ReferenceMgrBase.Current.Add(component, id);
							}
							ES3TypeMgr.GetOrCreateES3Type(type).ReadInto<Component>(reader, component);
							list.Remove(component);
						}
						else
						{
							object obj = ES3TypeMgr.GetOrCreateES3Type(type).Read<Component>(reader);
							if (obj != null)
							{
								ES3ReferenceMgrBase.Current.Add((Component)obj, id);
							}
						}
						goto end_IL_0036;
					}
					default:
						reader.overridePropertiesName = text;
						ReadObject<Component>(reader);
						goto end_IL_0036;
					case null:
						goto end_IL_0036;
					}
					type = reader.ReadType();
					continue;
					end_IL_0036:
					break;
				}
				reader.EndReadObject();
				if (reader.EndReadCollectionItem())
				{
					break;
				}
			}
			reader.EndReadCollection();
		}

		private GameObject CreateNewGameObject(ES3ReferenceMgrBase refMgr, long id)
		{
			GameObject gameObject = new GameObject();
			if (id != 0L)
			{
				refMgr.Add(gameObject, id);
			}
			else
			{
				refMgr.Add(gameObject);
			}
			return gameObject;
		}

		public static List<GameObject> GetChildren(GameObject go)
		{
			Transform transform = go.transform;
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in transform)
			{
				list.Add(item.gameObject);
			}
			return list;
		}

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			return null;
		}
	}
}
