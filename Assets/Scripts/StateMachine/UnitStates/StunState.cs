using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : BaseUnitState
{
    private float timeStun = 0;

    public override void EnterState(UnitStateController stateController)
    {
        // Nothing
    }

    public override void ExitState(UnitStateController stateController)
    {
        // Nothing
    }

    public override void UpdateState(UnitStateController stateController)
    {
        timeStun += Time.deltaTime;

        if (timeStun > stateController.stunTime)
        {
            stateController.SwitchState(stateController.stateBeforeStun);
        }
    }
}
