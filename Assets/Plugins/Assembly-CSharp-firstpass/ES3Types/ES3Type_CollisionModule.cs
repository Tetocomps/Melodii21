using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "type", "mode", "dampen", "dampenMultiplier", "bounce", "bounceMultiplier", "lifetimeLoss", "lifetimeLossMultiplier", "minKillSpeed",
		"maxKillSpeed", "collidesWith", "enableDynamicColliders", "maxCollisionShapes", "quality", "voxelSize", "radiusScale", "sendCollisionMessages"
	})]
	public class ES3Type_CollisionModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_CollisionModule()
			: base(typeof(ParticleSystem.CollisionModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.CollisionModule collisionModule = (ParticleSystem.CollisionModule)obj;
			writer.WriteProperty("enabled", collisionModule.enabled);
			writer.WriteProperty("type", collisionModule.type);
			writer.WriteProperty("mode", collisionModule.mode);
			writer.WriteProperty("dampen", collisionModule.dampen);
			writer.WriteProperty("dampenMultiplier", collisionModule.dampenMultiplier);
			writer.WriteProperty("bounce", collisionModule.bounce);
			writer.WriteProperty("bounceMultiplier", collisionModule.bounceMultiplier);
			writer.WriteProperty("lifetimeLoss", collisionModule.lifetimeLoss);
			writer.WriteProperty("lifetimeLossMultiplier", collisionModule.lifetimeLossMultiplier);
			writer.WriteProperty("minKillSpeed", collisionModule.minKillSpeed);
			writer.WriteProperty("maxKillSpeed", collisionModule.maxKillSpeed);
			writer.WriteProperty("collidesWith", collisionModule.collidesWith);
			writer.WriteProperty("enableDynamicColliders", collisionModule.enableDynamicColliders);
			writer.WriteProperty("maxCollisionShapes", collisionModule.maxCollisionShapes);
			writer.WriteProperty("quality", collisionModule.quality);
			writer.WriteProperty("voxelSize", collisionModule.voxelSize);
			writer.WriteProperty("radiusScale", collisionModule.radiusScale);
			writer.WriteProperty("sendCollisionMessages", collisionModule.sendCollisionMessages);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.CollisionModule collisionModule = default(ParticleSystem.CollisionModule);
			ReadInto<T>(reader, collisionModule);
			return collisionModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.CollisionModule collisionModule = (ParticleSystem.CollisionModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					collisionModule.enabled = reader.Read<bool>();
					break;
				case "type":
					collisionModule.type = reader.Read<ParticleSystemCollisionType>();
					break;
				case "mode":
					collisionModule.mode = reader.Read<ParticleSystemCollisionMode>();
					break;
				case "dampen":
					collisionModule.dampen = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "dampenMultiplier":
					collisionModule.dampenMultiplier = reader.Read<float>();
					break;
				case "bounce":
					collisionModule.bounce = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "bounceMultiplier":
					collisionModule.bounceMultiplier = reader.Read<float>();
					break;
				case "lifetimeLoss":
					collisionModule.lifetimeLoss = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
					break;
				case "lifetimeLossMultiplier":
					collisionModule.lifetimeLossMultiplier = reader.Read<float>();
					break;
				case "minKillSpeed":
					collisionModule.minKillSpeed = reader.Read<float>();
					break;
				case "maxKillSpeed":
					collisionModule.maxKillSpeed = reader.Read<float>();
					break;
				case "collidesWith":
					collisionModule.collidesWith = reader.Read<LayerMask>();
					break;
				case "enableDynamicColliders":
					collisionModule.enableDynamicColliders = reader.Read<bool>();
					break;
				case "maxCollisionShapes":
					collisionModule.maxCollisionShapes = reader.Read<int>();
					break;
				case "quality":
					collisionModule.quality = reader.Read<ParticleSystemCollisionQuality>();
					break;
				case "voxelSize":
					collisionModule.voxelSize = reader.Read<float>();
					break;
				case "radiusScale":
					collisionModule.radiusScale = reader.Read<float>();
					break;
				case "sendCollisionMessages":
					collisionModule.sendCollisionMessages = reader.Read<bool>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
