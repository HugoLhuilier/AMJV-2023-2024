using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFlaque : MonoBehaviour
{
    [SerializeField] private int damagesPerSecond = 2;
    [SerializeField] private float lifeTime = 5;

    private float timeLived = 0;
    public Team team {  get; private set; }

    private void Update()
    {
        timeLived += Time.deltaTime;

        if (timeLived > lifeTime)
            Despawn();
    }

    private void OnTriggerStay(Collider other)
    {
        Unit unit = other.GetComponent<Unit>();

        if(unit != null && ! unit.team.isSameTeam(team))
        {
            unit.lifeComp.StaysInAcid(damagesPerSecond);
        }
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }

    public static void SpawnFlaque(GameObject flaque, Vector3 pos, Team fTeam, Quaternion rot)
    {
        GameObject ins = Instantiate(flaque, pos, rot);

        AcidFlaque insFl = ins.GetComponent<AcidFlaque>();

        insFl.team = fTeam;
    }
}
