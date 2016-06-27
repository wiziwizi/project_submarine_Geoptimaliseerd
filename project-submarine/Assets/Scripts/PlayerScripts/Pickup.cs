using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField]
	private GameObject PickUpparticle;
	private ParticleSystem FX_pickup;
	private GameObject Target;
	private bool force;

	void Start(){
		audioSource = GetComponent<AudioSource>();
		Target = GameObject.Find ("GravitationalObject");
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Force"))
		{
			force = true;
		}

		if(other.gameObject.CompareTag("Player"))
		{
			Instantiate (PickUpparticle, transform.position, transform.rotation);

			UIController.Pickups++;
			Destroy (gameObject);
		}
	}
	void FixedUpdate()
	{
		if(force == true)
		{
			transform.position = Vector3.Lerp (transform.position, Target.transform.position, 3 * Time.fixedDeltaTime);
		}
	}
}
