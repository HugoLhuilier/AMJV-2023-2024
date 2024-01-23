using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicSpecialCapacity : SpecialCapacity
{
    [SerializeField] private int heal = 20;
    [SerializeField] private float healRadius = 10;

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
        // Nothing
    }

    protected override void useCapacity(Transform position)
    {
        Collider[] touched = Physics.OverlapSphere(position.position, healRadius);

        foreach (Collider collider in touched)
        {
            Unit unit = collider.GetComponent<Unit>();

            if (unit != null && team.isSameTeam(unit.team)) 
            {
                unit.lifeComp.GetHeal(heal);
            }
        }
    }
}
