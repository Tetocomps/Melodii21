using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "color", "range" })]
	public class ES3Type_ColorBySpeedModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_ColorBySpeedModule()
			: base(typeof(ParticleSystem.ColorBySpeedModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.ColorBySpeedModule colorBySpeedModule = (ParticleSystem.ColorBySpeedModule)obj;
			writer.WriteProperty("enabled", colorBySpeedModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("color", colorBySpeedModule.color, ES3Type_MinMaxGradient.Instance);
			writer.WriteProperty("range", colorBySpeedModule.range, ES3Type_Vector2.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.ColorBySpeedModule colorBySpeedModule = default(ParticleSystem.ColorBySpeedModule);
			ReadInto<T>(reader, colorBySpeedModule);
			return colorBySpeedModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.ColorBySpeedModule colorBySpeedModule = (ParticleSystem.ColorBySpeedModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					colorBySpeedModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "color":
					colorBySpeedModule.color = reader.Read<ParticleSystem.MinMaxGradient>(ES3Type_MinMaxGradient.Instance);
					break;
				case "range":
					colorBySpeedModule.range = reader.Read<Vector2>(ES3Type_Vector2.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
