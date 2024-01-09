using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCapacityState : BaseState
{
    public override void EnterState(UnitStateController stateController)
    {
        Debug.Log("Move to capacity");
        stateController.agent.SetDestination(stateController.targetUnity.position);
    }

    public override void ExitState(UnitStateController stateController)
    {
        stateController.agent.ResetPath();
    }

    public override void UpdateState(UnitStateController stateController)
    {
        if (Time.frameCount % stateController.framesPathRecalculation == 0)
        {
            stateController.agent.SetDestination(stateController.targetUnity.position);
        }

        if (!stateController.agent.hasPath)
        {
            stateController.SwitchState(stateController.idleState);
        }

        // Debug.Log("Distance restante : " + Vector3.Distance(stateController.transform.position, stateController.targetUnity.position) + " ; range : " + stateController.range);

        if (Vector3.Distance(stateController.transform.position, stateController.targetUnity.position) < stateController.range)
        {
            stateController.SwitchState(stateController.castCapacityState);
        }
    }
}
