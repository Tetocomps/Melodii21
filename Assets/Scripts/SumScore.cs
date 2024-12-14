using UnityEngine;

public class SumScore
{
	private static SumScoreManager mgr;

	public static int Score { get; protected set; }

	public static int HighScore { get; set; }

	private SumScore()
	{
	}

	public static void Add(int pointsToAdd)
	{
		Debug.Log(pointsToAdd + " points " + ((pointsToAdd > 0) ? "added" : "removed"));
		Score += pointsToAdd;
		if (MgrSet())
		{
			if (Score < 0 && !mgr.allowNegative)
			{
				Score = 0;
			}
			mgr.Updated();
		}
	}

	public static void Subtract(int pointsToSubtract)
	{
		Add(-pointsToSubtract);
	}

	public static void Reset()
	{
		Debug.Log("Reset score");
		Score = 0;
		if (MgrSet())
		{
			mgr.Updated();
		}
	}

	private static bool MgrSet()
	{
		if (mgr == null)
		{
			mgr = SumScoreManager.instance;
			if (mgr == null)
			{
				Debug.LogError("<b>SumScoreManager.instance</b> cannot be found. Make sure object is active in inspector.");
				return false;
			}
		}
		return true;
	}

	public static void SaveHighScore()
	{
		if (Score > HighScore)
		{
			Debug.Log("New high score " + Score);
			HighScore = Score;
			PlayerPrefs.SetInt("sumHS", Score);
			if (MgrSet())
			{
				mgr.UpdatedHS();
			}
		}
	}

	public static void ClearHighScore()
	{
		Debug.Log("Deleting high score");
		PlayerPrefs.DeleteKey("sumHS");
		HighScore = 0;
		if (MgrSet())
		{
			mgr.UpdatedHS();
		}
	}
}
