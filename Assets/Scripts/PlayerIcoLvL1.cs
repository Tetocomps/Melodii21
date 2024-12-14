using System.Collections;
using SonicBloom.Koreo;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerIcoLvL1 : MonoBehaviour
{
	public float ButtPresses;

	public static bool WoahFi = false;

	public static bool HiFi = true;

	public static bool MidFi = false;

	public static bool LoFi = false;

	public bool songOver;

	public bool GoHome;

	public bool BlueLine = true;

	public bool PinkLine;

	public static bool BlueLine1 = true;

	public static bool PinkLine1 = false;

	public Animator RhyBox;

	public ParticleSystem Trail;

	public Text DebugButtneed;

	public GameObject GameOver;

	public GameObject plusarrows;

	public GameObject DANGER;

	public GameObject Breather;

	public GameObject Scene1obj;

	public GameObject Scene2;

	public GameObject Customers;

	public GameObject CustomersMad;

	public Animator Cus1;

	public Animator Cus2;

	public Animator Cus3;

	public Animator Cus1m;

	public Animator Cus2m;

	public Animator Cus3m;

	public GameObject GameOpress;

	public AudioSource DangerBeat;

	public int ACP;

	public int ACP2;

	public int funkneeded;

	public int funkneededOG;

	public int ACPneeded;

	public int ACPneededOG;

	public int grooveneeded;

	public int grooveneededOG;

	public bool active;

	public bool active2;

	public bool ButtBusy;

	public bool GrooveReady;

	public Camera camera1;

	public Camera camera2;

	public GameObject Fryer;

	public GameObject Fryer2;

	public bool gamePaused;

	public AudioSource Instrumental;

	public GameObject Menu;

	public Animator Fidelity;

	public GameObject FreeMode;

	public bool FreeStyle;

	public AudioSource freeIntro;

	public AudioSource freeLoop;

	public AudioSource badend;

	public AudioSource twLoop;

	public GameObject freeLoop_obj;

	public GameObject MentorVoice;

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

	public GameObject sparkleP;

	public GameObject sparkleB;

	public bool SafeForPinkSpark = true;

	public AudioSource voice;

	public Animator PlayerFree;

	public Animator PlayerL1;

	public Animator PlayerL2;

	public Animator PlayerL3;

	public Animator PlayerClean1;

	public Animator PlayerClean2;

	public Animator Nami;

	public GameObject Tray;

	public GameObject Gross;

	public bool GoAway;

	public Animator PlayerArt;

	public Animator PlayerCoast;

	public Animator PlayerFresh;

	public Animator PlayerSeason;

	public Animator PlayerCoin;

	public Animator Register;

	public Animator ArtCam;

	public GameObject OurCanvas;

	public GameObject SynthzCoin;

	public GameObject MelCoin;

	public Animator funknob;

	public Animator camera;

	public Animator Scene1;

	public TextMeshProUGUI caption;

	public TextMeshProUGUI ScoreAdd;

	public TextMeshProUGUI ScoreSub;

	public Slider FunkSlider;

	public Slider ACPSlider;

	public GameObject Glow;

	public GameObject top_flipper;

	public GameObject bottom_flipper;

	public float line = 1f;

	public float groovycount;

	public float badcount;

	public GUI scoreText;

	public float rhyths;

	public bool onbackbeat;

	public bool onbeat;

	public bool onstarbeat;

	public bool offbeat = true;

	public bool offbackbeat = true;

	public bool offstarbeat = true;

	public bool offanybeat;

	public bool onanybeat;

	public bool good;

	public bool groovy;

	public bool pressUp;

	public bool pressDown;

	public bool pressRight;

	public bool pressLeft;

	public bool pressZL;

	public bool pressZR;

	public bool ZLdown;

	public bool ZRdown;

	public int funk;

	public AudioClip good1;

	public AudioClip bad1;

	public ParticleSystem burstin;

	public float Speed;

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

	public AudioClip miss;

	private Animator anim;

	public Animator lowflipper;

	public Animator highflipper;

	public Animator mentor;

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
	public string LineStart;

	[EventID]
	public string LineEnd;

	[EventID]
	public string LineNext;

	[EventID]
	public string GroovyStart;

	[EventID]
	public string Beat;

	[EventID]
	public string Backbeat;

	[EventID]
	public string Starbeat;

	[EventID]
	public string BeatG;

	[EventID]
	public string BackbeatG;

	[EventID]
	public string OffbeatG;

	[EventID]
	public string OffbackbeatG;

	[EventID]
	public string Offbeat;

	[EventID]
	public string Offbackbeat;

	[EventID]
	public string Offstarbeat;

	[EventID]
	public string EndSong;

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
	public string Perfect_Pink;

	[EventID]
	public string Perfect_Blue;

	[EventID]
	public string Perfect_BlueOFF;

	public TextMeshProUGUI ResStyle;

	public TextMeshProUGUI ResACP;

	public TextMeshProUGUI ResFunk;

	public int AllFunk;

	public int AllFunkSmall;

	public static int StyleStatic;

	public static int FunkStatic;

	public static int ACPStatic;

	private void Start()
	{
		camera1.enabled = true;
		camera2.enabled = false;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 1;
		voice = GetComponent<AudioSource>();
		anim = base.gameObject.GetComponent<Animator>();
		Koreographer.Instance.RegisterForEvents(LineStart, On_LineStart);
		Koreographer.Instance.RegisterForEvents(LineNext, On_NextLine);
		Koreographer.Instance.RegisterForEvents(LineEnd, On_LineEnd);
		Koreographer.Instance.RegisterForEvents(Starbeat, On_Starbeat);
		Koreographer.Instance.RegisterForEvents(Beat, On_Beat);
		Koreographer.Instance.RegisterForEvents(Backbeat, On_Backbeat);
		Koreographer.Instance.RegisterForEvents(BeatG, On_BeatG);
		Koreographer.Instance.RegisterForEvents(BackbeatG, On_BackbeatG);
		Koreographer.Instance.RegisterForEvents(OffbeatG, On_OffbeatG);
		Koreographer.Instance.RegisterForEvents(OffbackbeatG, On_OffbackbeatG);
		Koreographer.Instance.RegisterForEvents(GroovyStart, On_GroovyStart);
		Koreographer.Instance.RegisterForEvents(Offbeat, On_Offbeat);
		Koreographer.Instance.RegisterForEvents(Offbackbeat, On_Offbackbeat);
		Koreographer.Instance.RegisterForEvents(Offstarbeat, On_Offstarbeat);
		Koreographer.Instance.RegisterForEvents(EndSong, On_EndSong);
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
		Koreographer.Instance.RegisterForEvents(Perfect_Pink, On_Perfect_Pink);
		Koreographer.Instance.RegisterForEvents(Perfect_Blue, On_Perfect_Blue);
		Koreographer.Instance.RegisterForEvents(Perfect_BlueOFF, On_Perfect_BlueOFF);
	}

	private void On_EndSong(KoreographyEvent evt)
	{
		songOver = true;
	}

	private void ACPsliderAdj()
	{
		if (BlueLine)
		{
			ACPSlider.maxValue = SumScoreManager.NoteAmount;
			FunkSlider.maxValue = grooveneeded;
		}
		else if (PinkLine)
		{
			ACPSlider.maxValue = SumScoreManager.PinkNoteAmount;
			FunkSlider.maxValue = grooveneeded;
		}
	}

	private void SwitchCam()
	{
		camera.SetTrigger("PlayerTurn");
	}

	private void On_LineStart(KoreographyEvent evt)
	{
		Trail.Play();
		if (FreeStyle)
		{
			return;
		}
		plusarrows.SetActive(value: true);
		Hinput.gamepad[0].Vibrate(0.06f, 0.06f, 0.06f);
		if (BlueLine)
		{
			anim.SetTrigger("getreadyB");
			funkneeded = SumScoreManager.NoteAmount * 6;
			grooveneeded = funkneeded * 3;
			ACPneeded = SumScoreManager.NoteAmount / 3;
		}
		else if (PinkLine)
		{
			anim.SetTrigger("getreadyP");
			if (line == 5f)
			{
				funkneeded = 8;
			}
			else if (line == 6f)
			{
				funkneeded = 25;
			}
			else if (line == 7f)
			{
				funkneeded = 8;
			}
			else if (line == 8f)
			{
				funkneeded = 15;
			}
			grooveneeded = funkneeded * 4;
			ACPneeded = SumScoreManager.PinkNoteAmount / 3;
		}
		ACPsliderAdj();
		ACP = 0;
		active = true;
		if (line == 5f)
		{
			ACPSlider.maxValue = SumScoreManager.PinkNoteAmount;
			FunkSlider.maxValue = grooveneeded;
			grooveneeded = 30;
			groovy = false;
			RhyBox.SetTrigger("pink");
			PinkLine = true;
			BlueLine = false;
			lowflipper.SetTrigger("flipup");
		}
		if (line == 6f)
		{
			highflipper.SetTrigger("flipup");
			base.transform.localPosition = new Vector3(-11.31f, 4.292475f, 12.91997f);
		}
		if (line == 7f)
		{
			ACPSlider.maxValue = SumScoreManager.PinkNoteAmount;
			FunkSlider.maxValue = grooveneeded;
			RhyBox.SetTrigger("pink");
			lowflipper.SetTrigger("flipup");
		}
		if (line == 8f)
		{
			ACPSlider.maxValue = SumScoreManager.PinkNoteAmount;
			FunkSlider.maxValue = grooveneeded;
			OurCanvas.SetActive(value: true);
		}
		if (line == 9f || line == 10f)
		{
			highflipper.SetTrigger("flipup");
			base.transform.localPosition = new Vector3(-11.31f, 4.292475f, 12.91997f);
		}
		if (line == 9f)
		{
			SwitchCam();
		}
		else
		{
			lowflipper.SetTrigger("flipup");
		}
		if (line == 14f)
		{
			Register.SetTrigger("Open");
			SynthzCoin.SetActive(value: false);
			MelCoin.SetActive(value: true);
			caption.text = "Gotta put effort to chase that coin pile";
		}
		if (line == 15f)
		{
			caption.text = "";
		}
		if (line == 16f)
		{
			PlayerL1.SetInteger("Line", 1);
			lowflipper.SetTrigger("flipup");
		}
		if (line == 17f)
		{
			PlayerL1.SetInteger("Line", 2);
			lowflipper.SetTrigger("flipup");
		}
		Cus1.SetTrigger("mel");
		Cus2.SetTrigger("mel");
		Cus3.SetTrigger("mel");
		Cus1m.SetTrigger("mel");
		Cus2m.SetTrigger("mel");
		Cus3m.SetTrigger("mel");
		RhyBox = RhyBox.GetComponent<Animator>();
	}

	private void On_NextLine(KoreographyEvent evt)
	{
		if (active && !FreeStyle)
		{
			base.transform.localPosition = new Vector3(-9.7f, 2.982475f, 12.91997f);
		}
	}

	private void On_LineEnd(KoreographyEvent evt)
	{
		Trail.Stop();
		if (PinkLine && line <= 5f)
		{
			funkneeded = 8;
		}
		base.transform.localPosition = new Vector3(-11.31f, 2.982475f, 12.91997f);
		line += 1f;
		PlayerL1.SetInteger("Line", PlayerL1.GetInteger("Line") + 1);
		camera.SetInteger("Line", PlayerL1.GetInteger("Line") + 1);
		active = false;
		lowflipper.SetTrigger("flipdown");
		if (!FreeStyle)
		{
			if (good || groovy)
			{
				Nami.SetTrigger("yes");
				Tray.SetActive(value: false);
			}
			else
			{
				Nami.SetTrigger("no");
			}
			if (Gross.activeInHierarchy)
			{
				good = false;
				groovy = false;
			}
		}
		if (line == 11f)
		{
			camera.SetTrigger("breather");
			Scene1.SetTrigger("die");
			Scene2.SetActive(value: false);
			caption.text = "";
		}
		if (line == 12f)
		{
			caption.text = "";
			Breather.SetActive(value: false);
		}
		if (line >= 16f)
		{
			PlayerL1.SetTrigger("stop");
		}
		if (!FreeStyle)
		{
			SumScore.Add(ACP * 5);
			SumScore.Add(funk);
			if (good)
			{
				ScoreAdd.text = (ACP * 5 + funk).ToString();
				AllFunk += ACP * 5 + funk;
				AllFunkSmall += funk;
				Glow.SetActive(value: false);
				anim.SetTrigger("good");
				voice.clip = good1;
				voice.Play();
				KillNotes();
				groovycount = 0f;
				Hinput.gamepad[0].Vibrate(0.1f, 0.15f, 0.01f);
				if (badcount > 0f)
				{
					badcount -= 1f;
				}
			}
			else if (groovy)
			{
				ScoreAdd.text = (ACP * 5 + funk).ToString();
				AllFunk += ACP * 5 + funk;
				AllFunkSmall += funk;
				anim.SetTrigger("good");
				Glow.SetActive(value: true);
				voice.clip = good1;
				voice.Play();
				Hinput.gamepad[0].Vibrate(0.2f, 0.3f, 0.01f);
				KillNotes();
				groovycount += 1f;
			}
			else
			{
				ScoreSub.text = 20.ToString();
				AllFunk -= 20;
				Glow.SetActive(value: false);
				anim.SetTrigger("bad");
				mentor.SetTrigger("diss");
				badcount += 1f;
				voice.clip = bad1;
				voice.Play();
				SumScore.Subtract(20);
				Hinput.gamepad[0].Vibrate(0.3f, 0.1f, 0.5f);
				KillNotes();
				groovycount = 0f;
			}
			if (badcount == 3f)
			{
				TrainWreck();
			}
			if (groovycount == 2f && !GoHome)
			{
				Instrumental.mute = true;
				Instrumental.Pause();
				FreeMode.SetActive(value: true);
				camera2.enabled = true;
				GrooveMode();
				onstarbeat = false;
			}
		}
		if (FreeStyle && badcount > 4f)
		{
			GoHome = true;
			Instrumental.mute = false;
			FreeMode.SetActive(value: false);
			FreeStyle = false;
			MentorVoice.SetActive(value: true);
			active2 = false;
			base.transform.localPosition = new Vector3(-10.066f, 2.982475f, 12.91997f);
			KillNotes();
			groovy = false;
			freeLoop.Stop();
		}
		if (FreeStyle && line == 17f)
		{
			Instrumental.mute = false;
			FreeMode.SetActive(value: false);
			FreeStyle = false;
			MentorVoice.SetActive(value: true);
			active2 = false;
			base.transform.localPosition = new Vector3(-10.066f, 2.982475f, 12.91997f);
			KillNotes();
		}
		Debug.Log("ButtsNeeded: " + SumScoreManager.ButtsNeeded);
		ResFunk.text = AllFunk.ToString();
		ResStyle.text = AllFunkSmall.ToString();
		ResACP.text = ACP2.ToString();
	}

	private void GrooveMode()
	{
		MentorVoice.SetActive(value: false);
		FreeStyle = true;
		funk += 45;
		good = true;
	}

	private void On_GroovyStart(KoreographyEvent evt)
	{
		if (freeLoop_obj.activeInHierarchy && !GrooveReady)
		{
			GrooveReady = true;
			active2 = true;
			Instrumental.Play();
			badcount = 0f;
			good = true;
		}
		if (freeLoop_obj.activeInHierarchy && GrooveReady)
		{
			active2 = true;
			base.transform.localPosition = new Vector3(-10.066f, 2.982475f, 12.91997f);
			SumScore.Add(funk);
			if (good && groovy)
			{
				anim.SetTrigger("good");
				voice.clip = good1;
				voice.Play();
				KillNotes();
				badcount = 0f;
			}
			else
			{
				Glow.SetActive(value: false);
				anim.SetTrigger("bad");
				mentor.SetTrigger("diss");
				badcount += 1f;
				voice.clip = bad1;
				voice.Play();
				SumScore.Subtract(20);
				KillNotes();
			}
		}
	}

	private void TrainWreck()
	{
		camera.SetTrigger("Die1");
		active = false;
		GameOver.SetActive(value: true);
		Scene1obj.SetActive(value: false);
		Instrumental.Pause();
		voice.Pause();
		badend.Play();
		twLoop.PlayDelayed(badend.clip.length);
	}

	private void Update()
	{
		if (FreeStyle && active2)
		{
			if (Input.GetButtonDown("Butt1") && active2 && !ButtBusy)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				PlayerFree.SetTrigger("Butt1");
				if (Butt1Presses == 0f)
				{
					A.Play();
					Butt1Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt1Presses == 1f)
				{
					A2.Play();
					Butt1Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt1Presses == 2f)
				{
					A3.Play();
					Butt1Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt1Presses >= 3f)
				{
					A4.Play();
					Butt1Presses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetButtonDown("Butt2") && active2 && !ButtBusy)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				PlayerFree.SetTrigger("Butt2");
				if (Butt2Presses == 0f)
				{
					B.Play();
					Butt2Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt2Presses == 1f)
				{
					B2.Play();
					Butt2Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt2Presses == 2f)
				{
					B3.Play();
					Butt2Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt2Presses >= 3f)
				{
					B4.Play();
					Butt2Presses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetButtonDown("Butt3") && active2 && !ButtBusy)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				PlayerFree.SetTrigger("Butt3");
				if (Butt3Presses == 0f)
				{
					Y.Play();
					Butt3Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt3Presses == 1f)
				{
					Y2.Play();
					Butt3Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt3Presses == 2f)
				{
					Y3.Play();
					Butt3Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt3Presses >= 3f)
				{
					Y4.Play();
					Butt3Presses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetButtonDown("Butt4") && active2 && !ButtBusy)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				PlayerFree.SetTrigger("Butt4");
				if (Butt4Presses == 0f)
				{
					X.Play();
					Butt4Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt4Presses == 1f)
				{
					X2.Play();
					Butt4Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt4Presses == 2f)
				{
					X3.Play();
					Butt4Presses += 1f;
					ButtBusy = true;
				}
				else if (Butt4Presses >= 3f)
				{
					X4.Play();
					Butt4Presses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active2 && !ButtBusy && !pressUp)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressUp = true;
				PlayerFree.SetTrigger("Up");
				if (UpPresses == 0f)
				{
					Up.Play();
					UpPresses += 1f;
					ButtBusy = true;
				}
				else if (UpPresses == 1f)
				{
					Up2.Play();
					UpPresses += 1f;
					ButtBusy = true;
				}
				else if (UpPresses == 2f)
				{
					Up3.Play();
					UpPresses += 1f;
					ButtBusy = true;
				}
				else if (UpPresses >= 3f)
				{
					Up4.Play();
					UpPresses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active2 && !ButtBusy && !pressDown)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressDown = true;
				PlayerFree.SetTrigger("Down");
				if (DownPresses == 0f)
				{
					Down.Play();
					DownPresses += 1f;
					ButtBusy = true;
				}
				else if (DownPresses == 1f)
				{
					Down2.Play();
					DownPresses += 1f;
					ButtBusy = true;
				}
				else if (DownPresses == 2f)
				{
					Down3.Play();
					DownPresses += 1f;
					ButtBusy = true;
				}
				else if (DownPresses >= 3f)
				{
					Down4.Play();
					DownPresses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active2 && !ButtBusy && !pressLeft)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressLeft = true;
				PlayerFree.SetTrigger("Left");
				if (LeftPresses == 0f)
				{
					Left.Play();
					LeftPresses += 1f;
					ButtBusy = true;
				}
				else if (LeftPresses == 1f)
				{
					Left2.Play();
					LeftPresses += 1f;
					ButtBusy = true;
				}
				else if (LeftPresses == 2f)
				{
					Left3.Play();
					LeftPresses += 1f;
					ButtBusy = true;
				}
				else if (LeftPresses >= 3f)
				{
					Left4.Play();
					LeftPresses += 1f;
					ButtBusy = true;
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active2 && !ButtBusy && !pressRight)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressRight = true;
				PlayerFree.SetTrigger("Rights");
				if (RightPresses == 0f)
				{
					Right.Play();
					RightPresses += 1f;
					ButtBusy = true;
				}
				else if (RightPresses == 1f)
				{
					Right2.Play();
					RightPresses += 1f;
					ButtBusy = true;
				}
				else if (RightPresses == 2f)
				{
					Right3.Play();
					RightPresses += 1f;
					ButtBusy = true;
				}
				else if (RightPresses >= 3f)
				{
					Right4.Play();
					RightPresses += 1f;
					ButtBusy = true;
				}
			}
			if (ZLdown && active2 && !pressZL && !pressZL)
			{
				if (onbeat)
				{
					funk += 6;
					burstin.Play();
				}
				if (onbackbeat)
				{
					funk += 5;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressZL = true;
				PlayerFree.SetTrigger("ZL");
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
			if (ZRdown && active2 && !pressZR && !pressZR)
			{
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offbeat && offbackbeat)
				{
					funk -= 10;
				}
				pressZR = true;
				PlayerFree.SetTrigger("ZR");
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
			if (Input.GetAxisRaw("Vertical") == 0f)
			{
				pressUp = false;
				pressDown = false;
			}
			if (Input.GetAxisRaw("Horizontal") == 0f)
			{
				pressLeft = false;
				pressRight = false;
			}
			if (Input.GetAxisRaw("ZL") == 0f)
			{
				pressZL = false;
				ZLdown = false;
			}
			if (Input.GetAxisRaw("ZR") == 0f)
			{
				pressZR = false;
				ZRdown = false;
			}
		}
		if (Fryer2.activeInHierarchy)
		{
			Fryer.SetActive(value: false);
		}
		else
		{
			Fryer.SetActive(value: true);
		}
		if (Breather.activeInHierarchy)
		{
			Scene1.SetTrigger("die");
		}
		if (line == 5f)
		{
			funkneeded = 11;
			grooveneeded = funkneeded * 5;
		}
		BlueLine1 = BlueLine;
		PinkLine1 = PinkLine;
		if (line >= 9f)
		{
			BlueLine = true;
			PinkLine = false;
			RhyBox.SetTrigger("blue");
		}
		if (active && !FreeStyle)
		{
			if (line == 4f)
			{
				caption.text = "Order up!";
			}
			if (line == 9f)
			{
				caption.text = "Flippin' and fryin' to keep yourself from dying...";
			}
			if (line == 10f)
			{
				caption.text = "The grease keeps poppin', these grooves are non-stoppin'";
			}
			if (line == 11f)
			{
				caption.text = "Groove coastin', smooth roastin'";
			}
			if (line == 12f)
			{
				caption.text = "Cookin' burgers like you fresh out the ocean";
			}
			if (line == 13f)
			{
				caption.text = "Season them with style to make them worth while";
			}
			if (line == 15f)
			{
				caption.text = "";
			}
		}
		if (active)
		{
			if (Input.GetButtonDown("Butt1") && SumScoreManager.Butt1Needed)
			{
				SumScoreManager.Butt1Needed = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetButtonDown("Butt2") && SumScoreManager.Butt2Needed)
			{
				SumScoreManager.Butt2Needed = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetButtonDown("Butt3") && SumScoreManager.Butt3Needed)
			{
				SumScoreManager.Butt3Needed = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetButtonDown("Butt4") && SumScoreManager.Butt4Needed)
			{
				SumScoreManager.Butt4Needed = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetAxisRaw("Vertical") > 0f && !pressUp && SumScoreManager.UpNeeded)
			{
				SumScoreManager.UpNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetAxisRaw("Vertical") < 0f && !pressDown && SumScoreManager.DownNeeded)
			{
				SumScoreManager.DownNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && !pressLeft && SumScoreManager.LeftNeeded)
			{
				SumScoreManager.LeftNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && !pressRight && SumScoreManager.RightNeeded)
			{
				SumScoreManager.RightNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (ZLdown && !pressZL && SumScoreManager.ZLNeeded)
			{
				SumScoreManager.ZLNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
			if (ZRdown && !pressZR && SumScoreManager.ZRNeeded)
			{
				SumScoreManager.ZRNeeded = false;
				SumScoreManager.ButtsNeeded--;
			}
		}
		if (active)
		{
			FunkSlider.value = funk;
			ACPSlider.value = ACP;
			if (!good && !groovy)
			{
				funknob.SetTrigger("bad");
			}
			if (good)
			{
				funknob.SetTrigger("good");
			}
			if (groovy)
			{
				funknob.SetTrigger("groovy");
			}
			if (!Input.anyKeyDown)
			{
				ButtBusy = false;
			}
		}
		if (active2)
		{
			FunkSlider.value = funk;
			if (!good && !groovy)
			{
				funknob.SetTrigger("bad");
			}
			if (good)
			{
				funknob.SetTrigger("groovy");
			}
			if (groovy)
			{
				funknob.SetTrigger("groovy");
			}
			if (!Input.anyKeyDown)
			{
				ButtBusy = false;
			}
		}
		if (active && !FreeStyle)
		{
			if (BlueLine)
			{
				if ((funk >= funkneeded && ACP >= ACPneeded && SumScoreManager.ButtsNeeded == 0) || (funk >= funkneeded && ButtPresses < (float)(SumScoreManager.NoteAmount * 8) && SumScoreManager.ButtsNeeded <= 1))
				{
					good = true;
				}
				else if (funk < funkneeded || ACP < ACPneeded || SumScoreManager.ButtsNeeded > 2)
				{
					good = false;
					groovy = false;
				}
				if (funk >= grooveneeded && ACP >= ACPneeded)
				{
					groovy = true;
					good = false;
				}
				else if (funk < grooveneeded || ACP < ACPneeded)
				{
					groovy = false;
				}
			}
			else if (PinkLine)
			{
				if ((funk >= funkneeded && ACP >= ACPneeded) || (funk >= funkneeded && ButtPresses < (float)(SumScoreManager.PinkNoteAmount * 10)))
				{
					good = true;
				}
				else if (funk < funkneeded || ACP < ACPneeded)
				{
					good = false;
					groovy = false;
				}
				if (funk >= grooveneeded && ACP >= ACPneeded)
				{
					groovy = true;
					good = false;
				}
				else if (funk < grooveneeded || ACP < ACPneeded)
				{
					groovy = false;
				}
			}
		}
		ButtPresses = Butt1Presses + Butt2Presses + Butt3Presses + Butt4Presses + UpPresses + DownPresses + RightPresses + LeftPresses + ZRPresses + ZLPresses;
		if (active2)
		{
			if (funk >= 30)
			{
				good = true;
			}
			else if (funk < 30)
			{
				good = false;
			}
		}
		if (!FreeStyle)
		{
			if (badcount == 1f)
			{
				Fidelity.SetTrigger("Mid");
				DANGER.SetActive(value: false);
				Customers.SetActive(value: true);
				CustomersMad.SetActive(value: false);
			}
			else if (badcount == 2f)
			{
				Fidelity.SetTrigger("Lo");
				DANGER.SetActive(value: true);
				Customers.SetActive(value: false);
				CustomersMad.SetActive(value: true);
			}
			else if (badcount == 0f)
			{
				Fidelity.SetTrigger("Hi");
				DANGER.SetActive(value: false);
			}
		}
		if (Input.GetAxisRaw("ZL") > 0f || (Input.GetButtonDown("ZL") && !pressZL))
		{
			ZLdown = true;
		}
		if (Input.GetAxisRaw("ZR") < 0f || (Input.GetButtonDown("ZR") && !pressZR))
		{
			ZRdown = true;
		}
		if (Input.GetButtonDown("Submit") && !gamePaused && !songOver)
		{
			gamePaused = true;
			Time.timeScale = 0f;
			Menu.SetActive(value: true);
			Instrumental.Pause();
			if (FreeStyle)
			{
				freeLoop.Pause();
			}
			voice.Pause();
			voice.mute = true;
		}
		else if (Input.GetButtonDown("Submit") && gamePaused && !songOver)
		{
			gamePaused = false;
			Menu.SetActive(value: false);
			Time.timeScale = 1f;
			Instrumental.Play();
			if (FreeStyle)
			{
				freeLoop.Play();
			}
			voice.Play();
			voice.mute = false;
		}
		if (!gamePaused && !FreeStyle)
		{
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p4;
				voice.PlayOneShot(p4);
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt1");
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 1f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p5;
				voice.PlayOneShot(p5);
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt2");
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 1f && Butt2Presses >= 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p6;
				voice.PlayOneShot(p6);
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt1");
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 1f && !pressUp)
			{
				pressUp = true;
				voice.clip = p1;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 1f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 1f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p2;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 1f && !pressRight)
			{
				pressRight = true;
				voice.clip = p3;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Right");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 1f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 1f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") == 0f)
			{
				pressUp = false;
				pressDown = false;
			}
			if (Input.GetAxisRaw("Horizontal") == 0f)
			{
				pressLeft = false;
				pressRight = false;
			}
			if (Input.GetAxisRaw("ZL") == 0f)
			{
				pressZL = false;
				ZLdown = false;
			}
			if (Input.GetAxisRaw("ZR") == 0f)
			{
				pressZR = false;
				ZRdown = false;
			}
			if (active)
			{
				base.transform.Translate(Speed * Time.deltaTime, 0f, 0f);
				GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
			}
			if (active2)
			{
				base.transform.Translate(Speed * Time.deltaTime, 0f, 0f);
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZLdown && active && line == 2f && !pressZL)
			{
				anim.SetTrigger("speak");
				pressZL = true;
				voice.clip = p11;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("ZL");
				if (ZLPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (ZRdown && active && line == 2f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 2f && !pressUp)
			{
				pressUp = true;
				voice.clip = p8;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 2f && !pressDown)
			{
				pressDown = true;
				voice.clip = p8;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Down");
				if (DownPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 2f && LeftPresses <= 0f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p9;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (LeftPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 2f && LeftPresses > 0f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p10;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (LeftPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 2f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (pressZL && active && line == 3f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 3f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				DownPresses += 1f;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 3f && !pressUp)
			{
				pressUp = true;
				voice.clip = p12;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 3f && DownPresses <= 0f && !pressUp)
			{
				pressDown = true;
				voice.clip = p14;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Down");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 3f && DownPresses > 0f)
			{
				DownPresses += 1f;
				if (!pressDown)
				{
					pressDown = true;
					voice.clip = p15;
					voice.Play();
					DownPresses += 1f;
					ButtBusy = true;
					Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
					PlayerL1.SetTrigger("Down");
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 3f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 3f && !pressRight)
			{
				pressRight = true;
				voice.clip = p13;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Right");
				if (RightPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 4f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 4f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 4f)
			{
				anim.SetTrigger("speak");
				voice.clip = p21;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt3");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 4f)
			{
				anim.SetTrigger("speak");
				voice.clip = p20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt4");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 4f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 4f && !pressZR)
			{
				pressZR = true;
				voice.clip = p19;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("ZR");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 4f && !pressUp)
			{
				pressUp = true;
				voice.clip = p16;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 4f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 4f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p17;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (LeftPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 4f && !pressRight)
			{
				pressRight = true;
				voice.clip = p18;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Right");
				if (RightPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 5f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerClean1.SetTrigger("Miss");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 5f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerClean1.SetTrigger("Miss");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 5f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerClean1.SetTrigger("Butt3");
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 5f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerClean1.SetTrigger("Miss");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 5f && Butt4Presses >= 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerClean1.SetTrigger("Miss");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
			}
			if (ZLdown && active && line == 5f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 5f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 5f && !pressUp)
			{
				pressUp = true;
				voice.clip = p79;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Up");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 5f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 5f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 5f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerClean1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 6f)
			{
				anim.SetTrigger("speak");
				voice.clip = p80;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Butt1");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 6f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Miss");
				Nami.SetTrigger("no");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 6f)
			{
				anim.SetTrigger("speak");
				voice.clip = p21;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Butt3");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 6f)
			{
				anim.SetTrigger("speak");
				voice.clip = p20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Butt4");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 6f && ZLPresses == 0f)
			{
				if (!pressZL)
				{
					pressZL = true;
					voice.clip = p77;
					voice.Play();
					ZLPresses += 1f;
					Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
					PlayerClean2.SetTrigger("ZL");
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (ZLdown && active && line == 6f && ZLPresses >= 1f && !pressZL)
			{
				pressZL = true;
				voice.clip = p78;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("ZL");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZRdown && active && line == 6f && !pressZR)
			{
				pressZR = true;
				voice.clip = p19;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("ZR");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 6f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Miss");
				Nami.SetTrigger("no");
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 6f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Miss");
				Nami.SetTrigger("no");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 6f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Miss");
				Nami.SetTrigger("no");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 6f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerClean2.SetTrigger("Miss");
				Nami.SetTrigger("no");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 7f && Butt1Presses % 2f == 0f)
			{
				caption.text = "An art.";
				anim.SetTrigger("speak");
				voice.clip = p81;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerArt.SetTrigger("Butt1");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 7f)
			{
				anim.SetTrigger("speak");
				voice.clip = p82;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerArt.SetTrigger("A2");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 7f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerArt.SetTrigger("Miss1");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 7f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerArt.SetTrigger("Butt3");
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 7f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerArt.SetTrigger("Miss1");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 7f && Butt4Presses >= 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				PlayerArt.SetTrigger("Miss1");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (ZLdown && active && line == 7f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss1");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (ZRdown && active && line == 7f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss1");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 7f && !pressUp)
			{
				pressUp = true;
				voice.clip = p79;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Up");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 7f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss1");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 7f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss1");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 7f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss1");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 8f)
			{
				caption.text = "Our canvas.";
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerArt.SetTrigger("Miss");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 8f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerArt.SetTrigger("Miss");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 8f)
			{
				anim.SetTrigger("speak");
				voice.clip = p84;
				voice.Play();
				PlayerArt.SetTrigger("Butt3");
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 8f)
			{
				anim.SetTrigger("speak");
				voice.clip = p83;
				voice.Play();
				PlayerArt.SetTrigger("Butt4");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (ZLdown && active && line == 8f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (ZRdown && active && line == 8f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 8f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 8f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 8f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 8f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerArt.SetTrigger("Miss");
				if (ButtPresses == 0f)
				{
					ArtCam.SetTrigger("Mel");
				}
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 9f)
			{
				anim.SetTrigger("speak");
				voice.clip = p23;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerL2.SetTrigger("Butt1");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 9f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p25;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerL2.SetTrigger("Butt2");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 9f && Butt2Presses == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p26;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerL2.SetTrigger("B2");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 9f && Butt2Presses == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = p27;
				voice.Play();
				PlayerL2.SetTrigger("Butt2");
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 9f && Butt2Presses >= 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = p28;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerL2.SetTrigger("B2");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 9f && Butt3Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p22;
				voice.Play();
				PlayerL2.SetTrigger("Butt3");
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 9f)
			{
				anim.SetTrigger("speak");
				voice.clip = p24;
				voice.Play();
				PlayerL2.SetTrigger("Y2");
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 9f && Butt4Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p29;
				voice.Play();
				PlayerL2.SetTrigger("Butt4");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 9f && Butt4Presses >= 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p30;
				voice.Play();
				PlayerL2.SetTrigger("X2");
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 9f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 9f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 9f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 9f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 9f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 9f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL2.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 10f && Butt1Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p31;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 10f && Butt1Presses == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p32;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 10f && Butt1Presses >= 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = p33;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 10f && Butt2Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p34;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak2");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 10f)
			{
				anim.SetTrigger("speak2");
				voice.clip = p39;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 10f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 10f && Butt4Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p35;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 10f && Butt4Presses == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p36;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 10f && Butt4Presses == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = p37;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 10f && Butt4Presses >= 3f)
			{
				anim.SetTrigger("speak");
				voice.clip = p38;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("speak");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 10f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (ZRdown && active && line == 10f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 10f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 10f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 10f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 10f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL3.SetTrigger("miss");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 11f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 11f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 11f && Butt3Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p41;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (Butt3Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
				PlayerCoast.SetTrigger("Butt3");
			}
			else if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 11f)
			{
				anim.SetTrigger("speak");
				voice.clip = p43;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (Butt3Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
				PlayerCoast.SetTrigger("Butt3");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 11f && Butt4Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p40;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (Butt4Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
				PlayerCoast.SetTrigger("Butt4");
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 11f)
			{
				anim.SetTrigger("speak");
				voice.clip = p42;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (Butt4Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
				PlayerCoast.SetTrigger("Butt4");
			}
			if (ZLdown && active && line == 11f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 11f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 11f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 11f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 11f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 11f && !pressLeft)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerCoast.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 12f && Butt2Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p44;
				voice.Play();
				PlayerFresh.SetTrigger("B");
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 12f)
			{
				anim.SetTrigger("speak");
				voice.clip = p45;
				voice.Play();
				PlayerFresh.SetTrigger("B2");
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 12f && Butt1Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p46;
				voice.Play();
				PlayerFresh.SetTrigger("B");
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 12f && Butt1Presses == 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p47;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("B2");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 12f && Butt1Presses == 2f)
			{
				anim.SetTrigger("speak");
				voice.clip = p48;
				voice.Play();
				PlayerFresh.SetTrigger("A3");
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 12f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 12f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
			}
			if (ZLdown && active && line == 12f && !pressZL)
			{
				pressZL = true;
				voice.clip = p49;
				voice.Play();
				ZLPresses += 1f;
				PlayerFresh.SetTrigger("L");
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				if (ZLPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (ZRdown && active && line == 12f && !pressZR)
			{
				pressZR = true;
				voice.clip = p50;
				voice.Play();
				ZRPresses += 1f;
				PlayerFresh.SetTrigger("R");
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				if (ZRPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 12f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 12f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 12f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 12f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				PlayerFresh.SetTrigger("Miss");
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 13f)
			{
				anim.SetTrigger("speak");
				voice.clip = p51;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("A");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 13f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p52;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("B");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 13f)
			{
				anim.SetTrigger("speak");
				voice.clip = p53;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("B");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 13f && Butt3Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p56;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Y");
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (Butt3Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 13f)
			{
				anim.SetTrigger("speak");
				voice.clip = p57;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Y2");
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				if (Butt3Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 13f)
			{
				anim.SetTrigger("speak");
				voice.clip = p55;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("X");
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (Butt4Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (ZLdown && active && line == 13f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				PlayerSeason.SetTrigger("Miss");
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			}
			if (ZRdown && active && line == 13f && ZRPresses == 0f)
			{
				if (!pressZR)
				{
					pressZR = true;
					voice.clip = p54;
					voice.Play();
					ZRPresses += 1f;
					PlayerSeason.SetTrigger("R");
					Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
					if (ZRPresses <= 5f)
					{
						if (onstarbeat)
						{
							funk += 8;
							burstin.Play();
						}
						if (onbeat)
						{
							funk += 5;
						}
						if (onbackbeat)
						{
							funk += 3;
						}
						if (offanybeat)
						{
							funk -= 20;
						}
					}
				}
			}
			else if (ZRdown && active && line == 13f && !pressZR)
			{
				pressZR = true;
				voice.clip = p58;
				voice.Play();
				ZRPresses += 1f;
				PlayerSeason.SetTrigger("R");
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				if (ZRPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 13f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Miss");
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 13f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Miss");
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 13f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Miss");
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 13f && !pressLeft)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				PlayerSeason.SetTrigger("Miss");
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 14f && Butt1Presses % 2f == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p59;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("A");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 14f)
			{
				anim.SetTrigger("speak");
				voice.clip = p60;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("A2");
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 14f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p61;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("B");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 14f)
			{
				anim.SetTrigger("speak");
				voice.clip = p62;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("B2");
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 14f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 14f && Butt4Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p64;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("X");
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (Butt4Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 14f)
			{
				anim.SetTrigger("speak");
				voice.clip = p65;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("X");
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				if (Butt4Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (ZLdown && active && line == 14f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			}
			if (ZRdown && active && line == 14f && !pressZR)
			{
				pressZR = true;
				voice.clip = p63;
				voice.Play();
				ZRPresses += 1f;
				PlayerCoin.SetTrigger("R");
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				if (ZRPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 14f && !pressUp)
			{
				pressUp = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 14f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 14f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 14f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				PlayerCoin.SetTrigger("Miss");
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 15f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 15f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 15f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 15f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 15f && !pressUp)
			{
				pressUp = true;
				voice.clip = p72;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 15f && DownPresses == 0f)
			{
				if (!pressDown)
				{
					pressDown = true;
					voice.clip = p67;
					voice.Play();
					DownPresses += 1f;
					ButtBusy = true;
					Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
					PlayerL1.SetTrigger("Down");
					if (DownPresses <= 5f)
					{
						if (onstarbeat)
						{
							funk += 8;
							burstin.Play();
						}
						if (onbeat)
						{
							funk += 5;
						}
						if (onbackbeat)
						{
							funk += 3;
						}
						if (offanybeat)
						{
							funk -= 20;
						}
					}
				}
			}
			else if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 15f && DownPresses == 1f)
			{
				if (!pressDown)
				{
					pressDown = true;
					voice.clip = p68;
					voice.Play();
					DownPresses += 1f;
					ButtBusy = true;
					Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
					PlayerL1.SetTrigger("Down");
					if (DownPresses <= 5f)
					{
						if (onstarbeat)
						{
							funk += 8;
							burstin.Play();
						}
						if (onbeat)
						{
							funk += 5;
						}
						if (onbackbeat)
						{
							funk += 3;
						}
						if (offanybeat)
						{
							funk -= 20;
						}
					}
				}
			}
			else if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 15f && DownPresses > 1f && !pressDown)
			{
				pressDown = true;
				voice.clip = p71;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Down");
				if (DownPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 15f && LeftPresses == 0f)
			{
				if (!pressLeft)
				{
					pressLeft = true;
					voice.clip = p66;
					voice.Play();
					LeftPresses += 1f;
					ButtBusy = true;
					Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
					PlayerL1.SetTrigger("Left");
					if (UpPresses <= 5f)
					{
						if (onstarbeat)
						{
							funk += 8;
							burstin.Play();
						}
						if (onbeat)
						{
							funk += 5;
						}
						if (onbackbeat)
						{
							funk += 3;
						}
						if (offanybeat)
						{
							funk -= 20;
						}
					}
				}
			}
			else if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 15f && LeftPresses == 0f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p70;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 15f && !pressRight)
			{
				pressRight = true;
				voice.clip = p69;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Right");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 15f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 15f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 16f)
			{
				anim.SetTrigger("speak");
				voice.clip = p73;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt1");
				if (Butt1Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 16f && Butt2Presses == 0f)
			{
				anim.SetTrigger("speak");
				voice.clip = p74;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt2");
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			else if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 16f && Butt2Presses >= 1f)
			{
				anim.SetTrigger("speak");
				voice.clip = p75;
				voice.Play();
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Butt1");
				if (Butt2Presses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 16f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 16f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 16f && !pressUp)
			{
				pressUp = true;
				voice.clip = p1;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 16f && !pressDown)
			{
				pressDown = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 16f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p2;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 16f && !pressRight)
			{
				pressRight = true;
				voice.clip = p3;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Right");
				if (onstarbeat)
				{
					funk += 8;
					burstin.Play();
				}
				if (onbeat)
				{
					funk += 5;
				}
				if (onbackbeat)
				{
					funk += 3;
				}
				if (offanybeat)
				{
					funk -= 20;
				}
			}
			if (ZLdown && active && line == 16f && !pressZL)
			{
				pressZL = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZRdown && active && line == 16f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") == 0f)
			{
				pressUp = false;
				pressDown = false;
			}
			if (Input.GetAxisRaw("Horizontal") == 0f)
			{
				pressLeft = false;
				pressRight = false;
			}
			if (Input.GetAxisRaw("ZL") == 0f)
			{
				pressZL = false;
				ZLdown = false;
			}
			if (Input.GetAxisRaw("ZR") == 0f)
			{
				pressZR = false;
				ZRdown = false;
			}
			if (Input.anyKey && active && offbackbeat && offbeat && offstarbeat)
			{
				offanybeat = true;
			}
			if (Input.GetButtonDown("Butt1") && active && !ButtBusy && line == 17f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt1Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt2") && active && !ButtBusy && line == 17f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt2Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_B, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt3") && active && !ButtBusy && line == 17f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt3Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_Y, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetButtonDown("Butt4") && active && !ButtBusy && line == 17f)
			{
				anim.SetTrigger("speak");
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				Butt4Presses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_X, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (ZLdown && active && line == 17f && !pressZL)
			{
				anim.SetTrigger("speak");
				pressZL = true;
				voice.clip = p76;
				voice.Play();
				ZLPresses += 1f;
				Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("ZL");
				if (ZLPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (ZRdown && active && line == 17f && !pressZR)
			{
				pressZR = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				ZRPresses += 1f;
				Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
			if (Input.GetAxisRaw("Vertical") > 0f && active && !ButtBusy && line == 17f && !pressUp)
			{
				pressUp = true;
				voice.clip = p8;
				voice.Play();
				UpPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_up, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Up");
				if (UpPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Vertical") < 0f && active && !ButtBusy && line == 17f && !pressDown)
			{
				pressDown = true;
				voice.clip = p8;
				voice.Play();
				DownPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_down, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Down");
				if (DownPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 17f && LeftPresses <= 0f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p9;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (LeftPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && active && !ButtBusy && line == 17f && LeftPresses > 0f && !pressLeft)
			{
				pressLeft = true;
				voice.clip = p10;
				voice.Play();
				LeftPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_left, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Left");
				if (LeftPresses <= 5f)
				{
					if (onstarbeat)
					{
						funk += 8;
						burstin.Play();
					}
					if (onbeat)
					{
						funk += 5;
					}
					if (onbackbeat)
					{
						funk += 3;
					}
					if (offanybeat)
					{
						funk -= 20;
					}
				}
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && active && !ButtBusy && line == 17f && !pressRight)
			{
				pressRight = true;
				voice.clip = miss;
				funk -= 20;
				voice.Play();
				RightPresses += 1f;
				ButtBusy = true;
				Object.Instantiate(note_right, base.transform.position, base.transform.rotation);
				PlayerL1.SetTrigger("Miss");
			}
		}
		if (!FreeStyle)
		{
			if (!onbeat && !onbackbeat && !onstarbeat)
			{
				offanybeat = true;
				onanybeat = false;
			}
			else
			{
				offanybeat = false;
				onanybeat = true;
			}
		}
		else if (!onbeat && !onbackbeat)
		{
			offanybeat = true;
			onanybeat = false;
		}
		else
		{
			offanybeat = false;
			onanybeat = true;
		}
		FunkStatic = AllFunk;
		StyleStatic = AllFunkSmall;
		ACPStatic = ACP2;
		if (!FreeStyle)
		{
			if (badcount == 0f)
			{
				HiFi = true;
				MidFi = false;
				LoFi = false;
			}
			else if (badcount == 1f)
			{
				HiFi = false;
				MidFi = true;
				LoFi = false;
			}
			else if (badcount > 1f)
			{
				HiFi = false;
				MidFi = false;
				LoFi = true;
			}
		}
	}

	public void AddPoints(int points)
	{
		SumScore.Add(points);
	}

	private void KillNotes()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Note");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].transform.localPosition = new Vector3(-27.78f, -12.65f, 12.91997f);
		}
		Butt2Presses -= Butt2Presses;
		Butt1Presses -= Butt1Presses;
		Butt3Presses -= Butt3Presses;
		Butt4Presses -= Butt4Presses;
		LeftPresses -= LeftPresses;
		RightPresses -= RightPresses;
		DownPresses -= DownPresses;
		UpPresses -= UpPresses;
		ZLPresses -= ZLPresses;
		ZRPresses -= ZRPresses;
		funk -= funk;
		ACP2 += ACP;
	}

	private void LoseGroove()
	{
		Instrumental.mute = false;
		FreeMode.SetActive(value: false);
		FreeStyle = false;
		MentorVoice.SetActive(value: true);
		active2 = false;
	}

	public void Retry()
	{
		gamePaused = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		voice.mute = false;
	}

	public void Quit()
	{
		gamePaused = false;
		Time.timeScale = 1f;
		StartCoroutine(QuitGame());
	}

	private IEnumerator QuitGame()
	{
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadSceneAsync("Title");
	}

	public void QuitThx()
	{
		gamePaused = false;
		Time.timeScale = 1f;
		StartCoroutine(QuitGameThx());
	}

	private IEnumerator QuitGameThx()
	{
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadSceneAsync("ThankYou");
	}

	public void Resume()
	{
		StartCoroutine(Returntogame());
	}

	private IEnumerator Returntogame()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		gamePaused = false;
		Menu.SetActive(value: false);
		Time.timeScale = 1f;
		Instrumental.Play();
		voice.mute = false;
	}

	public void StoryContinue()
	{
		gamePaused = false;
		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync("JamWell");
	}

	private void On_Starbeat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onstarbeat = true;
			offstarbeat = false;
			offanybeat = false;
			if (badcount == 2f)
			{
				DangerBeat.Play();
				Hinput.gamepad[0].Vibrate(0.1f, 0.05f, 0.2f);
			}
		}
	}

	private void On_Beat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onbeat = true;
			offbeat = false;
			offanybeat = false;
		}
	}

	private void On_Backbeat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onbackbeat = true;
			offbackbeat = false;
			offanybeat = false;
		}
	}

	private void On_BeatG(KoreographyEvent evt)
	{
		if (FreeStyle)
		{
			onbeat = true;
			offbeat = false;
			offanybeat = false;
		}
	}

	private void On_BackbeatG(KoreographyEvent evt)
	{
		if (FreeStyle)
		{
			onbackbeat = true;
			offbackbeat = false;
			offanybeat = false;
		}
	}

	private void On_OffbeatG(KoreographyEvent evt)
	{
		if (FreeStyle)
		{
			onbeat = false;
			offbeat = true;
		}
	}

	private void On_OffbackbeatG(KoreographyEvent evt)
	{
		if (FreeStyle)
		{
			onbackbeat = false;
			offbackbeat = true;
		}
	}

	private void On_Offbeat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onbeat = false;
			offbeat = false;
		}
	}

	private void On_Offbackbeat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onbackbeat = false;
			offbackbeat = true;
		}
	}

	private void On_Offstarbeat(KoreographyEvent evt)
	{
		if (!FreeStyle)
		{
			onstarbeat = false;
			offstarbeat = true;
		}
	}

	private void On_Perfect_Pink(KoreographyEvent evt)
	{
		if (active && voice.clip != miss && SafeForPinkSpark)
		{
			if ((Input.GetButtonDown("Butt1") && Butt1Presses > 5f) || (Input.GetButtonDown("Butt2") && Butt2Presses > 5f) || (Input.GetButtonDown("Butt3") && Butt3Presses > 5f) || (Input.GetButtonDown("Butt4") && Butt4Presses > 5f))
			{
				funk++;
				Object.Instantiate(sparkleP, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") > 0f && !pressUp && UpPresses > 5f)
			{
				funk++;
				Object.Instantiate(sparkleP, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") < 0f && !pressDown && DownPresses > 5f)
			{
				funk++;
				Object.Instantiate(sparkleP, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && !pressLeft && LeftPresses > 5f)
			{
				funk++;
				Object.Instantiate(sparkleP, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && !pressRight && RightPresses > 5f)
			{
				funk++;
				Object.Instantiate(sparkleP, base.transform.position, base.transform.rotation);
			}
		}
	}

	private void On_Perfect_Blue(KoreographyEvent evt)
	{
		SafeForPinkSpark = false;
		if (active && voice.clip != miss)
		{
			if ((Input.GetButtonDown("Butt1") && Butt1Presses > 5f) || (Input.GetButtonDown("Butt2") && Butt2Presses > 5f) || (Input.GetButtonDown("Butt3") && Butt3Presses > 5f) || (Input.GetButtonDown("Butt4") && Butt4Presses > 5f))
			{
				ACP++;
				Object.Instantiate(sparkleB, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") > 0f && !pressUp)
			{
				ACP++;
				Object.Instantiate(sparkleB, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Vertical") < 0f && !pressDown)
			{
				ACP++;
				Object.Instantiate(sparkleB, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") < 0f && !pressLeft)
			{
				ACP++;
				Object.Instantiate(sparkleB, base.transform.position, base.transform.rotation);
			}
			if (Input.GetAxisRaw("Horizontal") > 0f && !pressRight)
			{
				ACP++;
				Object.Instantiate(sparkleB, base.transform.position, base.transform.rotation);
			}
		}
	}

	private void On_Perfect_BlueOFF(KoreographyEvent evt)
	{
	}

	private void On_Up(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Vertical") > 0f && !pressUp)
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Down(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Vertical") < 0f && !pressDown)
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Left(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Horizontal") < 0f && !pressLeft)
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Right(KoreographyEvent evt)
	{
		if (active && Input.GetAxisRaw("Horizontal") > 0f && !pressRight)
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Abutt(KoreographyEvent evt)
	{
		if (active && Input.GetButtonDown("Butt1"))
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Bbutt(KoreographyEvent evt)
	{
		if (active && Input.GetButtonDown("Butt2"))
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Xbutt(KoreographyEvent evt)
	{
		if (active && Input.GetButtonDown("Butt4"))
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Ybutt(KoreographyEvent evt)
	{
		if (active && Input.GetButtonDown("Butt3"))
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Lbutt(KoreographyEvent evt)
	{
		if (active && ZLdown && !pressZL)
		{
			funk += 3;
			ACP++;
		}
	}

	private void On_Rbutt(KoreographyEvent evt)
	{
		if (active && ZRdown && !pressZR)
		{
			funk += 3;
			ACP++;
		}
	}
}
