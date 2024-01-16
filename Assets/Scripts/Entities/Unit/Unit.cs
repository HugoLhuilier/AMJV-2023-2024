using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Moveable))]
[RequireComponent(typeof(UnitStateController))]
[RequireComponent(typeof(Team))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Life))]
public class Unit : Entity
{
    public Moveable moveable {  get; private set; }
    public SpecialCapacity specialCapacity { get; private set; }
    public UnitStateController stateController { get; private set; }
    public Team team { get; private set; }

    private void Start()
    {
        moveable = GetComponent<Moveable>();
        specialCapacity = GetComponent<SpecialCapacity>();
        stateController = GetComponent<UnitStateController>();
        team = GetComponent<Team>();
    }
}
