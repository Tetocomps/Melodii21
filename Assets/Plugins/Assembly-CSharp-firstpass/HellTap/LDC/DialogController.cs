using System.Collections;
using UnityEngine;

namespace HellTap.LDC
{
	public class DialogController : MonoBehaviour
	{
		public float startAfterXSeconds = 1f;

		public DCSTATUS status = DCSTATUS.ENDED;

		public int startID = 1;

		public int currentID;

		public DialogScreen currentScreen;

		public bool autoPlay;

		public int nextID;

		public string googleSpreadsheetFilename = "";

		public IEnumerator Start()
		{
			yield return null;
			base.gameObject.tag = "DialogController";
			status = DCSTATUS.ENDED;
			if (autoPlay)
			{
				Invoke("Play", startAfterXSeconds);
			}
		}

		public void Play()
		{
			status = DCSTATUS.START;
			StopOtherDialogs();
		}

		public void FindDialog(int theID)
		{
			currentID = 0;
			currentScreen = null;
			DialogScreen[] components = base.gameObject.GetComponents<DialogScreen>();
			foreach (DialogScreen dialogScreen in components)
			{
				if (dialogScreen.dialogID == theID)
				{
					currentScreen = dialogScreen;
					currentScreen.isActive = true;
					currentID = theID;
					StartCoroutine(currentScreen.Setup());
				}
			}
		}

		public void StopOtherDialogs()
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("DialogController");
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject != null) || !(gameObject != base.gameObject) || !(gameObject.GetComponent<DialogController>() != null))
				{
					continue;
				}
				DialogController component = gameObject.GetComponent<DialogController>();
				if (!(component != null) || !(component != this) || component.status == DCSTATUS.ENDED)
				{
					continue;
				}
				component.status = DCSTATUS.ENDED;
				component.currentScreen = null;
				component.currentID = 0;
				DialogScreen[] components = component.gameObject.GetComponents<DialogScreen>();
				foreach (DialogScreen dialogScreen in components)
				{
					if (dialogScreen != null)
					{
						dialogScreen.isActive = false;
					}
				}
				if (typeof(DialogUI) != null && DialogUI.dui != null)
				{
					DialogUI.dui.StopScreenNow();
					status = DCSTATUS.START;
				}
				if (component.autoPlay)
				{
					Debug.Log("Destroying DialogController of name: " + component.gameObject);
					Object.Destroy(component.gameObject);
				}
			}
		}

		public void FixedUpdate()
		{
			if (!DialogUI.ended && DialogUI.status == DUISTATUS.WAITFORSCREEN && DialogUI.changeThreadDC == this)
			{
				if (DialogUI.screen != null && DialogUI.screen.gameObject.GetComponent<DialogController>() != null && DialogUI.screen.gameObject.GetComponent<DialogController>() != this)
				{
					DialogController component = DialogUI.screen.gameObject.GetComponent<DialogController>();
					if (component != null)
					{
						component.status = DCSTATUS.ENDED;
						component.currentScreen = null;
						component.currentID = 0;
					}
				}
				status = DCSTATUS.SHOWING;
				if (DialogUI.changeThreadOverrideID <= 0)
				{
					FindDialog(startID);
				}
				else
				{
					FindDialog(DialogUI.changeThreadOverrideID);
				}
				DialogUI.changeThreadDC = null;
				DialogUI.changeThreadOverrideID = 0;
			}
			else if (DialogUI.ended && status == DCSTATUS.START && currentScreen == null && !DialogUI.dui.forceClose)
			{
				status = DCSTATUS.SHOWING;
				FindDialog(startID);
			}
			else if (status == DCSTATUS.NEXT && (DialogUI.status == DUISTATUS.ENDED || (DialogUI.status == DUISTATUS.WAITFORSCREEN && !DialogUI.dui.forceClose)))
			{
				status = DCSTATUS.SHOWING;
				FindDialog(nextID);
			}
		}
	}
}
