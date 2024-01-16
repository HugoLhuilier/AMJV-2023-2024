using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateController : MonoBehaviour
{
    private BaseUnitState currentState;

    public IdleState idleState = new IdleState();
    public MoveToCapacityState moveToCapacity = new MoveToCapacityState();
    public MovePositionState movePositionState = new MovePositionState();
    public CastCapacityState castCapacityState = new CastCapacityState();

    public Vector3 targetPos {  get; set; }
    public Transform targetUnity {  get; set; }
    public NavMeshAgent agent { get; private set; }
    public float basicRange {  get; set; }
    public bool specialCapacitySelected {  get; set; }

    public int framesPathRecalculation = 10;
    public BasicCapacity basicCapacity { get; private set; }
    public SpecialCapacity specialCapacity { get; private set; }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        basicCapacity = GetComponent<BasicCapacity>();
        specialCapacity = GetComponent<SpecialCapacity>();

        basicRange = basicCapacity.range;

        currentState = idleState;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseUnitState state)
    {
        // Debug.Log(state);
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
