using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Moves the given unity to a given position

public class MovePositionState : BaseUnitState
{
    public override void EnterState(UnitStateController stateController)
    {
        Debug.Log("Enter move position");
        stateController.agent.SetDestination(stateController.targetPos);
        Debug.Log(stateController.targetPos);
        Debug.Log(stateController.agent.destination);
    }

    public override void ExitState(UnitStateController stateController)
    {
        Debug.Log("Exit move position");
        stateController.agent.ResetPath();
    }

    public override void UpdateState(UnitStateController stateController)
    {
        if (!stateController.agent.hasPath && !stateController.agent.pathPending)
        {
            stateController.SwitchState(stateController.idleState);
        }
    }
}
