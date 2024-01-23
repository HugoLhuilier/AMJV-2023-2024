using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XafosSpecialCapacity : SpecialCapacity
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float range = 20;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }
    public override void endCapacity()
    {
        // Nothing
    }

    public override void RequestPosition()
    {
        InputManager.Instance.StartActionPosition(this, transform, range);
    }

    protected override void useCapacity(Transform position)
    {
        AcidBall.ThrowBall(ball, throwPoint, position.position, team);
    }
}
