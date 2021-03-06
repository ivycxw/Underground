﻿/*
    Team Underground

    Xiaowei Chen
    Hyun Seo Chung
    Hui Feng
    Sangmin Lee
    Zachary Peterson
*/


using UnityEngine;
using System.Collections;

public class KeyManager3 : MonoBehaviour {
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
		if (other.gameObject.tag == "Player") {
			PlayerItemManager.r3_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			if (PlayerItemManager.r3_num_keys == 2) {
				destinationParticle.Play ();
			}
			if (directionText != null) 
				directionText.enabled = true;
			source.PlayOneShot (collectedSound);
			other.gameObject.GetComponent<UndergroundCharacter> ().AddScore (10);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			PlayerItemManager.r3_num_keys += 1;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
			particle.Stop ();
			if (PlayerItemManager.r3_num_keys >= 2) {
				destinationParticle.Play ();
			}
			if (directionText != null) 
				directionText.enabled = true;
			source.PlayOneShot (collectedSound);
			other.gameObject.GetComponent<UndergroundCharacter> ().AddScore (10);
		}
	}

}
