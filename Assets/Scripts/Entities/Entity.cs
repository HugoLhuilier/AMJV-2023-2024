using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
[RequireComponent (typeof(Rigidbody))]
public class Entity : MonoBehaviour
{
    public Life lifeComp {  get; private set; }

    public virtual void Start()
    {
        lifeComp = GetComponent<Life>();
    }
}
