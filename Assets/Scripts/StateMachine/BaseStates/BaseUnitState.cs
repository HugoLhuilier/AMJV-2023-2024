using UnityEngine;

public abstract class BaseUnitState
{
    abstract public void EnterState(UnitStateController stateController);

    abstract public void ExitState(UnitStateController stateController);

    abstract public void UpdateState(UnitStateController stateController);
}
