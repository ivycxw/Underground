using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {
	public GameObject flag;
	public GameObject obelisk;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			flag.GetComponent<MeshRenderer> ().enabled = false;
			obelisk.GetComponent<MeshRenderer> ().enabled = false;
			flag.GetComponent<MeshCollider> ().enabled = false;
			obelisk.GetComponent<MeshCollider> ().enabled = false;
		}
	}

		
}
