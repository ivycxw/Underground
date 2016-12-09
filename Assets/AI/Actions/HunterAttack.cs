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
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class HunterAttack : RAINAction
{
	private GameObject player;
	private GameObject arrowPrefab;
	private Animator anim;
	private float maxHeight = 5f;

    public override void Start(RAIN.Core.AI ai)
    {
		player = ai.WorkingMemory.GetItem <GameObject> ("player");
		arrowPrefab = (GameObject) ai.WorkingMemory.GetItem ("arrow");
		anim = ai.Body.GetComponent<Animator> ();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if (anim.GetBool ("Dead")) {
			return ActionResult.FAILURE;
		}

		Vector3 velocity = player.GetComponent <Rigidbody> ().velocity;

		GameObject arrow = (GameObject) Object.Instantiate (arrowPrefab, ai.Kinematic.Position + ai.Kinematic.Forward * 0.5f + Vector3.up * 2f, Quaternion.identity);

		Vector3 predictedVelocity = predictVelocity (ai.Body.transform.position, player.transform.position, velocity);

		arrow.GetComponent <Rigidbody> ().velocity = predictedVelocity;
		arrow.GetComponent <MeshRenderer> ().enabled = true;
		arrow.tag = "Arrow";

		Object.Destroy (arrow, 5.0f);

        return ActionResult.SUCCESS;
    }

	private Vector3 predictVelocity (Vector3 origin, Vector3 target, Vector3 targetVelocity)
	{
		float g = -Physics.gravity.y;
		float verticalSpeed = Mathf.Sqrt(2f * g * maxHeight);
		float travelTime = Mathf.Sqrt(2f * (maxHeight - (target.y - origin.y)) / g) + Mathf.Sqrt(2f * maxHeight / g);

		target = target + targetVelocity * 1.5f * travelTime;

		Vector3 horizontalSpeed = (target - origin) / travelTime;

		return Vector3.up * verticalSpeed + horizontalSpeed * 0.76f;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}