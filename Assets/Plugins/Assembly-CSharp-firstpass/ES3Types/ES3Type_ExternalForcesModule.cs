using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled", "multiplier" })]
	public class ES3Type_ExternalForcesModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_ExternalForcesModule()
			: base(typeof(ParticleSystem.ExternalForcesModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.ExternalForcesModule externalForcesModule = (ParticleSystem.ExternalForcesModule)obj;
			writer.WriteProperty("enabled", externalForcesModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("multiplier", externalForcesModule.multiplier, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.ExternalForcesModule externalForcesModule = default(ParticleSystem.ExternalForcesModule);
			ReadInto<T>(reader, externalForcesModule);
			return externalForcesModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.ExternalForcesModule externalForcesModule = (ParticleSystem.ExternalForcesModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					externalForcesModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "multiplier":
					externalForcesModule.multiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
