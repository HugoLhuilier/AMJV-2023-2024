using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static List<Unit> attackUnits = new List<Unit>();
    public static List<Unit> defenseUnits = new List<Unit>();

    public static HashSet<Unit> selectedUnits = new HashSet<Unit>();

    public static LayerMask unitMask;

    [SerializeField] private LayerMask defUnitMask;

    private void Start()
    {
        unitMask = defUnitMask;

        debugActions(); // /!\ SEULEMENT POUR LE DEBUG /!\ \\
    }

    public static void addSelectedUnit(Unit unit)
    {
        selectedUnits.Add(unit);

        // Debug.Log(selectedUnits.Count);
    }


    public static void resetSelectedUnits()
    {
        selectedUnits = new HashSet<Unit>();
    }


    private void debugActions()
    {
        Unit[] tmp = Resources.FindObjectsOfTypeAll(typeof(Unit)) as Unit[];
        attackUnits = tmp.ToList();
        attackUnits.RemoveAll(unit => ! unit.gameObject.GetComponent<Team>().isAttacker);
    }
}
