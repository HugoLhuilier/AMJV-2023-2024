using System;
using TMPro;
using TMPro.Examples;
using UnityEngine;

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
                if (unit.isDisplayableInOverlay)
                {
                    Life life = unit.gameObject.GetComponent<Life>();
                    SpecialCapacity specialCapacity = unit.gameObject.GetComponent<SpecialCapacity>();
                    string specialCapacityString = "Ready";
                    if (specialCapacity.beingUsed)
                    {
                        specialCapacityString = $"using";
                    }
                    else if (!specialCapacity.isReady)
                    {
                        specialCapacityString = $"{Convert.ToInt32(specialCapacity.cooldownState)} s";
                    }
                    globalText.text += $"\n * Type    : <#00aaff>{unit.name}</color>\n";
                    globalText.text += $"   HP      : <#ff584d>{life.life}</color>\n";
                    globalText.text += $"   Shield  : <#2fff00>{life.shield}</color>\n";
                    globalText.text += $"   Special : <#2fff00>{specialCapacityString}</color>\n";
                } else
                {
                    globalText.text += $" * Type    : <#00aaff>{unit.name}</color>\n";
                }
            }
            globalText.text += "> _";
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            selectionConsole.refresh = true;
        }
    }

}
