using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeetleSpecialCapacity : SpecialCapacity
{
    private NavMeshAgent agent;
    private Moveable move;

    [SerializeField] private float boostSpeed = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        move = GetComponent<Moveable>();
    }

    public override void endCapacity()
    {
        agent.speed = move.speed;
    }

    protected override void useCapacity(Transform position)
    {
        agent.speed = boostSpeed;
    }

    public override void RequestPosition()
    {
        // Nothing
    }
}
