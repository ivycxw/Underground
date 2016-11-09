using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameOverGrayScript : MonoBehaviour {
	private bool isGray;
	private Grayscale effect;

	void Start () {
		isGray = false;
		effect = GetComponent<Grayscale> ();
	}

	void Update () {
		// will be triggered by Player's Health
		if(Input.GetButtonDown("Fire3"))
		{
			isGray = !isGray;
			effect.enabled = isGray;
		}
	}
}
