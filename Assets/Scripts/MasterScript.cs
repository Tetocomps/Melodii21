using UnityEngine;

public class MasterScript : MonoBehaviour
{
	public static MasterScript GM;

	public GameObject soundManager;

	public bool hasKeyboard;

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}
}
