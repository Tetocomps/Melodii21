using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DialogUIBackgroundLayers
	{
		public bool setLayer;

		public Texture2D tex;

		public ScaleMode scale;

		public Vector2 animationID = new Vector2(-1f, -1f);

		public DialogCastActor anim = new DialogCastActor();

		public float opacity;

		public DUI_LAYER_STATUS display = DUI_LAYER_STATUS.Hide;
	}
}
