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
		if (PlayerItemManager.hasKey == true) {
			Debug.Log ("Go To Next Step");
			PlayerItemManager.hasKey = false;
			source.PlayOneShot (movingSound);
			other.gameObject.transform.position = new Vector3(293, 9, 52);
			UndergroundCharacter character = other.gameObject.GetComponent<UndergroundCharacter>();
			if (character != null)
			{
				character.SetCheckpoint(new Vector3(293, 9, 52), Quaternion.Euler(0.0f, -90.0f, 0.0f));
			}
		}
	}
}
