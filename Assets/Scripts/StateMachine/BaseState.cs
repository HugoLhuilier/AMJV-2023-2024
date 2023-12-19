using UnityEngine;

public abstract class BaseState
{
    abstract public void EnterState(UnitStateController stateController);

    abstract public void ExitState(UnitStateController stateController);

    abstract public void UpdateState(UnitStateController stateController);
}
