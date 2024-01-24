using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUnityState : BaseEnnemyState
{
    public override void EnterState(EnnemyStateController stateController)
    {
        // Debug.Log("Enter target");
        stateController.unitController.SwitchMoveCapacity(stateController.targetUnity);
    }

    public override void ExitState(EnnemyStateController stateController)
    {
        // Debug.Log("Exit target");
    }

    public override void UpdateState(EnnemyStateController stateController)
    {
        if (stateController.targetUnity == null)
        {
            stateController.SwitchState(stateController.defaultState);
        }
    }
}
