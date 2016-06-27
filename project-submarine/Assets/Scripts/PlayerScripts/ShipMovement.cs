using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	private float tumbleL = 0;
	private float tumbleR = 0;
	private float tumbleU = 0;
	private float tumbleD = 0;
	private float accel = 0.4f;

	private float maxL = 30;
	private float maxR = -30;
	private float maxU = -20;
	private float maxD = 20;

	private Vector3 rotationDirection;
	// Update is called once per frame

	void Start() { 
		rotationDirection = new Vector3 (1, 0, 1);
		rotationDirection.Normalize ();
	}
	void Update ()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			tumbleL += accel;
			if (tumbleL > maxL)
			{
				tumbleL = maxL;
			}
		}

		else
		{
			tumbleL -= accel;
			if(tumbleL < 0)
			{
				tumbleL = 0;
			}
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			tumbleR -= accel;
			if (tumbleR < maxR)
			{
				tumbleR = maxR;
			}
		}

		else
		{
			tumbleR += accel;
			if(tumbleR > 0)
			{
				tumbleR = 0;
			}
		}

		if (Input.GetKey(KeyCode.Space))
		{
			tumbleU -= accel;
			if (tumbleU < maxU)
			{
				tumbleU = maxU;
			}
		}

		else
		{
			tumbleU += accel;
			if(tumbleU > 0)
			{
				tumbleU = 0;
			}
		}

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			tumbleD += accel;
			if (tumbleD > maxD)
			{
				tumbleD = maxD;
			}
		}

		else
		{
			tumbleD -= accel;
			if(tumbleD < 0)
			{
				tumbleD = 0;
			}
		}

		Vector3 newRotation = new Vector3(rotationDirection.x * (tumbleU + tumbleD), 0, rotationDirection.z * (tumbleL + tumbleR));
		transform.localRotation = Quaternion.Euler (newRotation);
	}
}
