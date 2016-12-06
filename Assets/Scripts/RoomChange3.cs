using UnityEngine;
using System.Collections;

public class RoomChange3 : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (PlayerItemManager.hasKey == true) {
			Debug.Log ("Go To Next Step");
			PlayerItemManager.hasKey = false;
			other.gameObject.transform.position = new Vector3(293, 9, 52);
		}
	}
}
