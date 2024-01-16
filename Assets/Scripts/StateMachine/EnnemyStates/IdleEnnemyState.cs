using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnnemyState : BaseEnnemyState
{
    public override void EnterState(EnnemyStateController stateController)
    {
        Debug.Log("Idle ennemy state");
        stateController.unitController.SwitchState(stateController.unitController.idleState);
    }

    public override void ExitState(EnnemyStateController stateController)
    {
        // Nothing
    }

    public override void UpdateState(EnnemyStateController stateController)
    {
        if (Time.frameCount % stateController.framesTargetCheck == 0)
        {
            stateController.CheckTarget();
        }
    }
}
