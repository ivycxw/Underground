using UnityEngine;
using System.Collections;

public class RoomChange2 : MonoBehaviour {
	public ParticleSystem particle;
	private AudioSource source;
	public AudioClip movingSound;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		if (PlayerItemManager.r2_num_keys >= 2) {
			Debug.Log ("Go To Next Step");
			PlayerItemManager.hasKey = false;
			source.PlayOneShot (movingSound);
			other.gameObject.transform.position = new Vector3(257, 9, 180);
		}
	}
}
