using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(BallisticItem))]
[RequireComponent (typeof(Rigidbody))]
public class ExplosiveBullet : MonoBehaviour
{
    [SerializeField] private float explosionRange;
    [SerializeField] private int explosionDamages;
    [SerializeField] private float explosionForce;

    public Team team {  get; private set; }


    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    public void Explode()
    {
        Collider[] touched = Physics.OverlapSphere(transform.position, explosionRange);

        foreach (Collider collider in touched)
        {
            if (collider.GetComponent<Entity>() != null)
            {
                Team colTeam = collider.GetComponent<Team>();
                if (colTeam != null && team.isSameTeam(colTeam))
                {
                    continue;
                }

                collider.GetComponent<Life>().GetDamages(explosionDamages);
                collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
            }
        }

        Destroy(gameObject);
    }

    public static void InstantiateExplosiveBullet(GameObject go, Transform spawnPos, Vector3 targetPos, Team team)
    {
        BallisticItem bal = BallisticItem.LaunchItem(go, spawnPos, targetPos);
        bal.gameObject.GetComponent<ExplosiveBullet>().team = team;
    }
}
