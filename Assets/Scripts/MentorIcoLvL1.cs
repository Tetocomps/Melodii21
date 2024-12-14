using System.Collections;
using SonicBloom.Koreo;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MentorIcoLvL1 : MonoBehaviour
{
	public bool InStory;

	public bool FirstTime;

	public bool DemoFin;

	public int story;

	public Animator RhyBox;

	public bool BlueLine = true;

	public bool PinkLine;

	public bool DoubleLineNext;

	public Animator Rep;

	public Animator Sup;

	public Animator Double;

	public GameObject playerico;

	public ParticleSystem Trail;

	public GameObject Line5P;

	public GameObject Line6P;

	public GameObject Line7P;

	public GameObject Line8P;

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

	public TextMeshProUGUI caption;

	public Animator MentorL1;

	public Animator MentorL2;

	public Animator MentorL3;

	public Animator MentorClean1;

	public Animator MentorClean2;

	public Animator MentorCoast;

	public Animator MentorArt;

	public Animator MentorFresh;

	public Animator MentorSeason;

	public Animator MentorCoin;

	public Animator Register;

	public Animator ArtCam;

	public Animator camera;

	public Animator CoastCam;

	public GameObject FlipFry;

	public GameObject GreasePop;

	public GameObject Cleanin1;

	public GameObject Cleanin2;

	public GameObject ScratchMore;

	public bool ScratchMoreDone;

	public Animator Didkid;

	public GameObject Bag;

	public GameObject Customers;

	public GameObject CustomersBack;

	public GameObject CustomersHalf;

	public GameObject CustomersDone;

	public Animator Cus1;

	public Animator Cus2;

	public Animator Cus3;

	public Animator Cus1m;

	public Animator Cus2m;

	public Animator Cus3m;

	public GameObject BurgerArt;

	public GameObject HandleThis;

	public GameObject Breather;

	public GameObject GrooveCoast;

	public GameObject FreshOut;

	public GameObject SeasonStyle;

	public GameObject CoinPile;

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
	public string EndSong;

	[EventID]
	public string SceneSwap;

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

	private float demoNum;

	public GameObject ResultsTheme;

	public GameObject CloseReg;

	public GameObject CloseStory;

	public GameObject CloseThx;

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
		firstTime = ES3.Load("FirstTimeGP", defaultValue);
		if (firstTime == 0f)
		{
			FirstTime = true;
			ES3.Save("Demo", 1);
		}
		demoNum = ES3.Load("DemoGP", defaultValue);
		if (demoNum == 0f)
		{
			DemoFin = true;
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
		Koreographer.Instance.RegisterForEvents(EndSong, On_EndSong);
		Koreographer.Instance.RegisterForEvents(SceneSwap, On_SceneSwap);
	}

	private void On_Up(KoreographyEvent evt)
	{
		if (!SumScoreManager.UpNeeded)
		{
			SumScoreManager.ButtsNeeded++;
		}
		SumScoreManager.UpNeeded = true;
		SumScoreManager.NoteAmount++;
		if (Line == 1f)
		{
			Customers.SetActive(value: true);
		}
		if (Line != 6f)
		{
			Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
		}
		self.SetTrigger("speak");
		MentorL1.SetTrigger("Up");
		if (Line == 5f)
		{
			MentorClean1.SetTrigger("Up");
		}
		if (Line == 6f)
		{
			MentorClean2.SetTrigger("Up");
		}
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
		self.SetTrigger("speak");
		MentorL1.SetTrigger("Down");
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
		self.SetTrigger("speak");
		MentorL1.SetTrigger("Left");
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
		self.SetTrigger("speak");
		MentorL1.SetTrigger("Right");
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
		MentorL1.SetTrigger("Butt1");
		if (Line == 9f)
		{
			MentorL2.SetTrigger("Butt1");
		}
		else if (Line == 10f)
		{
			MentorL3.SetTrigger("speak");
		}
		else if (Line == 5f)
		{
			MentorClean1.SetTrigger("Butt1");
		}
		else if (Line == 13f)
		{
			MentorSeason.SetTrigger("A");
		}
		if (Butt1Presses == 0f)
		{
			if (Line == 1f)
			{
				A.PlayOneShot(p4);
			}
			else
			{
				A.Play();
			}
			if (Line == 14f)
			{
				MentorCoin.SetTrigger("A");
			}
			Butt1Presses += 1f;
			if (Line == 12f)
			{
				MentorFresh.SetTrigger("B");
			}
		}
		else if (Butt1Presses == 1f)
		{
			A2.Play();
			Butt1Presses += 1f;
			if (Line == 12f)
			{
				MentorFresh.SetTrigger("B2");
			}
			if (Line == 14f)
			{
				MentorCoin.SetTrigger("A2");
			}
		}
		else if (Butt1Presses == 2f)
		{
			A3.Play();
			Butt1Presses += 1f;
			if (Line == 12f)
			{
				MentorFresh.SetTrigger("A3");
			}
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
		MentorL1.SetTrigger("Butt2");
		if (Line == 9f)
		{
			MentorL2.SetTrigger("Butt2");
		}
		if (Line == 7f)
		{
			MentorArt.SetTrigger("Butt2");
		}
		else if (Line == 13f)
		{
			MentorSeason.SetTrigger("B");
		}
		if (Butt2Presses == 0f)
		{
			if (Line == 1f)
			{
				B.PlayOneShot(p5);
			}
			else
			{
				B.Play();
			}
			Butt2Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("Butt2");
			}
			else if (Line == 10f)
			{
				MentorL3.SetTrigger("speak2");
			}
			else if (Line == 12f)
			{
				MentorFresh.SetTrigger("B");
			}
			if (Line == 14f)
			{
				MentorCoin.SetTrigger("B");
			}
		}
		else if (Butt2Presses == 1f)
		{
			if (Line == 1f)
			{
				B2.PlayOneShot(p6);
			}
			else
			{
				B2.Play();
			}
			Butt2Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("B2");
			}
			else if (Line == 10f)
			{
				MentorL3.SetTrigger("speak2");
			}
			else if (Line == 12f)
			{
				MentorFresh.SetTrigger("B2");
			}
			if (Line == 14f)
			{
				MentorCoin.SetTrigger("B2");
			}
		}
		else if (Butt2Presses == 2f)
		{
			B3.Play();
			Butt2Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("Butt2");
			}
			else if (Line == 10f)
			{
				MentorL3.SetTrigger("speak2");
			}
			else if (Line == 12f)
			{
				MentorFresh.SetTrigger("B");
			}
		}
		else if (Butt2Presses >= 3f)
		{
			B4.Play();
			Butt2Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("B2");
			}
			else if (Line == 6f)
			{
				MentorL3.SetTrigger("speak2");
			}
			else if (Line == 12f)
			{
				MentorFresh.SetTrigger("B2");
			}
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
		MentorL1.SetTrigger("Butt4");
		if (Line == 10f)
		{
			MentorL3.SetTrigger("speak");
		}
		if (Line == 5f)
		{
			MentorClean1.SetTrigger("Butt4");
		}
		if (Line == 6f)
		{
			MentorClean2.SetTrigger("Butt4");
		}
		if (Line == 8f)
		{
			MentorArt.SetTrigger("Butt4");
		}
		if (Line == 11f)
		{
			MentorCoast.SetTrigger("Butt4");
		}
		if (Line == 13f)
		{
			MentorSeason.SetTrigger("X");
		}
		if (Line == 14f)
		{
			MentorCoin.SetTrigger("X");
		}
		if (Butt4Presses == 0f)
		{
			X.Play();
			Butt4Presses += 1f;
			if (Line >= 9f)
			{
				MentorL2.SetTrigger("Butt4");
			}
		}
		else if (Butt4Presses == 1f)
		{
			X2.Play();
			Butt4Presses += 1f;
			if (Line >= 9f)
			{
				MentorL2.SetTrigger("X2");
			}
			if (Line == 14f)
			{
				Register.SetTrigger("Close");
			}
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
		MentorL1.SetTrigger("Butt3");
		if (Line == 10f)
		{
			MentorL3.SetTrigger("speak");
		}
		if (Line == 5f)
		{
			MentorClean1.SetTrigger("Butt3");
		}
		if (Line == 6f)
		{
			MentorClean2.SetTrigger("Butt3");
		}
		if (Line == 8f)
		{
			MentorArt.SetTrigger("Butt3");
		}
		if (Line == 10f)
		{
			MentorArt.SetTrigger("Butt3");
		}
		if (Line == 11f)
		{
			MentorCoast.SetTrigger("Butt3");
		}
		if (Butt3Presses == 0f)
		{
			camera.SetTrigger("MentorTurn");
			Y.Play();
			Butt3Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("Butt3");
			}
			if (Line == 13f)
			{
				MentorSeason.SetTrigger("Y");
			}
		}
		else if (Butt3Presses == 1f)
		{
			Y2.Play();
			Butt3Presses += 1f;
			if (Line == 9f)
			{
				MentorL2.SetTrigger("Y2");
			}
			if (Line == 13f)
			{
				MentorSeason.SetTrigger("Y2");
			}
		}
		else if (Butt3Presses == 2f)
		{
			Y3.Play();
			Butt3Presses += 1f;
			if (Line >= 9f)
			{
				MentorL2.SetTrigger("Y2");
			}
		}
		else if (Butt3Presses >= 3f)
		{
			Y4.Play();
			Butt3Presses += 1f;
			if (Line >= 9f)
			{
				MentorL2.SetTrigger("Y2");
			}
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
		MentorL1.SetTrigger("ZL");
		if (Line == 5f)
		{
			MentorClean1.SetTrigger("ZL");
		}
		if (Line == 6f)
		{
			MentorClean2.SetTrigger("ZL");
		}
		if (Line == 12f)
		{
			MentorFresh.SetTrigger("L");
		}
		if (Line == 13f)
		{
			MentorSeason.SetTrigger("L");
		}
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
		MentorL1.SetTrigger("ZR");
		if (Line == 5f)
		{
			MentorClean1.SetTrigger("ZR");
		}
		if (Line == 6f)
		{
			MentorClean2.SetTrigger("ZR");
		}
		if (Line == 12f)
		{
			MentorFresh.SetTrigger("R");
		}
		if (Line == 13f)
		{
			MentorSeason.SetTrigger("R");
		}
		if (Line == 14f)
		{
			MentorCoin.SetTrigger("R");
		}
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
		MentorL1.SetInteger("Line", MentorL1.GetInteger("Line") + 1);
		camera.SetInteger("Line", MentorL1.GetInteger("Line") + 1);
		active = true;
		highflipper.SetTrigger("flipup");
		GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
		GameObject[] array = GameObject.FindGameObjectsWithTag("NoteClone");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
		}
		done = false;
		Cus1.SetTrigger("synthz");
		Cus2.SetTrigger("synthz");
		Cus3.SetTrigger("synthz");
		Cus1m.SetTrigger("synthz");
		Cus2m.SetTrigger("synthz");
		Cus3m.SetTrigger("synthz");
		Debug.Log("ButtsNeeded: " + SumScoreManager.ButtsNeeded);
		if (DoubleLineNext)
		{
			Double.SetTrigger("In");
			DoubleLineNext = false;
		}
		else if (Line != 5f || Line != 8f)
		{
			Double.SetTrigger("Out");
		}
		_ = Line;
		_ = 5f;
		if (Line == 6f)
		{
			base.transform.localPosition = new Vector3(-11.31f, 2.982475f, 12.91997f);
		}
		if (Line == 7f)
		{
			caption.text = "Burgers?";
		}
		if (Line == 8f)
		{
			caption.text = "The grill?";
		}
		if (Line == 9f)
		{
			RhyBox.SetTrigger("blue");
			PlayerIcoLvL1.BlueLine1 = true;
			PlayerIcoLvL1.PinkLine1 = false;
			camera.SetTrigger("line5");
			HandleThis.SetActive(value: false);
			CustomersBack.SetActive(value: false);
			CustomersHalf.SetActive(value: true);
		}
		if (Line == 8f)
		{
			ArtCam.SetTrigger("Mentor");
		}
		if (Line == 14f)
		{
			CoinPile.SetActive(value: true);
			caption.text = "Gotta put effort to chase that coin pile";
		}
	}

	private void On_NextLine(KoreographyEvent evt)
	{
		if (active)
		{
			base.transform.localPosition = new Vector3(-9.7f, 2.982475f, 12.91997f);
		}
		if (BlueLine || Line == 6f)
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
		MentorL2.SetTrigger("done");
		if (BlueLine)
		{
			Rep.SetTrigger("Out");
		}
		else if (PinkLine)
		{
			Sup.SetTrigger("Out");
		}
		if (Line == 5f)
		{
			DoubleLineNext = true;
		}
		if (Line == 8f)
		{
			DoubleLineNext = true;
		}
		if (Line == 9f)
		{
			DoubleLineNext = true;
		}
		if (Line == 11f)
		{
			CoastCam.SetTrigger("MelTurn");
		}
		if (Line == 5f)
		{
			Didkid.SetTrigger("yes");
			Bag.SetActive(value: false);
		}
		if (Line == 17f)
		{
			MentorL1.SetTrigger("stop");
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
		if (Line == 8f)
		{
			caption.text = "Now, let's get to work and see if you can handle this...";
			HandleThis.SetActive(value: true);
			BurgerArt.SetActive(value: false);
		}
	}

	private void On_SceneSwap(KoreographyEvent evt)
	{
		if (Line == 7f)
		{
			Cleanin2.SetActive(value: false);
			BurgerArt.SetActive(value: true);
		}
		if (Line == 6f)
		{
			Cleanin1.SetActive(value: false);
			Cleanin2.SetActive(value: true);
		}
		if (Line == 14f)
		{
			if (ScratchMoreDone)
			{
				ScratchMore.SetActive(value: false);
				Scene1.SetActive(value: true);
				camera.SetTrigger("line12");
				caption.text = "";
			}
			else
			{
				CoinPile.SetActive(value: false);
				ScratchMore.SetActive(value: true);
				ScratchMoreDone = true;
				caption.text = "";
			}
		}
		if (Line >= 17f)
		{
			Customers.SetActive(value: false);
			CustomersHalf.SetActive(value: false);
			CustomersDone.SetActive(value: true);
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

	private void On_EndSong(KoreographyEvent evt)
	{
		ResultsTime = true;
		Results.SetActive(value: true);
		UIjunk.enabled = false;
		UIjunk1.SetActive(value: false);
		RhyCam.SetActive(value: false);
		if (FirstTime)
		{
			ES3.Save("FirstTimeGP", 1f);
		}
	}

	private void Bonus()
	{
		if (PlayerIcoLvL1.HiFi && !BonusAdded)
		{
			BonusAdded = true;
			HiFiBonus.SetActive(value: true);
			ResultsSlider.value += 500f;
		}
		else if (PlayerIcoLvL1.WoahFi && !BonusAdded)
		{
			BonusAdded = true;
			WoahFiBonus.SetActive(value: true);
			ResultsSlider.value += 1000f;
		}
	}

	private void Update()
	{
		BlueLine = PlayerIcoLvL1.BlueLine1;
		PinkLine = PlayerIcoLvL1.PinkLine1;
		if (active)
		{
			if (Line == 4f)
			{
				caption.text = "Order up!";
			}
			if (Line == 6f)
			{
				caption.text = "Order up!";
			}
			if (Line == 9f)
			{
				caption.text = "Flippin' and fryin' to keep myself from dying...";
			}
			if (Line == 10f)
			{
				caption.text = "The grease keeps poppin', my grooves are non-stoppin'";
			}
			if (Line == 11f)
			{
				caption.text = "Groove coastin', smooth roastin'";
			}
			if (Line == 12f)
			{
				caption.text = "Cookin' burgers like I'm fresh out the ocean";
			}
			if (Line == 13f)
			{
				caption.text = "Season them with style to make them worth while";
			}
		}
		if (ResultsTime)
		{
			if (!Funkdone)
			{
				ResultsSlider.value += 5f;
				tick.Play();
				FunkAdded += 5;
				if (FunkAdded >= PlayerIcoLvL1.FunkStatic)
				{
					Funkdone = true;
				}
			}
			if (Funkdone && !Styledone)
			{
				Stylecount.SetActive(value: true);
				ResultsSlider.value += 5f;
				tick.Play();
				StyleAdded += 5;
				if (StyleAdded >= PlayerIcoLvL1.StyleStatic)
				{
					Styledone = true;
				}
			}
			if (Styledone && !ACPdone)
			{
				Funkcount.SetActive(value: true);
				ResultsSlider.value += 5f;
				tick.Play();
				ACPAdded += 5;
				if (ACPAdded >= PlayerIcoLvL1.ACPStatic)
				{
					ACPdone = true;
				}
			}
			if (ACPdone)
			{
				highScore = ES3.Load("HighScoreGP", defaultValue);
				ACPcount.SetActive(value: true);
				StartCoroutine(GiveRank());
				if (ResultsSlider.value > highScore)
				{
					NewRecord = true;
					ES3.Save("HighScoreGP", ResultsSlider.value);
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
			Up.clip = p1;
			Left.clip = p2;
			Right.clip = p3;
			Left2.clip = p2;
			Right2.clip = p3;
			A.clip = p4;
			B.clip = p5;
			B2.clip = p6;
		}
		if (Line == 2f)
		{
			Down.clip = p7;
			Up.clip = p8;
			Left.clip = p9;
			Left2.clip = p10;
			L.clip = p11;
			L2.clip = p11;
		}
		if (Line == 3f)
		{
			Up.clip = p12;
			Up2.clip = p12;
			Up3.clip = p12;
			Right.clip = p13;
			Down.clip = p14;
			Down2.clip = p15;
		}
		if (Line == 4f)
		{
			Up.clip = p16;
			Left.clip = p17;
			Right.clip = p18;
			R.clip = p19;
			X.clip = p20;
			Y.clip = p21;
			SumScoreManager.PinkNoteAmount = 2;
		}
		if (Line == 5f)
		{
			GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
			Scene1.SetActive(value: false);
			Cleanin1.SetActive(value: true);
			Line5P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 2;
			L.clip = p77;
			L2.clip = p78;
			A.clip = p80;
			A2.clip = p80;
			R.clip = p19;
			X.clip = p20;
			Y.clip = p21;
		}
		if (Line == 6f)
		{
			Line6P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 6;
			Up.clip = p79;
			Up2.clip = p79;
			SumScoreManager.Butt3Needed = true;
			SumScoreManager.Butt4Needed = true;
			SumScoreManager.ZRNeeded = true;
			SumScoreManager.ZLNeeded = true;
			GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
		}
		if (Line == 7f)
		{
			Line7P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 2;
			B.clip = p81;
		}
		if (Line == 8f)
		{
			Line8P.SetActive(value: true);
			SumScoreManager.PinkNoteAmount = 2;
			Y.clip = p82;
			X.clip = p83;
			SumScoreManager.Butt3Needed = true;
			SumScoreManager.Butt4Needed = true;
		}
		if (Line == 9f)
		{
			Scene2.SetActive(value: true);
			Y.clip = p22;
			A.clip = p23;
			Y2.clip = p24;
			B.clip = p25;
			B2.clip = p26;
			B3.clip = p27;
			B4.clip = p28;
			X.clip = p29;
			X2.clip = p30;
		}
		if (Line == 10f)
		{
			camera.SetTrigger("line6");
			FlipFry.SetActive(value: false);
			GreasePop.SetActive(value: true);
			A.clip = p31;
			A2.clip = p32;
			A3.clip = p33;
			B.clip = p34;
			X.clip = p35;
			X2.clip = p36;
			X3.clip = p37;
			X4.clip = p38;
			B2.clip = p39;
		}
		if (Line == 11f)
		{
			GreasePop.SetActive(value: false);
			GrooveCoast.SetActive(value: true);
			X.clip = p40;
			Y.clip = p41;
			X2.clip = p42;
			Y2.clip = p43;
		}
		if (Line == 12f)
		{
			GrooveCoast.SetActive(value: false);
			FreshOut.SetActive(value: true);
			B.clip = p44;
			B2.clip = p45;
			A.clip = p46;
			A2.clip = p47;
			A3.clip = p48;
			L.clip = p49;
			R.clip = p50;
		}
		if (Line == 13f)
		{
			FreshOut.SetActive(value: false);
			SeasonStyle.SetActive(value: true);
			A.clip = p51;
			B.clip = p52;
			B2.clip = p53;
			R.clip = p54;
			X.clip = p55;
			Y.clip = p56;
			Y2.clip = p57;
			R2.clip = p58;
		}
		if (Line == 14f)
		{
			SeasonStyle.SetActive(value: false);
			A.clip = p59;
			A2.clip = p60;
			B.clip = p61;
			B2.clip = p62;
			R.clip = p63;
			X.clip = p64;
			X2.clip = p65;
		}
		if (Line == 15f)
		{
			Left.clip = p66;
			Down.clip = p67;
			Down2.clip = p68;
			Right.clip = p69;
			Left2.clip = p70;
			Down3.clip = p71;
			Up.clip = p72;
			Down4.clip = p71;
			Up2.clip = p72;
		}
		if (Line == 16f)
		{
			MentorL1.SetInteger("Line", 1);
			Up.clip = p1;
			Left.clip = p2;
			Right.clip = p3;
			Left2.clip = p2;
			Right2.clip = p3;
			A.clip = p4;
			B.clip = p5;
			B2.clip = p6;
		}
		if (Line == 17f)
		{
			MentorL1.SetInteger("Line", 2);
			Down.clip = p7;
			Up.clip = p8;
			Left.clip = p9;
			Left2.clip = p10;
			L.clip = p11;
			L2.clip = p11;
		}
	}

	private IEnumerator GiveRank()
	{
		Bonus();
		yield return new WaitForSeconds(2f);
		if (NewRecord)
		{
			NewRecordSplash.SetActive(value: true);
		}
		if (ResultsSlider.value >= 3300f)
		{
			Srank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("LvL1rank", 5);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 2770f && ResultsSlider.value < 3300f)
		{
			Arank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("LvL1rank", 4);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 2300f && ResultsSlider.value < 2770f)
		{
			Brank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("LvL1rank", 3);
			}
			MelodiiRes.SetTrigger("nice");
		}
		else if (ResultsSlider.value >= 1750f && ResultsSlider.value < 2300f)
		{
			Crank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("LvL1rank", 2);
			}
			MelodiiRes.SetTrigger("okay");
		}
		else
		{
			Drank.SetActive(value: true);
			if (NewRecord)
			{
				ES3.Save("LvL1rank", 1);
			}
			MelodiiRes.SetTrigger("okay");
		}
		yield return new WaitForSeconds(3f);
		ResultsTheme.SetActive(value: true);
		if (InStory)
		{
			ES3.Save("Level", 5);
			CloseStory.SetActive(value: true);
		}
		else if (DemoFin)
		{
			CloseThx.SetActive(value: true);
			ES3.Save("DemoGP", 1f);
		}
		else
		{
			CloseReg.SetActive(value: true);
		}
	}

	public void HeadOut()
	{
		SceneManager.LoadSceneAsync("LevelSelect");
		PlayerPrefs.SetInt("LastLevelPlayed", 4);
	}
}
