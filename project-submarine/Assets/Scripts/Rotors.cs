using UnityEngine;
using System.Collections;

public class Rotors : MonoBehaviour
{
	[SerializeField]
	private Vector3 rotation;
	private Vector3 originRot;

	void Awake()
	{
		originRot = rotation;
	}

	void Update ()
	{
		if (rotation.z > 100)
		{
			rotation.z = 0;
		}

		transform.Rotate(rotation * 10);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
		{
			rotation =  originRot * 2.5f;
		}
		else
		{
			rotation = originRot;
		}

	}
}
