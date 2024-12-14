using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
	public int LevelsUnlocked;

	public int LastLevel;

	public GameObject LVL1scr;

	public static int Level;

	public static bool InStory;

	public GameObject LVL0;

	public GameObject Riv1;

	public GameObject Riv2;

	public GameObject Riv3;

	public GameObject LVL1;

	private void Start()
	{
		Level = PlayerPrefs.GetInt("Level");
		LastLevel = PlayerPrefs.GetInt("LastLevelPlayed", 0);
		if (LastLevel == 0)
		{
			EventSystem.current.SetSelectedGameObject(LVL0);
		}
		else if (LastLevel == 1)
		{
			EventSystem.current.SetSelectedGameObject(Riv1);
		}
		else if (LastLevel == 2)
		{
			EventSystem.current.SetSelectedGameObject(Riv2);
		}
		else if (LastLevel == 3)
		{
			EventSystem.current.SetSelectedGameObject(Riv3);
		}
		else if (LastLevel == 4)
		{
			EventSystem.current.SetSelectedGameObject(LVL1);
		}
		LevelsUnlocked = PlayerPrefs.GetInt("Level");
		if (LevelsUnlocked == 1)
		{
			LVL1scr.SetActive(value: true);
		}
	}

	public void Quit()
	{
		InStory = false;
		SceneManager.LoadSceneAsync("Title");
	}

	public void Go_LvLSelect()
	{
		InStory = false;
		SceneManager.LoadSceneAsync("LevelSelect");
	}

	public void Go_Story()
	{
		InStory = true;
		if (Level == 0)
		{
			SceneManager.LoadSceneAsync("How2Funk");
		}
	}

	public void Go_LvL0()
	{
		InStory = false;
		SceneManager.LoadSceneAsync("How2Funk");
	}

	public void Go_RvL1()
	{
		InStory = false;
		SceneManager.LoadSceneAsync("Rival1");
	}

	public void Go_LvL1()
	{
		InStory = false;
		SceneManager.LoadSceneAsync("LvL1");
	}

	public void ClearData()
	{
		PlayerPrefs.DeleteAll();
	}

	private void Update()
	{
	}
}
