using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpecialCapacity : SpecialCapacity
{
    private Life life;
    [SerializeField] GameObject shield;
    private void Start()
    {
        life = GetComponent<Life>();
    }

    public override void endCapacity()
    {
        // Debug.Log("Plus de bouclier :(");
        life.NotInivincibleAnymore();
        shield.SetActive(false);
    }

    protected override void useCapacity(Transform position)
    {
        // Debug.Log("Bouclier !! :)");
        life.BecomeInvincible();
        shield.SetActive(true);
    }

    public override void RequestPosition()
    {
        // Nothing
    }
}
