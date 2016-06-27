using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour {

	public static bool _pause = false;
	[SerializeField]
	private Canvas pauseMenu;

	void Awake()
	{
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		pauseMenu.enabled = false;
	}

	void Update ()
	{
		if (!_pause && Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0f;
			_pause = true;
			pauseMenu.enabled = true;
		}
	}

	public void UnPause()
	{
		Time.timeScale = 1f;
		_pause = false;
		pauseMenu.enabled = false;
	}
	public void Exit()
	{
		SceneManager.LoadScene ("MenuScene");
		UnPause ();
	}
}
