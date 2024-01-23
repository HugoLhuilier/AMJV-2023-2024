using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCaCCapacity : BasicCapacity
{
    [SerializeField] private float attackRadius = 1;
    [SerializeField] private int damages = 5;
    [SerializeField] private float knockback = 0;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Vector3 position)
    {
        // Debug.Log("Position : " + position);
        Collider[] hits = Physics.OverlapSphere(position, attackRadius, GlobalVariables.unitMask);

        foreach (Collider hit in hits)
        {
            // Debug.Log(hit);
            if (!team.isSameTeam(hit.gameObject.GetComponent<Team>()))
            {
                hit.gameObject.GetComponent<Life>()?.GetDamages(damages);
                // Debug.Log(hit.GetComponent<Rigidbody>());
                hit.GetComponent<Rigidbody>()?.AddForce(knockback * (hit.transform.position - transform.position).normalized, ForceMode.Impulse);
            }
        }
    }
}
