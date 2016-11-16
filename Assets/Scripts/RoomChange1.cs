using UnityEngine;
using System.Collections;

public class RoomChange1 : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (KeyManager.hasKey == true) {
			Debug.Log ("Go To Next Step");
			KeyManager.hasKey = false;
			other.gameObject.transform.position = new Vector3(365, 6, 185);
		}
	}
}
