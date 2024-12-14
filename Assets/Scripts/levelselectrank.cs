using UnityEngine;
using UnityEngine.UI;

public class levelselectrank : MonoBehaviour
{
	public int Rank;

	public string Level;

	public Sprite A;

	public Sprite B;

	public Sprite C;

	public Sprite D;

	public Sprite None;

	private void Start()
	{
		if (Level == "CreamCheeseIcing")
		{
			Rank = ES3.Load("Riv1rank", 0);
		}
		if (Level == "GreasePoppin")
		{
			Rank = ES3.Load("LvL1rank", 0);
		}
	}

	private void Update()
	{
		if (Rank == 4)
		{
			GetComponent<Image>().sprite = A;
		}
		else if (Rank == 3)
		{
			GetComponent<Image>().sprite = B;
		}
		else if (Rank == 2)
		{
			GetComponent<Image>().sprite = C;
		}
		else if (Rank == 1)
		{
			GetComponent<Image>().sprite = D;
		}
		else if (Rank == 0)
		{
			GetComponent<Image>().sprite = None;
		}
	}
}
