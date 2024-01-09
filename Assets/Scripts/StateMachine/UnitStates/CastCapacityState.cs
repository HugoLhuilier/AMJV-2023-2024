using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastCapacityState : BaseState
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
            stateController.basicCapacity.castCapacity(stateController.targetUnity);
        }
    }

    public override void ExitState(UnitStateController stateController)
    {
        // Nothing
    }

    public override void UpdateState(UnitStateController stateController)
    {
        if (stateController.specialCapacitySelected)
        {
            stateController.SwitchState(stateController.idleState);
        }

        if (Vector3.Distance(stateController.transform.position, stateController.targetUnity.position) > stateController.range)
        {
            stateController.SwitchState(stateController.moveToCapacity);
        }

        stateController.basicCapacity.castCapacity(stateController.targetUnity);
    }
}
