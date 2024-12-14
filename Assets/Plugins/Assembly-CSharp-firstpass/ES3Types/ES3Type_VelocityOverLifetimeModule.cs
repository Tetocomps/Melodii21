using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "x", "y", "z", "xMultiplier", "yMultiplier", "zMultiplier", "space" })]
	public class ES3Type_VelocityOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_VelocityOverLifetimeModule()
			: base(typeof(ParticleSystem.VelocityOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)obj;
			writer.WriteProperty("enabled", velocityOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("x", velocityOverLifetimeModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("y", velocityOverLifetimeModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("z", velocityOverLifetimeModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", velocityOverLifetimeModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("yMultiplier", velocityOverLifetimeModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("zMultiplier", velocityOverLifetimeModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("space", velocityOverLifetimeModule.space);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = default(ParticleSystem.VelocityOverLifetimeModule);
			ReadInto<T>(reader, velocityOverLifetimeModule);
			return velocityOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					velocityOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "x":
					velocityOverLifetimeModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "y":
					velocityOverLifetimeModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "z":
					velocityOverLifetimeModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					velocityOverLifetimeModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "yMultiplier":
					velocityOverLifetimeModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "zMultiplier":
					velocityOverLifetimeModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "space":
					velocityOverLifetimeModule.space = reader.Read<ParticleSystemSimulationSpace>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
