using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectText : MonoBehaviour
{
	public string NextScene;

	public float letPause;

	public float letPauseOrigin;

	public float spacePause;

	public string message;

	public TextMeshProUGUI Phrase;

	public GameObject choice;

	public Animator speakerIco;

	public Animator player;

	public bool ready;

	public AudioSource voice;

	public float line = 1f;

	public GameObject close;

	public GameObject textBox;

	private bool lastCharPunctuation;

	private char charComma;

	private char charPeriod;

	private char charExclam;

	private char charQmark;

	private char charEmpty;

	public bool CanSkip = true;

	public bool IsCutscene;

	public GameObject Cutscene;

	public bool Person;

	public Animator NPC;

	public static bool amorgos;

	public bool NotStupid = true;

	public bool Choice;

	public bool MusicBox;

	private void OnEnable()
	{
		if (NotStupid)
		{
			amorgos = true;
		}
		charComma = Convert.ToChar(44);
		charPeriod = Convert.ToChar("!");
		charExclam = Convert.ToChar(46);
		charEmpty = Convert.ToChar(" ");
		ready = false;
		close.SetActive(value: false);
		Phrase = GetComponent<TextMeshProUGUI>();
		Phrase.text = "";
		StartCoroutine(TypeText());
	}

	private IEnumerator TypeText()
	{
		letPause = letPauseOrigin;
		speakerIco.SetTrigger("speak");
		char[] array = message.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char letter = array[i];
			if (!ready)
			{
				Phrase.text += letter;
				voice.Play();
				yield return 0;
				yield return new WaitForSeconds(letPause);
				if (lastCharPunctuation)
				{
					voice.Pause();
					yield return new WaitForSeconds(letPause = spacePause);
					lastCharPunctuation = false;
				}
				if (letter == charComma || letter == charPeriod || letter == charExclam)
				{
					voice.Pause();
					lastCharPunctuation = true;
				}
				else if (letter == charEmpty)
				{
					voice.Pause();
				}
				else
				{
					letPause = letPauseOrigin;
				}
			}
		}
		if (Phrase.text == message)
		{
			if (Choice)
			{
				choice.SetActive(value: true);
			}
			else
			{
				close.SetActive(value: true);
			}
		}
	}

	private void Update()
	{
		if (!NotStupid)
		{
			return;
		}
		if (Input.GetButtonDown("Butt1") && close.activeInHierarchy && ready)
		{
			textBox.SetActive(value: false);
			if (Person)
			{
				NPC.SetTrigger("stop");
			}
			if (IsCutscene)
			{
				Cutscene.SetActive(value: true);
			}
			if (!MusicBox)
			{
				amorgos = false;
			}
		}
		else if (Input.GetButtonDown("Butt1") && !ready && CanSkip)
		{
			Phrase.text = message;
			ready = true;
			close.SetActive(value: true);
			if (!MusicBox)
			{
				amorgos = false;
			}
			if (Person)
			{
				NPC.SetTrigger("stop");
			}
			if (IsCutscene)
			{
				Cutscene.SetActive(value: true);
			}
		}
	}
}
