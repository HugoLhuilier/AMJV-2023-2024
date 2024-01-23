using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Drapeau touché");
        Unit unit = other.GetComponent<Unit>();

        if (unit != null && unit.team.isAttacker)
        {
            TakeFlag(unit);
        }
    }

    public void TakeFlag(Unit unit)
    {
        unit.BecomeKing();

        Destroy(gameObject);
    }
}
