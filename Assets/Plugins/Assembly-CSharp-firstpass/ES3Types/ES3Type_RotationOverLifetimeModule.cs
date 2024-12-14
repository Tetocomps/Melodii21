using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "x", "xMultiplier", "y", "yMultiplier", "z", "zMultiplier", "separateAxes" })]
	public class ES3Type_RotationOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_RotationOverLifetimeModule()
			: base(typeof(ParticleSystem.RotationOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)obj;
			writer.WriteProperty("enabled", rotationOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("x", rotationOverLifetimeModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", rotationOverLifetimeModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("y", rotationOverLifetimeModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("yMultiplier", rotationOverLifetimeModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("z", rotationOverLifetimeModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("zMultiplier", rotationOverLifetimeModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("separateAxes", rotationOverLifetimeModule.separateAxes, ES3Type_bool.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = default(ParticleSystem.RotationOverLifetimeModule);
			ReadInto<T>(reader, rotationOverLifetimeModule);
			return rotationOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					rotationOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "x":
					rotationOverLifetimeModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					rotationOverLifetimeModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "y":
					rotationOverLifetimeModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "yMultiplier":
					rotationOverLifetimeModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "z":
					rotationOverLifetimeModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "zMultiplier":
					rotationOverLifetimeModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "separateAxes":
					rotationOverLifetimeModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
