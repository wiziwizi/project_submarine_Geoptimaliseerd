using UnityEngine;
using System.Collections;

public class Enemysoundmanager : MonoBehaviour {
	[SerializeField]
	private AudioClip [] gravel;
	private AudioSource aSource;


	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();

		StartCoroutine ("PlaySound");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator PlaySound(){
		
		if (_Spawner._nextWaveBool == true) {
		
			aSource.clip = gravel [Random.Range (0, gravel.Length)];
			aSource.Play ();
			yield return new WaitForSeconds (5f);
			StartCoroutine ("PlaySound");
		}

}

}
