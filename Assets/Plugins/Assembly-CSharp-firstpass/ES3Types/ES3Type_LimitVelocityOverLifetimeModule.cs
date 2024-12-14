using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "limitX", "limitXMultiplier", "limitY", "limitYMultiplier", "limitZ", "limitZMultiplier", "limit", "limitMultiplier", "dampen",
		"separateAxes", "space"
	})]
	public class ES3Type_LimitVelocityOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_LimitVelocityOverLifetimeModule()
			: base(typeof(ParticleSystem.LimitVelocityOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = (ParticleSystem.LimitVelocityOverLifetimeModule)obj;
			writer.WriteProperty("enabled", limitVelocityOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("limitX", limitVelocityOverLifetimeModule.limitX, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("limitXMultiplier", limitVelocityOverLifetimeModule.limitXMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("limitY", limitVelocityOverLifetimeModule.limitY, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("limitYMultiplier", limitVelocityOverLifetimeModule.limitYMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("limitZ", limitVelocityOverLifetimeModule.limitZ, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("limitZMultiplier", limitVelocityOverLifetimeModule.limitZMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("limit", limitVelocityOverLifetimeModule.limit, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("limitMultiplier", limitVelocityOverLifetimeModule.limitMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("dampen", limitVelocityOverLifetimeModule.dampen, ES3Type_float.Instance);
			writer.WriteProperty("separateAxes", limitVelocityOverLifetimeModule.separateAxes, ES3Type_bool.Instance);
			writer.WriteProperty("space", limitVelocityOverLifetimeModule.space);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = default(ParticleSystem.LimitVelocityOverLifetimeModule);
			ReadInto<T>(reader, limitVelocityOverLifetimeModule);
			return limitVelocityOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = (ParticleSystem.LimitVelocityOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					limitVelocityOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "limitX":
					limitVelocityOverLifetimeModule.limitX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "limitXMultiplier":
					limitVelocityOverLifetimeModule.limitXMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "limitY":
					limitVelocityOverLifetimeModule.limitY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "limitYMultiplier":
					limitVelocityOverLifetimeModule.limitYMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "limitZ":
					limitVelocityOverLifetimeModule.limitZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "limitZMultiplier":
					limitVelocityOverLifetimeModule.limitZMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "limit":
					limitVelocityOverLifetimeModule.limit = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "limitMultiplier":
					limitVelocityOverLifetimeModule.limitMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "dampen":
					limitVelocityOverLifetimeModule.dampen = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "separateAxes":
					limitVelocityOverLifetimeModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "space":
					limitVelocityOverLifetimeModule.space = reader.Read<ParticleSystemSimulationSpace>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
