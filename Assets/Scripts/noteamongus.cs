using UnityEngine;

public class noteamongus : MonoBehaviour
{
	private void Start()
	{
		base.transform.SetParent(GameObject.Find("Rhythm Box").transform);
	}

	private void Update()
	{
	}
}
