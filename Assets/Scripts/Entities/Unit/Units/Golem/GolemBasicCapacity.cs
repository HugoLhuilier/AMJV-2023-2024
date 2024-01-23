using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBasicCapacity : BasicCapacity
{
    [SerializeField] private GameObject throwingRock;
    [SerializeField] private Transform shootPoint;

    private Team team;

    private void Awake()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Vector3 position)
    {
        ThrowingRock.InstantiateThrowingRock(throwingRock, shootPoint, position, team);
    }
}
