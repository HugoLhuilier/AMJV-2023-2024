using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Moves the given unity to a given position

public class MovePositionState : BaseUnitState
{
    public override void EnterState(UnitStateController stateController)
    {
        stateController.agent.SetDestination(stateController.targetPos);
    }

    public override void ExitState(UnitStateController stateController)
    {
        stateController.agent.ResetPath();
    }

    public override void UpdateState(UnitStateController stateController)
    {
        // Debug.Log(stateController.agent.pathPending);

        if (!stateController.agent.hasPath && !stateController.agent.pathPending)
        {
            stateController.SwitchState(stateController.idleState);
        }
    }
}
