using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicBasicCapacity : BasicCapacity
{
    [SerializeField] private int heal = 5;
    [SerializeField] private float healRadius = 0.1f;

    public override void useCapacity(Vector3 position)
    {
        Collider[] touched = Physics.OverlapSphere(position, healRadius);

        foreach (Collider col in touched)
        {
            Life life = col.GetComponent<Life>();

            if (life != null)
            {
                life.GetHeal(heal);
                return;
            }
        }
    }
}