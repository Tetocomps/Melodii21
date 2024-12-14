using UnityEngine;

public class SumScoreExample : MonoBehaviour
{
	private bool timed;

	public void AddPoints(int points)
	{
		SumScore.Add(points);
	}

	public void SubtractPoints(int points)
	{
		SumScore.Add(-points);
	}

	public void ToggleTimed()
	{
		timed = !timed;
	}

	public void ResetPoints()
	{
		SumScore.Reset();
	}

	public void CheckHighScore()
	{
		if (SumScore.Score > SumScore.HighScore)
		{
			SumScore.SaveHighScore();
		}
	}

	public void ClearHighScore()
	{
		SumScore.ClearHighScore();
	}

	private void Update()
	{
		if (timed)
		{
			SumScore.Add(Mathf.RoundToInt(Time.deltaTime * 100f));
		}
	}
}
