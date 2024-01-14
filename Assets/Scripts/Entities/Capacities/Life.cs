using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Life : MonoBehaviour
{
    /* Impl�mente le syst�me de points de vie � l'objet. Il dispose ainsi d'un nombre de points de vies, nombre de points de vie maximum, un �ventuel shield d�duisant
     * le nombre de d�g�ts re�us (tout en re�evant toujours au moins 1 point de d�g�ts), et il peut recevoir des d�g�ts ou du heal. */

    [SerializeField] private int maxLife;
    [SerializeField] private int shield;

    private int life;

    private void Start()
    {
        life = maxLife;
    }

    public void getDamages(int damage)
    {
        if (damage <= shield)
        {
            life--;
        }

        else
        {
            life = life - damage + shield;
        }


        Debug.Log("AIIIEUUUUH IL ME RESTE " + life + " PONTS DE VIE");

        if (life <= 0)
        {
            die();
        }
    }

    public void getHeal(int heal)
    {
        life = Mathf.Min(life + heal, maxLife);
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
