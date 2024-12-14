using System;
using UnityEngine;
using UnityEngine.Events;

namespace HellTap.LDC
{
	[Serializable]
	public class DS_Actions
	{
		public DSObjectCreation[] createObjectsAtStart = new DSObjectCreation[0];

		public DSObjectCreation[] createObjectsAtEnd = new DSObjectCreation[0];

		public DS_SendMessage[] sendMessageAtStart = new DS_SendMessage[0];

		public DS_SendMessage[] sendMessageAtEnd = new DS_SendMessage[0];

		public string[] activateTheseObjectsAtStart = new string[0];

		public GameObject[] activateTheseObjectsAtStartDirectly = new GameObject[0];

		public GameObject[] activateTheseObjectsAtEnd = new GameObject[0];

		public string[] activateTheseObjectsAtEndByName = new string[0];

		public string[] deactivateTheseObjectsAtStart = new string[0];

		public GameObject[] deactivateTheseObjectsAtStartDirectly = new GameObject[0];

		public GameObject[] deactivateTheseObjectsAtEnd = new GameObject[0];

		public string[] deactivateTheseObjectsAtEndByName = new string[0];

		public string[] showMessageInConsoleAtStart = new string[0];

		public string[] showMessageInConsoleAtEnd = new string[0];

		public string[] findAndDestroyTheseObjectsAtStart = new string[0];

		public string[] findAndDestroyTheseObjectsAtEnd = new string[0];

		public GameObject[] destroyTheseObjectsAtStart = new GameObject[0];

		public GameObject[] destroyTheseObjectsAtEnd = new GameObject[0];

		public bool fadeAllSceneLayers;

		public DialogUIBackgroundLayers[] sceneLayers = new DialogUIBackgroundLayers[10];

		public bool fadeAllActorLayers;

		public DialogUIActorLayers[] actorLayers = new DialogUIActorLayers[10];

		public DSAudioSetup music = new DSAudioSetup();

		public DSAudioSetup sfx1 = new DSAudioSetup();

		public DSAudioSetup sfx2 = new DSAudioSetup();

		public DSAudioSetup sfx3 = new DSAudioSetup();

		public DSTokenActions[] tokens = new DSTokenActions[0];

		public DSTokenFileManagementActions tokenFileManagement;

		public DSPlayerPrefsActions[] playerPrefs = new DSPlayerPrefsActions[0];

		public UnityEvent callbacksAtStart;

		public UnityEvent callbacksAtEnd;

		public Action actionAtStart;

		public Action actionAtEnd;

		public DSActionsFor_uSequencer uSequencer = new DSActionsFor_uSequencer();

		public DSActionsFor_RTVoice rtVoice = new DSActionsFor_RTVoice();

		public DS_SetNewLanguage setNewLanguage;

		public bool updateGUISkins = true;
	}
}
