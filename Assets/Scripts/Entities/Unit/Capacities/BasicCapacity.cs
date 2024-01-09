using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicCapacity : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] public float range;

    private float cooldownState = 0;
    private bool isReady = true;

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            cooldownState -= Time.deltaTime;

            if (cooldownState <= 0)
            {
                isReady = true;
            }
        }
    }

    public void castCapacity(Transform position)
    {
        if (isReady)
        {
            isReady = false;
            cooldownState = cooldownTime;

            useCapacity(position);
        }
    }

    abstract public void useCapacity(Transform position);
}
