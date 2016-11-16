using UnityEngine;
using System.Collections;

public class RoomChange2 : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (KeyManager.hasKey == true) {
			Debug.Log ("Go To Next Step");
			KeyManager.hasKey = false;
			other.gameObject.transform.position = new Vector3(263, 9, 201);
		}
	}
}
