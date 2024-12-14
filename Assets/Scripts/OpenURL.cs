using UnityEngine;

public class OpenURL : MonoBehaviour
{
	public string link;

	private void Start()
	{
	}

	public void OpenUrl()
	{
		Application.OpenURL(link);
	}

	private void Update()
	{
	}
}
