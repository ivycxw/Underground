using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float d = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		anim.SetFloat ("Direction",d);
		anim.SetFloat ("Speed",v);

		if (Input.GetKeyDown ("space")) {
			anim.SetBool ("Jump",true);
		}
		if (Input.GetKeyUp ("space")) {
			anim.SetBool ("Jump", false);
		}


		if (currentBaseState.nameHash == jumpState) {
			Ray ray = new Ray (transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (ray, out hitInfo)) {
				if (hitInfo.distance > 8.0f) {
					anim.MatchTarget (hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask (new Vector3 (0, 1, 0), 0), 3.0f, 4.0f);
				}
			}
		}
	}
}
