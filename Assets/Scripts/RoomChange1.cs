using UnityEngine;
using System.Collections;

public class RoomChange1 : MonoBehaviour {
	public ParticleSystem particle;
	private AudioSource source;
	public AudioClip movingSound;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		if (PlayerItemManager.hasKey == true) {
			Debug.Log ("Go To Next Step");
			PlayerItemManager.hasKey = false;
			particle.Stop ();
			source.PlayOneShot (movingSound);
			other.gameObject.transform.position = new Vector3(365, 6, 185);
		}
	}
}
