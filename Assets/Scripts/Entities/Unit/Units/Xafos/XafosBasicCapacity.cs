using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XafosBasicCapacity : BasicCapacity
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform throwPoint;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Vector3 position)
    {
        AcidBall.ThrowBall(ball, throwPoint, position, team);
    }
}
