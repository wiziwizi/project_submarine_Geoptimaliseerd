using UnityEngine;
using System.Collections;
using Image=UnityEngine.UI.Image;

public class EnemyAI : MonoBehaviour {

	private GameObject _player;
	public static bool playerHit;

	private float BackSpeed;
	private float ForwardSpeed;
	private Rigidbody rb;
	private AudioSource clip;
	private ScreenShake screenShake;




	public float Damage;
	public float MoveSpeed;

	// Use this for initialization
	void Awake () 
	{
		clip = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		screenShake = _player.GetComponent<ScreenShake> ();
		BackSpeed = -MoveSpeed;
		ForwardSpeed = MoveSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt (_player.transform.position);
		if (playerHit == true)
		{
			screenShake.StartShake ();
			clip.Play ();
			MoveSpeed = BackSpeed;
			PlayerHealth.health -= Damage;
			playerHit = false;
			Invoke ("Reverse", 0.4f);
		}
	}

	void Reverse()
	{
		MoveSpeed = ForwardSpeed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerHit = true;
		}
		if (other.gameObject.tag == "projectile")
		{
			MoveSpeed = MoveSpeed / 2;
			Invoke ("Reverse", 0.2f);
		}
		if(other.CompareTag("Shield"))
		{
			MoveSpeed = BackSpeed;
			Invoke ("Reverse", 0.4f);
		}
	}

	void FixedUpdate()
	{
		if (Pauze.Pause == false)
		{
			rb.MovePosition (rb.position + (transform.TransformDirection (Vector3.forward) * MoveSpeed * Time.fixedDeltaTime));
		}
	}
}