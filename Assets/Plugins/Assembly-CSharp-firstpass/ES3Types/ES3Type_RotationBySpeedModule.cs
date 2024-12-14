using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "x", "xMultiplier", "y", "yMultiplier", "z", "zMultiplier", "separateAxes", "range" })]
	public class ES3Type_RotationBySpeedModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_RotationBySpeedModule()
			: base(typeof(ParticleSystem.RotationBySpeedModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.RotationBySpeedModule rotationBySpeedModule = (ParticleSystem.RotationBySpeedModule)obj;
			writer.WriteProperty("enabled", rotationBySpeedModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("x", rotationBySpeedModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", rotationBySpeedModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("y", rotationBySpeedModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("yMultiplier", rotationBySpeedModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("z", rotationBySpeedModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("zMultiplier", rotationBySpeedModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("separateAxes", rotationBySpeedModule.separateAxes, ES3Type_bool.Instance);
			writer.WriteProperty("range", rotationBySpeedModule.range, ES3Type_Vector2.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.RotationBySpeedModule rotationBySpeedModule = default(ParticleSystem.RotationBySpeedModule);
			ReadInto<T>(reader, rotationBySpeedModule);
			return rotationBySpeedModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.RotationBySpeedModule rotationBySpeedModule = (ParticleSystem.RotationBySpeedModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					rotationBySpeedModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "x":
					rotationBySpeedModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					rotationBySpeedModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "y":
					rotationBySpeedModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "yMultiplier":
					rotationBySpeedModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "z":
					rotationBySpeedModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "zMultiplier":
					rotationBySpeedModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "separateAxes":
					rotationBySpeedModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "range":
					rotationBySpeedModule.range = reader.Read<Vector2>(ES3Type_Vector2.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
