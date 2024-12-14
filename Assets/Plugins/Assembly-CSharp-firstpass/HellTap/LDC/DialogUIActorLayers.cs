using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DialogUIActorLayers
	{
		public bool setLayer;

		public Texture2D tex;

		public ScaleMode scale;

		public float size = 100f;

		public DUI_ACTOR_ALLIGN allignment = DUI_ACTOR_ALLIGN.Middle;

		public Vector2 offset = Vector2.zero;

		public DUI_ACTOR_MOTION motion;

		public Vector2 animationID = new Vector2(-1f, -1f);

		public DialogCastActor anim = new DialogCastActor();

		public Rect rect;

		public Rect motionRect;

		public float opacity;

		public DUI_LAYER_STATUS display = DUI_LAYER_STATUS.Hide;
	}
}
