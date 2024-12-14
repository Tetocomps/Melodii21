using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "rateOverTime", "rateOverTimeMultiplier", "rateOverDistance", "rateOverDistanceMultiplier" })]
	public class ES3Type_EmissionModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_EmissionModule()
			: base(typeof(ParticleSystem.EmissionModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)obj;
			writer.WriteProperty("enabled", emissionModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("rateOverTime", emissionModule.rateOverTime, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("rateOverTimeMultiplier", emissionModule.rateOverTimeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("rateOverDistance", emissionModule.rateOverDistance, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("rateOverDistanceMultiplier", emissionModule.rateOverDistanceMultiplier, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			ReadInto<T>(reader, emissionModule);
			return emissionModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					emissionModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "rateOverTime":
					emissionModule.rateOverTime = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "rateOverTimeMultiplier":
					emissionModule.rateOverTimeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "rateOverDistance":
					emissionModule.rateOverDistance = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "rateOverDistanceMultiplier":
					emissionModule.rateOverDistanceMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
