using UnityEngine;

public class ChangeBG : MonoBehaviour
{
	public bool nearby;

	public GameObject IN;

	public GameObject OUT;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Swap()
	{
		if (nearby)
		{
			IN.SetActive(value: true);
			OUT.SetActive(value: false);
		}
		else
		{
			OUT.SetActive(value: true);
			IN.SetActive(value: false);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = true;
			Swap();
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			nearby = false;
			Swap();
		}
	}
}
