using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "separateAxes", "strength", "strengthMultiplier", "strengthX", "strengthXMultiplier", "strengthY", "strengthYMultiplier", "strengthZ", "strengthZMultiplier",
		"frequency", "damping", "octaveCount", "octaveMultiplier", "octaveScale", "quality", "scrollSpeed", "scrollSpeedMultiplier", "remapEnabled", "remap",
		"remapMultiplier", "remapX", "remapXMultiplier", "remapY", "remapYMultiplier", "remapZ", "remapZMultiplier"
	})]
	public class ES3Type_NoiseModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_NoiseModule()
			: base(typeof(ParticleSystem.NoiseModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.NoiseModule noiseModule = (ParticleSystem.NoiseModule)obj;
			writer.WriteProperty("enabled", noiseModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("separateAxes", noiseModule.separateAxes, ES3Type_bool.Instance);
			writer.WriteProperty("strength", noiseModule.strength, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("strengthMultiplier", noiseModule.strengthMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("strengthX", noiseModule.strengthX, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("strengthXMultiplier", noiseModule.strengthXMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("strengthY", noiseModule.strengthY, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("strengthYMultiplier", noiseModule.strengthYMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("strengthZ", noiseModule.strengthZ, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("strengthZMultiplier", noiseModule.strengthZMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("frequency", noiseModule.frequency, ES3Type_float.Instance);
			writer.WriteProperty("damping", noiseModule.damping, ES3Type_bool.Instance);
			writer.WriteProperty("octaveCount", noiseModule.octaveCount, ES3Type_int.Instance);
			writer.WriteProperty("octaveMultiplier", noiseModule.octaveMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("octaveScale", noiseModule.octaveScale, ES3Type_float.Instance);
			writer.WriteProperty("quality", noiseModule.quality);
			writer.WriteProperty("scrollSpeed", noiseModule.scrollSpeed, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("scrollSpeedMultiplier", noiseModule.scrollSpeedMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("remapEnabled", noiseModule.remapEnabled, ES3Type_bool.Instance);
			writer.WriteProperty("remap", noiseModule.remap, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("remapMultiplier", noiseModule.remapMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("remapX", noiseModule.remapX, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("remapXMultiplier", noiseModule.remapXMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("remapY", noiseModule.remapY, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("remapYMultiplier", noiseModule.remapYMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("remapZ", noiseModule.remapZ, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("remapZMultiplier", noiseModule.remapZMultiplier, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.NoiseModule noiseModule = default(ParticleSystem.NoiseModule);
			ReadInto<T>(reader, noiseModule);
			return noiseModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.NoiseModule noiseModule = (ParticleSystem.NoiseModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					noiseModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "separateAxes":
					noiseModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "strength":
					noiseModule.strength = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "strengthMultiplier":
					noiseModule.strengthMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "strengthX":
					noiseModule.strengthX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "strengthXMultiplier":
					noiseModule.strengthXMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "strengthY":
					noiseModule.strengthY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "strengthYMultiplier":
					noiseModule.strengthYMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "strengthZ":
					noiseModule.strengthZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "strengthZMultiplier":
					noiseModule.strengthZMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "frequency":
					noiseModule.frequency = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "damping":
					noiseModule.damping = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "octaveCount":
					noiseModule.octaveCount = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "octaveMultiplier":
					noiseModule.octaveMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "octaveScale":
					noiseModule.octaveScale = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "quality":
					noiseModule.quality = reader.Read<ParticleSystemNoiseQuality>();
					break;
				case "scrollSpeed":
					noiseModule.scrollSpeed = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "scrollSpeedMultiplier":
					noiseModule.scrollSpeedMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "remapEnabled":
					noiseModule.remapEnabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "remap":
					noiseModule.remap = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "remapMultiplier":
					noiseModule.remapMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "remapX":
					noiseModule.remapX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "remapXMultiplier":
					noiseModule.remapXMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "remapY":
					noiseModule.remapY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "remapYMultiplier":
					noiseModule.remapYMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "remapZ":
					noiseModule.remapZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "remapZMultiplier":
					noiseModule.remapZMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
