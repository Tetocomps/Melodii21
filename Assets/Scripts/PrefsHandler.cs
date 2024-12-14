using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefsHandler : MonoBehaviour
{
	public int CTRlayout;

	public Toggle KB_Toggle;

	public Toggle XB_Toggle;

	public Toggle PS_Toggle;

	public Toggle NS_Toggle;

	public Toggle GEN_Toggle;

	public GameObject KBToggle;

	public GameObject XBToggle;

	public GameObject PSToggle;

	public GameObject NSToggle;

	public GameObject GENToggle;

	private GameObject lastSelected;

	private void Start()
	{
		CTRlayout = PlayerPrefs.GetInt("CTRlayout", 4);
		if (CTRlayout == 1)
		{
			XB_Toggle.isOn = true;
		}
		else if (CTRlayout == 2)
		{
			PS_Toggle.isOn = true;
		}
		else if (CTRlayout == 3)
		{
			NS_Toggle.isOn = true;
		}
		else if (CTRlayout == 4)
		{
			KB_Toggle.isOn = true;
		}
		else if (CTRlayout == 5)
		{
			GEN_Toggle.isOn = true;
		}
	}

	public void XB()
	{
		PlayerPrefs.SetInt("CTRlayout", 1);
	}

	public void PS()
	{
		PlayerPrefs.SetInt("CTRlayout", 2);
	}

	public void NS()
	{
		PlayerPrefs.SetInt("CTRlayout", 3);
	}

	public void KB()
	{
		PlayerPrefs.SetInt("CTRlayout", 4);
	}

	public void GEN()
	{
		PlayerPrefs.SetInt("CTRlayout", 5);
	}

	public void NotInStory()
	{
		PlayerPrefs.SetInt("Story", 0);
	}

	public void InStory()
	{
		PlayerPrefs.SetInt("Story", 1);
	}

	public void ClearData()
	{
		PlayerPrefs.DeleteAll();
	}

	public void OpenOptions()
	{
		CTRlayout = PlayerPrefs.GetInt("CTRlayout", 4);
		if (CTRlayout == 1)
		{
			XB_Toggle.isOn = true;
			EventSystem.current.SetSelectedGameObject(XBToggle);
		}
		else if (CTRlayout == 2)
		{
			PS_Toggle.isOn = true;
			EventSystem.current.SetSelectedGameObject(PSToggle);
		}
		else if (CTRlayout == 3)
		{
			NS_Toggle.isOn = true;
			EventSystem.current.SetSelectedGameObject(NSToggle);
		}
		else if (CTRlayout == 4)
		{
			KB_Toggle.isOn = true;
			EventSystem.current.SetSelectedGameObject(KBToggle);
		}
		else if (CTRlayout == 5)
		{
			GEN_Toggle.isOn = true;
			EventSystem.current.SetSelectedGameObject(GENToggle);
		}
	}

	private void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			if (lastSelected.gameObject.activeSelf && lastSelected.GetComponent<Button>() != null && lastSelected.GetComponent<Button>().interactable)
			{
				EventSystem.current.SetSelectedGameObject(lastSelected);
			}
		}
		else
		{
			lastSelected = EventSystem.current.firstSelectedGameObject;
		}
	}
}
