using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "material", "name" })]
	public class ES3Type_Font : ES3UnityObjectType
	{
		public static ES3Type Instance;

		public ES3Type_Font()
			: base(typeof(Font))
		{
			Instance = this;
		}

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
			Font font = (Font)obj;
			writer.WriteProperty("name", font.name, ES3Type_string.Instance);
			writer.WriteProperty("material", font.material);
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
			Font font = (Font)obj;
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (text != null && text == "material")
				{
					font.material = reader.Read<Material>(ES3Type_Material.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			Font font = new Font(reader.ReadProperty<string>(ES3Type_string.Instance));
			ReadObject<T>(reader, font);
			return font;
		}
	}
}
