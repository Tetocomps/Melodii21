using UnityEngine;

public class GetItem : MonoBehaviour
{
	public bool MelSticker;

	private void Start()
	{
		if (MelSticker)
		{
			StickerManager.Has_MelSticker = true;
		}
		StickerManager.Has_NoStickers = false;
	}

	private void Update()
	{
	}
}
