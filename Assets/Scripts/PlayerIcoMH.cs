using System.Collections;
using UnityEngine;

public class PlayerIcoMH : MonoBehaviour
{
	private bool active;

	public GameObject note_A;

	public GameObject note_ZL;

	public GameObject note_ZR;

	public GameObject note_B;

	public GameObject note_Y;

	public GameObject note_X;

	public GameObject note_left;

	public GameObject note_up;

	public GameObject note_right;

	public AudioSource voice;

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

	public AudioClip oops;

	public float line = 1f;

	public float pianoL = 1f;

	public float pianoR = 1f;

	public GUI scoreText;

	public float rhyths;

	public bool onbackbeat;

	public bool onbeat;

	public bool onstarbeat;

	public bool onanybeat;

	public bool good;

	public int funk;

	public AudioClip good1;

	public AudioClip bad1;

	public ParticleSystem burstin;

	public Transform target;

	private Animator anim;

	private void Start()
	{
		StartCoroutine("Wait");
		voice = GetComponent<AudioSource>();
		anim = base.gameObject.GetComponent<Animator>();
	}

	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(55.38f);
		base.transform.position = new Vector3(-9.455f, 4.671f, 0f);
		yield return new WaitForSeconds(3.69f);
		active = true;
		yield return new WaitForSeconds(3.69f);
		base.transform.position = new Vector3(-8.735f, 3.38f, 0f);
		active = true;
		yield return new WaitForSeconds(4.15f);
		base.transform.position = new Vector3(-9.45f, 3.38f, 0f);
		line += 1f;
		active = false;
		SumScore.Add(funk);
		if (good)
		{
			anim.SetTrigger("Active");
			voice.clip = good1;
			voice.Play();
		}
		else
		{
			voice.clip = bad1;
			voice.Play();
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt1") && active && line == 1f)
		{
			voice.clip = oops;
			voice.Play();
			Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
		}
		if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 1f)
		{
			voice.clip = p1;
			voice.Play();
			pianoL = 2f;
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 2f)
		{
			voice.clip = p2;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 3f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 3f)
		{
			voice.clip = p5;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 4f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 4f)
		{
			voice.clip = p7;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 6f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 6f)
		{
			voice.clip = p11;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 7f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 7f)
		{
			voice.clip = p13;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 8f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 8f)
		{
			voice.clip = p16;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 9f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 9f)
		{
			voice.clip = p17;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
			pianoL = 10f;
		}
		else if (Input.GetButtonDown("ZL") && active && line == 1f && pianoL == 10f)
		{
			voice.clip = p19;
			voice.Play();
			Object.Instantiate(note_ZL, base.transform.position, base.transform.rotation);
		}
		if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 1f)
		{
			voice.clip = p3;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 2f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 2f)
		{
			voice.clip = p4;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 3f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 3f)
		{
			voice.clip = p6;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 4f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 4f)
		{
			voice.clip = p8;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 5f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoL == 5f)
		{
			voice.clip = p9;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 5.5f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 5.5f)
		{
			voice.clip = p10;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 5f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 5f)
		{
			voice.clip = p12;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 6f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 6f)
		{
			voice.clip = p14;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 7f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 7f)
		{
			voice.clip = p15;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 8f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 8f)
		{
			voice.clip = p17;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
			pianoR = 9f;
		}
		else if (Input.GetButtonDown("ZR") && active && line == 1f && pianoR == 9f)
		{
			voice.clip = p18;
			voice.Play();
			Object.Instantiate(note_ZR, base.transform.position, base.transform.rotation);
		}
		if (Input.GetButtonDown("Butt1") && active && line == 1f)
		{
			voice.clip = oops;
			voice.Play();
			Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
		}
		if (Input.GetButtonDown("Butt1") && line == 1f)
		{
			funk -= 5;
		}
		if (funk >= 5)
		{
			good = true;
		}
		if (funk <= 0)
		{
			good = false;
		}
		if (active)
		{
			base.transform.Translate(3.5f * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetButton("Butt1") && active)
		{
			anim.SetTrigger("speak");
		}
		if ((Input.GetButtonDown("ZR") && active && line == 1f && onbackbeat) || (Input.GetButtonDown("ZL") && active && line == 1f && onbackbeat))
		{
			funk++;
		}
		if ((Input.GetButtonDown("ZR") && active && line == 1f && onbeat) || (Input.GetButtonDown("ZL") && active && line == 1f && onbeat))
		{
			funk += 2;
		}
		if ((Input.GetButtonDown("ZR") && active && line == 1f && onstarbeat) || (Input.GetButtonDown("ZL") && active && line == 1f && onstarbeat))
		{
			funk += 5;
			burstin.Play();
		}
		if ((Input.GetButtonDown("Butt1") && active && !onanybeat) || (Input.GetButtonDown("ZR") && active && !onanybeat) || (Input.GetButtonDown("ZL") && active && !onanybeat))
		{
			funk -= 20;
		}
		if (onbackbeat || onbeat || onstarbeat)
		{
			onanybeat = true;
		}
		else
		{
			onanybeat = false;
		}
	}

	public void AddPoints(int points)
	{
		SumScore.Add(points);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "backbeat")
		{
			onbackbeat = true;
			onanybeat = true;
		}
		if (coll.gameObject.tag == "beat")
		{
			onbeat = true;
			onanybeat = true;
		}
		if (coll.gameObject.tag == "StarNote")
		{
			onstarbeat = true;
			onanybeat = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "backbeat")
		{
			onbackbeat = false;
			onanybeat = false;
		}
		if (coll.gameObject.tag == "beat")
		{
			onbeat = false;
			onanybeat = false;
		}
		if (coll.gameObject.tag == "StarNote")
		{
			onstarbeat = false;
			onanybeat = false;
		}
		if (coll.gameObject.name == "PlayerRhyLine")
		{
			onanybeat = false;
		}
	}
}
