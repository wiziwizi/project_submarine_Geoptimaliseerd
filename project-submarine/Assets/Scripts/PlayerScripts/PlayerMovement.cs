using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	private float[] movementValeus;
	private float speedF = 0f; //speed forward.
	private float speedB = 0f; //speed Back.
	private float speedU = 0f; //speed Up.
	private float speedD = 0f; //speed Down.
	private float rotationR = 0f; //speed rotatie Rechts.
	private float rotationL = 0f; //speed rotatie Links.
	private float max = 20f; //max speed forward.
	private float maxB = 10f; //max speed back.
	private float maxR = 40f; //max speed rotatie.

	private float accel = .2f; //acceleratie Algemeen.
	private float accelR = .5f; //acceleratie rotatie.
	private float accelB = .2f; //acceleratie back.

	private Quaternion original;
	private Rigidbody rb;

	[SerializeField]
	private Canvas eToShop;

	[SerializeField]
	private GameObject[] particleEngines;

	private ParticleSystem[] particleEmissionEngines;

	void Start()
	{
		eToShop = eToShop.GetComponent<Canvas>();
		eToShop.enabled = false;
		rb = GetComponent<Rigidbody> ();
		for(int i = 0; i < particleEngines.Length; i++)
		{
			Debug.Log (i);
			Debug.Log (particleEngines.Length);
			particleEmissionEngines[i] = particleEngines[i].GetComponent<ParticleSystem> ();
			Debug.Log (particleEmissionEngines [i]);
		}
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			//Debug.Log (maxR);
			if(particleEngines[0].activeInHierarchy)
			{
				particleEmissionEngines[0].Play();
			}
			if(particleEngines[1].activeInHierarchy)
			{
				particleEmissionEngines[1].Play();
				particleEmissionEngines[2].Play();
			}
			if(particleEngines[3].activeInHierarchy)
			{
				particleEmissionEngines[3].Play();
				particleEmissionEngines[4].Play();
			}

			if(particleEngines[5].activeInHierarchy)
			{
				particleEmissionEngines[5].Play();
			}
		}
		else
		{
			for (int u = 0; u < particleEmissionEngines.Length; u++)
			{
				particleEmissionEngines[u].Stop();
			}
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			speedF += accel;

			if (speedF > max)
			{
				speedF = max;
			}
		}
		else
		{
			speedF -= accel;

			if (speedF < 0)
			{
				speedF = 0;
			}
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			rotationL += accelR;

			if (rotationL > maxR)
			{
				rotationL = maxR;
			}
		}

		else
		{
			rotationL -= accelR;

			if (rotationL < 0)
			{
				rotationL = 0;
			}
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			rotationR += accelR;

			if (rotationR > maxR)
			{
				rotationR = maxR;
			}
		}
		else
		{
			rotationR -= accelR;

			if (rotationR < 0)
			{
				rotationR = 0;
			}
		}


		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))// achteruit
		{
			speedB += accelB;

			if (speedB > maxB)
			{
				speedB = maxB;
			}
		}
		else
		{
			speedB -= accelB;

			if (speedB < 0)
			{
				speedB = 0;
			}
		}

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			speedD += accel;

			if (speedD > maxB)
			{
				speedD = maxB;

			}
		}
		else
		{
			speedD -= accel;

			if (speedD < 0)
			{
				speedD = 0;
			}
		}

		if (Input.GetKey(KeyCode.Space))
		{
			speedU += accel;

			if (speedU > maxB)
			{
				speedU = maxB;
			}
		}
		else
		{
			speedU -= accel;

			if (speedU < 0)
			{
				speedU = 0;
			}
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition (rb.position + (transform.TransformDirection( Vector3.forward) * speedF * Time.fixedDeltaTime));
		rb.MovePosition (rb.position + (transform.TransformDirection( Vector3.back) * speedB * Time.fixedDeltaTime));
		rb.MovePosition (rb.position + (transform.TransformDirection( Vector3.down) * speedD * Time.fixedDeltaTime));
		rb.MovePosition (rb.position + (transform.TransformDirection( Vector3.up) * speedU * Time.fixedDeltaTime));

		rb.MoveRotation (rb.rotation * Quaternion.Euler (Vector3.down * rotationL * Time.fixedDeltaTime));
		rb.MoveRotation (rb.rotation * Quaternion.Euler (Vector3.up * rotationR * Time.fixedDeltaTime));
	}
	public void UpgradeEngine ()
	{
		if(particleEngines[1].activeInHierarchy)
		{
			maxR = 55f;
			accelR = .8f;
			maxB = 20f;
			max = 25;
		}
		if(particleEngines[3].activeInHierarchy)
		{
			max = 40f;
			accel = .3f;
		}

		if(particleEngines[5].activeInHierarchy)
		{
			maxR = 65f;
			accelR = 1f;
			maxB = 20f;
			max = 50f;
			accel = .5f;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Shop"))
		{
			eToShop.enabled = true;
			UpgradeShop._canShop = true;
		}

		if (other.CompareTag("Shop"))
		{
			UpgradeShop._secret = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Shop"))
		{
			eToShop.enabled = false;
			UpgradeShop._canShop = false;
		}

		if (other.CompareTag("Secret"))
		{
			UpgradeShop._secret = false;
		}
	}
}