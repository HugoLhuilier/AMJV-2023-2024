using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpecialCapacity : MonoBehaviour
{
    [SerializeField] private float cooldownTime;

    private float cooldownState = 0;
    private bool isReady = true;

    private void Update()
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
        if(isReady)
        {
            isReady = false;
            cooldownState = cooldownTime;

            useCapacity(position);
        }
    }

    abstract public void useCapacity(Transform position);
}
