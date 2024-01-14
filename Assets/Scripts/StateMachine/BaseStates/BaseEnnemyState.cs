using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseEnnemyState
{
    abstract public void EnterState(EnnemyStateController stateController);

    abstract public void ExitState(EnnemyStateController stateController);

    abstract public void UpdateState(EnnemyStateController stateController);
}
