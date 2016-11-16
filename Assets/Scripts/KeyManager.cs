using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {
	public GameObject flag;
	public GameObject obelisk;
	public static bool hasKey;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger: " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			hasKey = true;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
		}
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collsion: " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			hasKey = true;
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
		}
	}
		
}
