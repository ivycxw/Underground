using UnityEngine;
using System.Collections;

public class SmallHPRotator : MonoBehaviour {

	private MeshRenderer mr;
	private MeshCollider mc;
	private AudioSource source;
	private float HP_AMOUNT = 15.0f;
	public AudioClip collectedSound;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		mc = GetComponent<MeshCollider> ();
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		mr.transform.Rotate(Vector3.up * Time.deltaTime * 50);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			mr.enabled = false;
			mc.enabled = false;
			source.PlayOneShot (collectedSound);
			other.gameObject.GetComponent<UndergroundCharacter>().IncreaseHP(HP_AMOUNT);
		}
	}
}
