using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"velocity", "angularVelocity", "drag", "angularDrag", "mass", "useGravity", "maxDepenetrationVelocity", "isKinematic", "freezeRotation", "constraints",
		"collisionDetectionMode", "centerOfMass", "inertiaTensorRotation", "inertiaTensor", "detectCollisions", "position", "rotation", "interpolation", "solverIterations", "sleepThreshold",
		"maxAngularVelocity", "solverVelocityIterations"
	})]
	public class ES3Type_Rigidbody : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_Rigidbody()
			: base(typeof(Rigidbody))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Rigidbody rigidbody = (Rigidbody)obj;
			writer.WriteProperty("velocity", rigidbody.velocity, ES3Type_Vector3.Instance);
			writer.WriteProperty("angularVelocity", rigidbody.angularVelocity, ES3Type_Vector3.Instance);
			writer.WriteProperty("drag", rigidbody.drag, ES3Type_float.Instance);
			writer.WriteProperty("angularDrag", rigidbody.angularDrag, ES3Type_float.Instance);
			writer.WriteProperty("mass", rigidbody.mass, ES3Type_float.Instance);
			writer.WriteProperty("useGravity", rigidbody.useGravity, ES3Type_bool.Instance);
			writer.WriteProperty("maxDepenetrationVelocity", rigidbody.maxDepenetrationVelocity, ES3Type_float.Instance);
			writer.WriteProperty("isKinematic", rigidbody.isKinematic, ES3Type_bool.Instance);
			writer.WriteProperty("freezeRotation", rigidbody.freezeRotation, ES3Type_bool.Instance);
			writer.WriteProperty("constraints", rigidbody.constraints);
			writer.WriteProperty("collisionDetectionMode", rigidbody.collisionDetectionMode);
			writer.WriteProperty("centerOfMass", rigidbody.centerOfMass, ES3Type_Vector3.Instance);
			writer.WriteProperty("inertiaTensorRotation", rigidbody.inertiaTensorRotation, ES3Type_Quaternion.Instance);
			writer.WriteProperty("inertiaTensor", rigidbody.inertiaTensor, ES3Type_Vector3.Instance);
			writer.WriteProperty("detectCollisions", rigidbody.detectCollisions, ES3Type_bool.Instance);
			writer.WriteProperty("position", rigidbody.position, ES3Type_Vector3.Instance);
			writer.WriteProperty("rotation", rigidbody.rotation, ES3Type_Quaternion.Instance);
			writer.WriteProperty("interpolation", rigidbody.interpolation);
			writer.WriteProperty("solverIterations", rigidbody.solverIterations, ES3Type_int.Instance);
			writer.WriteProperty("sleepThreshold", rigidbody.sleepThreshold, ES3Type_float.Instance);
			writer.WriteProperty("maxAngularVelocity", rigidbody.maxAngularVelocity, ES3Type_float.Instance);
			writer.WriteProperty("solverVelocityIterations", rigidbody.solverVelocityIterations, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Rigidbody rigidbody = (Rigidbody)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "velocity":
						rigidbody.velocity = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "angularVelocity":
						rigidbody.angularVelocity = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "drag":
						rigidbody.drag = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "angularDrag":
						rigidbody.angularDrag = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "mass":
						rigidbody.mass = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "useGravity":
						rigidbody.useGravity = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "maxDepenetrationVelocity":
						rigidbody.maxDepenetrationVelocity = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "isKinematic":
						rigidbody.isKinematic = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "freezeRotation":
						rigidbody.freezeRotation = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "constraints":
						rigidbody.constraints = reader.Read<RigidbodyConstraints>();
						break;
					case "collisionDetectionMode":
						rigidbody.collisionDetectionMode = reader.Read<CollisionDetectionMode>();
						break;
					case "centerOfMass":
						rigidbody.centerOfMass = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "inertiaTensorRotation":
						rigidbody.inertiaTensorRotation = reader.Read<Quaternion>(ES3Type_Quaternion.Instance);
						break;
					case "inertiaTensor":
						rigidbody.inertiaTensor = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "detectCollisions":
						rigidbody.detectCollisions = reader.Read<bool>(ES3Type_bool.Instance);
						break;
					case "position":
						rigidbody.position = reader.Read<Vector3>(ES3Type_Vector3.Instance);
						break;
					case "rotation":
						rigidbody.rotation = reader.Read<Quaternion>(ES3Type_Quaternion.Instance);
						break;
					case "interpolation":
						rigidbody.interpolation = reader.Read<RigidbodyInterpolation>();
						break;
					case "solverIterations":
						rigidbody.solverIterations = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "sleepThreshold":
						rigidbody.sleepThreshold = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "maxAngularVelocity":
						rigidbody.maxAngularVelocity = reader.Read<float>(ES3Type_float.Instance);
						break;
					case "solverVelocityIterations":
						rigidbody.solverVelocityIterations = reader.Read<int>(ES3Type_int.Instance);
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
