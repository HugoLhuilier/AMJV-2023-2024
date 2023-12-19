using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    [SerializeField] Moveable moveable;
    [SerializeField] SpecialCapacity specialCapacity;
    [SerializeField] UnitStates states;
}
