using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateController : MonoBehaviour
{
    private BaseState currentState;

    private IdleState idleState = new IdleState();

    public Vector3 targetPos {  get; set; }
    public Transform targetUnity {  get; set; }
    public NavMeshAgent agent { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        currentState = idleState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
