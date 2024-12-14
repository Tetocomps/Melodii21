using UnityEngine;

public class noteA : MonoBehaviour
{
	public SpriteRenderer current;

	public Sprite XB;

	public Sprite PS;

	public Sprite NS;

	public Sprite KB;

	public Sprite GEN;

	public Color color = Color.white;

	public int layout = 1;

	private void Start()
	{
	}

	private void Update()
	{
		layout = PlayerPrefs.GetInt("CTRlayout");
		if (layout == 1)
		{
			current.sprite = XB;
		}
		else if (layout == 2)
		{
			current.sprite = PS;
		}
		else if (layout == 3)
		{
			current.sprite = NS;
		}
		else if (layout == 4)
		{
			current.sprite = KB;
		}
		else if (layout == 5)
		{
			current.sprite = GEN;
		}
	}

	private void Awake()
	{
		if (base.gameObject == null)
		{
			Object.Destroy(base.gameObject, 7f);
		}
	}
}
