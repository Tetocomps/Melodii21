using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "name", "samples", "channels", "frequency", "sampleData" })]
	public class ES3Type_AudioClip : ES3UnityObjectType
	{
		public static ES3Type Instance;

		public ES3Type_AudioClip()
			: base(typeof(AudioClip))
		{
			Instance = this;
		}

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
			AudioClip audioClip = (AudioClip)obj;
			float[] array = new float[audioClip.samples * audioClip.channels];
			audioClip.GetData(array, 0);
			writer.WriteProperty("name", audioClip.name);
			writer.WriteProperty("samples", audioClip.samples);
			writer.WriteProperty("channels", audioClip.channels);
			writer.WriteProperty("frequency", audioClip.frequency);
			writer.WriteProperty("sampleData", array);
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
			AudioClip audioClip = (AudioClip)obj;
			foreach (string property in reader.Properties)
			{
				if (property != null && property == "sampleData")
				{
					audioClip.SetData(reader.Read<float[]>(ES3Type_floatArray.Instance), 0);
				}
				else
				{
					reader.Skip();
				}
			}
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			string name = "";
			int lengthSamples = 0;
			int channels = 0;
			int frequency = 0;
			AudioClip audioClip = null;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "name":
						name = reader.Read<string>(ES3Type_string.Instance);
						break;
					case "samples":
						lengthSamples = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "channels":
						channels = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "frequency":
						frequency = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "sampleData":
						audioClip = AudioClip.Create(name, lengthSamples, channels, frequency, stream: false);
						audioClip.SetData(reader.Read<float[]>(ES3Type_floatArray.Instance), 0);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				return audioClip;
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
