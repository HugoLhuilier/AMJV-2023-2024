using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallisticItem))]
public class MeatPiece : MonoBehaviour
{
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private float stopTime = 1;
    [SerializeField] private GameObject bigWorm;
    [SerializeField] private float bigWormCooldown = 5;
    [SerializeField] private float bigWormSpawnDist = 5;

    private bool wormTriggered = false;
    private float elapsedStopTime = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > stopSpeed)
            elapsedStopTime = 0;
        else
            elapsedStopTime += Time.deltaTime;

        if (!wormTriggered && elapsedStopTime > stopTime)
        {
            TriggerWorm();
        }
    }

    public void TriggerWorm()
    {
        wormTriggered = true;
        StartCoroutine(BigWorm.PrepareSpawn(bigWorm, transform, bigWormCooldown, bigWormSpawnDist));
    }

    public static void ThrowMeat(GameObject go, Transform spawnPos, Vector3 targetPos)
    {
        BallisticItem.LaunchItem(go, spawnPos, targetPos);
    }
}
