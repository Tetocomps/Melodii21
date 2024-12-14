using System;
using System.Collections.Generic;
using System.IO;
using ES3Internal;

public class ES3Spreadsheet
{
	protected struct Index
	{
		public int col;

		public int row;

		public Index(int col, int row)
		{
			this.col = col;
			this.row = row;
		}
	}

	private int cols;

	private int rows;

	private Dictionary<Index, string> cells = new Dictionary<Index, string>();

	private const string QUOTE = "\"";

	private const char QUOTE_CHAR = '"';

	private const char COMMA_CHAR = ',';

	private const char NEWLINE_CHAR = '\n';

	private const string ESCAPED_QUOTE = "\"\"";

	private static char[] CHARS_TO_ESCAPE = new char[4] { ',', '"', '\n', ' ' };

	public int ColumnCount => cols;

	public int RowCount => rows;

	public void SetCell<T>(int col, int row, T value)
	{
		if (value.GetType() == typeof(string))
		{
			SetCellString(col, row, (string)(object)value);
			return;
		}
		ES3Settings eS3Settings = new ES3Settings();
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (ES3JSONWriter eS3JSONWriter = new ES3JSONWriter(memoryStream, eS3Settings, writeHeaderAndFooter: false, mergeKeys: false))
			{
				eS3JSONWriter.Write(value, ES3.ReferenceMode.ByValue);
			}
			SetCellString(col, row, eS3Settings.encoding.GetString(memoryStream.ToArray()));
		}
		if (col >= cols)
		{
			cols = col + 1;
		}
		if (row >= rows)
		{
			rows = row + 1;
		}
	}

	private void SetCellString(int col, int row, string value)
	{
		cells[new Index(col, row)] = value;
		if (col >= cols)
		{
			cols = col + 1;
		}
		if (row >= rows)
		{
			rows = row + 1;
		}
	}

	public T GetCell<T>(int col, int row)
	{
		object cell = GetCell(typeof(T), col, row);
		if (cell == null)
		{
			return default(T);
		}
		return (T)cell;
	}

	internal object GetCell(Type type, int col, int row)
	{
		if (col >= cols || row >= rows)
		{
			throw new IndexOutOfRangeException("Cell (" + col + ", " + row + ") is out of bounds of spreadsheet (" + cols + ", " + rows + ").");
		}
		if (!cells.TryGetValue(new Index(col, row), out var value) || string.IsNullOrEmpty(value))
		{
			return null;
		}
		if (type == typeof(string))
		{
			return value;
		}
		ES3Settings eS3Settings = new ES3Settings();
		using MemoryStream stream = new MemoryStream(eS3Settings.encoding.GetBytes(value));
		using ES3JSONReader reader = new ES3JSONReader(stream, eS3Settings, readHeaderAndFooter: false);
		return ES3TypeMgr.GetOrCreateES3Type(type).Read<object>(reader);
	}

	public void Load(string filePath)
	{
		Load(new ES3Settings(filePath));
	}

	public void Load(string filePath, ES3Settings settings)
	{
		Load(new ES3Settings(filePath, settings));
	}

	public void Load(ES3Settings settings)
	{
		Load(ES3Stream.CreateStream(settings, ES3FileMode.Read), settings);
	}

	public void LoadRaw(string str)
	{
		Load(new MemoryStream(new ES3Settings().encoding.GetBytes(str)), new ES3Settings());
	}

	public void LoadRaw(string str, ES3Settings settings)
	{
		Load(new MemoryStream(settings.encoding.GetBytes(str)), settings);
	}

	private void Load(Stream stream, ES3Settings settings)
	{
		using StreamReader streamReader = new StreamReader(stream);
		string text = "";
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = streamReader.Read();
			char c = (char)num3;
			if (c == '"')
			{
				while (true)
				{
					c = (char)streamReader.Read();
					if (c == '"')
					{
						if ((ushort)streamReader.Peek() != 34)
						{
							break;
						}
						c = (char)streamReader.Read();
					}
					text += c;
				}
			}
			else if (c == ',' || c == '\n' || num3 == -1)
			{
				SetCell(num, num2, text);
				text = "";
				switch (c)
				{
				case ',':
					num++;
					break;
				case '\n':
					num = 0;
					num2++;
					break;
				default:
					return;
				}
			}
			else
			{
				text += c;
			}
		}
	}

	public void Save(string filePath)
	{
		Save(new ES3Settings(filePath), append: false);
	}

	public void Save(string filePath, ES3Settings settings)
	{
		Save(new ES3Settings(filePath, settings), append: false);
	}

	public void Save(ES3Settings settings)
	{
		Save(settings, append: false);
	}

	public void Save(string filePath, bool append)
	{
		Save(new ES3Settings(filePath), append);
	}

	public void Save(string filePath, ES3Settings settings, bool append)
	{
		Save(new ES3Settings(filePath, settings), append);
	}

	public void Save(ES3Settings settings, bool append)
	{
		using (StreamWriter streamWriter = new StreamWriter(ES3Stream.CreateStream(settings, (!append) ? ES3FileMode.Write : ES3FileMode.Append)))
		{
			if (append && ES3.FileExists(settings))
			{
				streamWriter.Write('\n');
			}
			string[,] array = ToArray();
			for (int i = 0; i < rows; i++)
			{
				if (i != 0)
				{
					streamWriter.Write('\n');
				}
				for (int j = 0; j < cols; j++)
				{
					if (j != 0)
					{
						streamWriter.Write(',');
					}
					streamWriter.Write(Escape(array[j, i]));
				}
			}
		}
		if (!append)
		{
			ES3IO.CommitBackup(settings);
		}
	}

	private static string Escape(string str, bool isAlreadyWrappedInQuotes = false)
	{
		if (string.IsNullOrEmpty(str))
		{
			return null;
		}
		if (str.Contains("\""))
		{
			str = str.Replace("\"", "\"\"");
		}
		if (str.IndexOfAny(CHARS_TO_ESCAPE) > -1)
		{
			str = "\"" + str + "\"";
		}
		return str;
	}

	private static string Unescape(string str)
	{
		if (str.StartsWith("\"") && str.EndsWith("\""))
		{
			str = str.Substring(1, str.Length - 2);
			if (str.Contains("\"\""))
			{
				str = str.Replace("\"\"", "\"");
			}
		}
		return str;
	}

	private string[,] ToArray()
	{
		string[,] array = new string[cols, rows];
		foreach (KeyValuePair<Index, string> cell in cells)
		{
			array[cell.Key.col, cell.Key.row] = cell.Value;
		}
		return array;
	}
}
