using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "inside", "outside", "enter", "exit", "radiusScale" })]
	public class ES3Type_TriggerModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_TriggerModule()
			: base(typeof(ParticleSystem.TriggerModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.TriggerModule triggerModule = (ParticleSystem.TriggerModule)obj;
			writer.WriteProperty("enabled", triggerModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("inside", triggerModule.inside);
			writer.WriteProperty("outside", triggerModule.outside);
			writer.WriteProperty("enter", triggerModule.enter);
			writer.WriteProperty("exit", triggerModule.exit);
			writer.WriteProperty("radiusScale", triggerModule.radiusScale, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.TriggerModule triggerModule = default(ParticleSystem.TriggerModule);
			ReadInto<T>(reader, triggerModule);
			return triggerModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.TriggerModule triggerModule = (ParticleSystem.TriggerModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					triggerModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "inside":
					triggerModule.inside = reader.Read<ParticleSystemOverlapAction>();
					break;
				case "outside":
					triggerModule.outside = reader.Read<ParticleSystemOverlapAction>();
					break;
				case "enter":
					triggerModule.enter = reader.Read<ParticleSystemOverlapAction>();
					break;
				case "exit":
					triggerModule.exit = reader.Read<ParticleSystemOverlapAction>();
					break;
				case "radiusScale":
					triggerModule.radiusScale = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
