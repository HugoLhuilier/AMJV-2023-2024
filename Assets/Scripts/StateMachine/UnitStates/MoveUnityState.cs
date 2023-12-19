using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnityState : BaseState
{
    public override void EnterState(UnitStateController stateController)
    {
        stateController.agent.SetDestination(stateController.targetUnity.position);
    }

    public override void ExitState(UnitStateController stateController)
    {
        stateController.agent.ResetPath();
    }

    public override void UpdateState(UnitStateController stateController)
    {
        stateController.agent.SetDestination(stateController.targetUnity.position);
    }
}
