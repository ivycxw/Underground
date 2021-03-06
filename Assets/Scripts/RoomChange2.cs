/*
    Team Underground

    Xiaowei Chen
    Hyun Seo Chung
    Hui Feng
    Sangmin Lee
    Zachary Peterson
*/

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
			source.PlayOneShot (movingSound);
			particle.Stop ();
			other.gameObject.transform.position = new Vector3(257, 9, 180);
			UndergroundCharacter character = other.gameObject.GetComponent<UndergroundCharacter>();
			if (character != null)
			{
				character.SetCheckpoint(new Vector3(257, 9, 180), Quaternion.Euler(0.0f, -90.0f, 0.0f));
			}
		}
	}
}
