using UnityEngine;
using System.Collections;
using Image=UnityEngine.UI.Image;

public class EnemyAI : MonoBehaviour {

	private GameObject player;
	private float backSpeed;
	private float forwardSpeed;
	private Rigidbody rb;
	private AudioSource clip;
	private ScreenShake screenShake;
	public static bool _playerHit;

	[SerializeField]
	private float damage;
	[SerializeField]
	private float moveSpeed;

	// Use this for initialization
	void Awake () 
	{
		clip = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		screenShake = player.GetComponent<ScreenShake> ();
		backSpeed = -moveSpeed;
		forwardSpeed = moveSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt (player.transform.position);
		if (_playerHit == true)
		{
			screenShake.StartShake ();
			clip.Play ();
			moveSpeed = backSpeed;
			PlayerHealth._health -= damage;
			_playerHit = false;
			Invoke ("Reverse", 0.4f);
		}
	}

	void Reverse()
	{
		moveSpeed = forwardSpeed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			_playerHit = true;
		}
		if (other.gameObject.tag == "projectile")
		{
			moveSpeed = moveSpeed / 2;
			Invoke ("Reverse", 0.2f);
		}
		if(other.CompareTag("Shield"))
		{
			moveSpeed = backSpeed;
			Invoke ("Reverse", 0.4f);
		}
	}

	void FixedUpdate()
	{
		if (Pauze._pause == false)
		{
			rb.MovePosition (rb.position + (transform.TransformDirection (Vector3.forward) * moveSpeed * Time.fixedDeltaTime));
		}
	}
}