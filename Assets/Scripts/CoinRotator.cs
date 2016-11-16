using UnityEngine;
using System.Collections;

public class CoinRotator : MonoBehaviour {

	private MeshRenderer mr;
	private MeshCollider mc;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		mc = GetComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		mr.transform.Rotate(Vector3.up * Time.deltaTime * 50);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			mr.enabled = false;
			mc.enabled = false;
		}
	}
	
}
