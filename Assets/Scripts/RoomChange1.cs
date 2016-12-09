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

public class RoomChange1 : MonoBehaviour {
	public ParticleSystem particle;
	private AudioSource source;
	public AudioClip movingSound;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		if (PlayerItemManager.hasKey == true) {
			PlayerItemManager.hasKey = false;
			particle.Stop ();
			source.PlayOneShot (movingSound);
			other.gameObject.transform.position = new Vector3(365, 6, 185);
			UndergroundCharacter character = other.gameObject.GetComponent<UndergroundCharacter>();
			if (character != null)
			{
				character.SetCheckpoint(new Vector3(365, 6, 185), Quaternion.Euler(0.0f, -90.0f, 0.0f));
			}
		}
	}
}
