using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	[SerializeField]
	private GameObject pickUpparticle;
	private ParticleSystem FX_pickup;
	private GameObject target;
	private bool force;

	void Start()
	{
		target = GameObject.Find ("GravitationalObject");
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Force"))
		{
			force = true;
		}

		if(other.gameObject.CompareTag("Player"))
		{
			Instantiate (pickUpparticle, transform.position, transform.rotation);

			UIController._pickups++;
			Destroy (gameObject);
		}
	}
	void FixedUpdate()
	{
		if(force == true)
		{
			transform.position = Vector3.Lerp (transform.position, target.transform.position, 3 * Time.fixedDeltaTime);
		}
	}
}
