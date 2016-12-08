using UnityEngine;
using System.Collections;

public class EndingScreenScript : MonoBehaviour {
	private AudioSource source;
	public ParticleSystem particle;
	public AudioClip movingSound;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		if (PlayerItemManager.r4_num_keys >= 1) {
			source.PlayOneShot (movingSound);
			particle.Stop ();
			// Ending Screen should be hooked up here

		}
	}
}
