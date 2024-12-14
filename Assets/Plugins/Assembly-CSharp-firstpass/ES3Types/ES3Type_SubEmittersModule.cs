using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "properties", "systems", "types" })]
	public class ES3Type_SubEmittersModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_SubEmittersModule()
			: base(typeof(ParticleSystem.SubEmittersModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.SubEmittersModule subEmittersModule = (ParticleSystem.SubEmittersModule)obj;
			ParticleSystemSubEmitterProperties[] array = new ParticleSystemSubEmitterProperties[subEmittersModule.subEmittersCount];
			ParticleSystem[] array2 = new ParticleSystem[subEmittersModule.subEmittersCount];
			ParticleSystemSubEmitterType[] array3 = new ParticleSystemSubEmitterType[subEmittersModule.subEmittersCount];
			for (int i = 0; i < subEmittersModule.subEmittersCount; i++)
			{
				array[i] = subEmittersModule.GetSubEmitterProperties(i);
				array2[i] = subEmittersModule.GetSubEmitterSystem(i);
				array3[i] = subEmittersModule.GetSubEmitterType(i);
			}
			writer.WriteProperty("properties", array);
			writer.WriteProperty("systems", array2);
			writer.WriteProperty("types", array3);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.SubEmittersModule subEmittersModule = default(ParticleSystem.SubEmittersModule);
			ReadInto<T>(reader, subEmittersModule);
			return subEmittersModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.SubEmittersModule subEmittersModule = (ParticleSystem.SubEmittersModule)obj;
			ParticleSystemSubEmitterProperties[] array = null;
			ParticleSystem[] array2 = null;
			ParticleSystemSubEmitterType[] array3 = null;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					subEmittersModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "properties":
					array = reader.Read<ParticleSystemSubEmitterProperties[]>(new ES3ArrayType(typeof(ParticleSystemSubEmitterProperties[])));
					break;
				case "systems":
					array2 = reader.Read<ParticleSystem[]>();
					break;
				case "types":
					array3 = reader.Read<ParticleSystemSubEmitterType[]>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					subEmittersModule.RemoveSubEmitter(i);
					subEmittersModule.AddSubEmitter(array2[i], array3[i], array[i]);
				}
			}
		}
	}
}
