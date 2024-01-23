using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DompteurSpecialCapacity : SpecialCapacity
{
    [SerializeField] private float throwAngle = 30;
    [SerializeField] private float range = 20;
    [SerializeField] private GameObject meatPiece;
    [SerializeField] private Transform throwPos;
    [SerializeField] private Transform throwPos2;
    [SerializeField] private Transform throwPos3;

    public override void endCapacity()
    {
        // Nothing
    }

    public override void RequestPosition()
    {
        InputManager.Instance.StartActionPosition(this, transform, range);
    }

    protected override void useCapacity(Transform position)
    {
        transform.LookAt(position);

        Vector3 locPos = transform.InverseTransformPoint(position.position);

        MeatPiece.ThrowMeat(meatPiece, throwPos, position.position);
        MeatPiece.ThrowMeat(meatPiece, throwPos2, transform.TransformPoint(Quaternion.Euler(0, -throwAngle, 0) * locPos));
        MeatPiece.ThrowMeat(meatPiece, throwPos3, transform.TransformPoint(Quaternion.Euler(0, throwAngle, 0) * locPos));
    }
}
