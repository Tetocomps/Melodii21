using System.Collections;
using SonicBloom.Koreo;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MentorIcoRiv1 : MonoBehaviour
{
	public bool InStory;

	public int story;

	public bool FirstTime;

	public Animator RhyBox;

	public bool BlueLine = true;

	public bool PinkLine;

	public bool DoubleLineNext;

	public Animator Rep;

	public Animator Sup;

	public Animator Double;

	public GameObject playerico;

	public ParticleSystem Trail;

	public int ExtraCount;

	public GameObject Line6P;

	public GameObject Line7P;

	public GameObject note_A;

	public GameObject note_ZL;

	public GameObject note_ZR;

	public GameObject note_B;

	public GameObject note_Y;

	public GameObject note_X;

	public GameObject note_up;

	public GameObject note_down;

	public GameObject note_left;

	public GameObject note_right;

	public GameObject Rhybox;

	public GameObject Scene1;

	public GameObject Scene2;

	public GameObject Scene3;

	public TextMeshProUGUI caption;

	public Animator PlayerL1;

	public Animator MentorL1;

	public Animator MentorBL1;

	public Animator MentorL2;

	public Animator MentorBL2;

	public Animator MentorL3;

	public Animator camera;

	public bool done;

	public float Speed;

	public AudioSource Song;

	private bool active;

	public Animator lowflipper;

	public Animator highflipper;

	public Animator self;

	public float Butt2Presses;

	public float Butt1Presses;

	public float Butt3Presses;

	public float Butt4Presses;

	public float LeftPresses;

	public float RightPresses;

	public float DownPresses;

	public float UpPresses;

	public float ZLPresses;

	public float ZRPresses;

	public float Line;

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

	public AudioClip p23;

	public AudioClip p24;

	public AudioClip p25;

	public AudioClip p26;

	public AudioClip p27;

	public AudioClip p28;

	public AudioClip p29;

	public AudioClip p30;

	public AudioClip p31;

	public AudioClip p32;

	public AudioClip p33;

	public AudioClip p34;

	public AudioClip p35;

	public AudioClip p36;

	public AudioClip p37;

	public AudioClip p38;

	public AudioClip p39;

	public AudioClip p40;

	public AudioClip p41;

	public AudioClip p42;

	public AudioClip p43;

	public AudioClip p44;

	public AudioClip p45;

	public AudioClip p46;

	public AudioClip p47;

	public AudioClip p48;

	public AudioClip p49;

	public AudioClip p50;

	public AudioClip p51;

	public AudioClip p52;

	public AudioClip p53;

	public AudioClip p54;

	public AudioClip p55;

	public AudioClip p56;

	public AudioClip p57;

	public AudioClip p58;

	public AudioClip p59;

	public AudioClip p60;

	public AudioClip p61;

	public AudioClip p62;

	public AudioClip p63;

	public AudioClip p64;

	public AudioClip p65;

	public AudioClip p66;

	public AudioClip p67;

	public AudioClip p68;

	public AudioClip p69;

	public AudioClip p70;

	public AudioClip p71;

	public AudioClip p72;

	public AudioClip p73;

	public AudioClip p74;

	public AudioClip p75;

	public AudioClip p76;

	public AudioClip p77;

	public AudioClip p78;

	public AudioClip p79;

	public AudioClip p80;

	public AudioClip p81;

	public AudioClip p82;

	public AudioClip p83;

	public AudioClip p84;

	public AudioClip p85;

	public AudioClip p86;

	public AudioSource voice;

	public AudioSource Up;

	public AudioSource Up2;

	public AudioSource Up3;

	public AudioSource Up4;

	public AudioSource Down;

	public AudioSource Down2;

	public AudioSource Down3;

	public AudioSource Down4;

	public AudioSource Left;

	public AudioSource Left2;

	public AudioSource Left3;

	public AudioSource Left4;

	public AudioSource Right;

	public AudioSource Right2;

	public AudioSource Right3;

	public AudioSource Right4;

	public AudioSource A;

	public AudioSource A2;

	public AudioSource A3;

	public AudioSource A4;

	public AudioSource B;

	public AudioSource B2;

	public AudioSource B3;

	public AudioSource B4;

	public AudioSource X;

	public AudioSource X2;

	public AudioSource X3;

	public AudioSource X4;

	public AudioSource Y;

	public AudioSource Y2;

	public AudioSource Y3;

	public AudioSource Y4;

	public AudioSource L;

	public AudioSource L2;

	public AudioSource L3;

	public AudioSource L4;

	public AudioSource R;

	public AudioSource R2;

	public AudioSource R3;

	public AudioSource R4;

	[EventID]
	public string A_note;

	[EventID]
	public string B_note;

	[EventID]
	public string X_note;

	[EventID]
	public string Y_note;

	[EventID]
	public string L_note;

	[EventID]
	public string R_note;

	[EventID]
	public string Up_note;

	[EventID]
	public string Down_note;

	[EventID]
	public string Left_note;

	[EventID]
	public string Right_note;

	[EventID]
	public string LineStart;

	[EventID]
	public string LineEnd;

	[EventID]
	public string LineNext;

	[EventID]
	public string PlayerLineEnd;

	[EventID]
	public string Intro;

	[EventID]
	public string EndSong;

	public Slider ResultsSlider;

	public GameObject Funkcount;

	public GameObject Stylecount;

	public GameObject ACPcount;

	public GameObject Rewards;

	public bool ResultsTime;

	public GameObject Results;

	public AudioSource tick;

	public int StyleAdded;

	public int FunkAdded;

	public int ACPAdded;

	public bool Funkdone;

	public bool Styledone;

	public bool ACPdone;

	public Canvas UIjunk;

	public GameObject UIjunk1;

	public GameObject HiFiBonus;

	public GameObject WoahFiBonus;

	public GameObject RhyCam;

	public bool BonusAdded;

	public Animator MelodiiRes;

	public GameObject Srank;

	public GameObject Arank;

	public GameObject Brank;

	public GameObject Crank;

	public GameObject Drank;

	public bool NewRecord;

	public GameObject NewRecordSplash;

	public float highScore;

	public float defaultValue;

	private float firstTime;

	public GameObject ResultsTheme;

	public GameObject CloseReg;

	public GameObject CloseStory;

	private void Start()
	{
		story = PlayerPrefs.GetInt("Story");
		if (story == 0)
		{
			InStory = false;
		}
		else
		{
			InStory = true;
		}
		firstTime = ES3.Load("FirstTimeCCI", defaultValue);
		if (firstTime == 0f)
		{
			FirstTime = true;
		}
		Koreographer.Instance.RegisterForEvents(LineStart, On_LineStart);
		Koreographer.Instance.RegisterForEvents(LineNext, On_NextLine);
		Koreographer.Instance.RegisterForEvents(LineEnd, On_LineEnd);
		Koreographer.Instance.RegisterForEvents(PlayerLineEnd, On_PLineEnd);
		Koreographer.Instance.RegisterForEvents(A_note, On_Abutt);
		Koreographer.Instance.RegisterForEvents(B_note, On_Bbutt);
		Koreographer.Instance.RegisterForEvents(X_note, On_Xbutt);
		Koreographer.Instance.RegisterForEvents(Y_note, On_Ybutt);
		Koreographer.Instance.RegisterForEvents(L_note, On_Lbutt);
		Koreographer.Instance.RegisterForEvents(R_note, On_Rbutt);
		Koreographer.Instance.RegisterForEvents(Up_note, On_Up);
		Koreographer.Instance.RegisterForEvents(Down_note, On_Down);
		Koreographer.Instance.RegisterForEvents(Left_note, On_Left);
		Koreographer.Instance.RegisterForEvents(Right_note, On_Right);
		Koreographer.Instance.RegisterForEvents(Intro, On_Intro);
		Koreographer.Instance.RegisterForEvents(EndSong, On_EndSong);
	}

	private void On_EndSong(KoreographyEvent evt)
	{
		self.SetTrigger("cry");
		ResultsTime = true;
		Results.SetActive(value: true);
		UIjunk.enabled = false;
		UIjunk1.SetActive(value: false);
		RhyCam.SetActive(value: false);
	}

	private void Bonus()
	{
		if (PlayerIcoLvL1.HiFi && !BonusAdded)
		{
			BonusAdded = true;
			HiFiBonus.SetActive(value: true);
			ResultsSlider.value += 25f;
		}
		else if (PlayerIcoLvL1.WoahFi && !BonusAdded)
		{
			BonusAdded = true;
			WoahFiBonus.SetActive(value: true);
			ResultsSlider.value += 400f;
		}
	}

	private void On_Intro(KoreographyEvent evt)
	{
		if (Line == 3f)
		{
			if (ExtraCount == 1)
			{
				MentorBL2.SetTrigger("Go");
				ExtraCount++;
			}
			else
			{
				Scene2.SetActive(value: false);
				Scene3.SetActive(value: true);
				RhyBox.SetTrigger("boxout");
			}
		}
		else
		{
			MentorBL1.SetTrigger("bam");
			MentorBL1.SetTrigger("bam");
		}
	}

	private void On_Up(KoreographyEvent evt)
	{
		if (!SumScoreManager.UpNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.UpNeeded = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak1");
		MentorBL1.SetTrigger("Up");
		if (UpPresses == 0f)
		{
			Up.Play();
			UpPresses += 1f;
		}
		else if (UpPresses == 1f)
		{
			Up2.Play();
			UpPresses += 1f;
		}
		else if (UpPresses == 2f)
		{
			Up3.Play();
			UpPresses += 1f;
		}
		else if (UpPresses >= 3f)
		{
			Up4.Play();
			UpPresses += 1f;
		}
	}

	private void On_Down(KoreographyEvent evt)
	{
		if (!SumScoreManager.DownNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.DownNeeded = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak1");
		MentorBL1.SetTrigger("Down");
		if (DownPresses == 0f)
		{
			Down.Play();
			DownPresses += 1f;
		}
		else if (DownPresses == 1f)
		{
			Down2.Play();
			DownPresses += 1f;
		}
		else if (DownPresses == 2f)
		{
			Down3.Play();
			DownPresses += 1f;
		}
		else if (DownPresses >= 3f)
		{
			Down4.Play();
			DownPresses += 1f;
		}
	}

	private void On_Left(KoreographyEvent evt)
	{
		if (!SumScoreManager.LeftNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.LeftNeeded = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak1");
		MentorBL1.SetTrigger("Left");
		if (LeftPresses == 0f)
		{
			Left.Play();
			LeftPresses += 1f;
		}
		else if (LeftPresses == 1f)
		{
			Left2.Play();
			LeftPresses += 1f;
		}
		else if (LeftPresses == 2f)
		{
			Left3.Play();
			LeftPresses += 1f;
		}
		else if (LeftPresses >= 3f)
		{
			Left4.Play();
			LeftPresses += 1f;
		}
	}

	private void On_Right(KoreographyEvent evt)
	{
		if (!SumScoreManager.RightNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.RightNeeded = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak1");
		MentorBL1.SetTrigger("Right");
		if (RightPresses == 0f)
		{
			Right.Play();
			RightPresses += 1f;
		}
		else if (RightPresses == 1f)
		{
			Right2.Play();
			RightPresses += 1f;
		}
		else if (RightPresses == 2f)
		{
			Right3.Play();
			RightPresses += 1f;
		}
		else if (RightPresses >= 3f)
		{
			Right4.Play();
			RightPresses += 1f;
		}
	}

	private void On_Abutt(KoreographyEvent evt)
	{
		if (!SumScoreManager.Butt1Needed)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.Butt1Needed = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("A");
		MentorL2.SetTrigger("A");
		if (Butt1Presses == 0f)
		{
			A.Play();
			Butt1Presses += 1f;
			if (Line == 4f)
			{
				Scene3.SetActive(value: false);
				Scene1.SetActive(value: true);
				PlayerL1.SetTrigger("escape");
			}
		}
		else if (Butt1Presses == 1f)
		{
			A2.Play();
			Butt1Presses += 1f;
		}
		else if (Butt1Presses == 2f)
		{
			A3.Play();
			Butt1Presses += 1f;
		}
		else if (Butt1Presses >= 3f)
		{
			A4.Play();
			Butt1Presses += 1f;
		}
	}

	private void On_Bbutt(KoreographyEvent evt)
	{
		if (!SumScoreManager.Butt2Needed)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.Butt2Needed = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("B");
		MentorL2.SetTrigger("B");
		if (Butt2Presses == 0f)
		{
			B.Play();
			Butt2Presses += 1f;
		}
		else if (Butt2Presses == 1f)
		{
			B2.Play();
			Butt2Presses += 1f;
		}
		else if (Butt2Presses == 2f)
		{
			B3.Play();
			Butt2Presses += 1f;
		}
		else if (Butt2Presses >= 3f)
		{
			B4.Play();
			Butt2Presses += 1f;
		}
	}

	private void On_Xbutt(KoreographyEvent evt)
	{
		if (!SumScoreManager.Butt4Needed)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.Butt4Needed = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("X");
		if (Butt4Presses == 0f)
		{
			X.Play();
			Butt4Presses += 1f;
			MentorL2.SetTrigger("X");
		}
		else if (Butt4Presses == 1f)
		{
			X2.Play();
			Butt4Presses += 1f;
			MentorL2.SetTrigger("X2");
		}
		else if (Butt4Presses == 2f)
		{
			X3.Play();
			Butt4Presses += 1f;
		}
		else if (Butt4Presses >= 3f)
		{
			X4.Play();
			Butt4Presses += 1f;
		}
	}

	private void On_Ybutt(KoreographyEvent evt)
	{
		if (!SumScoreManager.Butt3Needed)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.Butt3Needed = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("Y");
		if (Butt3Presses == 0f)
		{
			Y.Play();
			Butt3Presses += 1f;
			MentorL2.SetTrigger("Y");
		}
		else if (Butt3Presses == 1f)
		{
			Y2.Play();
			Butt3Presses += 1f;
			MentorL2.SetTrigger("Y2");
		}
		else if (Butt3Presses == 2f)
		{
			Y3.Play();
			Butt3Presses += 1f;
		}
		else if (Butt3Presses >= 3f)
		{
			Y4.Play();
			Butt3Presses += 1f;
		}
	}

	private void On_Lbutt(KoreographyEvent evt)
	{
		SumScoreManager.ZLNeeded = true;
		if (!SumScoreManager.ZLNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("L");
		if (ZLPresses == 0f)
		{
			L.Play();
			ZLPresses += 1f;
		}
		else if (ZLPresses == 1f)
		{
			L2.Play();
			ZLPresses += 1f;
		}
		else if (ZLPresses == 2f)
		{
			L3.Play();
			ZLPresses += 1f;
		}
		else if (ZLPresses >= 3f)
		{
			L4.Play();
			ZLPresses += 1f;
		}
	}

	private void On_Rbutt(KoreographyEvent evt)
	{
		if (!SumScoreManager.ZRNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.ZRNeeded = true;
		SumScoreManager.NoteAmount++;
		Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		self.SetTrigger("speak");
		MentorL1.SetTrigger("R");
		if (ZRPresses == 0f)
		{
			R.Play();
			ZRPresses += 1f;
		}
		else if (ZRPresses == 1f)
		{
			R2.Play();
			ZRPresses += 1f;
		}
		else if (ZRPresses == 2f)
		{
			R3.Play();
			ZRPresses += 1f;
		}
		else if (ZRPresses >= 3f)
		{
			R4.Play();
			ZRPresses += 1f;
		}
	}

	private void SwitchCam()
	{
		camera.SetTrigger("MentorTurn");
	}

	private void On_LineStart(KoreographyEvent evt)
	{
		Trail.Play();
		SumScoreManager.ButtsNeeded = 0;
		KillNotes();
		Line += 1f;
		active = true;
		highflipper.SetTrigger("flipup");
		GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
		GameObject[] array = GameObject.FindGameObjectsWithTag("NoteClone");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
		}
		done = false;
		Debug.Log("ButtsNeeded: " + SumScoreManager.ButtsNeeded);
		if (BlueLine)
		{
			Rep.SetTrigger("In");
		}
		else if (PinkLine)
		{
			Sup.SetTrigger("In");
		}
		if (DoubleLineNext)
		{
			Double.SetTrigger("In");
			DoubleLineNext = false;
		}
		else
		{
			Double.SetTrigger("Out");
		}
		_ = Line;
		_ = 2f;
		if (Line == 3f)
		{
			caption.text = "Hey DJ, I've gotta admit, this kid's got style and bars to spit...";
			Scene2.SetActive(value: true);
		}
		if (Line == 4f)
		{
			RhyBox.SetTrigger("boxin");
		}
		_ = Line;
		_ = 5f;
		if (Line == 7f)
		{
			SumScoreManager.ButtsNeeded = 2;
		}
	}

	private void On_NextLine(KoreographyEvent evt)
	{
		if (active)
		{
			base.transform.localPosition = new Vector3(-9.7f, 2.982475f, 12.91997f);
			MentorL1.SetTrigger("stop");
			MentorBL1.SetTrigger("stop");
		}
		if (BlueLine)
		{
			Rep.SetTrigger("Out");
		}
		else if (PinkLine)
		{
			Sup.SetTrigger("Out");
		}
	}

	private void On_LineEnd(KoreographyEvent evt)
	{
		Trail.Stop();
		caption.text = "";
		MentorL1.SetTrigger("stop");
		base.transform.localPosition = new Vector3(-11.31f, 4.292475f, 12.91997f);
		active = false;
		highflipper.SetTrigger("flipdown");
		GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
		GameObject[] array = GameObject.FindGameObjectsWithTag("NoteClone");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
		}
		done = true;
		Debug.Log("ButtsNeeded: " + SumScoreManager.ButtsNeeded);
		MentorL1.SetTrigger("Stop");
		MentorBL1.SetTrigger("stop");
		if (BlueLine)
		{
			Rep.SetTrigger("Out");
		}
		else if (PinkLine)
		{
			Sup.SetTrigger("Out");
		}
		if (Line == 2f)
		{
			DoubleLineNext = true;
		}
		if (Line == 3f)
		{
			DoubleLineNext = true;
		}
		if (Line == 4f)
		{
			DoubleLineNext = true;
		}
	}

	private void On_PLineEnd(KoreographyEvent evt)
	{
		if (Line == 4f && done)
		{
			KillNotes();
		}
		if (Line == 5f && done)
		{
			KillNotes();
		}
	}

	private void KillNotes()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("NoteClone");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].transform.localPosition = new Vector3(-27.78f, -12.65f, 12.91997f);
		}
		Butt2Presses = 0f;
		Butt1Presses = 0f;
		Butt3Presses = 0f;
		Butt4Presses = 0f;
		LeftPresses = 0f;
		RightPresses = 0f;
		DownPresses = 0f;
		UpPresses = 0f;
		ZLPresses = 0f;
		ZRPresses = 0f;
		SumScoreManager.NoteAmount = 0;
		SumScoreManager.Butt1Needed = false;
		SumScoreManager.Butt2Needed = false;
		SumScoreManager.Butt3Needed = false;
		SumScoreManager.Butt4Needed = false;
		SumScoreManager.UpNeeded = false;
		SumScoreManager.DownNeeded = false;
		SumScoreManager.LeftNeeded = false;
		SumScoreManager.RightNeeded = false;
		SumScoreManager.ZRNeeded = false;
		SumScoreManager.ZLNeeded = false;
	}

	private void Update()
	{
		BlueLine = PlayerIcoRiv1.BlueLine1;
		PinkLine = PlayerIcoRiv1.PinkLine1;
		if (active && Line == 2f)
		{
			caption.text = "Got that sweet sweet magic!";
		}
		if (ResultsTime)
		{
			if (!Funkdone)
			{
				ResultsSlider.value += 4f;
				tick.Play();
				FunkAdded += 4;
				if (FunkAdded > PlayerIcoRiv1.FunkStatic)
				{
					FunkAdded = PlayerIcoRiv1.FunkStatic;
				}
				if (FunkAdded == PlayerIcoRiv1.FunkStatic)
				{
					Funkdone = true;
				}
			}
			if (Funkdone && !Styledone)
			{
				Stylecount.SetActive(value: true);
				ResultsSlider.value += 4f;
				tick.Play();
				StyleAdded += 4;
				if (StyleAdded > PlayerIcoRiv1.StyleStatic)
				{
					StyleAdded = PlayerIcoRiv1.StyleStatic;
				}
				if (StyleAdded >= PlayerIcoRiv1.StyleStatic)
				{
					Styledone = true;
				}
			}
			if (Styledone && !ACPdone)
			{
				Funkcount.SetActive(value: true);
				ResultsSlider.value += 4f;
				tick.Play();
				ACPAdded += 4;
				if (ACPAdded > PlayerIcoRiv1.ACPStatic)
				{
					ACPAdded = PlayerIcoRiv1.ACPStatic;
				}
				if (ACPAdded >= PlayerIcoRiv1.ACPStatic)
				{
					ACPdone = true;
				}
			}
			if (ACPdone)
			{
				highScore = ES3.Load("HighScoreCCI", defaultValue);
				ACPcount.SetActive(value: true);
				StartCoroutine(GiveRank());
				if (ResultsSlider.value > highScore)
				{
					NewRecord = true;
					ES3.Save("HighScoreCCI", ResultsSlider.value);
				}
			}
		}
		if (active)
		{
			base.transform.Translate(Speed * Time.deltaTime, 0f, 0f);
			if (!PinkLine)
			{
				playerico.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
		if (Line == 1f)
		{
			MentorL1.SetInteger("Line", 1);
			A.clip = p1;
			A2.clip = p1;
			Y.clip = p2;
			Y2.clip = p3;
			B.clip = p4;
			X.clip = p5;
		}
		if (Line == 2f)
		{
			MentorL1.SetInteger("Line", 2);
			X.clip = p6;
			Y.clip = p7;
			A.clip = p8;
			A2.clip = p33;
			L.clip = p9;
		}
		if (Line == 3f)
		{
			Scene1.SetActive(value: false);
			X.clip = p10;
			X2.clip = p11;
			Y.clip = p12;
			Y2.clip = p13;
			A.clip = p14;
			B.clip = p15;
			B2.clip = p16;
			B3.clip = p17;
			L.clip = p18;
			A2.clip = p19;
			R.clip = p20;
			R2.clip = p21;
			R3.clip = p22;
		}
		if (Line == 4f)
		{
			MentorL1.SetInteger("Line", 1);
			A.clip = p1;
			A2.clip = p1;
			Left.clip = p23;
			Left2.clip = p23;
			Up.clip = p24;
			Up2.clip = p24;
			Y.clip = p2;
			Y2.clip = p3;
			B.clip = p4;
			X.clip = p5;
		}
		if (Line == 5f)
		{
			MentorL1.SetInteger("Line", 2);
			Up.clip = p25;
			Down.clip = p26;
			Right.clip = p27;
			Right2.clip = p27;
			Up2.clip = p25;
			Up3.clip = p25;
			X.clip = p6;
			Y.clip = p7;
			A.clip = p8;
			A2.clip = p33;
			L.clip = p9;
		}
		if (Line == 6f)
		{
			Line6P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 2;
			Up.clip = p28;
			Left.clip = p29;
			Right.clip = p30;
			Down.clip = p31;
			Down2.clip = p32;
			SumScoreManager.Butt1Needed = true;
			SumScoreManager.ButtsNeeded = 1;
		}
		if (Line == 7f)
		{
			Line7P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 5;
			Up.clip = p28;
			Left.clip = p29;
			Right.clip = p30;
			Down.clip = p31;
			Down2.clip = p32;
			SumScoreManager.Butt2Needed = true;
			SumScoreManager.Butt4Needed = true;
		}
	}

	private IEnumerator GiveRank()
	{
		Bonus();
		yield return new WaitForSeconds(2f);
		if (ResultsSlider.value >= 1650f)
		{
			Srank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("Riv1rank", 5);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 1288f && ResultsSlider.value < 1650f)
		{
			Arank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("Riv1rank", 4);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 1005f && ResultsSlider.value < 1288f)
		{
			Brank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("Riv1rank", 3);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 700f && ResultsSlider.value < 1005f)
		{
			Crank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("Riv1rank", 2);
			}
			MelodiiRes.SetTrigger("okay");
		}
		else
		{
			Drank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("Riv1rank", 1);
			}
			MelodiiRes.SetTrigger("okay");
		}
		yield return new WaitForSeconds(3f);
		ResultsTheme.SetActive(value: true);
		if (InStory)
		{
			ES3.Save("Level", 2);
			CloseStory.SetActive(value: true);
		}
		else
		{
			CloseReg.SetActive(value: true);
		}
	}

	public void HeadOut()
	{
		SceneManager.LoadSceneAsync("LevelSelect");
		PlayerPrefs.SetInt("LastLevelPlayed", 1);
	}
}
