using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{
    public float speed;
    [SerializeField] private float jumpDist;
    public NavMeshAgent agent { get; private set; }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;
    }
}
