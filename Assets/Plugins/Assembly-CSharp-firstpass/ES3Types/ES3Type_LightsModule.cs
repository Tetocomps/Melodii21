using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "ratio", "useRandomDistribution", "light", "useParticleColor", "sizeAffectsRange", "alphaAffectsIntensity", "range", "rangeMultiplier", "intensity",
		"intensityMultiplier", "maxLights"
	})]
	public class ES3Type_LightsModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_LightsModule()
			: base(typeof(ParticleSystem.LightsModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.LightsModule lightsModule = (ParticleSystem.LightsModule)obj;
			writer.WriteProperty("enabled", lightsModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("ratio", lightsModule.ratio, ES3Type_float.Instance);
			writer.WriteProperty("useRandomDistribution", lightsModule.useRandomDistribution, ES3Type_bool.Instance);
			writer.WritePropertyByRef("light", lightsModule.light);
			writer.WriteProperty("useParticleColor", lightsModule.useParticleColor, ES3Type_bool.Instance);
			writer.WriteProperty("sizeAffectsRange", lightsModule.sizeAffectsRange, ES3Type_bool.Instance);
			writer.WriteProperty("alphaAffectsIntensity", lightsModule.alphaAffectsIntensity, ES3Type_bool.Instance);
			writer.WriteProperty("range", lightsModule.range, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("rangeMultiplier", lightsModule.rangeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("intensity", lightsModule.intensity, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("intensityMultiplier", lightsModule.intensityMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("maxLights", lightsModule.maxLights, ES3Type_int.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.LightsModule lightsModule = default(ParticleSystem.LightsModule);
			ReadInto<T>(reader, lightsModule);
			return lightsModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.LightsModule lightsModule = (ParticleSystem.LightsModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					lightsModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "ratio":
					lightsModule.ratio = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "useRandomDistribution":
					lightsModule.useRandomDistribution = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "light":
					lightsModule.light = reader.Read<Light>(ES3Type_Light.Instance);
					break;
				case "useParticleColor":
					lightsModule.useParticleColor = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "sizeAffectsRange":
					lightsModule.sizeAffectsRange = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "alphaAffectsIntensity":
					lightsModule.alphaAffectsIntensity = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "range":
					lightsModule.range = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "rangeMultiplier":
					lightsModule.rangeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "intensity":
					lightsModule.intensity = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "intensityMultiplier":
					lightsModule.intensityMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "maxLights":
					lightsModule.maxLights = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
