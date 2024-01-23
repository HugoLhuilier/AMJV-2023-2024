    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireurBasicCapacity : BasicCapacity
{
    [SerializeField] private int bulletDamages = 5;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip capacityAudioClip;

    private Team team;

    private void Start()
    {
        team = GetComponent<Team>();
    }

    public override void useCapacity(Vector3 position)
    {
        Bullet.InstantiateBullet(bullet, shootPoint, team, bulletDamages);
        AudioManager.Instance.PlaySFX(capacityAudioClip);
    }
}
