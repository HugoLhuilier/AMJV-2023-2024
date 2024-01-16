using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBasicCapacity : BasicCapacity
{
    [SerializeField] private float attackRadius = 1;
    [SerializeField] private int damages = 5;
    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Transform position)
    {
        // Debug.Log("Position : " + position.position);
        Collider[] hits = Physics.OverlapSphere(position.position, attackRadius, GlobalVariables.unitMask);

        foreach (Collider hit in hits)
        {
            // Debug.Log("Voici le hit : " + hit);
            if (!team.isSameTeam(hit.gameObject.GetComponent<Team>()))
                hit.gameObject.GetComponent<Life>()?.GetDamages(damages);
        }
    }
}
