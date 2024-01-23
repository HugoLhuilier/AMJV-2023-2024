using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrobarakSpecialCapacity : SpecialCapacity
{
    [SerializeField] private float stunTime = 5;
    [SerializeField] private float stunRadius = 5;

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
        Collider[] touched = Physics.OverlapSphere(position.position, stunRadius);

        foreach (Collider collider in touched)
        {
            Unit unit = collider.GetComponent<Unit>();

            if(unit != null && unit.GetComponent<GrobarakSpecialCapacity>() != this)
            {
                unit.stateController.GetStun(stunTime);
            }
        }
    }
}
