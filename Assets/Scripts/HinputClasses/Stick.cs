using HinputClasses.Internal;
using UnityEngine;

namespace HinputClasses
{
	public class Stick
	{
		public readonly int index;

		public readonly string name;

		public readonly Gamepad gamepad;

		private readonly Axis horizontalAxis;

		private readonly Axis verticalAxis;

		private Vector2 positionRaw;

		public readonly StickPressedZone inPressedZone;

		public readonly StickDirection up;

		public readonly StickDirection down;

		public readonly StickDirection left;

		public readonly StickDirection right;

		public readonly StickDirection upLeft;

		public readonly StickDirection downLeft;

		public readonly StickDirection upRight;

		public readonly StickDirection downRight;

		public bool isEnabled { get; private set; }

		public Vector2 position { get; private set; }

		public float horizontal => position.x;

		public float vertical => position.y;

		public float distance => Mathf.Clamp01(position.magnitude);

		public float angle
		{
			get
			{
				if (position.sqrMagnitude.IsEqualTo(0f))
				{
					return 0f;
				}
				return Vector2.SignedAngle(Vector2.right, position);
			}
		}

		public Vector3 worldPositionCamera
		{
			get
			{
				try
				{
					return Settings.worldCamera.right * horizontal + Settings.worldCamera.up * vertical;
				}
				catch
				{
					Debug.LogError("Hinput error : No camera found !");
				}
				return Vector2.zero;
			}
		}

		public Vector3 worldPositionFlat => new Vector3(horizontal, 0f, vertical);

		public void Enable()
		{
			isEnabled = true;
		}

		public void Disable()
		{
			Reset();
			isEnabled = false;
		}

		public void Reset()
		{
			positionRaw = Vector2.zero;
			up.Reset();
			down.Reset();
			left.Reset();
			right.Reset();
			upLeft.Reset();
			downLeft.Reset();
			upRight.Reset();
			downRight.Reset();
			inPressedZone.Reset();
		}

		public static implicit operator Vector2(Stick stick)
		{
			return stick.position;
		}

		public static implicit operator bool(Stick stick)
		{
			return stick.inPressedZone;
		}

		public Stick(string stickName, Gamepad gamepad, int index, bool isEnabled)
		{
			this.gamepad = gamepad;
			this.index = index;
			this.isEnabled = isEnabled;
			name = gamepad.name + "_" + stickName;
			up = new StickDirection("Up", 90f, this);
			down = new StickDirection("Down", -90f, this);
			left = new StickDirection("Left", 180f, this);
			right = new StickDirection("Right", 0f, this);
			upLeft = new StickDirection("UpLeft", 135f, this);
			downLeft = new StickDirection("DownLeft", -135f, this);
			upRight = new StickDirection("UpRight", 45f, this);
			downRight = new StickDirection("DownRight", -45f, this);
			inPressedZone = new StickPressedZone("PressedZone", this);
			if (index == 0 || index == 1)
			{
				horizontalAxis = new Axis(Utils.os.ToString() + "_" + name + "_Horizontal");
				verticalAxis = new Axis(Utils.os.ToString() + "_" + name + "_Vertical");
			}
			if (index == 2)
			{
				horizontalAxis = new Axis(Utils.os.ToString() + "_" + name + "_Horizontal", Utils.os.ToString() + "_" + name + "_Right", Utils.os.ToString() + "_" + name + "_Left");
				verticalAxis = new Axis(Utils.os.ToString() + "_" + name + "_Vertical", Utils.os.ToString() + "_" + name + "_Up", Utils.os.ToString() + "_" + name + "_Down");
			}
		}

		protected virtual Vector2 GetPosition()
		{
			if (Settings.stickDeadZone.IsEqualTo(1f))
			{
				return Vector2.zero;
			}
			if (positionRaw.magnitude < Settings.stickDeadZone)
			{
				return Vector2.zero;
			}
			return (1.01f / (1f - Settings.stickDeadZone) * (positionRaw - positionRaw.normalized * Settings.stickDeadZone)).Clamp(-1f, 1f);
		}

		public void Update()
		{
			if (isEnabled)
			{
				if (horizontalAxis != null && verticalAxis != null)
				{
					positionRaw = new Vector2(horizontalAxis.GetPosition(), verticalAxis.GetPosition());
				}
				position = GetPosition();
				inPressedZone.Update();
				up.Update();
				down.Update();
				left.Update();
				right.Update();
				upLeft.Update();
				downLeft.Update();
				upRight.Update();
				downRight.Update();
			}
		}
	}
}
