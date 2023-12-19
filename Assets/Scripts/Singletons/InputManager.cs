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
        if (Input.GetMouseButtonDown(0))
        {
            unitSelection.StartSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            unitSelection.StopSelection();
        }
    }
}
