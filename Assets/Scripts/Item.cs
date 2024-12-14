using UnityEngine;

public class Item : MonoBehaviour
{
	public GameObject notifBox;

	public bool nearby;

	public bool notifup;

	public Animator player;

	public GameObject self;

	public GameObject inventoryGO;

	public AudioSource music;

	public AudioSource ItemSound;

	public SpriteRenderer rend;

	public CircleCollider2D collo;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt1") && nearby && !notifup)
		{
			NotifUp();
		}
	}

	public void NotifUp()
	{
		notifup = true;
		notifBox.SetActive(value: true);
		player.SetTrigger("Stop");
		inventoryGO.SetActive(value: true);
		ItemSound.Play();
		music.mute = true;
		rend.enabled = false;
		collo.enabled = false;
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = false;
		}
	}
}
