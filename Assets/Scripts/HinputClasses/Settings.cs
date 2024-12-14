using UnityEngine;

namespace HinputClasses
{
	public class Settings : MonoBehaviour
	{
		public enum DefaultPressTypes
		{
			SimplePress = 0,
			DoublePress = 1,
			LongPress = 2
		}

		public enum DefaultPressFeatures
		{
			Pressed = 0,
			JustPressed = 1,
			Released = 2,
			JustReleased = 3
		}

		public enum StickTypes
		{
			FourDirections = 90,
			EightDirections = 45
		}

		private static Settings _instance;

		[Header("Implicit Conversion")]
		[SerializeField]
		[Tooltip("The default conversion of Pressable to Press values\n\nDetermines how Hinput interprets buttons, triggers and stick directions when the type of Press to use is not specified")]
		private DefaultPressTypes _defaultPressType;

		[SerializeField]
		[Tooltip("The default conversion of Press and Pressable to boolean values\n\nDetermines how Hinput interprets buttons, triggers and stick directions when the feature to use is not specified.")]
		private DefaultPressFeatures _defaultPressFeature;

		[Header("Presses")]
		[SerializeField]
		[Range(0f, 2f)]
		[Tooltip("The maximum duration between the start of two presses for them to be considered a double press.")]
		private float _doublePressDuration = 0.3f;

		[SerializeField]
		[Range(0f, 2f)]
		[Tooltip("The minimum duration of a press for it to be considered a long press.")]
		private float _longPressDuration = 0.3f;

		[Header("Sticks")]
		[SerializeField]
		[Tooltip("The type of stick to use.\n\n- Set it to Four Directions for 4-directional sticks, with virtual buttons that span 1/4 of a circle (90 degrees). Use diagonals with caution in this case.\n\n- Set it to Eight Directions for 8-directional sticks, with virtual buttons that span 1/8 of a circle (45 degrees).")]
		private StickTypes _stickType = StickTypes.EightDirections;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The distance from the origin beyond which stick inputs start being registered.")]
		private float _stickDeadZone = 0.2f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The distance from the end of the dead zone beyond which stick inputs are considered pushed.")]
		private float _stickPressedZone = 0.5f;

		[SerializeField]
		[Tooltip("The Camera on which the worldPositionCamera feature of Stick should be based. If no Camera is set, Hinput will try to find one on the scene.")]
		private Transform _worldCamera;

		[Header("Triggers")]
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The distance from the origin beyond which trigger inputs start being registered.")]
		private float _triggerDeadZone = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The distance from the end of the dead zone beyond which trigger inputs are considered pushed.")]
		private float _triggerPressedZone = 0.5f;

		[Header("Vibration Defaults")]
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The default intensity of the left (low-frequency) motor when controllers vibrate.\n\nThe left motor's vibration feels like a low rumble.")]
		private float _vibrationDefaultLeftIntensity = 0.2f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The default intensity of the right (high-frequency) motor when controllers vibrate.\n\nThe right motor's vibration feels like a sharp buzz.")]
		private float _vibrationDefaultRightIntensity = 0.8f;

		[SerializeField]
		[Range(0f, 2f)]
		[Tooltip("The default duration of gamepad vibrations.")]
		private float _vibrationDefaultDuration = 0.2f;

		[Header("Performance")]
		[SerializeField]
		[Range(0f, 8f)]
		[Tooltip("The maximum amount of gamepads to be tracked by Hinput.\n\nReducing this before entering play mode may improve performance.")]
		private int _amountOfGamepads = 8;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the AnyGamepad feature to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableAnyGamepad;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the A button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableA;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the B button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableB;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the X button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableX;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the Y button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableY;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the left bumper of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableLeftBumper;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the right bumper of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableRightBumper;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the left trigger of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableLeftTrigger;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the right trigger of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableRightTrigger;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the back button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableBack;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the start button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableStart;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the left stick click of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableLeftStickClick;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the right stick click of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableRightStickClick;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the xBox button of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableXBoxButton;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the left stick of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableLeftStick;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the right stick of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableRightStick;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the D-pad of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableDPad;

		[SerializeField]
		[Tooltip("Checking this before entering play mode will cause the AnyInput feature of gamepads to not be tracked by Hinput. \n\nThis may improve performance.")]
		private bool _disableAnyInput;

		public static Settings instance
		{
			get
			{
				CheckInstance();
				return _instance;
			}
		}

		public static DefaultPressTypes defaultPressType
		{
			get
			{
				return instance._defaultPressType;
			}
			set
			{
				instance._defaultPressType = value;
			}
		}

		public static DefaultPressFeatures defaultPressFeature
		{
			get
			{
				return instance._defaultPressFeature;
			}
			set
			{
				instance._defaultPressFeature = value;
			}
		}

		public static float doublePressDuration
		{
			get
			{
				return instance._doublePressDuration;
			}
			set
			{
				instance._doublePressDuration = value;
			}
		}

		public static float longPressDuration
		{
			get
			{
				return instance._longPressDuration;
			}
			set
			{
				instance._longPressDuration = value;
			}
		}

		public static StickTypes stickType
		{
			get
			{
				return instance._stickType;
			}
			set
			{
				instance._stickType = value;
			}
		}

		public static float stickDeadZone
		{
			get
			{
				return instance._stickDeadZone;
			}
			set
			{
				instance._stickDeadZone = value;
			}
		}

		public static float stickPressedZone
		{
			get
			{
				return instance._stickPressedZone;
			}
			set
			{
				instance._stickPressedZone = value;
			}
		}

		public static Transform worldCamera
		{
			get
			{
				if (instance._worldCamera == null)
				{
					if (Camera.main != null)
					{
						instance._worldCamera = Camera.main.transform;
					}
					else
					{
						if (!(Object.FindObjectOfType<Camera>() != null))
						{
							return null;
						}
						instance._worldCamera = Object.FindObjectOfType<Camera>().transform;
					}
				}
				return instance._worldCamera;
			}
			set
			{
				instance._worldCamera = value;
			}
		}

		public static float triggerDeadZone
		{
			get
			{
				return instance._triggerDeadZone;
			}
			set
			{
				instance._triggerDeadZone = value;
			}
		}

		public static float triggerPressedZone
		{
			get
			{
				return instance._triggerPressedZone;
			}
			set
			{
				instance._triggerPressedZone = value;
			}
		}

		public static float vibrationDefaultLeftIntensity
		{
			get
			{
				return instance._vibrationDefaultLeftIntensity;
			}
			set
			{
				instance._vibrationDefaultLeftIntensity = value;
			}
		}

		public static float vibrationDefaultRightIntensity
		{
			get
			{
				return instance._vibrationDefaultRightIntensity;
			}
			set
			{
				instance._vibrationDefaultRightIntensity = value;
			}
		}

		public static float vibrationDefaultDuration
		{
			get
			{
				return instance._vibrationDefaultDuration;
			}
			set
			{
				instance._vibrationDefaultDuration = value;
			}
		}

		public static int amountOfGamepads
		{
			get
			{
				return instance._amountOfGamepads;
			}
			set
			{
				instance._amountOfGamepads = value;
			}
		}

		public static bool disableAnyGamepad
		{
			get
			{
				return instance._disableAnyGamepad;
			}
			set
			{
				instance._disableAnyGamepad = value;
			}
		}

		public static bool disableA
		{
			get
			{
				return instance._disableA;
			}
			set
			{
				instance._disableA = value;
			}
		}

		public static bool disableB
		{
			get
			{
				return instance._disableB;
			}
			set
			{
				instance._disableB = value;
			}
		}

		public static bool disableX
		{
			get
			{
				return instance._disableX;
			}
			set
			{
				instance._disableX = value;
			}
		}

		public static bool disableY
		{
			get
			{
				return instance._disableY;
			}
			set
			{
				instance._disableY = value;
			}
		}

		public static bool disableLeftBumper
		{
			get
			{
				return instance._disableLeftBumper;
			}
			set
			{
				instance._disableLeftBumper = value;
			}
		}

		public static bool disableRightBumper
		{
			get
			{
				return instance._disableRightBumper;
			}
			set
			{
				instance._disableRightBumper = value;
			}
		}

		public static bool disableLeftTrigger
		{
			get
			{
				return instance._disableLeftTrigger;
			}
			set
			{
				instance._disableLeftTrigger = value;
			}
		}

		public static bool disableRightTrigger
		{
			get
			{
				return instance._disableRightTrigger;
			}
			set
			{
				instance._disableRightTrigger = value;
			}
		}

		public static bool disableBack
		{
			get
			{
				return instance._disableBack;
			}
			set
			{
				instance._disableBack = value;
			}
		}

		public static bool disableStart
		{
			get
			{
				return instance._disableStart;
			}
			set
			{
				instance._disableStart = value;
			}
		}

		public static bool disableLeftStickClick
		{
			get
			{
				return instance._disableLeftStickClick;
			}
			set
			{
				instance._disableLeftStickClick = value;
			}
		}

		public static bool disableRightStickClick
		{
			get
			{
				return instance._disableRightStickClick;
			}
			set
			{
				instance._disableRightStickClick = value;
			}
		}

		public static bool disableXBoxButton
		{
			get
			{
				return instance._disableXBoxButton;
			}
			set
			{
				instance._disableXBoxButton = value;
			}
		}

		public static bool disableLeftStick
		{
			get
			{
				return instance._disableLeftStick;
			}
			set
			{
				instance._disableLeftStick = value;
			}
		}

		public static bool disableRightStick
		{
			get
			{
				return instance._disableRightStick;
			}
			set
			{
				instance._disableRightStick = value;
			}
		}

		public static bool disableDPad
		{
			get
			{
				return instance._disableDPad;
			}
			set
			{
				instance._disableDPad = value;
			}
		}

		public static bool disableAnyInput
		{
			get
			{
				return instance._disableAnyInput;
			}
			set
			{
				instance._disableAnyInput = value;
			}
		}

		private static void CheckInstance()
		{
			if (!(_instance != null))
			{
				_instance = new GameObject
				{
					name = "Hinput Settings"
				}.AddComponent<Settings>();
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
			Object.DontDestroyOnLoad(this);
		}
	}
}
