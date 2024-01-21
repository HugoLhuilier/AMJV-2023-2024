using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TireurSpecialCapacity : SpecialCapacity
{
    [SerializeField] private float arcAngle = 45;
    [SerializeField] private float numBullets = 10;
    [SerializeField] private int bulletDamages;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;

    private Team team;
    private Quaternion initRotation;

    private void Start()
    {
        team = GetComponent<Team>();

        initRotation = transform.rotation;
    }

    public override void endCapacity()
    {
        transform.rotation = initRotation;
    }

    protected override void useCapacity(Transform position)
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        float waitTime = (capacityDuration / numBullets) - Time.deltaTime;
        float rotationAngle = 2 * arcAngle / (numBullets - 1);

        transform.Rotate(0,-arcAngle, 0);

        for (int i = 0; i < numBullets; i++)
        {
            // Debug.Log(transform.rotation);

            Bullet.InstantiateBullet(bullet, shootPoint, team, bulletDamages);
            yield return new WaitForSeconds(waitTime);
            transform.Rotate(0, rotationAngle, 0);
        }
    }

    public override void RequestPosition()
    {
        // Nothing
    }
}
