using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	[SerializeField]
	private Text Score;
	public Text WaveText;
	public Text WaveNumber;
	[SerializeField]
	private Text PickupText;
	private GameObject[] er;
	public static int score;
	public static int Pickups;
	public static bool NextWaveBool;

	// Use this for initialization
	void Start()
	{
		WaveText.CrossFadeAlpha (0f, 0.5f, false);
		WaveNumber.CrossFadeAlpha (0f, 0.5f, false);
		score = 0;
		UpdateScore ();
	}

	void Update()
	{
		PickupText.text = ":" + Pickups;
		WaveText.text = _Spawner.WaveNumber.ToString();

		if(NextWaveBool == true)
		{
			WaveText.canvasRenderer.SetAlpha (1f);
			WaveNumber.canvasRenderer.SetAlpha (1f);
		}
		else
		{
			WaveText.CrossFadeAlpha (0f, 0.5f, false);
			WaveNumber.CrossFadeAlpha (0f, 0.5f, false);
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		Score.text = score + ":";
	}
}