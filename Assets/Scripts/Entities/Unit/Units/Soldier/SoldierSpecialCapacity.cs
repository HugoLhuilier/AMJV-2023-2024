using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpecialCapacity : SpecialCapacity
{
    private Life life;

    private void Start()
    {
        life = GetComponent<Life>();
    }

    public override void endCapacity()
    {
        Debug.Log("Plus de bouclier :(");
        life.NotInivincibleAnymore();
    }

    public override void useCapacity(Transform position)
    {
        Debug.Log("Bouclier !! :)");
        life.BecomeInvincible();
    }
}
