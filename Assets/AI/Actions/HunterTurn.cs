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
public class HunterTurn: RAINAction
{
	private GameObject player;
	private TurnAssist turnAssist;

    public override void Start(RAIN.Core.AI ai)
    {
		player = ai.WorkingMemory.GetItem <GameObject> ("player");
		turnAssist = ai.Body.GetComponent <TurnAssist> ();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.Body.transform.LookAt (player.transform.position);
		turnAssist.FaceObject (player);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}