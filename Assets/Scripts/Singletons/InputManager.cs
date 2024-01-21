using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private UnitSelection unitSelection;
    [SerializeField] private GameObject selectionSphere;

    private GameObject activeSelectionSphere;
    private SpecialCapacity pendingSpecialCapacity = null;
    private Transform specialPos = null;
    private float specialRange = 0f;

    private void Start()
    {
        Instance = this;
    }

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
            AbortActionPosition();

            foreach(Unit unit in GlobalVariables.selectedUnits)
            {
                unit.specialCapacity.RequestCast(unit.transform);
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
            AbortActionPosition();

            unitSelection.StopSelection();
        }
    }

    private void RightClickInput()
    {
        // Debug.Log("Bouton");

        if (Input.GetMouseButtonDown (1))
        {
            if (pendingSpecialCapacity != null)  // Execute pending special action if cursor in range
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && Vector3.Distance(specialPos.position, hit.point) < specialRange)
                {
                    ExecuteActionPosition(hit.point);
                }
                else
                    AbortActionPosition();
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

    public void StartActionPosition(SpecialCapacity cap, Transform center = null, float range = Mathf.Infinity)
    {
        pendingSpecialCapacity = cap;

        specialPos = center;
        specialRange = range;

        if (center != null)
        {
            activeSelectionSphere = Instantiate(selectionSphere, center);
            activeSelectionSphere.transform.localScale = 2 * range * Vector3.one;
        }
    }

    public void StopActionPosition()
    {
        pendingSpecialCapacity = null;

        Destroy(activeSelectionSphere);
    }

    public void ExecuteActionPosition(Vector3 pos)
    {
        GameObject go = new GameObject();

        go.transform.position = pos;

        pendingSpecialCapacity.Cast(go.transform);
        StopActionPosition();
    }

    public void AbortActionPosition()
    {
        if (pendingSpecialCapacity != null)
        {
            pendingSpecialCapacity.ResetCooldown();
            StopActionPosition();
        }
    }
}
