using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"time", "hideFlags", "collision", "colorBySpeed", "colorOverLifetime", "emission", "externalForces", "forceOverLifetime", "inheritVelocity", "lights",
		"limitVelocityOverLifetime", "main", "noise", "rotatonBySpeed", "rotationOverLifetime", "shape", "sizeBySpeed", "sizeOverLifetime", "subEmitters", "textureSheetAnimation",
		"trails", "trigger", "useAutoRandomSeed", "velocityOverLifetime", "isPaused", "isPlaying", "isStopped"
	})]
	public class ES3Type_ParticleSystem : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_ParticleSystem()
			: base(typeof(ParticleSystem))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			ParticleSystem particleSystem = (ParticleSystem)obj;
			writer.WriteProperty("time", particleSystem.time);
			writer.WriteProperty("hideFlags", particleSystem.hideFlags);
			writer.WriteProperty("collision", particleSystem.collision);
			writer.WriteProperty("colorBySpeed", particleSystem.colorBySpeed);
			writer.WriteProperty("colorOverLifetime", particleSystem.colorOverLifetime);
			writer.WriteProperty("emission", particleSystem.emission);
			writer.WriteProperty("externalForces", particleSystem.externalForces);
			writer.WriteProperty("forceOverLifetime", particleSystem.forceOverLifetime);
			writer.WriteProperty("inheritVelocity", particleSystem.inheritVelocity);
			writer.WriteProperty("lights", particleSystem.lights);
			writer.WriteProperty("limitVelocityOverLifetime", particleSystem.limitVelocityOverLifetime);
			writer.WriteProperty("main", particleSystem.main);
			writer.WriteProperty("noise", particleSystem.noise);
			writer.WriteProperty("rotationBySpeed", particleSystem.rotationBySpeed);
			writer.WriteProperty("rotationOverLifetime", particleSystem.rotationOverLifetime);
			writer.WriteProperty("shape", particleSystem.shape);
			writer.WriteProperty("sizeBySpeed", particleSystem.sizeBySpeed);
			writer.WriteProperty("sizeOverLifetime", particleSystem.collision);
			writer.WriteProperty("subEmitters", particleSystem.subEmitters);
			writer.WriteProperty("textureSheetAnimation", particleSystem.textureSheetAnimation);
			writer.WriteProperty("trails", particleSystem.trails);
			writer.WriteProperty("trigger", particleSystem.trigger);
			writer.WriteProperty("useAutoRandomSeed", particleSystem.useAutoRandomSeed);
			writer.WriteProperty("velocityOverLifetime", particleSystem.velocityOverLifetime);
			writer.WriteProperty("isPaused", particleSystem.isPaused);
			writer.WriteProperty("isPlaying", particleSystem.isPlaying);
			writer.WriteProperty("isStopped", particleSystem.isStopped);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			ParticleSystem particleSystem = (ParticleSystem)obj;
			particleSystem.Stop();
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "time":
						particleSystem.time = reader.Read<float>();
						break;
					case "hideFlags":
						particleSystem.hideFlags = reader.Read<HideFlags>();
						break;
					case "collision":
						reader.ReadInto<ParticleSystem.CollisionModule>(particleSystem.collision, ES3Type_CollisionModule.Instance);
						break;
					case "colorBySpeed":
						reader.ReadInto<ParticleSystem.ColorBySpeedModule>(particleSystem.colorBySpeed, ES3Type_ColorBySpeedModule.Instance);
						break;
					case "colorOverLifetime":
						reader.ReadInto<ParticleSystem.ColorOverLifetimeModule>(particleSystem.colorOverLifetime, ES3Type_ColorOverLifetimeModule.Instance);
						break;
					case "emission":
						reader.ReadInto<ParticleSystem.EmissionModule>(particleSystem.emission, ES3Type_EmissionModule.Instance);
						break;
					case "externalForces":
						reader.ReadInto<ParticleSystem.ExternalForcesModule>(particleSystem.externalForces, ES3Type_ExternalForcesModule.Instance);
						break;
					case "forceOverLifetime":
						reader.ReadInto<ParticleSystem.ForceOverLifetimeModule>(particleSystem.forceOverLifetime, ES3Type_ForceOverLifetimeModule.Instance);
						break;
					case "inheritVelocity":
						reader.ReadInto<ParticleSystem.InheritVelocityModule>(particleSystem.inheritVelocity, ES3Type_InheritVelocityModule.Instance);
						break;
					case "lights":
						reader.ReadInto<ParticleSystem.LightsModule>(particleSystem.lights, ES3Type_LightsModule.Instance);
						break;
					case "limitVelocityOverLifetime":
						reader.ReadInto<ParticleSystem.LimitVelocityOverLifetimeModule>(particleSystem.limitVelocityOverLifetime, ES3Type_LimitVelocityOverLifetimeModule.Instance);
						break;
					case "main":
						reader.ReadInto<ParticleSystem.MainModule>(particleSystem.main, ES3Type_MainModule.Instance);
						break;
					case "noise":
						reader.ReadInto<ParticleSystem.NoiseModule>(particleSystem.noise, ES3Type_NoiseModule.Instance);
						break;
					case "rotationBySpeed":
						reader.ReadInto<ParticleSystem.RotationBySpeedModule>(particleSystem.rotationBySpeed, ES3Type_RotationBySpeedModule.Instance);
						break;
					case "rotationOverLifetime":
						reader.ReadInto<ParticleSystem.RotationOverLifetimeModule>(particleSystem.rotationOverLifetime, ES3Type_RotationOverLifetimeModule.Instance);
						break;
					case "subEmitters":
						reader.ReadInto<ParticleSystem.SubEmittersModule>(particleSystem.subEmitters, ES3Type_SubEmittersModule.Instance);
						break;
					case "textureSheetAnimation":
						reader.ReadInto<ParticleSystem.TextureSheetAnimationModule>(particleSystem.textureSheetAnimation, ES3Type_TextureSheetAnimationModule.Instance);
						break;
					case "trails":
						reader.ReadInto<ParticleSystem.TrailModule>(particleSystem.trails, ES3Type_TrailModule.Instance);
						break;
					case "trigger":
						reader.ReadInto<ParticleSystem.TriggerModule>(particleSystem.trigger, ES3Type_TriggerModule.Instance);
						break;
					case "useAutoRandomSeed":
						particleSystem.useAutoRandomSeed = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "velocityOverLifetime":
						reader.ReadInto<ParticleSystem.VelocityOverLifetimeModule>(particleSystem.velocityOverLifetime, ES3Type_VelocityOverLifetimeModule.Instance);
						break;
					case "isPaused":
						if (reader.Read<bool>(ES3Type_bool.Instance))
						{
							particleSystem.Pause();
						}
						break;
					case "isPlaying":
						if (reader.Read<bool>(ES3Type_bool.Instance))
						{
							particleSystem.Play();
						}
						break;
					case "isStopped":
						if (reader.Read<bool>(ES3Type_bool.Instance))
						{
							particleSystem.Stop();
						}
						break;
					default:
						reader.Skip();
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
