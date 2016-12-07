using UnityEngine;
using System.Collections;

public class KeyManager2 : MonoBehaviour {
	private AudioSource source;
	public AudioClip collectedSound;
	public ParticleSystem particle;
	public ParticleSystem destinationParticle1;
	public ParticleSystem destinationParticle2;
	public MeshRenderer directionText1;
	public MeshRenderer directionText2;
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
			PlayerItemManager.r2_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			if (PlayerItemManager.r2_num_keys == 2) {
				directionText2.enabled = true;
				destinationParticle1.Play ();
				destinationParticle2.Play ();
			} else {
				directionText1.enabled = true;
			}
			source.PlayOneShot (collectedSound);
		}
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collsion: " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			PlayerItemManager.r2_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			if (PlayerItemManager.r2_num_keys == 2) {
				directionText2.enabled = true;
				destinationParticle1.Play ();
				destinationParticle2.Play ();
			} else {
				directionText1.enabled = true;
			}
			source.PlayOneShot (collectedSound);
		}
	}

}
