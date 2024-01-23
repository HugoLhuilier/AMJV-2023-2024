using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpecialCapacity : MonoBehaviour
{
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float capacityDuration = 0;
    [SerializeField] protected bool needPosition = false;

    public bool beingUsed { get; private set;  }
    private float useDuration = 0;
    public float cooldownState { get; private set; }
    public bool isReady { get; private set; }

    private void Start()
    {
        beingUsed = false;
        isReady = true;
        cooldownState = 0;
    }

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

    public void RequestCast(Transform position)
    {
        if(isReady)
        {
            if (needPosition)
                RequestPosition();
            else
                Cast(position);
        }
    }

    public void Cast(Transform position)
    {
        // Debug.Log("Distance : " + Vector3.Distance(position.position, transform.position));

        isReady = false;
        beingUsed = true;

        useDuration = capacityDuration;

        useCapacity(position);
    }

    public void capacityStops()
    {
        beingUsed = false;
        cooldownState = cooldownTime;

        endCapacity();
    }

    public void ResetCooldown()
    {
        isReady = true;
        cooldownState = 0;
    }

    abstract protected void useCapacity(Transform position);

    abstract public void endCapacity();

    abstract public void RequestPosition();
}
