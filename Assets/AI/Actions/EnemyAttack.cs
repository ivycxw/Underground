using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;


[RAINAction]
public class EnemyAttack : RAINAction
{
	private UndergroundCharacter player;
	private Animator anim;
	
    public override void Start(RAIN.Core.AI ai)
    {
		player = ai.WorkingMemory.GetItem<GameObject> ("player").GetComponent<UndergroundCharacter> ();
		anim = ai.Body.GetComponent<Animator> ();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if (Vector3.Distance (ai.Kinematic.Position, player.transform.position) <= 1.3f) {
			anim.SetTrigger ("Attack");

			if (ai.Body.CompareTag ("Enemy-Knight")) {
				player.TakeDamage (15);
			} else if (ai.Body.CompareTag ("Enemy-Swords")) {
				player.TakeDamage (10);
			}

			return ActionResult.SUCCESS;
		}

		return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}