using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnitSelection unitSelection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectionInput();

        RightClickInput();
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
                        foreach(Unit unit in GlobalVariables.selectedUnits)
                        {
                            unit.stateController.targetUnity = hit.transform;
                            unit.stateController.SwitchState(unit.stateController.moveUnityState);
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

                GlobalVariables.resetSelectedUnits();
            }
        } 
    }
}
