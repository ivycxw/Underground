using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private AudioSource source;
	public AudioClip collectedSound;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			source.PlayOneShot (collectedSound);
		}
	}

}