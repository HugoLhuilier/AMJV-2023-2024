using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public RectTransform unitSelectionBox;
    private LayerMask unitMask;
    public bool isSelecting {  get; private set; }

    private List<Unit> unitList;
    private Vector2 startPos;

    private Camera cam;



    private void Start()
    {
        cam = Camera.main;
        unitMask = GlobalVariables.unitMask;
    }

    private void Update()
    {
        if (isSelecting)
        {
            UpdateSelectionBox();
        }
    }

    public void StartSelection()
    {
        isSelecting = true;
        startPos = Input.mousePosition;

        unitSelectionBox.gameObject.SetActive(true);
    }

    public void UpdateSelectionBox()
    {
        Vector2 mousePos = Input.mousePosition;

        float width = mousePos.x - startPos.x;
        float height = mousePos.y - startPos.y;

        unitSelectionBox.sizeDelta = new Vector2 (Mathf.Abs(width), Mathf.Abs(height));
        unitSelectionBox.anchoredPosition = startPos + new Vector2 (width/2, height/2);
    }

    public void StopSelection()
    {
        isSelecting = false;
        unitSelectionBox.gameObject.SetActive(false);

        Vector2 minPos = unitSelectionBox.anchoredPosition - unitSelectionBox.sizeDelta/2;
        Vector2 maxPos = unitSelectionBox.anchoredPosition + unitSelectionBox.sizeDelta/2;

        bool newUnits = false;

        foreach (Unit unit in GlobalVariables.attackUnits)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x > minPos.x && screenPos.x < maxPos.x && screenPos.y > minPos.y && screenPos.y < maxPos.y)
            {
                GlobalVariables.AddSelectedUnit(unit);
                

                newUnits = true;
            }
        }

        if (!newUnits)
        {
            GlobalVariables.ResetSelectedUnits();
        }

    }
}
