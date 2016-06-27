using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	[SerializeField]
	private Text score;
	[SerializeField]
	private Text waveText;
	[SerializeField]
	private Text waveNumber;
	[SerializeField]
	private Text pickupText;
	private GameObject[] er;
	public static int _score;
	public static int _pickups;
	public static bool _nextWaveBool;

	// Use this for initialization
	void Start()
	{
		waveText.CrossFadeAlpha (0f, 0.5f, false);
		waveNumber.CrossFadeAlpha (0f, 0.5f, false);
		_score = 0;
		UpdateScore ();
	}

	void Update()
	{
		pickupText.text = ":" + _pickups;
		waveText.text = _Spawner._waveNumber.ToString();

		if(_nextWaveBool == true)
		{
			waveText.canvasRenderer.SetAlpha (1f);
			waveNumber.canvasRenderer.SetAlpha (1f);
		}
		else
		{
			waveText.CrossFadeAlpha (0f, 0.5f, false);
			waveNumber.CrossFadeAlpha (0f, 0.5f, false);
		}
	}

	public void AddScore (int newScoreValue)
	{
		_score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		score.text = _score + ":";
	}
}