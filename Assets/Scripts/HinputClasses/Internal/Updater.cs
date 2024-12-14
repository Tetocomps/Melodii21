using UnityEngine;

namespace HinputClasses.Internal
{
	public class Updater : MonoBehaviour
	{
		private static Updater _instance;

		public static Updater instance
		{
			get
			{
				CheckInstance();
				return _instance;
			}
		}

		public static void CheckInstance()
		{
			if (!(_instance != null))
			{
				GameObject obj = new GameObject();
				obj.name = "Hinput Updater";
				obj.transform.SetParent(Settings.instance.transform);
				_instance = obj.AddComponent<Updater>();
				UpdateGamepads();
			}
		}

		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			if (_instance != this)
			{
				Object.Destroy(this);
			}
		}

		private void Update()
		{
			UpdateGamepads();
		}

		private static void UpdateGamepads()
		{
			Hinput.gamepad.ForEach(delegate(Gamepad gamepad)
			{
				gamepad.Update();
			});
			Hinput.anyGamepad.Update();
		}

		public void OnApplicationQuit()
		{
			Hinput.anyGamepad.StopVibration();
		}
	}
}
