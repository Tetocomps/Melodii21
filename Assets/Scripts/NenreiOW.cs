using UnityEngine;

public class NenreiOW : MonoBehaviour
{
	private Rigidbody2D rb2d;

	public float speed;

	public float speedOG;

	public float Runspeed;

	public GameObject notifBox;

	public Animator self;

	public bool moving;

	public bool hasKeyboard;

	public static bool canMove;

	public AudioSource music;

	public bool SCam;

	public bool FCam;

	public Camera stillcam;

	public Camera followcam;

	public GameObject Stopper;

	public bool InMenu;

	public GameObject StickerBook;

	private void Start()
	{
		Application.targetFrameRate = 60;
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void StillCam()
	{
		stillcam.enabled = true;
		followcam.enabled = false;
		SCam = true;
		FCam = false;
	}

	private void FollowCam()
	{
		stillcam.enabled = false;
		followcam.enabled = true;
		FCam = true;
		SCam = false;
	}

	public void EmergencyCanMove()
	{
		canMove = true;
		ObjectText.amorgos = false;
	}

	private void FixedUpdate()
	{
		if (!ObjectText.amorgos)
		{
			canMove = true;
		}
		else
		{
			canMove = false;
			moving = false;
			self.SetTrigger("Stop");
		}
		if (notifBox.activeInHierarchy)
		{
			canMove = false;
			self.SetTrigger("ItemGet");
			if (Input.GetButtonDown("Butt1"))
			{
				notifBox.SetActive(value: false);
				self.SetTrigger("CloseNotif");
				music.mute = false;
			}
		}
		if (Stopper.activeInHierarchy)
		{
			canMove = false;
			moving = false;
		}
		if (Input.GetButton("Butt4"))
		{
			speed = Runspeed;
		}
		else
		{
			speed = speedOG;
		}
		if (canMove)
		{
			float axis = Input.GetAxis("Vertical");
			if (Input.GetAxis("Vertical") > 0f)
			{
				self.SetTrigger("Up");
				moving = true;
			}
			if (Input.GetAxis("Vertical") < 0f)
			{
				self.SetTrigger("Down");
				moving = true;
			}
			if (Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f)
			{
				self.SetTrigger("Stop");
				moving = false;
			}
			float axis2 = Input.GetAxis("Horizontal");
			if (Input.GetAxis("Horizontal") > 0f && axis == 0f)
			{
				self.SetTrigger("Right");
				moving = true;
			}
			if (Input.GetAxis("Horizontal") < 0f && axis == 0f)
			{
				self.SetTrigger("Left");
				moving = true;
			}
			Vector2 vector = new Vector2(axis2, axis);
			rb2d.AddForce(vector * speed);
			if (!moving)
			{
				rb2d.velocity = Vector2.zero;
			}
		}
		else
		{
			moving = false;
		}
		if (Input.GetButton("Butt3") && !InMenu && canMove)
		{
			StickerBook.SetActive(value: true);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "FCAM")
		{
			FollowCam();
		}
		if (coll.gameObject.tag == "SCAM")
		{
			StillCam();
		}
	}
}
