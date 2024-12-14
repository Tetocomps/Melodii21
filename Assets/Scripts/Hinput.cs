using System.Collections.Generic;
using HinputClasses;
using HinputClasses.Internal;

public static class Hinput
{
	private static List<Gamepad> _gamepad;

	private static Gamepad _anyGamepad;

	public static List<Gamepad> gamepad
	{
		get
		{
			Updater.CheckInstance();
			if (_gamepad == null)
			{
				_gamepad = new List<Gamepad>();
				for (int i = 0; (float)i < 8f; i++)
				{
					_gamepad.Add(new Gamepad(i));
				}
			}
			return _gamepad;
		}
	}

	public static Gamepad anyGamepad
	{
		get
		{
			Updater.CheckInstance();
			if (_anyGamepad == null)
			{
				_anyGamepad = new AnyGamepad();
			}
			return _anyGamepad;
		}
	}

	public static Pressable anyInput => anyGamepad.anyInput;
}
