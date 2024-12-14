using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "mode", "gradientMax", "gradientMin", "colorMax", "colorMin", "color", "gradient" })]
	public class ES3Type_MinMaxGradient : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_MinMaxGradient()
			: base(typeof(ParticleSystem.MinMaxGradient))
		{
			Instance = this;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ParticleSystem.MinMaxGradient minMaxGradient = (ParticleSystem.MinMaxGradient)obj;
			writer.WriteProperty("mode", minMaxGradient.mode);
			writer.WriteProperty("gradientMax", minMaxGradient.gradientMax, ES3Type_Gradient.Instance);
			writer.WriteProperty("gradientMin", minMaxGradient.gradientMin, ES3Type_Gradient.Instance);
			writer.WriteProperty("colorMax", minMaxGradient.colorMax, ES3Type_Color.Instance);
			writer.WriteProperty("colorMin", minMaxGradient.colorMin, ES3Type_Color.Instance);
			writer.WriteProperty("color", minMaxGradient.color, ES3Type_Color.Instance);
			writer.WriteProperty("gradient", minMaxGradient.gradient, ES3Type_Gradient.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ParticleSystem.MinMaxGradient minMaxGradient = default(ParticleSystem.MinMaxGradient);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "mode":
					minMaxGradient.mode = reader.Read<ParticleSystemGradientMode>();
					break;
				case "gradientMax":
					minMaxGradient.gradientMax = reader.Read<Gradient>(ES3Type_Gradient.Instance);
					break;
				case "gradientMin":
					minMaxGradient.gradientMin = reader.Read<Gradient>(ES3Type_Gradient.Instance);
					break;
				case "colorMax":
					minMaxGradient.colorMax = reader.Read<Color>(ES3Type_Color.Instance);
					break;
				case "colorMin":
					minMaxGradient.colorMin = reader.Read<Color>(ES3Type_Color.Instance);
					break;
				case "color":
					minMaxGradient.color = reader.Read<Color>(ES3Type_Color.Instance);
					break;
				case "gradient":
					minMaxGradient.gradient = reader.Read<Gradient>(ES3Type_Gradient.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return minMaxGradient;
		}
	}
}
