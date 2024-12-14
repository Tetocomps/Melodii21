using System;
using UnityEngine;

namespace HellTap.LDC
{
	[Serializable]
	public class DSAudioSetup
	{
		public AudioSource source;

		public DSAudioAction action;

		public bool useAudioPath;

		public string playFromPath = "";

		public AudioClip clip;

		public float volume = 1f;

		public float currentVolume = 1f;

		public float pitch = 1f;

		public bool loop;

		public float fadeDuration = 2f;
	}
}
