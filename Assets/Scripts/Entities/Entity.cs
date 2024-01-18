using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Life lifeComp {  get; private set; }

    public virtual void Start()
    {
        lifeComp = GetComponent<Life>();
    }
}
