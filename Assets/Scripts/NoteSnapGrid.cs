using UnityEngine;

public class NoteSnapGrid : MonoBehaviour
{
	public GameObject self;

	public GameObject Rhybox;

	public Vector3 beatPos;

	public bool backbeat;

	public bool beat;

	public bool starbeat;

	private void Start()
	{
		self.transform.SetParent(Rhybox.transform);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "backbeat")
		{
			beatPos = coll.transform.gameObject.transform.position;
			backbeat = true;
			self.transform.position = beatPos;
		}
		if (coll.gameObject.tag == "beat")
		{
			beatPos = coll.transform.gameObject.transform.position;
			beat = true;
			self.transform.position = beatPos;
		}
		if (coll.gameObject.tag == "StarNote")
		{
			beatPos = coll.transform.gameObject.transform.position;
			starbeat = true;
			self.transform.position = beatPos;
		}
	}

	private void Update()
	{
	}
}
