using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private NavMeshAgent _navMeshAgent;
	private GameObject _PlayerObj;

	// Use this for initialization
	void Awake () {
		_navMeshAgent = GetComponent<NavMeshAgent> ();
		_PlayerObj = GameObject.FindGameObjectWithTag ("Player");


	}

	// Update is called once per frame
	void Update () {
		_navMeshAgent.SetDestination (_PlayerObj.transform.position);

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			//other.gameObject.GetComponent<PlayerHealth>().removeHealth(damagePerHit);



		}
	}
}
