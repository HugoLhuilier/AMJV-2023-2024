    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireurBasicCapacity : BasicCapacity
{
    [SerializeField] private int bulletDamages = 5;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Transform position)
    {
        Bullet.InstantiateBullet(bullet, shootPoint, team, bulletDamages);
    }
}
