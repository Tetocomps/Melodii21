using UnityEngine;

public class ObjectDepth : MonoBehaviour
{
	public SpriteRenderer self;

	public GameObject boundary;

	public GameObject boundary2;

	public bool Collider;

	public int newOrder = 11;

	public int OGorder = 8;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			self.sortingOrder = newOrder;
			if (Collider)
			{
				boundary.SetActive(value: false);
				boundary2.SetActive(value: true);
			}
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			self.sortingOrder = OGorder;
			if (Collider)
			{
				boundary.SetActive(value: true);
				boundary2.SetActive(value: false);
			}
		}
	}
}
