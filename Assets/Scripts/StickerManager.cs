using UnityEngine;

public class StickerManager : MonoBehaviour
{
	public AudioSource Slap;

	public AudioSource No;

	public static bool Has_MelSticker;

	public static bool MelSticker;

	public static bool Has_NoStickers = true;

	public GameObject MelodiiSticker;

	public GameObject NoStickers;

	public GameObject EquipButton;

	public GameObject CloseButton;

	private void Start()
	{
	}

	public void EquipSticker_Mel()
	{
		if (!MelSticker)
		{
			MelSticker = true;
			Slap.Play();
		}
	}

	public void RemoveSticker_Mel()
	{
		if (MelSticker)
		{
			MelSticker = false;
			No.Play();
		}
	}

	private void Update()
	{
		if (Input.GetButton("Butt3"))
		{
			ObjectText.amorgos = true;
			NenreiOW.canMove = false;
			if (Has_NoStickers)
			{
				NoStickers.SetActive(value: true);
				EquipButton.SetActive(value: false);
			}
			else
			{
				NoStickers.SetActive(value: false);
				CloseButton.SetActive(value: true);
			}
			if (Has_MelSticker)
			{
				MelodiiSticker.SetActive(value: true);
			}
		}
	}
}
