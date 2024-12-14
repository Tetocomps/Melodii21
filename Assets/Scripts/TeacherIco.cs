using System.Collections;
using UnityEngine;

public class TeacherIco : MonoBehaviour
{
	public GameObject note_A;

	private bool active;

	public AudioSource cut1;

	private void Start()
	{
		StartCoroutine("Wait");
	}

	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(9.6f);
		active = true;
		yield return new WaitForSeconds(0.5f);
		GetComponent<AudioSource>().Play();
		GameObject clone = Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
		yield return new WaitForSeconds(4.39f);
		base.transform.position = new Vector3(-9.45f, 4.69f, 0f);
		active = false;
		Object.Destroy(clone);
		yield return new WaitForSeconds(4f);
		active = true;
	}

	private void Update()
	{
		if (active)
		{
			base.transform.Translate(3f * Time.deltaTime, 0f, 0f);
		}
	}
}
