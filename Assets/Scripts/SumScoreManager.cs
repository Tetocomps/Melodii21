using UnityEngine;
using UnityEngine.UI;

public class SumScoreManager : MonoBehaviour
{
	public static SumScoreManager instance;

	public int initialScore;

	public bool storeHighScore = true;

	public bool allowNegative = true;

	public Text field;

	public Text highScoreField;

	public static int NoteAmount;

	public static int PinkNoteAmount;

	public static bool Butt1Needed;

	public static bool Butt2Needed;

	public static bool Butt3Needed;

	public static bool Butt4Needed;

	public static bool UpNeeded;

	public static bool DownNeeded;

	public static bool LeftNeeded;

	public static bool RightNeeded;

	public static bool ZRNeeded;

	public static bool ZLNeeded;

	public static int ButtsNeeded;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
		if (field == null)
		{
			Debug.LogError("Missing reference to 'field' on <b>SumScoreManager</b> component");
		}
		if (storeHighScore && highScoreField == null)
		{
			Debug.LogError("Missing reference to 'highScoreField' on <b>SumScoreManager</b> component");
		}
	}

	private void Start()
	{
		SumScore.Reset();
		if (initialScore != 0)
		{
			SumScore.Add(initialScore);
		}
		if (storeHighScore)
		{
			if (PlayerPrefs.HasKey("sumHS"))
			{
				SumScore.HighScore = PlayerPrefs.GetInt("sumHS");
				UpdatedHS();
			}
			else
			{
				SumScore.HighScore = 0;
			}
		}
		Updated();
	}

	public void Updated()
	{
		field.text = SumScore.Score.ToString("0");
	}

	public void UpdatedHS()
	{
		if (storeHighScore)
		{
			highScoreField.text = SumScore.HighScore.ToString("0");
		}
	}
}
