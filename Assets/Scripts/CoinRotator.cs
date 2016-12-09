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

public class CoinRotator : MonoBehaviour {

	private MeshRenderer mr;
	private MeshCollider mc;
	private AudioSource source;
	public AudioClip collectedSound;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		mc = GetComponent<MeshCollider> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		mr.transform.Rotate(Vector3.right * Time.deltaTime * 50);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			mr.enabled = false;
			mc.enabled = false;
			other.gameObject.GetComponent<UndergroundCharacter> ().AddScore (5);
			source.PlayOneShot (collectedSound);
			PlayerItemManager.number_of_coins++;
		}
	}
	
}
