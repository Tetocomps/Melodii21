using UnityEngine;

public class CutscenePage : MonoBehaviour
{
	public GameObject LastPage;

	public GameObject CurrentPage;

	public GameObject NextPage;

	public GameObject close;

	public GameObject SceneToRemove;

	public bool FinalPage;

	public bool FirstPage;

	private void OnEnable()
	{
		if (!FirstPage)
		{
			LastPage.SetActive(value: false);
		}
		ObjectText.amorgos = true;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt1") && close.activeInHierarchy)
		{
			if (!FinalPage)
			{
				NextPage.SetActive(value: true);
			}
			if (FinalPage)
			{
				ObjectText.amorgos = false;
				CurrentPage.SetActive(value: false);
				SceneToRemove.SetActive(value: false);
			}
		}
	}
}
