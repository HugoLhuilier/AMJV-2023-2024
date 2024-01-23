using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallisticItem))]
public class AcidBall : MonoBehaviour
{
    [SerializeField] private GameObject flaque;

    private Rigidbody rb;
    public Team team { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == GlobalVariables.groundMask)
        {
            SpawnFlaque();
        }
    }

    public void SpawnFlaque()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y = GlobalVariables.groundHeight + 0.05f;

        Vector3 vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, vel);

        AcidFlaque.SpawnFlaque(flaque, spawnPos, team, rot);

        Destroy(gameObject);
    }

    public static void ThrowBall(GameObject go, Transform spawnPos, Vector3 targetPos, Team team)
    {
        BallisticItem bal = BallisticItem.LaunchItem(go, spawnPos, targetPos);
        bal.GetComponent<AcidBall>().team = team;
    }
}
