using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static List<Unit> attackUnits = new List<Unit>();
    public static List<Unit> defenseUnits = new List<Unit>();

    public static HashSet<Unit> selectedUnits = new HashSet<Unit>();

    public static LayerMask unitMask;
    public static int groundMask = 6;

    public static float groundHeight;

    [SerializeField] private LayerMask defUnitMask;
    [SerializeField] private float defGroundHeight;

    private void Start()
    {
        unitMask = defUnitMask;
        groundHeight = defGroundHeight;

        // DebugActions(); // /!\ SEULEMENT POUR LE DEBUG /!\ \\
    }

    public static void AddSelectedUnit(Unit unit)
    {
        selectedUnits.Add(unit);
        unit.getSelected();
        // Debug.Log(selectedUnits.Count);
    }


    public static void ResetSelectedUnits()
    {
        foreach (Unit unit in selectedUnits) {
            unit.getUnselected();
        }
        selectedUnits = new HashSet<Unit>();
    }

    public static void DeleteUnit(GameObject unit)
    {
        Unit unitComp = unit.GetComponent<Unit>();

        if (unitComp == null)
            throw new System.Exception("Gameobject does not contain a unit.");

        if (unit.GetComponent<Team>().isAttacker)
        {
            attackUnits.Remove(unitComp);
            selectedUnits.Remove(unitComp);
        }
            
        else
            defenseUnits.Remove(unitComp);

        Destroy(unit);
    }


    private void DebugActions()
    {
        Unit[] tmp = Resources.FindObjectsOfTypeAll(typeof(Unit)) as Unit[];
        attackUnits = tmp.ToList();
        attackUnits.RemoveAll(unit => ! unit.gameObject.GetComponent<Team>().isAttacker);
    }
}
