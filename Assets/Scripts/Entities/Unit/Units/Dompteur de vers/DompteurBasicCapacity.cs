using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DompteurBasicCapacity : BasicCapacity
{
    [SerializeField] private GameObject meatPiece;
    [SerializeField] private Transform throwPos;

    public override void useCapacity(Transform position)
    {
        MeatPiece.ThrowMeat(meatPiece, throwPos, position.position);
    }
}
