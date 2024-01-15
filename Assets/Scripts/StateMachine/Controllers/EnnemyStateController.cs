using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyStateController : MonoBehaviour
{
    private BaseEnnemyState currentState;

    public PatrolState patrolState = new PatrolState();

    public UnitStateController unitController {  get; private set; }
    public Transform[] patrolPositions = new Transform[2];
    public float waitPositionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        unitController = GetComponent<UnitStateController>();

        currentState = patrolState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseEnnemyState state)
    {
        // Debug.Log("Switch State");
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
