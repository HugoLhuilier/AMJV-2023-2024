using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallisticItem))]
public class ThrowingRock : MonoBehaviour
{
    [SerializeField] private float knockback;
    [SerializeField] private int damages;

    public Team team {  get; private set; }


    public static void InstantiateThrowingRock(GameObject go, Transform spawnPos, Vector3 targetPos, Team team)
    {
        BallisticItem bal = BallisticItem.LaunchItem(go, spawnPos, targetPos);
        bal.gameObject.GetComponent<ThrowingRock>().team = team;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Team teamComp = collision.gameObject.GetComponent<Team>();

        if (teamComp != null && team.isSameTeam(teamComp))
            return;

        Life life = collision.gameObject.GetComponent<Life>();

        if (life != null)
            life.GetDamages(damages);

        if (collision.rigidbody != null)
            collision.rigidbody.AddForce(knockback * collision.relativeVelocity, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
