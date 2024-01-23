using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicCapacity : MonoBehaviour
{
    [SerializeField] protected float cooldownTime;
    public bool forAllies = false;
    public float range;

    private float cooldownState = 0;
    public bool isReady { get; private set; }

    private void Start()
    {
        isReady = true;
    }

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

            useCapacity(position.position);
        }
    }

    abstract public void useCapacity(Vector3 position);
}
