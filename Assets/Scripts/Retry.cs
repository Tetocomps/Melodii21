using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
	public GameObject Loading;

	public GameObject QuitFade;

	public AudioSource Tw_Loop;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt1"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
			Loading.SetActive(value: true);
		}
		if (Input.GetButtonDown("Butt2"))
		{
			QuitFade.SetActive(value: true);
			Tw_Loop.Stop();
			StartCoroutine(QuitGame());
		}
		static IEnumerator QuitGame()
		{
			yield return new WaitForSecondsRealtime(2f);
			SceneManager.LoadSceneAsync("Title");
		}
	}
}
