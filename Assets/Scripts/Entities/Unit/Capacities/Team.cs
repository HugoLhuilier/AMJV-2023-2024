using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public bool isAttacker { get;  }

    public bool isSameTeam(Team opp)
    {
        return opp.isAttacker == isAttacker;
    }
}