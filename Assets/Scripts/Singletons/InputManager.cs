using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private UnitSelection unitSelection;
    [SerializeField] private GameObject selectionSphere;
    [SerializeField] private float groundHeight;

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

        MeatThrowInput();
    }

    private void MeatThrowInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AbortActionPosition();

            foreach (Unit unit in GlobalVariables.selectedUnits)
            {
                DompteurBasicCapacity cap = unit.gameObject.GetComponent<DompteurBasicCapacity>();

                if (cap != null)
                {

                }
            }
        }
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

            GlobalVariables.ResetSelectedUnits();
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
                            // Debug.Log(unit.stateController);

                            unit.stateController.specialCapacitySelected = false;
                            // unit.stateController.range = unit.gameObject.GetComponent<BasicCapacity>().range;
                            unit.stateController.SwitchMoveCapacity(hit.transform);
                        }
                    }
                    else
                    {
                        foreach (Unit unit in GlobalVariables.selectedUnits)
                        {
                            // Debug.Log(unit.stateController);
                            unit.stateController.SwitchMovePosition(hit.point);
                        }
                    }
                }
            }
            GlobalVariables.ResetSelectedUnits();
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
            activeSelectionSphere.transform.position = new Vector3(activeSelectionSphere.transform.position.x, groundHeight, activeSelectionSphere.transform.position.z);
            activeSelectionSphere.transform.localScale = 2 * range * new Vector3(1, 0, 1) + 0.1f * Vector3.up;
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
