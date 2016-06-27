using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Image=UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour 
{
	public static float health = 100;
	private bool heal;
	private bool playerDead;

	[SerializeField]
	private Image HealthBar;

	void Update()
	{
		HealthBar.fillAmount = health / 100f;
		if (health <= 0) 
		{
			health = 100;
			LevelReset ();
		}
		if (health < 100 && heal == false)
		{
			heal = true;
			StartCoroutine ("Healing");
		}
	}

	void LevelReset()
	{
		SceneManager.LoadScene("EndScene");
	}
	IEnumerator Healing()
	{
		yield return new WaitForSeconds (2);
		health += 2;
		if (health > 99)
		{
			heal = false;
		}
		else
		{
			StartCoroutine ("Healing");	
		}
	}
}