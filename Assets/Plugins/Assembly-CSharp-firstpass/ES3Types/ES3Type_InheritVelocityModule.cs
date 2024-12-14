using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "mode", "curve", "curveMultiplier" })]
	public class ES3Type_InheritVelocityModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_InheritVelocityModule()
			: base(typeof(ParticleSystem.InheritVelocityModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.InheritVelocityModule inheritVelocityModule = (ParticleSystem.InheritVelocityModule)obj;
			writer.WriteProperty("enabled", inheritVelocityModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("mode", inheritVelocityModule.mode);
			writer.WriteProperty("curve", inheritVelocityModule.curve, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("curveMultiplier", inheritVelocityModule.curveMultiplier, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.InheritVelocityModule inheritVelocityModule = default(ParticleSystem.InheritVelocityModule);
			ReadInto<T>(reader, inheritVelocityModule);
			return inheritVelocityModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.InheritVelocityModule inheritVelocityModule = (ParticleSystem.InheritVelocityModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					inheritVelocityModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "mode":
					inheritVelocityModule.mode = reader.Read<ParticleSystemInheritVelocityMode>();
					break;
				case "curve":
					inheritVelocityModule.curve = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "curveMultiplier":
					inheritVelocityModule.curveMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
