using UnityEngine;

public abstract class BaseState
{
    abstract public void EnterState();

    abstract public void ExitState();

    abstract public void UpdateState();

    abstract public bool CheckExit();
}
