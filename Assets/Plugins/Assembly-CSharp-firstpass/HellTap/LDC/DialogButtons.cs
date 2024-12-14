using System.Collections;
using UnityEngine;

namespace HellTap.LDC
{
	public class DialogButtons : MonoBehaviour
	{
		public DialogCastGroup[] theCast;

		public static DialogButtons com;

		public void Awake()
		{
			com = this;
		}

		public static DialogCastActor GetAnimation(int groupID, int actorID)
		{
			if (com != null && com.theCast[groupID] != null && com.theCast[groupID].actors[actorID] != null && com.theCast[groupID].actors[actorID].animated)
			{
				return com.theCast[groupID].actors[actorID];
			}
			return null;
		}

		public static DialogCastActor EditorGetAnimation(int groupID, int actorID)
		{
			DialogButtons[] array = (DialogButtons[])Object.FindObjectsOfType(typeof(DialogButtons));
			if (array.Length != 0 && array[0] != null && array[0].theCast != null && groupID < array[0].theCast.Length && array[0].theCast[groupID] != null && actorID < array[0].theCast[groupID].actors.Length && array[0].theCast[groupID].actors[actorID] != null && array[0].theCast[groupID].actors[actorID].animated)
			{
				return array[0].theCast[groupID].actors[actorID];
			}
			return null;
		}

		public static DialogCastGroup[] GetDialogCastGroups()
		{
			DialogButtons[] array = (DialogButtons[])Object.FindObjectsOfType(typeof(DialogButtons));
			if (array.Length != 0 && array[0] != null)
			{
				return array[0].theCast;
			}
			return null;
		}

		public static GUIContent[] GetPopup()
		{
			DialogButtons[] array = (DialogButtons[])Object.FindObjectsOfType(typeof(DialogButtons));
			if (array.Length != 0 && array[0] != null)
			{
				DialogCastGroup[] array2 = array[0].theCast;
				ArrayList arrayList = new ArrayList();
				arrayList.Clear();
				DialogCastGroup[] array3 = array2;
				foreach (DialogCastGroup dialogCastGroup in array3)
				{
					new GUIContent
					{
						image = null,
						text = dialogCastGroup.name,
						tooltip = ""
					};
					DialogCastActor[] actors = dialogCastGroup.actors;
					foreach (DialogCastActor dialogCastActor in actors)
					{
						if (dialogCastActor.icon != null)
						{
							GUIContent gUIContent = new GUIContent();
							gUIContent.image = dialogCastActor.icon;
							gUIContent.text = dialogCastGroup.name + " - " + dialogCastActor.name;
							gUIContent.tooltip = "";
							arrayList.Add(gUIContent);
						}
					}
				}
				return arrayList.ToArray(typeof(GUIContent)) as GUIContent[];
			}
			return null;
		}
	}
}
