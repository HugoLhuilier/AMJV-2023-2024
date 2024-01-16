using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUnityState : BaseEnnemyState
{
    public override void EnterState(EnnemyStateController stateController)
    {
        // Debug.Log("Enter target");
        stateController.unitController.targetUnity = stateController.targetUnity;
        stateController.unitController.SwitchState(stateController.unitController.moveToCapacity);
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
