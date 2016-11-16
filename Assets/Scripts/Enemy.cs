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
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof (Animator))]
public class Enemy : MonoBehaviour {

	private ThirdPersonCharacter character;
	private Animator anim;

	private int health = 100;

	// Use this for initialization
	void Start () {
		character = GetComponent <ThirdPersonCharacter> ();
		anim = GetComponent <Animator> ();

		character.shouldTransformDirection = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = new Vector3 (anim.GetFloat ("Turn") / 360f, 0, anim.GetFloat ("Forward"));
		character.Move (velocity, false, false);
	}

	void TakeDamage (int damageAmount) {
		health -= damageAmount;

		if (health <= 0) {
			Die ();
		}
	}

	void Die () {
		// TODO
	}
}
