using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TireurSpecialCapacity : SpecialCapacity
{
    [SerializeField] private float arcAngle = 45;
    [SerializeField] private float numBullets = 10;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;

    private Quaternion initRotation;

    private void Start()
    {
        initRotation = transform.rotation;
    }

    public override void endCapacity()
    {
        transform.rotation = initRotation;
    }

    public override void useCapacity(Transform position)
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
            Debug.Log(transform.rotation);

            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            yield return new WaitForSeconds(waitTime);
            transform.Rotate(0, rotationAngle, 0);
        }
    }
}
