﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private Transform muzzle;
	[SerializeField]
	private projectile Projectile;
	[SerializeField]
	private float shootRate;
	[SerializeField]
	private bool aim = false;
	[SerializeField]
	private GameObject weapon4;

	RaycastHit hit;

	private AudioSource audioSource;
	private float nextFireTime;

	[SerializeField]
	private GameObject particles;
	private ParticleSystem particleEmission;

	void Start()
	{
		hit = new RaycastHit(); 
		nextFireTime = 0;
		audioSource = GetComponent<AudioSource>();
		if (particles != null)
		{
			particleEmission = particles.GetComponent<ParticleSystem> ();
		}
	}

	void Update()
	{
		if(weapon4.activeInHierarchy)
		{
			shootRate = .25f;
		}
		if (Pauze._pause == false)
		{
			if (Input.GetMouseButton (0) && (Time.time >= nextFireTime))
			{
				Shoot ();
			}
			if (!Input.GetMouseButton (0))
			{
				if (particleEmission != null)
				{
					particleEmission.Pause ();
				}
			}
		}
	}

	void FixedUpdate()
	{
		if (aim == true)
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 400.0f))
			{
				transform.LookAt(hit.point);
			}
		}
	}
	private void Shoot()
	{
		if (particleEmission != null)
		{
			particleEmission.Play ();
		}
		GameObject obj = NewObjectPooler._current.GetPooledObject ();
		if (obj == null) return;
		obj.transform.position = muzzle.position;
		obj.transform.rotation = muzzle.rotation;
		obj.SetActive(true);
		nextFireTime = Time.time + shootRate;
		audioSource.Play ();
	}
}