using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseEnnemyState
{
    private float waitTime = 0;
    private bool isWaiting;
    private int toPoint;

    public override void EnterState(EnnemyStateController stateController)
    {
        isWaiting = false;
        toPoint = 0;

        if (Vector3.Distance(stateController.transform.position, stateController.patrolPositions[0].position) > Vector3.Distance(stateController.transform.position, stateController.patrolPositions[1].position))
            toPoint = 1;

        MoveToPosition(stateController);

        // Debug.Log("Start patrol");
    }

    public override void ExitState(EnnemyStateController stateController)
    {
        StopMoving(stateController);
    }

    public override void UpdateState(EnnemyStateController stateController)
    {
        waitTime += Time.deltaTime;

        if (!stateController.unitController.agent.hasPath && !isWaiting)
        {
            isWaiting = true;
            waitTime = -stateController.waitPositionTime;

            StopMoving(stateController);
        }

        if (isWaiting && waitTime > 0)
        {
            isWaiting = false;
            toPoint = 1 - toPoint;

            MoveToPosition(stateController);
        }

        if (Time.frameCount % stateController.framesTargetCheck == 0)
        {
            stateController.CheckTarget();
        }
    }


    public void MoveToPosition(EnnemyStateController stateController)
    {
        stateController.unitController.targetPos = stateController.patrolPositions[toPoint].position;

        stateController.unitController.SwitchState(stateController.unitController.movePositionState);
    }


    public void StopMoving(EnnemyStateController stateController)
    {
        stateController.unitController.SwitchState(stateController.unitController.idleState);
    }
}
