using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnitSelection unitSelection;

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
            unitSelection.StopSelection();
        }
    }

    private void RightClickInput()
    {
        if (Input.GetMouseButtonDown (1))
        {
            // Debug.Log("Bouton");
            if (GlobalVariables.selectedUnits.Count > 0)
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
}
