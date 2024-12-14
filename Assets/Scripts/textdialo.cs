using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textdialo : MonoBehaviour
{
	public string NextScene;

	public float letPause = 0.05f;

	public string message;

	public Text Phrase;

	public GameObject choice;

	public Animator speakerIco;

	public Animator player;

	public bool ready;

	public AudioSource voice;

	public float line = 1f;

	public GameObject close;

	public GameObject textBox;

	public GameObject loadscreen;

	public bool CanSkip = true;

	private void OnEnable()
	{
		Phrase = GetComponent<Text>();
		message = Phrase.text;
		message = "Yo. You ready to rock?";
		Phrase.text = "";
		StartCoroutine(TypeText());
	}

	private IEnumerator TypeText()
	{
		letPause = 0.05f;
		speakerIco.SetTrigger("speak");
		char[] array = message.ToCharArray();
		foreach (char c in array)
		{
			Phrase.text += c;
			voice.Play();
			yield return 0;
			yield return new WaitForSeconds(letPause);
		}
		if (line == 1f)
		{
			speakerIco.SetTrigger("neutral");
			choice.SetActive(value: true);
			ready = true;
		}
		else if (line == 2f)
		{
			speakerIco.SetTrigger("neutral");
			close.SetActive(value: true);
			ready = true;
		}
	}

	private IEnumerator LetsaGo()
	{
		yield return new WaitForSeconds(1f);
		loadscreen.SetActive(value: true);
		SceneManager.LoadScene(NextScene);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt1") && ready && line == 1f)
		{
			player.SetTrigger("pose");
			StartCoroutine(LetsaGo());
		}
		if (Input.GetButtonDown("Butt1") && !ready && CanSkip)
		{
			letPause = 0f;
		}
		if (Input.GetButtonDown("Butt2") && ready && line == 1f)
		{
			choice.SetActive(value: false);
			line += 1f;
			Phrase.text = "";
			message = "Take your time, little dude.";
			StartCoroutine(TypeText());
		}
		if (Input.GetButtonDown("Butt1") && line == 2f && ready)
		{
			line = 1f;
			textBox.SetActive(value: false);
		}
	}
}
