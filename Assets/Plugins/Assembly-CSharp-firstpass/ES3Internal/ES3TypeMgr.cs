using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ES3Types;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Internal
{
	[Preserve]
	public static class ES3TypeMgr
	{
		private static object _lock = new object();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Dictionary<Type, ES3Type> types = null;

		private static ES3Type lastAccessedType = null;

		public static ES3Type GetOrCreateES3Type(Type type, bool throwException = true)
		{
			if (types == null)
			{
				Init();
			}
			if (type != typeof(object) && lastAccessedType != null && lastAccessedType.type == type)
			{
				return lastAccessedType;
			}
			if (types.TryGetValue(type, out lastAccessedType))
			{
				return lastAccessedType;
			}
			return lastAccessedType = CreateES3Type(type, throwException);
		}

		public static ES3Type GetES3Type(Type type)
		{
			if (types == null)
			{
				Init();
			}
			if (types.TryGetValue(type, out lastAccessedType))
			{
				return lastAccessedType;
			}
			return null;
		}

		internal static void Add(Type type, ES3Type es3Type)
		{
			if (types == null)
			{
				Init();
			}
			ES3Type eS3Type = GetES3Type(type);
			if (eS3Type != null && eS3Type.priority > es3Type.priority)
			{
				return;
			}
			lock (_lock)
			{
				types[type] = es3Type;
			}
		}

		internal static ES3Type CreateES3Type(Type type, bool throwException = true)
		{
			if (ES3Reflection.IsEnum(type))
			{
				return new ES3Type_enum(type);
			}
			ES3Type eS3Type;
			if (ES3Reflection.TypeIsArray(type))
			{
				switch (ES3Reflection.GetArrayRank(type))
				{
				case 1:
					eS3Type = new ES3ArrayType(type);
					break;
				case 2:
					eS3Type = new ES32DArrayType(type);
					break;
				case 3:
					eS3Type = new ES33DArrayType(type);
					break;
				default:
					if (throwException)
					{
						throw new NotSupportedException("Only arrays with up to three dimensions are supported by Easy Save.");
					}
					return null;
				}
			}
			else if (ES3Reflection.IsGenericType(type) && ES3Reflection.ImplementsInterface(type, typeof(IEnumerable)))
			{
				Type genericTypeDefinition = ES3Reflection.GetGenericTypeDefinition(type);
				if (genericTypeDefinition == typeof(List<>))
				{
					eS3Type = new ES3ListType(type);
				}
				else if (genericTypeDefinition == typeof(Dictionary<, >))
				{
					eS3Type = new ES3DictionaryType(type);
				}
				else if (genericTypeDefinition == typeof(Queue<>))
				{
					eS3Type = new ES3QueueType(type);
				}
				else if (genericTypeDefinition == typeof(Stack<>))
				{
					eS3Type = new ES3StackType(type);
				}
				else
				{
					if (!(genericTypeDefinition == typeof(HashSet<>)))
					{
						if (throwException)
						{
							throw new NotSupportedException("Generic type \"" + type.ToString() + "\" is not supported by Easy Save.");
						}
						return null;
					}
					eS3Type = new ES3HashSetType(type);
				}
			}
			else
			{
				if (ES3Reflection.IsPrimitive(type))
				{
					if (types == null || types.Count == 0)
					{
						throw new TypeLoadException("ES3Type for primitive could not be found, and the type list is empty. Please contact Easy Save developers at http://www.moodkie.com/contact");
					}
					throw new TypeLoadException("ES3Type for primitive could not be found, but the type list has been initialised and is not empty. Please contact Easy Save developers on mail@moodkie.com");
				}
				if (ES3Reflection.IsAssignableFrom(typeof(UnityEngine.Component), type))
				{
					eS3Type = new ES3ReflectedComponentType(type);
				}
				else if (ES3Reflection.IsValueType(type))
				{
					eS3Type = new ES3ReflectedValueType(type);
				}
				else if (ES3Reflection.IsAssignableFrom(typeof(ScriptableObject), type))
				{
					eS3Type = new ES3ReflectedScriptableObjectType(type);
				}
				else
				{
					if (!ES3Reflection.HasParameterlessConstructor(type) && !ES3Reflection.IsAbstract(type) && !ES3Reflection.IsInterface(type))
					{
						if (throwException)
						{
							throw new NotSupportedException("Type of " + type?.ToString() + " is not supported as it does not have a parameterless constructor. Only value types, Components or ScriptableObjects are supportable without a parameterless constructor. However, you may be able to create an ES3Type script to add support for it.");
						}
						return null;
					}
					eS3Type = new ES3ReflectedObjectType(type);
				}
			}
			if (eS3Type.type == null || eS3Type.isUnsupported)
			{
				if (throwException)
				{
					throw new NotSupportedException($"ES3Type.type is null when trying to create an ES3Type for {type}, possibly because the element type is not supported.");
				}
				return null;
			}
			Add(type, eS3Type);
			return eS3Type;
		}

		internal static void Init()
		{
			lock (_lock)
			{
				types = new Dictionary<Type, ES3Type>();
				ES3Reflection.GetInstances<ES3Type>();
				if (types == null || types.Count == 0)
				{
					throw new TypeLoadException("Type list could not be initialised. Please contact Easy Save developers on mail@moodkie.com.");
				}
			}
		}
	}
}
