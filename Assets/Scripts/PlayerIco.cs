using System.Collections;
using UnityEngine;

public class PlayerIco : MonoBehaviour
{
	private bool active;

	public GameObject note_A;

	public GameObject note1a;

	public AudioSource voice;

	public AudioClip cut1;

	public AudioClip cut2;

	public float line = 1f;

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

	public int funk;

	public AudioClip good1;

	public AudioClip bad1;

	public ParticleSystem burstin;

	private Animator anim;

	private void Start()
	{
		StartCoroutine("Wait");
		voice = GetComponent<AudioSource>();
		anim = base.gameObject.GetComponent<Animator>();
	}

	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(14f);
		active = true;
		yield return new WaitForSeconds(4.39f);
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
			voice.clip = cut1;
			voice.Play();
			Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
		}
		if (Input.GetButtonDown("Butt1") && active && line == 2f)
		{
			voice.clip = cut2;
			voice.Play();
			Object.Instantiate(note_A, base.transform.position, base.transform.rotation);
			SumScore.Add(5);
			active = true;
		}
		if (Input.GetButtonDown("Butt1") && active && offbackbeat && offbeat && offstarbeat)
		{
			offanybeat = true;
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
			base.transform.Translate(3f * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetButton("Butt1") && active)
		{
			anim.SetTrigger("speak");
		}
		if (Input.GetButtonDown("Butt1") && active && line == 1f && onbackbeat && !offbackbeat)
		{
			funk++;
			offanybeat = false;
		}
		if (Input.GetButtonDown("Butt1") && active && line == 1f && onbeat && !offbeat)
		{
			funk += 2;
			offanybeat = false;
		}
		if (Input.GetButtonDown("Butt1") && active && line == 1f && onstarbeat && !offstarbeat)
		{
			funk += 5;
			offanybeat = false;
			burstin.Play();
		}
		if (Input.GetButtonDown("Butt1") && active && offanybeat)
		{
			SumScore.Subtract(5);
			offanybeat = false;
		}
		if (onbackbeat || onbeat || onstarbeat)
		{
			onanybeat = true;
		}
		if (offbackbeat || offbeat || offstarbeat)
		{
			onanybeat = true;
		}
		if (onanybeat)
		{
			offanybeat = false;
		}
		if (offanybeat)
		{
			onanybeat = true;
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
			offanybeat = false;
			offbackbeat = false;
		}
		if (coll.gameObject.tag == "beat")
		{
			onbeat = true;
			offanybeat = false;
			offbeat = false;
		}
		if (coll.gameObject.tag == "StarNote")
		{
			onstarbeat = true;
			offanybeat = false;
			offstarbeat = false;
		}
		if (coll.gameObject.name == "PlayerRhyLine")
		{
			onanybeat = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "backbeat")
		{
			offbackbeat = true;
			onbackbeat = false;
		}
		if (coll.gameObject.tag == "beat")
		{
			offbeat = true;
			onbeat = false;
		}
		if (coll.gameObject.tag == "StarNote")
		{
			offstarbeat = true;
			onstarbeat = false;
		}
		if (coll.gameObject.name == "PlayerRhyLine")
		{
			offanybeat = true;
		}
	}
}
