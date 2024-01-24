using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpecialCapacity : SpecialCapacity
{
    [SerializeField] private float spawnDist = 2;
    [SerializeField] private GameObject miniGolem;
    [SerializeField] private int nbMiniGolems = 5;

    private UnitStateController controller;
    private float angleDelta;
    private Team team;

    private void Start()
    {
        controller = GetComponent<UnitStateController>();
        team = GetComponent<Team>();

        angleDelta = 360 / nbMiniGolems;
    }

    public override void endCapacity()
    {
        // Nothing
    }

    public override void RequestPosition()
    {
        // Nothing
    }

    protected override void useCapacity(Transform position)
    {
        Vector3 baseSpawn = spawnDist * transform.forward;

        for (int i = 0; i < nbMiniGolems; i++)
        {
            SpawnMiniGolem(Quaternion.Euler(0, angleDelta * i, 0) * baseSpawn);
        }
    }

    public void SpawnMiniGolem(Vector3 relPos)
    {
        GameObject ins = Instantiate(miniGolem, transform.position + relPos, transform.rotation);
        Unit unit = ins.GetComponentInChildren<Unit>();

        unit.BecomeAttacker(team.isAttacker);

        if (controller.currentState == controller.castCapacityState || controller.currentState == controller.moveToCapacity)
        {
            UnitStateController insController = ins.GetComponentInChildren<UnitStateController>();
            insController.SwitchMoveCapacity(controller.targetUnity);
        }

        if (controller.currentState == controller.movePositionState)
        {
            UnitStateController insController = ins.GetComponentInChildren<UnitStateController>();
            insController.SwitchMovePosition(controller.targetPos);
        }
    }
}
