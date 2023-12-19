using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Life lifeComp;

    private void Start()
    {
        lifeComp = GetComponent<Life>();
    }
}
