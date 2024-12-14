using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DialogCastActor
	{
		public string name = "None";

		public Texture2D icon;

		public bool animated;

		public Texture2D[] frames = new Texture2D[0];

		public int loopToFrame;

		public float animationSpeed = 0.2f;

		public float timer;

		public int currentFrame;

		public float editorTimer;

		public int editorCurrentFrame;
	}
}
