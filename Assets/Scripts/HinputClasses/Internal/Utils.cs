using System.Collections;
using System.IO;
using UnityEngine;

namespace HinputClasses.Internal
{
	public static class Utils
	{
		public enum OS
		{
			Unknown = 0,
			Windows = 1,
			Mac = 2,
			Linux = 3
		}

		public const float maxGamepads = 8f;

		public const float stickPositionMultiplier = 1.01f;

		public const string inputManagerPath = "./ProjectSettings/InputManager.asset";

		private static OS _os;

		public static OS os
		{
			get
			{
				if (_os == OS.Unknown)
				{
					string operatingSystem = SystemInfo.operatingSystem;
					if (operatingSystem.Contains("Windows"))
					{
						_os = OS.Windows;
					}
					else if (Application.platform == RuntimePlatform.XboxOne)
					{
						_os = OS.Windows;
					}
					else if (operatingSystem.Contains("Mac"))
					{
						_os = OS.Mac;
					}
					else if (operatingSystem.Contains("Linux"))
					{
						_os = OS.Linux;
					}
					else
					{
						Debug.LogError("Hinput Error : Unknown OS !");
					}
				}
				return _os;
			}
		}

		public static bool HinputIsInstalled()
		{
			return File.ReadAllText("./ProjectSettings/InputManager.asset").Contains(HinputInputArray());
		}

		public static string HinputInputArray()
		{
			try
			{
				return File.ReadAllText("./Assets/Hinput/Scripts/Setup/Hinput_8Controllers_inputManager");
			}
			catch
			{
				MissingInputArrayError();
			}
			return null;
		}

		public static bool GetButton(string fullName)
		{
			try
			{
				return Input.GetButton(fullName);
			}
			catch
			{
				HinputNotSetUpError();
			}
			return false;
		}

		public static float GetAxis(string fullName)
		{
			return GetAxis(fullName, logError: true);
		}

		public static float GetAxis(string fullName, bool logError)
		{
			try
			{
				return Input.GetAxisRaw(fullName);
			}
			catch
			{
				if (logError)
				{
					HinputNotSetUpError();
				}
			}
			return 0f;
		}

		public static bool PushedTowards(this Stick stick, float angle)
		{
			return Mathf.Abs(Mathf.DeltaAngle(angle, stick.angle)) < (float)Settings.stickType / 2f;
		}

		public static void Coroutine(IEnumerator coroutine)
		{
			Updater.instance.StartCoroutine(coroutine);
		}

		public static void StopRoutines()
		{
			Updater.instance.StopAllCoroutines();
		}

		public static bool IsEqualTo(this float target, float other)
		{
			return Mathf.Abs(target - other) < Mathf.Epsilon;
		}

		public static bool IsNotEqualTo(this float target, float other)
		{
			return Mathf.Abs(target - other) > Mathf.Epsilon;
		}

		public static Vector2 Clamp(this Vector2 target, float min, float max)
		{
			return new Vector2(Mathf.Clamp(target.x, min, max), Mathf.Clamp(target.y, min, max));
		}

		private static void HinputNotSetUpError()
		{
			Debug.LogWarning("Warning : Hinput has not been set up, so gamepad inputs cannot be recorded. To set it up, go to the Tools menu and click \"Hinput > Set up Hinput\".");
		}

		public static void MissingInputArrayError()
		{
			Debug.LogError("Hinput setup error : /Assets/Hinput/Scripts/Setup/Hinput_8Controllers_inputManager not found. Make sure this file is present in your project, or reinstall the package.");
		}

		public static void SetupError()
		{
			Debug.LogWarning("Error while setting up Hinput. Try reinstalling the plugin and rebooting your computer. If the problem persists, please contact me at hello@hinput.co.");
		}

		public static void UninstallError()
		{
			Debug.LogWarning("Error while uninstalling Hinput. Try reinstalling the plugin and rebooting your computer. If the problem persists, please contact me at hello@hinput.co.");
		}

		public static void VibrationNotAvailableError()
		{
			if (os != OS.Windows)
			{
				Debug.LogWarning("Hinput warning : vibration is only supported on Windows computers.");
			}
			else
			{
				Debug.LogWarning("Hinput warning : vibration is only supported on four controllers.");
			}
		}
	}
}
