using UnityEngine;
using System.Collections;

public class KeyManager4 : MonoBehaviour {
	private AudioSource source;
	public AudioClip collectedSound;
	public ParticleSystem particle;
	public ParticleSystem destinationParticle;
	public MeshRenderer directionText;
	public GameObject flag;
	public GameObject obelisk;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger: " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			PlayerItemManager.r4_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			destinationParticle.Play ();
			directionText.enabled = true;
			source.PlayOneShot (collectedSound);
		}
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collsion: " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			PlayerItemManager.r4_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			destinationParticle.Play ();
			directionText.enabled = true;
			source.PlayOneShot (collectedSound);
		}
	}

}
