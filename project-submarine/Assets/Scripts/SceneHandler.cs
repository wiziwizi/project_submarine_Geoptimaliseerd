using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneHandler : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas optionMenu;
	public Canvas creditsMenu;

	public Button startText;
	public Button exitText;

	public Text WaveNumber;
	public Text Score;

	private AudioSource audioSource;

	void Start()
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		optionMenu = optionMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		audioSource = GetComponentInChildren<AudioSource>();

		quitMenu.enabled = false;
		optionMenu.enabled = false;
		creditsMenu.enabled = false;
		 
		WaveNumber.text = _Spawner.WaveNumber.ToString();
		Score.text = UIController.score.ToString();
	}
	public void NewGame()
	{	
		
		SceneManager.LoadScene ("MainScene");
	}

	public void Tutorial()
	{
		SceneManager.LoadScene ("Tutorial");
	}

	public void OptionMenu()
	{	
		audioSource.Play ();
		optionMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void QuitMenu()
	{
		audioSource.Play ();
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void ExitQuitMenu()
	{
		audioSource.Play ();
		optionMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void Quit()
	{	
		audioSource.Play ();
		Application.Quit();
	}

	public void Menu()
	{
		audioSource.Play ();
		SceneManager.LoadScene ("MenuScene");
	}

	public void Credits()
	{
		creditsMenu.enabled = true;
	}
	public void ExitCredits()
	{
		creditsMenu.enabled = false;
	}
}