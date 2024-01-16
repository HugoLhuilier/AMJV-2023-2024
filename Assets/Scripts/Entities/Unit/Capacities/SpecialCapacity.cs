using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpecialCapacity : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] private float capacityDuration = 0;

    private bool beingUsed = false;
    private float useDuration = 0;
    private float cooldownState = 0;
    private bool isReady = true;

    private void Update()
    {
        if (!isReady && !beingUsed)
        {
            cooldownState -= Time.deltaTime;

            if (cooldownState <= 0)
            {
                isReady = true;
            }
        }

        if(beingUsed)
        {
            useDuration -= Time.deltaTime;

            if(useDuration <= 0)
            {
                capacityStops();
            }
        }
    }

    public void castCapacity(Transform position)
    {
        if(isReady)
        {
            isReady = false;
            beingUsed = true;

            useDuration = capacityDuration;

            useCapacity(position);
        }
    }

    public void capacityStops()
    {
        beingUsed = false;
        cooldownState = cooldownTime;

        endCapacity();
    }

    abstract public void useCapacity(Transform position);

    abstract public void endCapacity();
}
