using SonicBloom.Koreo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SongWithintroLoop : MonoBehaviour
{
	public AudioSource Intro;

	public AudioSource Loop;

	public Animator dancer;

	public bool SongToLoop;

	[EventID]
	public string Beat;

	private GameObject lastSelected;

	private void Start()
	{
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 1;
		if (SongToLoop)
		{
			double num = (double)Intro.clip.samples / (double)Intro.clip.frequency;
			double dspTime = AudioSettings.dspTime;
			Intro.PlayScheduled(dspTime);
			Loop.PlayScheduled(dspTime + num);
		}
		Koreographer.Instance.RegisterForEvents(Beat, On_Beat);
		PlayerPrefs.SetInt("LastLevelPlayed", 0);
	}

	private void On_Beat(KoreographyEvent evt)
	{
		dancer.SetTrigger("bop");
	}

	public void Menu()
	{
		EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
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
