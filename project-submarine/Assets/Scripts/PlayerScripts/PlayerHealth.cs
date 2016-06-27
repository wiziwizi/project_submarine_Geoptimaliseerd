using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Image=UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour 
{
	public static float _health = 100;
	private bool heal;
	private bool playerDead;

	[SerializeField]
	private Image healthBar;

	void Update()
	{
		healthBar.fillAmount = _health / 100f;
		if (_health <= 0) 
		{
			_health = 100;
			LevelReset ();
		}
		if (_health < 100 && heal == false)
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
		_health += 2;
		if (_health > 99)
		{
			heal = false;
		}
		else
		{
			StartCoroutine ("Healing");	
		}
	}
}