using System.Collections;
using UnityEngine;

public class MiraIco : MonoBehaviour
{
	public GameObject note_A;

	public GameObject note_ZL;

	public GameObject note_ZR;

	public GameObject note_B;

	public GameObject note_Y;

	public GameObject note_X;

	public GameObject note_left;

	public GameObject note_up;

	public GameObject note_right;

	private bool active;

	public AudioClip p1;

	public AudioClip p2;

	public AudioClip p3;

	public AudioClip p4;

	public AudioClip p5;

	public AudioClip p6;

	public AudioClip p7;

	public AudioClip p8;

	public AudioClip p9;

	public AudioClip p10;

	public AudioClip p11;

	public AudioClip p12;

	public AudioClip p13;

	public AudioClip p14;

	public AudioClip p15;

	public AudioClip p16;

	public AudioClip p17;

	public AudioClip p18;

	public AudioClip p19;

	public AudioClip p20;

	public AudioClip p21;

	public AudioClip p22;

	public AudioSource voice;

	private void Start()
	{
		StartCoroutine("Wait");
	}

	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(51.92f);
		active = true;
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p1;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p2;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p3;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p4;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p5;
		voice.Play();
		yield return new WaitForSeconds(0.46f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p6;
		voice.Play();
		yield return new WaitForSeconds(0.46f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p7;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p8;
		voice.Play();
		yield return new WaitForSeconds(0.115f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p9;
		voice.Play();
		yield return new WaitForSeconds(0.115f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p10;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p11;
		voice.Play();
		yield return new WaitForSeconds(0.115f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p12;
		voice.Play();
		yield return new WaitForSeconds(0.57f);
		base.transform.position = new Vector3(-8.735f, 3.38f, 0f);
		active = false;
		yield return new WaitForSeconds(0f);
		active = true;
		yield return new WaitForSeconds(0.46f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p13;
		voice.Play();
		yield return new WaitForSeconds(0.46f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p14;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p15;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p16;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p17;
		voice.Play();
		yield return new WaitForSeconds(0.23f);
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		voice.clip = p18;
		voice.Play();
		yield return new WaitForSeconds(0.115f);
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		voice.clip = p19;
		voice.Play();
		yield return new WaitForSeconds(0.8f);
		GameObject original = note_left;
		Vector3 position = (base.transform.position = new Vector3(-5.53f, -2.91f, 2.09f));
		Object.Instantiate(original, position, base.transform.rotation);
		voice.clip = p20;
		voice.Play();
		yield return new WaitForSeconds(0.46f);
		GameObject original2 = note_up;
		position = (base.transform.position = new Vector3(-3.5f, -0.49f, 2.09f));
		Object.Instantiate(original2, position, base.transform.rotation);
		voice.clip = p21;
		voice.Play();
		yield return new WaitForSeconds(0.46f);
		GameObject original3 = note_right;
		position = (base.transform.position = new Vector3(-1.51f, -2.91f, 2.09f));
		Object.Instantiate(original3, position, base.transform.rotation);
		voice.clip = p22;
		voice.Play();
		yield return new WaitForSeconds(0f);
		base.transform.position = new Vector3(-8.735f, 4.69f, 0f);
		active = false;
		GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
		GameObject[] array = GameObject.FindGameObjectsWithTag("Note");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
		}
		yield return new WaitForSeconds(9.23f);
		active = true;
	}

	private void Update()
	{
		if (active)
		{
			base.transform.Translate(3.75f * Time.deltaTime, 0f, 0f);
		}
	}
}
