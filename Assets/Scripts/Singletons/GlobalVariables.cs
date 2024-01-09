using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static List<Unit> attackUnits = new List<Unit>();
    public static List<Unit> defenseUnits = new List<Unit>();

    public static HashSet<Unit> selectedUnits = new HashSet<Unit>();

    private void Start()
    {
        debugActions(); // /!\ SEULEMENT POUR LE DEBUG /!\ \\
    }

    public static void addSelectedUnit(Unit unit)
    {
        selectedUnits.Add(unit);

        Debug.Log("nb unite selec : " + selectedUnits.Count);
    }


    public static void resetSelectedUnits()
    {
        selectedUnits = new HashSet<Unit>();
    }


    private void debugActions()
    {
        Unit[] tmp = Resources.FindObjectsOfTypeAll(typeof(Unit)) as Unit[];
        attackUnits = tmp.ToList();
    }
}
