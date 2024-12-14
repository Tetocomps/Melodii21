using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "x", "y", "z", "xMultiplier", "yMultiplier", "zMultiplier", "space", "randomized" })]
	public class ES3Type_ForceOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_ForceOverLifetimeModule()
			: base(typeof(ParticleSystem.ForceOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule = (ParticleSystem.ForceOverLifetimeModule)obj;
			writer.WriteProperty("enabled", forceOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("x", forceOverLifetimeModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("y", forceOverLifetimeModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("z", forceOverLifetimeModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", forceOverLifetimeModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("yMultiplier", forceOverLifetimeModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("zMultiplier", forceOverLifetimeModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("space", forceOverLifetimeModule.space);
			writer.WriteProperty("randomized", forceOverLifetimeModule.randomized, ES3Type_bool.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule = default(ParticleSystem.ForceOverLifetimeModule);
			ReadInto<T>(reader, forceOverLifetimeModule);
			return forceOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule = (ParticleSystem.ForceOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					forceOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "x":
					forceOverLifetimeModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "y":
					forceOverLifetimeModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "z":
					forceOverLifetimeModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					forceOverLifetimeModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "yMultiplier":
					forceOverLifetimeModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "zMultiplier":
					forceOverLifetimeModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "space":
					forceOverLifetimeModule.space = reader.Read<ParticleSystemSimulationSpace>();
					break;
				case "randomized":
					forceOverLifetimeModule.randomized = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
