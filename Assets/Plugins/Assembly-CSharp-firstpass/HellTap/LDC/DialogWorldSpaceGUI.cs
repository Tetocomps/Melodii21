using UnityEngine;

namespace HellTap.LDC
{
	[RequireComponent(typeof(MeshCollider))]
	public class DialogWorldSpaceGUI : MonoBehaviour
	{
		public enum InputMode
		{
			Disabled = 0,
			Mouse = 1,
			Transform = 2
		}

		public enum ScrollingMode
		{
			NoScrolling = 0,
			ScrollWithInputAxes = 1,
			ScrollWithInputKeyCodes = 2
		}

		public static DialogWorldSpaceGUI com = null;

		public static Vector3 rayStartPoint = Vector3.zero;

		public static Vector3 rayEndPoint = Vector3.zero;

		private Renderer _renderer;

		private MeshCollider _meshCollider;

		[Header("Input Mode")]
		public InputMode inputMode = InputMode.Mouse;

		[Header("Mouse Input Mode")]
		public float mouseScrollWheelSensitivity = 1f;

		[Header("Transform Input Mode")]
		public Transform inputModeTransform;

		public KeyCode inputModeKeyCode = KeyCode.JoystickButton0;

		public LDCInputAxes inputScrollHorizontal = new LDCInputAxes("Horizontal");

		public LDCInputAxes inputScrollVertical = new LDCInputAxes("Vertical");

		[Header("Raycasts")]
		public float raycastDistance = 100f;

		public bool ignoreObstacles = true;

		public LayerMask raycastLayerMask = 32;

		public string raycastTag = "";

		[Header("[Optional] Camera")]
		public Camera cachedMainCamera;

		[Header("Options")]
		public bool useScreenKeyboardForDataEntry = true;

		public bool debugRaycasts;

		private Ray _ray;

		private RaycastHit[] _hits = new RaycastHit[30];

		private RaycastHit _hit;

		private RaycastHit _currentHit;

		private int _raycastHitLength;

		private float _distance;

		private float _closest;

		private bool _foundHit;

		private readonly LayerMask _layerMaskAll = -1;

		private Vector2 _pixelUV = Vector2.zero;

		private bool simulatedMouseWithinScreen;

		private Vector2 simulatedMousePosition = Vector2.zero;

		private bool _inputButton;

		private bool _inputButtonUp;

		private bool _inputButtonDown;

		private Vector2 _scrollDelta = Vector2.zero;

		private Vector2 _inputKeycodesV2 = Vector2.zero;

		private const float _keyCodeSpeed = 7.5f;

		public ScrollingMode scrollingMode;

		public KeyCode kcScrollLeft = KeyCode.LeftArrow;

		public KeyCode kcScrollRight = KeyCode.RightArrow;

		public KeyCode kcScrollUp = KeyCode.UpArrow;

		public KeyCode kcScrollDown = KeyCode.DownArrow;

		public float scrollSensitivity = 30f;

		private static Vector3 _matrixPos = default(Vector3);

		private static Vector3 _matrixSize = default(Vector3);

		private static Rect _dynamicBlockWidthRect = default(Rect);

		private static Rect _dynamicBlockHeightRect = default(Rect);

		private void Awake()
		{
			com = this;
		}

		private void Start()
		{
			_renderer = GetComponent<Renderer>();
			_meshCollider = GetComponent<MeshCollider>();
			if (_meshCollider == null || _meshCollider.sharedMesh == null)
			{
				Debug.LogError("LDC - DIALOG WORLD SPACE SCREEN: A MeshCollider either doesn't exist or doesn't have a sharedMesh. Make sure a MeshCollider is correctly setup on the gameObject: " + base.gameObject.name);
			}
			if (Object.FindObjectsOfType(typeof(DialogWorldSpaceGUI)).Length > 1)
			{
				Debug.LogError("LDC - DIALOG WORLD SPACE SCREEN: You should only ever have 1 DialogWorldSpaceGUI components in the scene at a time!");
			}
			if (!Application.isEditor)
			{
				debugRaycasts = false;
			}
		}

		private void Update()
		{
			HandleInputButtons();
			if (DialogUI.ended || (DialogOnGUI.com != null && DialogOnGUI.com.renderMode != OnGuiRenderMode.Material) || _meshCollider == null || _meshCollider.sharedMesh == null)
			{
				_pixelUV = Vector2.zero;
				simulatedMousePosition = Vector2.zero;
				simulatedMouseWithinScreen = false;
				if (_renderer.enabled)
				{
					_renderer.enabled = false;
				}
				return;
			}
			if (!_renderer.enabled)
			{
				_renderer.enabled = true;
			}
			if (inputMode == InputMode.Mouse)
			{
				if (cachedMainCamera != null)
				{
					_ray = cachedMainCamera.ScreenPointToRay(Input.mousePosition);
				}
				else
				{
					_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				}
			}
			else
			{
				if (inputMode != InputMode.Transform)
				{
					_pixelUV = Vector2.zero;
					simulatedMousePosition = Vector2.zero;
					simulatedMouseWithinScreen = false;
					return;
				}
				_ray.origin = inputModeTransform.position;
				_ray.direction = inputModeTransform.TransformDirection(Vector3.forward);
			}
			DoRaycast();
		}

		private void DoRaycast()
		{
			_closest = 10000f;
			_foundHit = false;
			_raycastHitLength = Physics.RaycastNonAlloc(_ray, _hits, raycastDistance, ignoreObstacles ? _layerMaskAll : raycastLayerMask);
			for (int i = 0; i < _raycastHitLength; i++)
			{
				_hit = _hits[i];
				_distance = _hit.distance;
				if (ignoreObstacles && _hit.collider == _meshCollider)
				{
					_closest = _distance;
					_currentHit = _hit;
					_foundHit = true;
					break;
				}
				if (!ignoreObstacles && _distance < _closest && (raycastTag == string.Empty || _hit.transform.CompareTag(raycastTag)))
				{
					_closest = _distance;
					_currentHit = _hit;
					_foundHit = true;
				}
			}
			if (_foundHit)
			{
				rayStartPoint = _ray.origin;
				rayEndPoint = _currentHit.point;
				if (_currentHit.collider == _meshCollider)
				{
					if (debugRaycasts)
					{
						Debug.DrawLine(_ray.origin, _currentHit.point, Color.green);
					}
					if (inputMode == InputMode.Disabled)
					{
						_pixelUV = Vector2.one * -1f;
						simulatedMouseWithinScreen = true;
					}
					else
					{
						_pixelUV = _currentHit.textureCoord;
						simulatedMouseWithinScreen = true;
					}
				}
				else
				{
					_pixelUV = Vector2.zero;
					simulatedMouseWithinScreen = false;
					if (debugRaycasts)
					{
						Debug.DrawLine(_ray.origin, _currentHit.point, Color.red);
					}
				}
			}
			else
			{
				_pixelUV = Vector2.zero;
				simulatedMouseWithinScreen = false;
				rayStartPoint = _ray.origin;
				rayEndPoint = _ray.origin + _ray.direction * raycastDistance;
				if (debugRaycasts)
				{
					Debug.DrawLine(_ray.origin, rayEndPoint, Color.red);
				}
			}
			simulatedMousePosition.x = (float)Screen.width * _pixelUV.x;
			simulatedMousePosition.y = (float)Screen.height - (float)Screen.height * _pixelUV.y;
		}

		public static Vector2 GetSimulatedMousePosition()
		{
			if (com == null)
			{
				return Vector2.zero;
			}
			return com.simulatedMousePosition;
		}

		public void HandleInputButtons()
		{
			if (DialogOnGUI.com != null && DialogOnGUI.com.renderMode == OnGuiRenderMode.Material)
			{
				_inputButton = false;
				_inputButtonUp = false;
				_inputButtonDown = false;
				_scrollDelta = Vector2.zero;
				if (com.inputMode == InputMode.Mouse)
				{
					_inputKeycodesV2 = Vector2.zero;
					_inputButton = Input.GetMouseButton(0);
					_inputButtonUp = Input.GetMouseButtonUp(0);
					_inputButtonDown = Input.GetMouseButtonDown(0);
					_scrollDelta = Input.mouseScrollDelta * mouseScrollWheelSensitivity;
				}
				else
				{
					if (com.inputMode != InputMode.Transform)
					{
						return;
					}
					_inputButton = Input.GetKey(com.inputModeKeyCode);
					_inputButtonUp = Input.GetKeyUp(com.inputModeKeyCode);
					_inputButtonDown = Input.GetKeyDown(com.inputModeKeyCode);
					if (scrollingMode == ScrollingMode.NoScrolling)
					{
						return;
					}
					if (scrollingMode == ScrollingMode.ScrollWithInputAxes)
					{
						if (inputScrollHorizontal.axis != string.Empty)
						{
							_scrollDelta.x = Input.GetAxis(inputScrollHorizontal.axis) * (inputScrollHorizontal.invert ? (-1f) : 1f);
							_scrollDelta.x *= scrollSensitivity;
						}
						else
						{
							_scrollDelta.x = 0f;
						}
						if (inputScrollVertical.axis != string.Empty)
						{
							_scrollDelta.y = Input.GetAxis(inputScrollVertical.axis) * (inputScrollVertical.invert ? (-1f) : 1f);
							_scrollDelta.y *= scrollSensitivity;
						}
						else
						{
							_scrollDelta.y = 0f;
						}
					}
					else if (scrollingMode == ScrollingMode.ScrollWithInputKeyCodes)
					{
						if ((Input.GetKey(kcScrollLeft) && Input.GetKey(kcScrollRight)) || (!Input.GetKey(kcScrollLeft) && !Input.GetKey(kcScrollRight)))
						{
							_inputKeycodesV2.x = Mathf.MoveTowards(_inputKeycodesV2.x, 0f, Time.deltaTime * 7.5f);
						}
						else if (Input.GetKey(kcScrollLeft) && !Input.GetKey(kcScrollRight))
						{
							_inputKeycodesV2.x = Mathf.MoveTowards(_inputKeycodesV2.x, -1f, Time.deltaTime * 7.5f);
						}
						else if (!Input.GetKey(kcScrollLeft) && Input.GetKey(kcScrollRight))
						{
							_inputKeycodesV2.x = Mathf.MoveTowards(_inputKeycodesV2.x, 1f, Time.deltaTime * 7.5f);
						}
						if ((Input.GetKey(kcScrollDown) && Input.GetKey(kcScrollUp)) || (!Input.GetKey(kcScrollDown) && !Input.GetKey(kcScrollUp)))
						{
							_inputKeycodesV2.y = Mathf.MoveTowards(_inputKeycodesV2.y, 0f, Time.deltaTime * 7.5f);
						}
						else if (Input.GetKey(kcScrollDown) && !Input.GetKey(kcScrollUp))
						{
							_inputKeycodesV2.y = Mathf.MoveTowards(_inputKeycodesV2.y, -1f, Time.deltaTime * 7.5f);
						}
						else if (!Input.GetKey(kcScrollDown) && Input.GetKey(kcScrollUp))
						{
							_inputKeycodesV2.y = Mathf.MoveTowards(_inputKeycodesV2.y, 1f, Time.deltaTime * 7.5f);
						}
						_scrollDelta = _inputKeycodesV2 * scrollSensitivity;
					}
				}
			}
			else
			{
				_inputButton = false;
				_inputButtonUp = false;
				_inputButtonDown = false;
				_scrollDelta = Vector2.zero;
			}
		}

		public static Vector2 GetInputScrollDelta()
		{
			if (com == null)
			{
				return Vector2.zero;
			}
			return com._scrollDelta;
		}

		public static bool GetInputButton()
		{
			if (com == null)
			{
				return false;
			}
			return com._inputButton;
		}

		public static bool GetInputButtonUp()
		{
			if (com == null)
			{
				return false;
			}
			return com._inputButtonUp;
		}

		public static bool GetInputButtonDown()
		{
			if (com == null)
			{
				return false;
			}
			return com._inputButtonDown;
		}

		public static bool SimulatedMouseIsWithinScreen()
		{
			if (com == null)
			{
				return false;
			}
			return com.simulatedMouseWithinScreen;
		}

		public static Rect ApplyMatrixToRect(Rect rect, Matrix4x4 matrix)
		{
			_matrixPos.x = rect.x;
			_matrixPos.y = rect.y;
			_matrixPos.z = 0f;
			_matrixPos = matrix.MultiplyPoint3x4(_matrixPos);
			_matrixSize.x = rect.width;
			_matrixSize.y = rect.height;
			_matrixSize.z = 0f;
			_matrixSize = matrix.MultiplyPoint3x4(_matrixSize);
			rect.x = _matrixPos.x;
			rect.y = _matrixPos.y;
			rect.width = _matrixSize.x;
			rect.height = _matrixSize.y;
			return rect;
		}

		public static bool SimulatedMouseIsWithinRect(Rect rect, Matrix4x4 matrix)
		{
			if (com == null)
			{
				return false;
			}
			if (!com.simulatedMouseWithinScreen)
			{
				return false;
			}
			_dynamicBlockWidthRect = rect;
			_dynamicBlockWidthRect.x += rect.width;
			_dynamicBlockHeightRect = rect;
			_dynamicBlockHeightRect.y += rect.height;
			rect = ApplyMatrixToRect(rect, matrix);
			_dynamicBlockWidthRect = ApplyMatrixToRect(_dynamicBlockWidthRect, matrix);
			_dynamicBlockHeightRect = ApplyMatrixToRect(_dynamicBlockHeightRect, matrix);
			if (_dynamicBlockWidthRect.Contains(com.simulatedMousePosition))
			{
				return false;
			}
			if (_dynamicBlockHeightRect.Contains(com.simulatedMousePosition))
			{
				return false;
			}
			return rect.Contains(com.simulatedMousePosition);
		}

		public static bool SimulatedMouseIsWithinAScrollViewRect(Rect buttonRect, Rect blockSpacerWidthRect, Rect blockSpacerHeightRect, Rect scrollViewRect, Matrix4x4 matrix)
		{
			if (com == null)
			{
				return false;
			}
			if (!com.simulatedMouseWithinScreen)
			{
				return false;
			}
			buttonRect = ApplyMatrixToRect(buttonRect, matrix);
			scrollViewRect = ApplyMatrixToRect(scrollViewRect, matrix);
			blockSpacerWidthRect = ApplyMatrixToRect(blockSpacerWidthRect, matrix);
			blockSpacerHeightRect = ApplyMatrixToRect(blockSpacerHeightRect, matrix);
			if (scrollViewRect.Contains(com.simulatedMousePosition))
			{
				if (blockSpacerWidthRect.Contains(com.simulatedMousePosition) || blockSpacerHeightRect.Contains(com.simulatedMousePosition))
				{
					return false;
				}
				return buttonRect.Contains(com.simulatedMousePosition);
			}
			return false;
		}
	}
}
