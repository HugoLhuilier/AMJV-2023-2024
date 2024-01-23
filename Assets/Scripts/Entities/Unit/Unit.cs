using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Moveable))]
[RequireComponent(typeof(UnitStateController))]
[RequireComponent(typeof(Team))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : Entity
{
    public Moveable moveable { get; private set; }
    public SpecialCapacity specialCapacity { get; private set; }
    public UnitStateController stateController { get; private set; }
    public Team team { get; private set; }
    [SerializeField] GameObject selectionAura;
    public bool isDisplayableInOverlay;

    public override void Start()
    {
        base.Start();

        moveable = GetComponent<Moveable>();
        specialCapacity = GetComponent<SpecialCapacity>();
        stateController = GetComponent<UnitStateController>();
        team = GetComponent<Team>();

        if (team.isAttacker)
            GlobalVariables.attackUnits.Add(this);
        else
            GlobalVariables.defenseUnits.Add(this);
    }

    private void OnDestroy()
    {
        if (team.isAttacker)
            GlobalVariables.attackUnits.Remove(this);
        else
            GlobalVariables.defenseUnits.Remove(this);
    }

    public void getSelected()
    {
        selectionAura.SetActive(true);
    }

    public void getUnselected()
    {
        selectionAura.SetActive(false);
    }
}