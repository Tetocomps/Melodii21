using System.Collections;
using UnityEngine;

public class VideoScene : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Movie());
	}

	public IEnumerator Movie()
	{
		yield return new WaitForSeconds(6.1f);
		Application.LoadLevel("Title");
	}
}
