using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "size", "sizeMultiplier", "x", "xMultiplier", "y", "yMultiplier", "z", "zMultiplier", "separateAxes" })]
	public class ES3Type_SizeOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_SizeOverLifetimeModule()
			: base(typeof(ParticleSystem.SizeOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = (ParticleSystem.SizeOverLifetimeModule)obj;
			writer.WriteProperty("enabled", sizeOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("size", sizeOverLifetimeModule.size, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("sizeMultiplier", sizeOverLifetimeModule.sizeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("x", sizeOverLifetimeModule.x, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("xMultiplier", sizeOverLifetimeModule.xMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("y", sizeOverLifetimeModule.y, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("yMultiplier", sizeOverLifetimeModule.yMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("z", sizeOverLifetimeModule.z, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("zMultiplier", sizeOverLifetimeModule.zMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("separateAxes", sizeOverLifetimeModule.separateAxes, ES3Type_bool.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = default(ParticleSystem.SizeOverLifetimeModule);
			ReadInto<T>(reader, sizeOverLifetimeModule);
			return sizeOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = (ParticleSystem.SizeOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					sizeOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "size":
					sizeOverLifetimeModule.size = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "sizeMultiplier":
					sizeOverLifetimeModule.sizeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "x":
					sizeOverLifetimeModule.x = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "xMultiplier":
					sizeOverLifetimeModule.xMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "y":
					sizeOverLifetimeModule.y = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "yMultiplier":
					sizeOverLifetimeModule.yMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "z":
					sizeOverLifetimeModule.z = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "zMultiplier":
					sizeOverLifetimeModule.zMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "separateAxes":
					sizeOverLifetimeModule.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
