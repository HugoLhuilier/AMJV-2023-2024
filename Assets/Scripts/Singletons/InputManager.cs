using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnitSelection unitSelection;

    private Func<Vector3> specialAction = null;
    private Transform specialPos = null;
    private float specialRange = 0f;

    // Update is called once per frame
    void Update()
    {
        SelectionInput();

        RightClickInput();

        SpecialInput();
    }

    private void SpecialInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            specialAction = null;

            foreach(Unit unit in GlobalVariables.selectedUnits)
            {
                unit.specialCapacity.castCapacity(unit.transform);
            }
        }
    }

    void SelectionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            unitSelection.StartSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            specialAction = null;
            unitSelection.StopSelection();
        }
    }

    private void RightClickInput()
    {
        // Debug.Log("Bouton");

        if (Input.GetMouseButtonDown (1))
        {
            if (specialAction != null)  // Execute pending special action if cursor in range
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit) && Vector3.Distance(specialPos.position, hit.point) < specialRange)
                {
                    
                }
            }  
            else if (GlobalVariables.selectedUnits.Count > 0)
            {
                // Debug.Log(">0");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

                if(Physics.Raycast (ray, out hit))
                {
                    // Debug.Log("raycast ok");
                    if (hit.collider.gameObject.GetComponent<Unit>() != null)
                    {
                        foreach (Unit unit in GlobalVariables.selectedUnits)
                        {
                            unit.stateController.specialCapacitySelected = false;
                            // unit.stateController.range = unit.gameObject.GetComponent<BasicCapacity>().range;
                            unit.stateController.targetUnity = hit.transform;
                            unit.stateController.SwitchState(unit.stateController.moveToCapacity);
                        }
                    }
                    else
                    {
                        foreach (Unit unit in GlobalVariables.selectedUnits)
                        {
                            unit.stateController.targetPos = hit.point;
                            unit.stateController.SwitchState(unit.stateController.movePositionState);
                        }
                    }
                }

                GlobalVariables.ResetSelectedUnits();
            }
        } 
    }

    public void StartActionPosition(Func<Vector3> action, Transform center = null, float range = Mathf.Infinity)
    {
        specialAction = action;

        specialPos = center;
        specialRange = range;
    }
}
