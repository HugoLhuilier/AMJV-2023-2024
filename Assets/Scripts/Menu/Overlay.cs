using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.UI.CanvasScaler;

public class Overlay : MonoBehaviour
{
    [SerializeField] private TMP_Text globalText;
    [SerializeField] private UnitSelection unitSelection;
    [SerializeField] private SelectionConsole selectionConsole;
    void Start()
    {
/*        UnitSelection unitSelection = unitSelector.GetComponent<UnitSelection>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (unitSelection.isSelecting)
        {
            globalText.text = "> Selecting ...";
        }
        else
        {
            globalText.text = $"> Selected Unit : {GlobalVariables.selectedUnits.Count}\n";
            foreach (Unit unit in GlobalVariables.selectedUnits)
            {
                Life life = unit.gameObject.GetComponent<Life>();
                globalText.text += $" * Type   : <#00aaff>{unit.name}</color>\n";
                globalText.text += $"   HP     : <#ff584d>{life.life}</color>\n";
                globalText.text += $"   Shield : <#2fff00>{life.shield}</color>\n";
            }
            globalText.text += "> _";
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            selectionConsole.refresh = true;
        }
    }

}