using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCapacityState : BaseUnitState
{
    public override void EnterState(UnitStateController stateController)
    {
        // Debug.Log("Start move to capacity");
        stateController.agent.SetDestination(stateController.targetUnity.position);
    }

    public override void ExitState(UnitStateController stateController)
    {
        // Debug.Log("Stop move to capacity");
        stateController.agent.ResetPath();
    }

    public override void UpdateState(UnitStateController stateController)
    {
        if(stateController.targetUnity == null)
        {
            stateController.SwitchState(stateController.idleState);
        }

        if (Time.frameCount % stateController.framesPathRecalculation == 0)
        {
            stateController.agent.SetDestination(stateController.targetUnity.position);
        }

        if (!stateController.agent.hasPath && !stateController.agent.pathPending)
        {
            // Debug.Log(stateController.agent.pathPending);
            stateController.SwitchState(stateController.idleState);
        }

        // Debug.Log("Distance restante : " + Vector3.Distance(stateController.transform.position, stateController.targetUnity.position) + " ; range : " + stateController.basicRange);

        if (Vector3.Distance(stateController.targetUnityCollider.ClosestPoint(stateController.transform.position), stateController.transform.position) < stateController.basicRange)
        {
            stateController.SwitchState(stateController.castCapacityState);
        }
    }
}
