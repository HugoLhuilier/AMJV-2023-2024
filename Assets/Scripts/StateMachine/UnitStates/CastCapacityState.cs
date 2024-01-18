using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastCapacityState : BaseUnitState
{
    public override void EnterState(UnitStateController stateController)
    {
        // Debug.Log("Cast capacity enter");
        if (stateController.specialCapacitySelected)
        {
            stateController.specialCapacity.castCapacity(stateController.targetUnity);
        }
        else
        {
            // Debug.Log("Attaque basique");
            stateController.transform.LookAt(stateController.targetUnity.position);
            stateController.basicCapacity.castCapacity(stateController.targetUnity);
        }
    }

    public override void ExitState(UnitStateController stateController)
    {
        // Nothing
    }

    public override void UpdateState(UnitStateController stateController)
    {
        if (stateController.targetUnity == null)
        {
            stateController.SwitchState(stateController.idleState);
            return;
        }

        if (stateController.specialCapacitySelected)
        {
            stateController.SwitchState(stateController.idleState);
        }

        if (Vector3.Distance(stateController.transform.position, stateController.targetUnity.position) > stateController.basicRange)
        {
            stateController.SwitchState(stateController.moveToCapacity);
        }

        stateController.transform.LookAt(stateController.targetUnity.position);
        stateController.basicCapacity.castCapacity(stateController.targetUnity);
    }
}
