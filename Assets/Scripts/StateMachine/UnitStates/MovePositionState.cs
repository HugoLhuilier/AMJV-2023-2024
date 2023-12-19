using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePosition : BaseState
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
        // Nothing
    }
}
