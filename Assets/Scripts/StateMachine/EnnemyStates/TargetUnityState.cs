using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUnityState : BaseEnnemyState
{
    public override void EnterState(EnnemyStateController stateController)
    {
        stateController.unitController.targetUnity = stateController.targetUnity;
        stateController.unitController.SwitchState(stateController.unitController.moveToCapacity);
    }

    public override void ExitState(EnnemyStateController stateController)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnnemyStateController stateController)
    {
        // Nothing
    }
}
