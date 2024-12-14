using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuRestore : MonoBehaviour
{
	public GameObject Return;

	private GameObject lastSelected;

	private void Start()
	{
	}

	private void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null && lastSelected.gameObject.activeSelf && lastSelected.GetComponent<Button>() != null && lastSelected.GetComponent<Button>().interactable)
		{
			EventSystem.current.SetSelectedGameObject(Return);
		}
	}
}
