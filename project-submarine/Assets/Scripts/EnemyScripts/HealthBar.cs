using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Transform cam;

	void Start()
	{
		cam = Camera.main.transform;
	}

	void Update ()
	{
		transform.LookAt (cam);
	}
}
