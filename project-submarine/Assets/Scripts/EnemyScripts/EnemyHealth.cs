using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Image=UnityEngine.UI.Image;

public class EnemyHealth : MonoBehaviour 
{
	[SerializeField]
	private float health;
	[SerializeField]
	private float damage;
	[SerializeField]
	private GameObject pickup;
	[SerializeField]
	private GameObject particles;
	[SerializeField]
	private Image healthBar;
	[SerializeField]
	private ParticleSystem FX_Enemy;

	private int i;
	private float random;
	private bool canHit = true;
	private GameObject[] sp;
	private GameObject canvas;
	private UIController uiController;
	private ParticleSystem particleEmission;


	void Awake ()
	{
		particleEmission = particles.GetComponent<ParticleSystem> ();
		canvas = GameObject.FindGameObjectWithTag ("UIController");
		uiController = canvas.GetComponent<UIController> ();
		sp = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");
		random = Random.value * 100f;
	}


	void Update()
	{
		
		if (health <= 0) 
		{
			canHit = false;
			//particleEmission.Play ();
			Instantiate (FX_Enemy, transform.position, transform.rotation);
			EnemyDeath ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "projectile" && canHit == true)
		{
			health -= damage;
			healthBar.fillAmount = health / 100f;
		}
	}

	void EnemyDeath()
	{
		particleEmission.Stop ();
		Destroy (gameObject);
		uiController.AddScore (20);
		for (i = 0; i < sp.Length; i++)
		{
			Debug.Log (sp.Length);
			sp [i].GetComponent<_Spawner> ().OnEnemyDeath ();
		}
		if(random < 30)
		{
			Instantiate (pickup, transform.position, transform.rotation);
		}
	}
}