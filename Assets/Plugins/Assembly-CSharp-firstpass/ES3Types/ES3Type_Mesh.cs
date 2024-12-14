using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"bounds", "subMeshCount", "boneWeights", "bindposes", "vertices", "normals", "tangents", "uv", "uv2", "uv3",
		"uv4", "colors32", "triangles", "subMeshes"
	})]
	public class ES3Type_Mesh : ES3UnityObjectType
	{
		public static ES3Type Instance;

		public ES3Type_Mesh()
			: base(typeof(Mesh))
		{
			Instance = this;
		}

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
			Mesh mesh = (Mesh)obj;
			if (!mesh.isReadable)
			{
				ES3Debug.LogWarning("Easy Save cannot save the vertices for this Mesh because it is not marked as readable, so it will be stored by reference. To save the vertex data for this Mesh, check the 'Read/Write Enabled' checkbox in its Import Settings.", mesh);
				return;
			}
			writer.WriteProperty("vertices", mesh.vertices, ES3Type_Vector3Array.Instance);
			writer.WriteProperty("triangles", mesh.triangles, ES3Type_intArray.Instance);
			writer.WriteProperty("bounds", mesh.bounds, ES3Type_Bounds.Instance);
			writer.WriteProperty("boneWeights", mesh.boneWeights, ES3Type_BoneWeightArray.Instance);
			writer.WriteProperty("bindposes", mesh.bindposes, ES3Type_Matrix4x4Array.Instance);
			writer.WriteProperty("normals", mesh.normals, ES3Type_Vector3Array.Instance);
			writer.WriteProperty("tangents", mesh.tangents, ES3Type_Vector4Array.Instance);
			writer.WriteProperty("uv", mesh.uv, ES3Type_Vector2Array.Instance);
			writer.WriteProperty("uv2", mesh.uv2, ES3Type_Vector2Array.Instance);
			writer.WriteProperty("uv3", mesh.uv3, ES3Type_Vector2Array.Instance);
			writer.WriteProperty("uv4", mesh.uv4, ES3Type_Vector2Array.Instance);
			writer.WriteProperty("colors32", mesh.colors32, ES3Type_Color32Array.Instance);
			writer.WriteProperty("subMeshCount", mesh.subMeshCount, ES3Type_int.Instance);
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				writer.WriteProperty("subMesh" + i, mesh.GetTriangles(i), ES3Type_intArray.Instance);
			}
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			Mesh mesh = new Mesh();
			ReadUnityObject<T>(reader, mesh);
			return mesh;
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
			Mesh mesh = (Mesh)obj;
			if (mesh == null)
			{
				return;
			}
			if (!mesh.isReadable)
			{
				ES3Debug.LogWarning("Easy Save cannot load the vertices for this Mesh because it is not marked as readable, so it will be loaded by reference. To load the vertex data for this Mesh, check the 'Read/Write Enabled' checkbox in its Import Settings.", mesh);
			}
			foreach (string property in reader.Properties)
			{
				if (!mesh.isReadable)
				{
					reader.Skip();
					continue;
				}
				switch (property)
				{
				case "bounds":
					mesh.bounds = reader.Read<Bounds>(ES3Type_Bounds.Instance);
					break;
				case "boneWeights":
					mesh.boneWeights = reader.Read<BoneWeight[]>(ES3Type_BoneWeightArray.Instance);
					break;
				case "bindposes":
					mesh.bindposes = reader.Read<Matrix4x4[]>(ES3Type_Matrix4x4Array.Instance);
					break;
				case "vertices":
					mesh.vertices = reader.Read<Vector3[]>(ES3Type_Vector3Array.Instance);
					break;
				case "normals":
					mesh.normals = reader.Read<Vector3[]>(ES3Type_Vector3Array.Instance);
					break;
				case "tangents":
					mesh.tangents = reader.Read<Vector4[]>(ES3Type_Vector4Array.Instance);
					break;
				case "uv":
					mesh.uv = reader.Read<Vector2[]>(ES3Type_Vector2Array.Instance);
					break;
				case "uv2":
					mesh.uv2 = reader.Read<Vector2[]>(ES3Type_Vector2Array.Instance);
					break;
				case "uv3":
					mesh.uv3 = reader.Read<Vector2[]>(ES3Type_Vector2Array.Instance);
					break;
				case "uv4":
					mesh.uv4 = reader.Read<Vector2[]>(ES3Type_Vector2Array.Instance);
					break;
				case "colors32":
					mesh.colors32 = reader.Read<Color32[]>(ES3Type_Color32Array.Instance);
					break;
				case "triangles":
					mesh.triangles = reader.Read<int[]>(ES3Type_intArray.Instance);
					break;
				case "subMeshCount":
				{
					mesh.subMeshCount = reader.Read<int>(ES3Type_int.Instance);
					for (int i = 0; i < mesh.subMeshCount; i++)
					{
						mesh.SetTriangles(reader.ReadProperty<int[]>(ES3Type_intArray.Instance), i);
					}
					break;
				}
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
