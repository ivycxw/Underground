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

	public AudioClip hurtAudio;
	public AudioClip attackAudio;

	private ThirdPersonCharacter character;
	private Animator anim;
	private AudioSource audioSource;

	private int health = 100;

	// Use this for initialization
	void Start () {
		character = GetComponent <ThirdPersonCharacter> ();
		anim = GetComponent <Animator> ();
		audioSource = GetComponent <AudioSource> ();

		character.shouldTransformDirection = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = new Vector3 (anim.GetFloat ("Turn") / 360f, 0, anim.GetFloat ("Forward"));
		character.Move (velocity, false, false);
	}

	public void TakeDamage (int damageAmount) {
		health -= damageAmount;

		audioSource.clip = hurtAudio;
		audioSource.Play ();

		if (health <= 0) {
			StartCoroutine(Die());
		}
	}

	IEnumerator Die () {
		anim.SetBool ("Dead", true);
		yield return new WaitForSeconds(1);
		Destroy (gameObject);
	}
}
