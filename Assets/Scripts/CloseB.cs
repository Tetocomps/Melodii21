using UnityEngine;
using UnityEngine.UI;

public class CloseB : MonoBehaviour
{
	public Button button;

	public Image current;

	public Sprite XB;

	public Sprite PS;

	public Sprite NS;

	public Sprite KB;

	public Sprite GEN;

	public int layout = 1;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetButtonDown("Butt2"))
		{
			button.onClick.Invoke();
		}
		layout = PlayerPrefs.GetInt("CTRlayout");
		if (layout == 1)
		{
			GetComponent<Image>().sprite = XB;
		}
		else if (layout == 2)
		{
			GetComponent<Image>().sprite = PS;
		}
		else if (layout == 3)
		{
			GetComponent<Image>().sprite = NS;
		}
		else if (layout == 4)
		{
			GetComponent<Image>().sprite = KB;
		}
		else if (layout == 5)
		{
			GetComponent<Image>().sprite = GEN;
		}
	}
}
