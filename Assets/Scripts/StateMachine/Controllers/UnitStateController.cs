using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateController : MonoBehaviour
{
    public BaseUnitState currentState {  get; private set; }

    public IdleState idleState = new IdleState();
    public MoveToCapacityState moveToCapacity = new MoveToCapacityState();
    public MovePositionState movePositionState = new MovePositionState();
    public CastCapacityState castCapacityState = new CastCapacityState();
    public StunState stunState = new StunState();
    public Collider selfCollider { get; private set; }

    public Vector3 targetPos {  get; set; }
    public Transform targetUnity {  get; set; }
    public Collider targetUnityCollider { get; set; }
    public NavMeshAgent agent { get; private set; }
    public float basicRange {  get; set; }
    public bool specialCapacitySelected {  get; set; }

    public int framesPathRecalculation = 10;
    public BasicCapacity basicCapacity { get; private set; }
    public SpecialCapacity specialCapacity { get; private set; }

    public BaseUnitState stateBeforeStun = null;
    public float stunTime {  get; private set; }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        basicCapacity = GetComponent<BasicCapacity>();
        specialCapacity = GetComponent<SpecialCapacity>();
        selfCollider = GetComponent<Collider>();

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

    public void SetTargetUnity(Transform unitTr)
    {
        targetUnity = unitTr;
        targetUnityCollider = unitTr.GetComponent<Collider>();
    }

    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }

    public void SwitchMoveCapacity(Transform target)
    {
        SetTargetUnity(target);
        SwitchState(moveToCapacity);
    }

    public void SwitchMovePosition(Vector3 pos)
    {
        SetTargetPos(pos);
        SwitchState(movePositionState);
    }

    public void GetStun(float time)
    {
        stateBeforeStun = currentState;
        stunTime = time;

        SwitchState(stunState);
    }
}
