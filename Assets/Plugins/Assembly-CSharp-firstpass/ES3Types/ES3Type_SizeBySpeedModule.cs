using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "size", "sizeMultiplier", "x", "xMultiplier", "y", "yMultiplier", "z", "zMultiplier", "separateAxes",
		"range"
	})]
	public class ES3Type_SizeBySpeedModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_SizeBySpeedModule()
			: base(typeof(ParticleSystem.SizeBySpeedModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.SizeBySpeedModule sizeBySpeedModule = (ParticleSystem.SizeBySpeedModule)obj;
			writer.WriteProperty("enabled", sizeBySpeedModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("size", sizeBySpeedModule.size, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("sizeMultiplier", sizeBySpeedModule.sizeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("x", sizeBySpeedModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", sizeBySpeedModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("y", sizeBySpeedModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("yMultiplier", sizeBySpeedModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("z", sizeBySpeedModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("zMultiplier", sizeBySpeedModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("separateAxes", sizeBySpeedModule.separateAxes, ES3Type_bool.Instance);
			writer.WriteProperty("range", sizeBySpeedModule.range, ES3Type_Vector2.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.SizeBySpeedModule sizeBySpeedModule = default(ParticleSystem.SizeBySpeedModule);
			ReadInto<T>(reader, sizeBySpeedModule);
			return sizeBySpeedModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.SizeBySpeedModule sizeBySpeedModule = (ParticleSystem.SizeBySpeedModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					sizeBySpeedModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "size":
					sizeBySpeedModule.size = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "sizeMultiplier":
					sizeBySpeedModule.sizeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "x":
					sizeBySpeedModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					sizeBySpeedModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "y":
					sizeBySpeedModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "yMultiplier":
					sizeBySpeedModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "z":
					sizeBySpeedModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "zMultiplier":
					sizeBySpeedModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "separateAxes":
					sizeBySpeedModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "range":
					sizeBySpeedModule.range = reader.Read<Vector2>(ES3Type_Vector2.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
