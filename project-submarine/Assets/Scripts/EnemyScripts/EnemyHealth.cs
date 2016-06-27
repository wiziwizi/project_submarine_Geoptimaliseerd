using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Image=UnityEngine.UI.Image;

public class EnemyHealth : MonoBehaviour 
{
	public float health;
	public float Damage;
	public GameObject Pickup;
	private int i;
	private float random;
	private bool CanHit = true;
	private GameObject[] sp;
	private GameObject _canvas;
	[SerializeField]
	private Image HealthBar;
	private UIController uiController;
	[SerializeField]



	public GameObject particles;
	private ParticleSystem particleEmission;
	private AudioSource audioSource;
	[SerializeField]
	//private GameObject Enemy;
	private ParticleSystem FX_Enemy;

	void Awake ()
	{
		particleEmission = particles.GetComponent<ParticleSystem> ();
		_canvas = GameObject.FindGameObjectWithTag ("UIController");
		uiController = _canvas.GetComponent<UIController> ();
		sp = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");
		random = Random.value * 100f;
		audioSource = GetComponent<AudioSource>();
	}


	void Update()
	{
		
		if (health <= 0) 
		{
			CanHit = false;
			//particleEmission.Play ();
			Instantiate (FX_Enemy, transform.position, transform.rotation);
			EnemyDeath ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "projectile" && CanHit == true)
		{
			health -= Damage;
			HealthBar.fillAmount = health / 100f;
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
			Instantiate (Pickup, transform.position, transform.rotation);
		}
	}
}