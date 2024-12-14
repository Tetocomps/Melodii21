using SonicBloom.Koreo;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
	public bool active;

	public Animator Up;

	public Animator Down;

	public Animator Left;

	public Animator Right;

	public int points;

	public int pointsNeeded;

	public AudioSource Ups;

	public AudioSource Downs;

	public AudioSource Lefts;

	public AudioSource Rights;

	public bool busy;

	public Animator musicbox;

	public AudioSource good;

	public AudioSource bad;

	public Animator player;

	public GameObject ItemGet;

	public GameObject Close;

	public GameObject Lock;

	public AudioSource music;

	public Animator Tag;

	[EventID]
	public string Up_note;

	[EventID]
	public string Down_note;

	[EventID]
	public string Left_note;

	[EventID]
	public string Right_note;

	[EventID]
	public string Up_P;

	[EventID]
	public string Down_P;

	[EventID]
	public string Left_P;

	[EventID]
	public string Right_P;

	[EventID]
	public string End;

	[EventID]
	public string StartUp;

	private void OnEnable()
	{
		Koreographer.Instance.RegisterForEvents(Up_note, On_Up);
		Koreographer.Instance.RegisterForEvents(Down_note, On_Down);
		Koreographer.Instance.RegisterForEvents(Left_note, On_Left);
		Koreographer.Instance.RegisterForEvents(Right_note, On_Right);
		Koreographer.Instance.RegisterForEvents(Up_P, On_UpP);
		Koreographer.Instance.RegisterForEvents(Down_P, On_DownP);
		Koreographer.Instance.RegisterForEvents(Left_P, On_LeftP);
		Koreographer.Instance.RegisterForEvents(Right_P, On_RightP);
		Koreographer.Instance.RegisterForEvents(StartUp, On_Start);
		Koreographer.Instance.RegisterForEvents(End, On_End);
		music.Stop();
		NenreiOW.canMove = false;
	}

	private void Update()
	{
		if (active && !busy)
		{
			if (Input.GetAxisRaw("Vertical") > 0f)
			{
				Up.SetTrigger("go");
				Ups.Play();
				busy = true;
			}
			else if (Input.GetAxisRaw("Vertical") < 0f)
			{
				Down.SetTrigger("go");
				Downs.Play();
				busy = true;
			}
			else if (Input.GetAxisRaw("Horizontal") < 0f)
			{
				Left.SetTrigger("go");
				Lefts.Play();
				busy = true;
			}
			else if (Input.GetAxisRaw("Horizontal") > 0f)
			{
				Right.SetTrigger("go");
				Rights.Play();
				busy = true;
			}
		}
		if (Close.activeInHierarchy && Input.GetButtonDown("Butt1"))
		{
			ItemGet.SetActive(value: false);
			player.SetTrigger("CloseNotif");
			music.mute = false;
		}
		if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f)
		{
			busy = false;
		}
	}

	private void On_Start(KoreographyEvent evt)
	{
		active = true;
		Tag.SetTrigger("yourturn");
	}

	private void On_End(KoreographyEvent evt)
	{
		active = false;
		Tag.SetTrigger("stop");
		if (points >= pointsNeeded)
		{
			musicbox.SetTrigger("open");
			good.Play();
			player.SetTrigger("ItemGet");
			Lock.SetActive(value: false);
			ES3.Save("hasMelSticker", value: true);
		}
		else
		{
			bad.Play();
			music.Play();
			musicbox.SetTrigger("stop");
			ObjectText.amorgos = false;
		}
	}

	private void On_Up(KoreographyEvent evt)
	{
		Up.SetTrigger("go");
		Ups.Play();
	}

	private void On_Down(KoreographyEvent evt)
	{
		Down.SetTrigger("go");
		Downs.Play();
	}

	private void On_Left(KoreographyEvent evt)
	{
		Left.SetTrigger("go");
		Lefts.Play();
	}

	private void On_Right(KoreographyEvent evt)
	{
		Right.SetTrigger("go");
		Rights.Play();
	}

	private void On_UpP(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Vertical") > 0f && !busy)
		{
			points++;
		}
	}

	private void On_DownP(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Vertical") < 0f && !busy)
		{
			points++;
		}
	}

	private void On_LeftP(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Horizontal") < 0f && !busy)
		{
			points++;
		}
	}

	private void On_RightP(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Horizontal") > 0f && !busy)
		{
			points++;
		}
	}
}
