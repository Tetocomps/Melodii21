using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"enabled", "shapeType", "randomDirectionAmount", "sphericalDirectionAmount", "alignToDirection", "radius", "angle", "length", "box", "meshShapeType",
		"mesh", "meshRenderer", "skinnedMeshRenderer", "useMeshMaterialIndex", "meshMaterialIndex", "useMeshColors", "normalOffset", "meshScale", "arc"
	})]
	public class ES3Type_ShapeModule : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_ShapeModule()
			: base(typeof(ParticleSystem.ShapeModule))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)obj;
			writer.WriteProperty("enabled", shapeModule.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("shapeType", shapeModule.shapeType);
			writer.WriteProperty("randomDirectionAmount", shapeModule.randomDirectionAmount, ES3Type_float.Instance);
			writer.WriteProperty("sphericalDirectionAmount", shapeModule.sphericalDirectionAmount, ES3Type_float.Instance);
			writer.WriteProperty("alignToDirection", shapeModule.alignToDirection, ES3Type_bool.Instance);
			writer.WriteProperty("radius", shapeModule.radius, ES3Type_float.Instance);
			writer.WriteProperty("angle", shapeModule.angle, ES3Type_float.Instance);
			writer.WriteProperty("length", shapeModule.length, ES3Type_float.Instance);
			writer.WriteProperty("scale", shapeModule.scale, ES3Type_Vector3.Instance);
			writer.WriteProperty("meshShapeType", shapeModule.meshShapeType);
			writer.WritePropertyByRef("mesh", shapeModule.mesh);
			writer.WritePropertyByRef("meshRenderer", shapeModule.meshRenderer);
			writer.WritePropertyByRef("skinnedMeshRenderer", shapeModule.skinnedMeshRenderer);
			writer.WriteProperty("useMeshMaterialIndex", shapeModule.useMeshMaterialIndex, ES3Type_bool.Instance);
			writer.WriteProperty("meshMaterialIndex", shapeModule.meshMaterialIndex, ES3Type_int.Instance);
			writer.WriteProperty("useMeshColors", shapeModule.useMeshColors, ES3Type_bool.Instance);
			writer.WriteProperty("normalOffset", shapeModule.normalOffset, ES3Type_float.Instance);
			writer.WriteProperty("arc", shapeModule.arc, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.ShapeModule shapeModule = default(ParticleSystem.ShapeModule);
			ReadInto<T>(reader, shapeModule);
			return shapeModule;
		}

		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "enabled":
					shapeModule.enabled = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "shapeType":
					shapeModule.shapeType = reader.Read<ParticleSystemShapeType>();
					break;
				case "randomDirectionAmount":
					shapeModule.randomDirectionAmount = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "sphericalDirectionAmount":
					shapeModule.sphericalDirectionAmount = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "alignToDirection":
					shapeModule.alignToDirection = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "radius":
					shapeModule.radius = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "angle":
					shapeModule.angle = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "length":
					shapeModule.length = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "scale":
					shapeModule.scale = reader.Read<Vector3>(ES3Type_Vector3.Instance);
					break;
				case "meshShapeType":
					shapeModule.meshShapeType = reader.Read<ParticleSystemMeshShapeType>();
					break;
				case "mesh":
					shapeModule.mesh = reader.Read<Mesh>();
					break;
				case "meshRenderer":
					shapeModule.meshRenderer = reader.Read<MeshRenderer>();
					break;
				case "skinnedMeshRenderer":
					shapeModule.skinnedMeshRenderer = reader.Read<SkinnedMeshRenderer>();
					break;
				case "useMeshMaterialIndex":
					shapeModule.useMeshMaterialIndex = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "meshMaterialIndex":
					shapeModule.meshMaterialIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "useMeshColors":
					shapeModule.useMeshColors = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "normalOffset":
					shapeModule.normalOffset = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "arc":
					shapeModule.arc = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
