using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewObjectPooler : MonoBehaviour {
	public static NewObjectPooler _current;

	[SerializeField]
	private GameObject pooledObject;
	[SerializeField]
	private int pooledAmount = 20;
	[SerializeField]
	private bool willGrow = true;

	List<GameObject> pooledObjects;

	void Awake()
	{
		_current = this;
	}

	void Start ()
	{
		pooledObjects = new List<GameObject> ();
		for(int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjects.Add (obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for(int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		if(willGrow)
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			pooledObjects.Add (obj);
			return obj;
		}
		return null;
	}
}
