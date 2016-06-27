using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {

	void Awake ()
	{
		RenderSettings.fogMode = FogMode.Exponential;
		RenderSettings.fogDensity = 0.025f;
		RenderSettings.fogColor = new Color (0.22f, 0.45f, 0.57f, 0.2f);
	}
}