using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateController : MonoBehaviour
{
    private BaseState currentState;

    public IdleState idleState = new IdleState();
    public MoveUnityState moveUnityState = new MoveUnityState();
    public MovePositionState movePositionState = new MovePositionState();

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

    public void SwitchState(BaseState state)
    {
        // Debug.Log("Switch State");
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
