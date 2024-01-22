using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWorm : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float despawnHeight = 10;
    [SerializeField] private int damages = 25;
    [SerializeField] private float knockback = 1000;
    [SerializeField] private float knockBackRadius = 10;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = speed * Vector3.up;
    }

    private void Update()
    {
        if (transform.position.y > despawnHeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeatPiece>())
        {
            Destroy(other.gameObject);
            return;
        }

        Life life = other.GetComponent<Life>();

        if (life != null )
        {
            life.GetDamages(damages);
        }

        if (other.attachedRigidbody != null)
        {
            Vector3 explosionCenter = transform.position;
            explosionCenter.y = other.transform.position.y;

            other.attachedRigidbody.AddExplosionForce(knockback, explosionCenter, knockBackRadius);
        }
    }

    public static IEnumerator PrepareSpawn(GameObject worm, Transform meat, float coolDown = 5, float undergroundDist = 5)
    {
        yield return new WaitForSeconds(coolDown);

        Instantiate(worm, meat.position + undergroundDist * Vector3.down, Quaternion.identity);
    }
}
