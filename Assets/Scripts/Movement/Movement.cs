using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask groundlayer; 
    private Boolean isSelected = false;
    private Camera m_camera;
    void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        // Selection & Deplacement
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (isSelected)
            {
                // Teleported
                transform.position = GetClickedPosition();
                isSelected = false;
            }
        }
    }

    // Selection & Deplacement
    private void OnMouseDown()
    {
        if (!isSelected)
        {
            // Selected
            isSelected = true;
        }
    }

    private Vector3 GetClickedPosition ()
    {
        RaycastHit hit;
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, groundlayer))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
