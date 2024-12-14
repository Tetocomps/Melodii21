using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "ratio", "lifetime", "lifetimeMultiplier", "minVertexDistance", "textureMode", "worldSpace", "dieWithParticles", "sizeAffectsWidth", "sizeAffectsLifetime",
		"inheritParticleColor", "colorOverLifetime", "widthOverTrail", "widthOverTrailMultiplier", "colorOverTrail"
	})]
	public class ES3Type_TrailModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_TrailModule()
			: base(typeof(ParticleSystem.TrailModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.TrailModule trailModule = (ParticleSystem.TrailModule)obj;
			writer.WriteProperty("enabled", trailModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("ratio", trailModule.ratio, ES3Type_float.Instance);
			writer.WriteProperty("lifetime", trailModule.lifetime, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("lifetimeMultiplier", trailModule.lifetimeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("minVertexDistance", trailModule.minVertexDistance, ES3Type_float.Instance);
			writer.WriteProperty("textureMode", trailModule.textureMode);
			writer.WriteProperty("worldSpace", trailModule.worldSpace, ES3Type_bool.Instance);
			writer.WriteProperty("dieWithParticles", trailModule.dieWithParticles, ES3Type_bool.Instance);
			writer.WriteProperty("sizeAffectsWidth", trailModule.sizeAffectsWidth, ES3Type_bool.Instance);
			writer.WriteProperty("sizeAffectsLifetime", trailModule.sizeAffectsLifetime, ES3Type_bool.Instance);
			writer.WriteProperty("inheritParticleColor", trailModule.inheritParticleColor, ES3Type_bool.Instance);
			writer.WriteProperty("colorOverLifetime", trailModule.colorOverLifetime, ES3Type_MinMaxGradient.Instance);
			writer.WriteProperty("widthOverTrail", trailModule.widthOverTrail, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("widthOverTrailMultiplier", trailModule.widthOverTrailMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("colorOverTrail", trailModule.colorOverTrail, ES3Type_MinMaxGradient.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.TrailModule trailModule = default(ParticleSystem.TrailModule);
			ReadInto<T>(reader, trailModule);
			return trailModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.TrailModule trailModule = (ParticleSystem.TrailModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					trailModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "ratio":
					trailModule.ratio = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "lifetime":
					trailModule.lifetime = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "lifetimeMultiplier":
					trailModule.lifetimeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "minVertexDistance":
					trailModule.minVertexDistance = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "textureMode":
					trailModule.textureMode = reader.Read<ParticleSystemTrailTextureMode>();
					break;
				case "worldSpace":
					trailModule.worldSpace = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "dieWithParticles":
					trailModule.dieWithParticles = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "sizeAffectsWidth":
					trailModule.sizeAffectsWidth = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "sizeAffectsLifetime":
					trailModule.sizeAffectsLifetime = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "inheritParticleColor":
					trailModule.inheritParticleColor = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "colorOverLifetime":
					trailModule.colorOverLifetime = reader.Read<ParticleSystem.MinMaxGradient>(ES3Type_MinMaxGradient.Instance);
					break;
				case "widthOverTrail":
					trailModule.widthOverTrail = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "widthOverTrailMultiplier":
					trailModule.widthOverTrailMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "colorOverTrail":
					trailModule.colorOverTrail = reader.Read<ParticleSystem.MinMaxGradient>(ES3Type_MinMaxGradient.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
