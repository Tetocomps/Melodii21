using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DSActionsFor_uSequencer
	{
		public GameObject go;

		public string findGo = "";

		public bool setup;

		public float setPlaybackTime;

		public float setPlaybackRate = 1f;

		public DSuSequencerActionType startAction;

		public DSuSequencerActionType endAction;
	}
}
