using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyStateController : MonoBehaviour
{
    private BaseEnnemyState currentState;


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
}
