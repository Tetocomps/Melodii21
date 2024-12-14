using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "numTilesX", "numTilesY", "animation", "useRandomRow", "frameOverTime", "frameOverTimeMultiplier", "startFrame", "startFrameMultiplier", "cycleCount",
		"rowIndex", "uvChannelMask", "flipU", "flipV"
	})]
	public class ES3Type_TextureSheetAnimationModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_TextureSheetAnimationModule()
			: base(typeof(ParticleSystem.TextureSheetAnimationModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = (ParticleSystem.TextureSheetAnimationModule)obj;
			writer.WriteProperty("enabled", textureSheetAnimationModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("numTilesX", textureSheetAnimationModule.numTilesX, ES3Type_int.Instance);
			writer.WriteProperty("numTilesY", textureSheetAnimationModule.numTilesY, ES3Type_int.Instance);
			writer.WriteProperty("animation", textureSheetAnimationModule.animation);
			writer.WriteProperty("useRandomRow", textureSheetAnimationModule.rowMode);
			writer.WriteProperty("frameOverTime", textureSheetAnimationModule.frameOverTime, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("frameOverTimeMultiplier", textureSheetAnimationModule.frameOverTimeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startFrame", textureSheetAnimationModule.startFrame, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startFrameMultiplier", textureSheetAnimationModule.startFrameMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("cycleCount", textureSheetAnimationModule.cycleCount, ES3Type_int.Instance);
			writer.WriteProperty("rowIndex", textureSheetAnimationModule.rowIndex, ES3Type_int.Instance);
			writer.WriteProperty("uvChannelMask", textureSheetAnimationModule.uvChannelMask);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = default(ParticleSystem.TextureSheetAnimationModule);
			ReadInto<T>(reader, textureSheetAnimationModule);
			return textureSheetAnimationModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = (ParticleSystem.TextureSheetAnimationModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					textureSheetAnimationModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "numTilesX":
					textureSheetAnimationModule.numTilesX = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "numTilesY":
					textureSheetAnimationModule.numTilesY = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "animation":
					textureSheetAnimationModule.animation = reader.Read<ParticleSystemAnimationType>();
					break;
				case "rowMode":
					textureSheetAnimationModule.rowMode = reader.Read<ParticleSystemAnimationRowMode>();
					break;
				case "frameOverTime":
					textureSheetAnimationModule.frameOverTime = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "frameOverTimeMultiplier":
					textureSheetAnimationModule.frameOverTimeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startFrame":
					textureSheetAnimationModule.startFrame = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startFrameMultiplier":
					textureSheetAnimationModule.startFrameMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "cycleCount":
					textureSheetAnimationModule.cycleCount = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "rowIndex":
					textureSheetAnimationModule.rowIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "uvChannelMask":
					textureSheetAnimationModule.uvChannelMask = reader.Read<UVChannelFlags>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
