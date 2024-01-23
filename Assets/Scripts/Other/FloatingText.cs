using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1;

    private float timeLived = 0;

    private void Start()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeLived += Time.deltaTime;

        if(timeLived > lifeTime )
            Destroy(gameObject);
    }
}
