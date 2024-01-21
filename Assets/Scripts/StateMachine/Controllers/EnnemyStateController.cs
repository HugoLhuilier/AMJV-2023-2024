using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// public enum DefaultState { PatrolState, IdleState}

public class EnnemyStateController : MonoBehaviour
{
    private BaseEnnemyState currentState;

    public PatrolState patrolState = new PatrolState();
    public IdleEnnemyState idleEnnemyState = new IdleEnnemyState();
    public TargetUnityState targetUnityState = new TargetUnityState();

    // public DefaultState defaultStateSelection;
    public BaseEnnemyState defaultState { get; private set; }
    public UnitStateController unitController {  get; private set; }
    public Transform[] patrolPositions = new Transform[2];
    public float waitPositionTime = 1f;
    public float visionRange = 0;
    public int framesTargetCheck = 10;
    public Transform targetUnity { get; private set; }

    private Team teamComp;


    private void Awake()
    {
        unitController = GetComponent<UnitStateController>();
        teamComp = GetComponent<Team>();

        defaultState = patrolState;

        currentState = defaultState;
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

    public void SwitchState(BaseEnnemyState state)
    {
        // Debug.Log("Switch State");
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }


    public void CheckTarget()
    {
        // Debug.Log("Checking targets");
        Collider[] hit = Physics.OverlapSphere(transform.position, visionRange, GlobalVariables.unitMask);
        Transform tmpTargetUnity = null;

        foreach (Collider c in hit)
        {
            if (! c.gameObject.GetComponent<Team>().isSameTeam(teamComp))
            {
                if (tmpTargetUnity == null || Vector3.Distance(transform.position, c.transform.position) < Vector3.Distance(transform.position, tmpTargetUnity.position))
                {
                    tmpTargetUnity = c.transform;
                }
            }
        }

        if (tmpTargetUnity != null)
        {
            SetTargetUnityEnnemy(tmpTargetUnity);
            SwitchState(targetUnityState);
        }
    }


    public void SetTargetUnityEnnemy(Transform targetTr)
    {
        targetUnity = targetTr;
    }
}
