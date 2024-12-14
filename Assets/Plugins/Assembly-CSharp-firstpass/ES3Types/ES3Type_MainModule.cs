using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"duration", "loop", "prewarm", "startDelay", "startDelayMultiplier", "startLifetime", "startLifetimeMultiplier", "startSpeed", "startSpeedMultiplier", "startSize3D",
		"startSize", "startSizeMultiplier", "startSizeX", "startSizeXMultiplier", "startSizeY", "startSizeYMultiplier", "startSizeZ", "startSizeZMultiplier", "startRotation3D", "startRotation",
		"startRotationMultiplier", "startRotationX", "startRotationXMultiplier", "startRotationY", "startRotationYMultiplier", "startRotationZ", "startRotationZMultiplier", "randomizeRotationDirection", "startColor", "gravityModifier",
		"gravityModifierMultiplier", "simulationSpace", "customSimulationSpace", "simulationSpeed", "scalingMode", "playOnAwake", "maxParticles"
	})]
	public class ES3Type_MainModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_MainModule()
			: base(typeof(ParticleSystem.MainModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)obj;
			writer.WriteProperty("duration", mainModule.duration, ES3Type_float.Instance);
			writer.WriteProperty("loop", mainModule.loop, ES3Type_bool.Instance);
			writer.WriteProperty("prewarm", mainModule.prewarm, ES3Type_bool.Instance);
			writer.WriteProperty("startDelay", mainModule.startDelay, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startDelayMultiplier", mainModule.startDelayMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startLifetime", mainModule.startLifetime, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startLifetimeMultiplier", mainModule.startLifetimeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startSpeed", mainModule.startSpeed, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startSpeedMultiplier", mainModule.startSpeedMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startSize3D", mainModule.startSize3D, ES3Type_bool.Instance);
			writer.WriteProperty("startSize", mainModule.startSize, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startSizeMultiplier", mainModule.startSizeMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startSizeX", mainModule.startSizeX, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startSizeXMultiplier", mainModule.startSizeXMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startSizeY", mainModule.startSizeY, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startSizeYMultiplier", mainModule.startSizeYMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startSizeZ", mainModule.startSizeZ, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startSizeZMultiplier", mainModule.startSizeZMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startRotation3D", mainModule.startRotation3D, ES3Type_bool.Instance);
			writer.WriteProperty("startRotation", mainModule.startRotation, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startRotationMultiplier", mainModule.startRotationMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startRotationX", mainModule.startRotationX, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startRotationXMultiplier", mainModule.startRotationXMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startRotationY", mainModule.startRotationY, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startRotationYMultiplier", mainModule.startRotationYMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("startRotationZ", mainModule.startRotationZ, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("startRotationZMultiplier", mainModule.startRotationZMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("flipRotation", mainModule.flipRotation, ES3Type_float.Instance);
			writer.WriteProperty("startColor", mainModule.startColor, ES3Type_MinMaxGradient.Instance);
			writer.WriteProperty("gravityModifier", mainModule.gravityModifier, ES3Type_MinMaxCurve.Instance);
			writer.WriteProperty("gravityModifierMultiplier", mainModule.gravityModifierMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("simulationSpace", mainModule.simulationSpace);
			writer.WritePropertyByRef("customSimulationSpace", mainModule.customSimulationSpace);
			writer.WriteProperty("simulationSpeed", mainModule.simulationSpeed, ES3Type_float.Instance);
			writer.WriteProperty("scalingMode", mainModule.scalingMode);
			writer.WriteProperty("playOnAwake", mainModule.playOnAwake, ES3Type_bool.Instance);
			writer.WriteProperty("maxParticles", mainModule.maxParticles, ES3Type_int.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			ReadInto<T>(reader, mainModule);
			return mainModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "duration":
					mainModule.duration = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "loop":
					mainModule.loop = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "prewarm":
					mainModule.prewarm = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "startDelay":
					mainModule.startDelay = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startDelayMultiplier":
					mainModule.startDelayMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startLifetime":
					mainModule.startLifetime = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startLifetimeMultiplier":
					mainModule.startLifetimeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startSpeed":
					mainModule.startSpeed = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startSpeedMultiplier":
					mainModule.startSpeedMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startSize3D":
					mainModule.startSize3D = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "startSize":
					mainModule.startSize = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startSizeMultiplier":
					mainModule.startSizeMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startSizeX":
					mainModule.startSizeX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startSizeXMultiplier":
					mainModule.startSizeXMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startSizeY":
					mainModule.startSizeY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startSizeYMultiplier":
					mainModule.startSizeYMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startSizeZ":
					mainModule.startSizeZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startSizeZMultiplier":
					mainModule.startSizeZMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startRotation3D":
					mainModule.startRotation3D = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "startRotation":
					mainModule.startRotation = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startRotationMultiplier":
					mainModule.startRotationMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startRotationX":
					mainModule.startRotationX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startRotationXMultiplier":
					mainModule.startRotationXMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startRotationY":
					mainModule.startRotationY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startRotationYMultiplier":
					mainModule.startRotationYMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startRotationZ":
					mainModule.startRotationZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "startRotationZMultiplier":
					mainModule.startRotationZMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "flipRotation":
					mainModule.flipRotation = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "randomizeRotationDirection":
					mainModule.flipRotation = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "startColor":
					mainModule.startColor = reader.Read<ParticleSystem.MinMaxGradient>(ES3Type_MinMaxGradient.Instance);
					break;
				case "gravityModifier":
					mainModule.gravityModifier = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "gravityModifierMultiplier":
					mainModule.gravityModifierMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "simulationSpace":
					mainModule.simulationSpace = reader.Read<ParticleSystemSimulationSpace>();
					break;
				case "customSimulationSpace":
					mainModule.customSimulationSpace = reader.Read<Transform>(ES3Type_Transform.Instance);
					break;
				case "simulationSpeed":
					mainModule.simulationSpeed = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "scalingMode":
					mainModule.scalingMode = reader.Read<ParticleSystemScalingMode>();
					break;
				case "playOnAwake":
					mainModule.playOnAwake = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "maxParticles":
					mainModule.maxParticles = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
