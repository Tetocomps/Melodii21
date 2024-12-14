using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "mode", "curveMultiplier", "curveMax", "curveMin", "constantMax", "constantMin", "constant", "curve" })]
	public class ES3Type_MinMaxCurve : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_MinMaxCurve()
			: base(typeof(ParticleSystem.MinMaxCurve))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)obj;
			writer.WriteProperty("mode", minMaxCurve.mode);
			writer.WriteProperty("curveMultiplier", minMaxCurve.curveMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("curveMax", minMaxCurve.curveMax, ES3Type_AnimationCurve.Instance);
			writer.WriteProperty("curveMin", minMaxCurve.curveMin, ES3Type_AnimationCurve.Instance);
			writer.WriteProperty("constantMax", minMaxCurve.constantMax, ES3Type_float.Instance);
			writer.WriteProperty("constantMin", minMaxCurve.constantMin, ES3Type_float.Instance);
			writer.WriteProperty("constant", minMaxCurve.constant, ES3Type_float.Instance);
			writer.WriteProperty("curve", minMaxCurve.curve, ES3Type_AnimationCurve.Instance);
		}

		[Preserve]
		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "mode":
					minMaxCurve.mode = reader.Read<ParticleSystemCurveMode>();
					break;
				case "curveMultiplier":
					minMaxCurve.curveMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "curveMax":
					minMaxCurve.curveMax = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				case "curveMin":
					minMaxCurve.curveMin = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				case "constantMax":
					minMaxCurve.constantMax = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "constantMin":
					minMaxCurve.constantMin = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "constant":
					minMaxCurve.constant = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "curve":
					minMaxCurve.curve = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return minMaxCurve;
		}

		[Preserve]
		public override void ReadInto<T>(ES3Reader reader, object obj)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "mode":
					minMaxCurve.mode = reader.Read<ParticleSystemCurveMode>();
					break;
				case "curveMultiplier":
					minMaxCurve.curveMultiplier = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "curveMax":
					minMaxCurve.curveMax = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				case "curveMin":
					minMaxCurve.curveMin = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				case "constantMax":
					minMaxCurve.constantMax = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "constantMin":
					minMaxCurve.constantMin = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "constant":
					minMaxCurve.constant = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "curve":
					minMaxCurve.curve = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
