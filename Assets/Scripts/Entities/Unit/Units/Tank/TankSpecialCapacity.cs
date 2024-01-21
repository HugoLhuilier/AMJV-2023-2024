using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpecialCapacity : SpecialCapacity
{
    [SerializeField] private GameObject explosiveBullet;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float bulletRange = 50;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void endCapacity()
    {
        // Nothing
    }

    protected override void useCapacity(Transform position)
    {
        ExplosiveBullet.InstantiateExplosiveBullet(explosiveBullet, spawnPos, position.position, team);
    }

    public override void RequestPosition()
    {
        InputManager.Instance.StartActionPosition(this, transform, bulletRange);
    }
}
