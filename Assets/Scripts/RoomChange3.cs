using UnityEngine;
using System.Collections;

public class RoomChange3 : MonoBehaviour {
	public ParticleSystem particle;
	private AudioSource source;
	public AudioClip movingSound;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		if (PlayerItemManager.r3_num_keys >= 2) {
			Debug.Log ("Go To Next Step");
			PlayerItemManager.hasKey = false;
			source.PlayOneShot (movingSound);
			PlayerItemManager.number_of_coins = 0;
			other.gameObject.transform.position = new Vector3(293, 9, 52);
		}
	}
}
