using System.Collections;
using UnityEngine;

namespace HellTap.LDC
{
	public class DialogCast : MonoBehaviour
	{
		public DialogCastGroup[] theCast = new DialogCastGroup[0];

		public static DialogCast com;

		public void Awake()
		{
			com = this;
		}

		public static DialogCastActor GetAnimation(int groupID, int actorID)
		{
			if (com != null && com.theCast != null && com.theCast.Length > groupID && com.theCast[groupID] != null && com.theCast[groupID].actors != null && com.theCast[groupID].actors[actorID] != null && com.theCast[groupID].actors[actorID].animated)
			{
				return com.theCast[groupID].actors[actorID];
			}
			return null;
		}

		public static DialogCastActor EditorGetAnimation(int groupID, int actorID)
		{
			DialogCast[] array = (DialogCast[])Object.FindObjectsOfType(typeof(DialogCast));
			if (array != null && array.Length != 0 && array[0] != null && array[0].theCast != null && groupID < array[0].theCast.Length && array[0].theCast[groupID] != null && actorID < array[0].theCast[groupID].actors.Length && array[0].theCast[groupID].actors[actorID] != null && array[0].theCast[groupID].actors[actorID].animated)
			{
				return array[0].theCast[groupID].actors[actorID];
			}
			return null;
		}

		public static DialogCastGroup[] GetDialogCastGroups()
		{
			DialogCast[] array = (DialogCast[])Object.FindObjectsOfType(typeof(DialogCast));
			if (array.Length != 0 && array[0] != null)
			{
				return array[0].theCast;
			}
			return null;
		}

		public static Vector2 GetDialogCastIDByName(string nameToFind)
		{
			DialogCast[] array = (DialogCast[])Object.FindObjectsOfType(typeof(DialogCast));
			if (nameToFind != "" && array.Length != 0 && array[0] != null && array[0].theCast != null)
			{
				int num = 0;
				DialogCastGroup[] array2 = array[0].theCast;
				foreach (DialogCastGroup dialogCastGroup in array2)
				{
					int num2 = 0;
					if (dialogCastGroup.actors.Length != 0)
					{
						DialogCastActor[] actors = dialogCastGroup.actors;
						for (int j = 0; j < actors.Length; j++)
						{
							if (actors[j].name == nameToFind)
							{
								return new Vector2(num, num2);
							}
							num2++;
						}
					}
					num++;
				}
			}
			return new Vector2(-1f, -1f);
		}

		public static GUIContent[] GetPopup()
		{
			DialogCast[] array = (DialogCast[])Object.FindObjectsOfType(typeof(DialogCast));
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
