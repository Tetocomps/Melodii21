using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "color" })]
	public class ES3Type_ColorOverLifetimeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_ColorOverLifetimeModule()
			: base(typeof(ParticleSystem.ColorOverLifetimeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)obj;
			writer.WriteProperty("enabled", colorOverLifetimeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("color", colorOverLifetimeModule.color, ES3Type_MinMaxGradient.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = default(ParticleSystem.ColorOverLifetimeModule);
			ReadInto<T>(reader, colorOverLifetimeModule);
			return colorOverLifetimeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					colorOverLifetimeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "color":
					colorOverLifetimeModule.color = reader.Read<ParticleSystem.MinMaxGradient>(ES3Type_MinMaxGradient.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
