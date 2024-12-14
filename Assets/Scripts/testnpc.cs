using UnityEngine;
using UnityEngine.SceneManagement;

public class testnpc : MonoBehaviour
{
	public GameObject textBox;

	public GameObject Choice;

	public bool nearby;

	public GameObject player;

	public Animator Player;

	public Animator doorfade;

	public bool NeedKBToPass;

	public bool hasKeyboard;

	public bool Door;

	public bool SceneDoor;

	public Vector3 TakeTo;

	public GameObject CurrentCam;

	public GameObject NewCam;

	public GameObject doorBlack;

	public bool CamReady;

	public bool Instant;

	public bool active;

	public bool InstaCutscene;

	public GameObject Cutscene;

	public bool Important;

	public GameObject Notif;

	public bool Person;

	public Animator NPC;

	public AudioSource bgmusic;

	public bool IsCutscene;

	public bool readytogo;

	public string NextScene;

	public bool musicbox;

	public Animator MusicBox;

	public bool done;

	public GameObject Lock;

	public GameObject Close;

	public GameObject ItemGet;

	public GameObject StickerBook;

	private void Start()
	{
	}

	private void Update()
	{
		if (active)
		{
			if (doorBlack.activeInHierarchy)
			{
				CamReady = true;
				active = false;
			}
			if (CamReady)
			{
				SwitchCam();
			}
			if (!Door && Input.GetButtonDown("Butt1") && nearby)
			{
				textBox.SetActive(value: true);
				if (Important)
				{
					Notif.SetActive(value: false);
				}
				if (Person)
				{
					NPC.SetTrigger("talk");
				}
			}
			if (Door)
			{
				if (Input.GetButtonDown("Butt1") && nearby && NeedKBToPass)
				{
					if (!hasKeyboard)
					{
						textBox.SetActive(value: true);
					}
					else if (hasKeyboard)
					{
						doorfade.SetTrigger("go");
						player.transform.position = TakeTo;
						textBox.SetActive(value: false);
					}
				}
				else if (Input.GetButtonDown("Butt1") && nearby && !NeedKBToPass)
				{
					textBox.SetActive(value: true);
				}
				else if (nearby && Instant)
				{
					player.transform.position = TakeTo;
				}
			}
			if (SceneDoor)
			{
				if (Input.GetButtonDown("Butt1") && nearby && !readytogo)
				{
					textBox.SetActive(value: true);
				}
				if (Choice.activeInHierarchy && Input.GetButtonDown("Butt1"))
				{
					doorfade.SetTrigger("goExit");
					SceneManager.LoadSceneAsync(NextScene);
				}
			}
			else if (Input.GetButtonDown("Butt1") && nearby)
			{
				textBox.SetActive(value: true);
			}
			else if (nearby && Instant)
			{
				player.transform.position = TakeTo;
			}
		}
		if (InstaCutscene)
		{
			Cutscene.SetActive(value: true);
			if (Important)
			{
				Notif.SetActive(value: false);
			}
		}
		if (IsCutscene && Cutscene.activeInHierarchy)
		{
			bgmusic.Stop();
		}
		if (!musicbox || done)
		{
			return;
		}
		if (Input.GetButtonDown("Butt1") && nearby && Lock.activeInHierarchy && NenreiOW.canMove)
		{
			textBox.SetActive(value: true);
			NenreiOW.canMove = false;
		}
		if (Choice.activeInHierarchy)
		{
			NenreiOW.canMove = false;
			if (Input.GetButtonDown("Butt1"))
			{
				MusicBox.SetTrigger("go");
				active = false;
				NenreiOW.canMove = false;
				textBox.SetActive(value: false);
			}
			if (Input.GetButtonDown("Butt2"))
			{
				NenreiOW.canMove = true;
				ObjectText.amorgos = false;
				textBox.SetActive(value: false);
			}
		}
		if (Close.activeInHierarchy)
		{
			if (Input.GetButtonDown("Butt1"))
			{
				MusicBox.SetTrigger("end");
				Lock.SetActive(value: false);
				ItemGet.SetActive(value: false);
				done = true;
				active = false;
				Player.SetTrigger("CloseNotif");
				NenreiOW.canMove = true;
				ObjectText.amorgos = false;
				bgmusic.Play();
			}
			if (Input.GetButtonDown("Butt3"))
			{
				ItemGet.SetActive(value: false);
				Lock.SetActive(value: false);
				StickerBook.SetActive(value: true);
				done = true;
				active = false;
				MusicBox.SetTrigger("end");
				Lock.SetActive(value: false);
				bgmusic.Play();
			}
		}
	}

	private void SwitchCam()
	{
		CamReady = false;
		CurrentCam.SetActive(value: false);
		NewCam.SetActive(value: true);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = true;
			active = true;
		}
		if (coll.gameObject.name == "HasKeyboard")
		{
			hasKeyboard = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = false;
		}
		if (coll.gameObject.name == "HasKeyboard")
		{
			hasKeyboard = false;
		}
	}
}
