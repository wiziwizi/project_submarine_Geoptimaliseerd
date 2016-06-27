using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	[SerializeField]
	private Vector3 rotation;


	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(rotation * 10 * Time.deltaTime);
	}
}
