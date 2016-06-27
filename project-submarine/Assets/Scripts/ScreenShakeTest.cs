using UnityEngine;
using System.Collections;

public class ScreenShakeTest : MonoBehaviour {
	[SerializeField]
	private ScreenShake screenShake;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) 
		{
			screenShake.StartShake ();
		}
	}
}