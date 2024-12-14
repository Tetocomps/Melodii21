using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HinputClasses.Internal
{
	public class Debugger : MonoBehaviour
	{
		public enum SD
		{
			none = 0,
			verticalsAndHorizontals = 1,
			diagonals = 2,
			pressedZone = 3
		}

		public enum BF
		{
			none = 0,
			defaultCast = 1,
			simplePress = 2,
			doublePress = 3,
			longPress = 4,
			triggerPosition = 5
		}

		public enum PF
		{
			defaultCast = 0,
			justPressedAndJustReleased = 1,
			pressedAndReleased = 2,
			pressDurationAndReleaseDuration = 3
		}

		public enum SF
		{
			none = 0,
			position = 1,
			horizontal = 2,
			vertical = 3,
			angle = 4,
			distance = 5,
			worldPositionCamera = 6,
			worldPositionFlat = 7
		}

		public enum GM
		{
			individualGamepads = 0,
			anyGamepad = 1
		}

		public enum IM
		{
			individualInputs = 0,
			anyInput = 1
		}

		public enum VM
		{
			noArgs = 0,
			duration = 1,
			intensity = 2,
			durationAndIntensity = 3,
			oneCurve = 4,
			twoCurves = 5,
			vibrationPreset = 6,
			advanced = 7
		}

		[Header("GENERAL")]
		public bool startMessage;

		public bool lockCurrentInput;

		[Header("BUTTONS")]
		public SD stickDirections;

		public BF buttonFeature;

		public PF pressFeature;

		[Header("STICKS")]
		public SF stickFeature;

		[Header("VIBRATION")]
		public bool vibrateOnVPressed;

		[Header("TIME")]
		[Space(20f)]
		[Header("--------------------")]
		[Space(20f)]
		[Range(0f, 3f)]
		public float timeScale = 1f;

		public bool playInUpdate;

		public bool playInFixedUpdate;

		[Header("GAMEPAD AND INPUT MODE")]
		public GM gamepadMode;

		public IM inputMode;

		[Header("INFO")]
		public bool gamepadInfoOnGPressed;

		public bool gamepadListsOnLPressed;

		public bool stickInfoOnPPressed;

		public bool buttonInfoOnBPressed;

		[Header("ENABLE/DISABLE")]
		public bool toggleGamepadOnGPressed;

		public bool toggleStickOnPPressed;

		public bool toggleButtonOnBPressed;

		[Header("VIBRATION")]
		[Range(0f, 7f)]
		public int gamepadToVibrate;

		public VM vibrationMode;

		[Range(0f, 10f)]
		public float duration;

		[Range(0f, 1f)]
		public float leftIntensity;

		[Range(0f, 1f)]
		public float rightIntensity;

		public AnimationCurve curve;

		public AnimationCurve leftCurve;

		public AnimationCurve rightCurve;

		public VibrationPreset vibrationPreset;

		public bool multiplyVibrationPreset;

		public bool stopVibrationOnSPressed;

		[Range(-1f, 3f)]
		public float stopVibrationDuration;

		public bool displayIntensity;

		[Header("REFERENCES")]
		[Space(20f)]
		[Header("--------------------")]
		[Space(20f)]
		public GameObject message;

		public Transform plane;

		public Transform redCube;

		public Transform blueSphere;

		public float moveSpeed;

		private Stick currentStick;

		private Pressable currentButton;

		private void Start()
		{
			if (startMessage)
			{
				Debug.Log("Press a button to log it in the debugger");
			}
		}

		private void Update()
		{
			Time.timeScale = timeScale;
			if (playInUpdate)
			{
				TestEverything();
			}
		}

		private void FixedUpdate()
		{
			if (playInFixedUpdate)
			{
				TestEverything();
			}
		}

		private void TestEverything()
		{
			TestInfo();
			TestEnableDisable();
			TestSticks();
			TestButtons();
			TestVibration();
		}

		private void TestInfo()
		{
			if (gamepadInfoOnGPressed && Input.GetKeyDown(KeyCode.G))
			{
				if (currentButton == null)
				{
					Debug.Log("Current gamepad has not been set");
					return;
				}
				Gamepad gamepad = currentButton.gamepad;
				Debug.Log("current gamepad: [isConnected = " + gamepad.isConnected + ", isEnabled = " + gamepad.isEnabled + ", type = " + gamepad.type + ", index = " + gamepad.index + ", name = " + gamepad.name + "]");
			}
			if (gamepadListsOnLPressed && Input.GetKeyDown(KeyCode.L))
			{
				if (currentButton == null)
				{
					Debug.Log("Current gamepad has not been set");
					return;
				}
				Gamepad gamepad2 = currentButton.gamepad;
				Debug.Log("current gamepad buttons : " + ToString(Enumerable.ToList(Enumerable.Select(gamepad2.buttons, (Pressable button) => button.name))) + ", current gamepad sticks : " + ToString(Enumerable.ToList(Enumerable.Select(gamepad2.sticks, (Stick stick) => stick.name))));
			}
			if (stickInfoOnPPressed && Input.GetKeyDown(KeyCode.P))
			{
				if (currentStick == null)
				{
					Debug.Log("Current stick has not been set");
					return;
				}
				Debug.Log("current stick: [isEnabled = " + currentStick.isEnabled + ", index = " + currentStick.index + ", name = " + currentStick.name + ", gamepad = " + currentStick.gamepad.name + "]");
			}
			if (!buttonInfoOnBPressed || !Input.GetKeyDown(KeyCode.B))
			{
				return;
			}
			if (currentButton == null)
			{
				Debug.Log("Current button has not been set");
				return;
			}
			string text = "isEnabled = " + currentButton.isEnabled + ", name = " + currentButton.name + ", gamepad = " + currentButton.gamepad.name;
			if (currentButton is StickDirection)
			{
				text = "current direction: [" + text + ", stick = " + ((StickDirection)currentButton).stick.name;
			}
			else if (currentButton is StickPressedZone)
			{
				text = "current stick pressed zone: [" + text + ", stick = " + ((StickPressedZone)currentButton).stick.name;
			}
			else if (currentButton is Button)
			{
				text = "current button: [" + text + ", index = " + ((Button)currentButton).index;
			}
			else if (currentButton is Trigger)
			{
				text = "current trigger: [" + text + ", index = " + ((Trigger)currentButton).index;
			}
			else if (currentButton is AnyInput)
			{
				text = "current anyInput: [" + text;
			}
			text += "]";
			Debug.Log(text);
		}

		private void TestEnableDisable()
		{
			if (toggleGamepadOnGPressed && Input.GetKeyDown(KeyCode.G))
			{
				if (currentButton == null)
				{
					Debug.Log("Current gamepad has not been set");
					return;
				}
				if (currentButton.gamepad.isEnabled)
				{
					currentButton.gamepad.Disable();
					Debug.Log("Disabling " + currentButton.gamepad.name);
				}
				else
				{
					currentButton.gamepad.Enable();
					Debug.Log("Enabling " + currentButton.gamepad.name);
				}
			}
			if (toggleStickOnPPressed && Input.GetKeyDown(KeyCode.P))
			{
				if (currentStick == null)
				{
					Debug.Log("Current stick has not been set");
					return;
				}
				if (currentStick.isEnabled)
				{
					currentStick.Disable();
					Debug.Log("Disabling " + currentStick.name);
				}
				else
				{
					currentStick.Enable();
					Debug.Log("Enabling " + currentStick.name);
				}
			}
			if (toggleButtonOnBPressed && Input.GetKeyDown(KeyCode.B))
			{
				if (currentButton == null)
				{
					Debug.Log("Current button has not been set");
				}
				else if (currentButton.isEnabled)
				{
					currentButton.Disable();
					Debug.Log("Disabling " + currentButton.name);
				}
				else
				{
					currentButton.Enable();
					Debug.Log("Enabling " + currentButton.name);
				}
			}
		}

		private void TestButtons()
		{
			if (!lockCurrentInput && (currentButton == null || currentButton.released))
			{
				GetNewCurrentButton();
			}
			if (currentButton != null)
			{
				TestCurrentButton();
			}
		}

		private void GetNewCurrentButton()
		{
			List<Gamepad> list = new List<Gamepad>();
			if (gamepadMode == GM.anyGamepad)
			{
				list.Add(Hinput.anyGamepad);
			}
			if (gamepadMode == GM.individualGamepads)
			{
				list = Hinput.gamepad;
			}
			if (inputMode == IM.anyInput)
			{
				list.ForEach(delegate(Gamepad gamepad)
				{
					if (gamepad.anyInput.pressed)
					{
						currentButton = gamepad.anyInput;
					}
				});
			}
			if (inputMode != 0)
			{
				return;
			}
			list.ForEach(delegate(Gamepad gamepad)
			{
				AllGamepadButtons(gamepad).ForEach(delegate(Pressable button)
				{
					if (button.pressed)
					{
						currentButton = button;
					}
				});
			});
		}

		private List<Pressable> AllGamepadButtons(Gamepad gamepad)
		{
			List<Pressable> list = new List<Pressable>();
			list.AddRange(new List<Pressable>
			{
				gamepad.A, gamepad.B, gamepad.X, gamepad.Y, gamepad.leftBumper, gamepad.rightBumper, gamepad.leftTrigger, gamepad.rightTrigger, gamepad.leftStickClick, gamepad.rightStickClick,
				gamepad.back, gamepad.start
			});
			if (stickDirections == SD.verticalsAndHorizontals)
			{
				list.AddRange(new List<Pressable>
				{
					gamepad.leftStick.up,
					gamepad.leftStick.down,
					gamepad.leftStick.left,
					gamepad.leftStick.right,
					gamepad.rightStick.up,
					gamepad.rightStick.down,
					gamepad.rightStick.left,
					gamepad.rightStick.right,
					gamepad.dPad.up,
					gamepad.dPad.down,
					gamepad.dPad.left,
					gamepad.dPad.right
				});
			}
			if (stickDirections == SD.diagonals)
			{
				list.AddRange(new List<Pressable>
				{
					gamepad.leftStick.upLeft,
					gamepad.leftStick.upRight,
					gamepad.leftStick.downLeft,
					gamepad.leftStick.downRight,
					gamepad.rightStick.upLeft,
					gamepad.rightStick.upRight,
					gamepad.rightStick.downLeft,
					gamepad.rightStick.downRight,
					gamepad.dPad.upLeft,
					gamepad.dPad.upRight,
					gamepad.dPad.downLeft,
					gamepad.dPad.downRight
				});
			}
			if (stickDirections == SD.pressedZone)
			{
				list.AddRange(new List<Pressable>
				{
					gamepad.leftStick.inPressedZone,
					gamepad.rightStick.inPressedZone,
					gamepad.dPad.inPressedZone
				});
			}
			return list;
		}

		private void TestCurrentButton()
		{
			if (buttonFeature == BF.none)
			{
				return;
			}
			if (buttonFeature == BF.triggerPosition)
			{
				if (currentButton is Trigger)
				{
					Debug.Log(currentButton.name + " position : " + ((Trigger)currentButton).position);
				}
				else
				{
					Debug.Log("Pressable position is only available on triggers!");
				}
			}
			Press press;
			string text;
			if (buttonFeature == BF.defaultCast)
			{
				press = currentButton;
				text = "default ";
			}
			else if (buttonFeature == BF.simplePress)
			{
				press = currentButton.simplePress;
				text = "";
			}
			else if (buttonFeature == BF.doublePress)
			{
				press = currentButton.doublePress;
				text = "double ";
			}
			else
			{
				if (buttonFeature != BF.longPress)
				{
					return;
				}
				press = currentButton.longPress;
				text = "long ";
			}
			if (pressFeature == PF.defaultCast)
			{
				if ((bool)press)
				{
					Debug.Log(currentButton.name + " is being " + text + "default pressed!!");
				}
				else
				{
					Debug.Log(currentButton.name + " is not being " + text + "default pressed");
				}
			}
			else if (pressFeature == PF.pressedAndReleased)
			{
				if (press.pressed)
				{
					Debug.Log(currentButton.name + " is being " + text + "pressed!!");
				}
				else
				{
					Debug.Log(currentButton.name + " is not being " + text + "pressed");
				}
			}
			else if (pressFeature == PF.justPressedAndJustReleased)
			{
				if (press.justPressed)
				{
					Debug.Log(currentButton.name + " was just " + text + "pressed!!");
				}
				if (press.justReleased)
				{
					Debug.Log(currentButton.name + " was just released after a " + text + "press");
				}
			}
			else if (pressFeature == PF.pressDurationAndReleaseDuration)
			{
				if (press.pressed)
				{
					Debug.Log(currentButton.name + " has been held (" + text + "press) for " + press.pressDuration + " seconds!!!");
				}
				else
				{
					Debug.Log(currentButton.name + " has been released (" + text + "press) for " + press.releaseDuration + " seconds");
				}
			}
		}

		private void TestSticks()
		{
			if (!lockCurrentInput && (currentStick == null || !currentStick.inPressedZone))
			{
				GetNewCurrentStick();
			}
			if (currentStick != null)
			{
				TestCurrentStick();
			}
		}

		private void GetNewCurrentStick()
		{
			if (gamepadMode == GM.individualGamepads)
			{
				Hinput.gamepad.ForEach(UpdateCurrentStickFromGamepad);
			}
			else
			{
				UpdateCurrentStickFromGamepad(Hinput.anyGamepad);
			}
		}

		private void UpdateCurrentStickFromGamepad(Gamepad gamepad)
		{
			if ((bool)gamepad.leftStick.inPressedZone)
			{
				currentStick = gamepad.leftStick;
			}
			else if ((bool)gamepad.rightStick.inPressedZone)
			{
				currentStick = gamepad.rightStick;
			}
			else if ((bool)gamepad.dPad.inPressedZone)
			{
				currentStick = gamepad.dPad;
			}
		}

		private void TestCurrentStick()
		{
			if (stickFeature == SF.worldPositionCamera)
			{
				message.gameObject.SetActive(value: false);
				plane.gameObject.SetActive(value: true);
				redCube.gameObject.SetActive(value: false);
				blueSphere.gameObject.SetActive(value: true);
				Debug.Log(currentStick.name + " is controlling the blue sphere");
				blueSphere.transform.position += moveSpeed * Time.deltaTime * currentStick.worldPositionCamera;
			}
			else if (stickFeature == SF.worldPositionFlat)
			{
				message.gameObject.SetActive(value: false);
				plane.gameObject.SetActive(value: true);
				redCube.gameObject.SetActive(value: true);
				blueSphere.gameObject.SetActive(value: false);
				Debug.Log(currentStick.name + " is controlling the red cube");
				redCube.transform.position += moveSpeed * Time.deltaTime * currentStick.worldPositionFlat;
			}
			else
			{
				message.gameObject.SetActive(value: true);
				plane.gameObject.SetActive(value: false);
				redCube.gameObject.SetActive(value: false);
				blueSphere.gameObject.SetActive(value: false);
			}
			if (stickFeature != 0)
			{
				if (stickFeature == SF.position)
				{
					Debug.Log(currentStick.name + " position : " + currentStick.position.ToString());
				}
				if (stickFeature == SF.horizontal)
				{
					Debug.Log(currentStick.name + " horizontal : " + currentStick.horizontal);
				}
				if (stickFeature == SF.vertical)
				{
					Debug.Log(currentStick.name + " vertical : " + currentStick.vertical);
				}
				if (stickFeature == SF.angle)
				{
					Debug.Log(currentStick.name + " angle : " + currentStick.angle);
				}
				if (stickFeature == SF.distance)
				{
					Debug.Log(currentStick.name + " distance : " + currentStick.distance);
				}
			}
		}

		private void TestVibration()
		{
			if (gamepadMode == GM.anyGamepad)
			{
				TestVibrationOnGamepad(Hinput.anyGamepad);
			}
			if (gamepadMode == GM.individualGamepads)
			{
				TestVibrationOnGamepad(Hinput.gamepad[gamepadToVibrate]);
			}
		}

		private void TestVibrationOnGamepad(Gamepad gamepad)
		{
			if (vibrateOnVPressed && Input.GetKeyDown(KeyCode.V))
			{
				if (vibrationMode == VM.noArgs)
				{
					gamepad.Vibrate();
				}
				if (vibrationMode == VM.duration)
				{
					gamepad.Vibrate(duration);
				}
				if (vibrationMode == VM.intensity)
				{
					gamepad.Vibrate(leftIntensity, rightIntensity);
				}
				if (vibrationMode == VM.durationAndIntensity)
				{
					gamepad.Vibrate(leftIntensity, rightIntensity, duration);
				}
				if (vibrationMode == VM.oneCurve)
				{
					gamepad.Vibrate(curve);
				}
				if (vibrationMode == VM.twoCurves)
				{
					gamepad.Vibrate(leftCurve, rightCurve);
				}
				if (vibrationMode == VM.advanced)
				{
					gamepad.VibrateAdvanced(leftIntensity, rightIntensity);
				}
				if (vibrationMode == VM.vibrationPreset)
				{
					if (multiplyVibrationPreset)
					{
						gamepad.Vibrate(vibrationPreset, leftIntensity, rightIntensity, duration);
					}
					else
					{
						gamepad.Vibrate(vibrationPreset);
					}
				}
			}
			if (stopVibrationOnSPressed && Input.GetKeyDown(KeyCode.S))
			{
				if (stopVibrationDuration.IsEqualTo(0f))
				{
					gamepad.StopVibration();
				}
				else
				{
					gamepad.StopVibration(stopVibrationDuration);
				}
			}
			if (displayIntensity)
			{
				Debug.Log("left vibration : " + gamepad.leftVibration + ", right vibration : " + gamepad.rightVibration);
			}
		}

		private static string ToString<T>(List<T> list)
		{
			if (list.Count == 0)
			{
				return "[]";
			}
			string text = "[";
			for (int i = 0; i < list.Count - 1; i++)
			{
				text = text + list[i]?.ToString() + ", ";
			}
			return text + list[list.Count - 1]?.ToString() + "]";
		}
	}
}
