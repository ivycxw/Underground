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

public class Arrow : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (-rb.velocity);
	}

	void OnCollisionEnter (Collision collision) {
		GameObject collidedObject = collision.gameObject;

		if (collidedObject.layer == LayerMask.NameToLayer ("Enemy")) {
			return;
		}

		Object.Destroy (gameObject);
		
		UndergroundCharacter character = collidedObject.GetComponent <UndergroundCharacter> ();

		if (character != null) {
			character.TakeDamage (5);
		}
	}
}
