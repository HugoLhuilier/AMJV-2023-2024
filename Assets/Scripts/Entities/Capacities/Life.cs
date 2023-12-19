using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Life : MonoBehaviour
{
    /* Implémente le système de points de vie à l'objet. Il dispose ainsi d'un nombre de points de vies, nombre de points de vie maximum, un éventuel shield déduisant
     * le nombre de dégâts reçus (tout en reçevant toujours au moins 1 point de dégâts), et il peut recevoir des dégâts ou du heal. */

    [SerializeField] private int maxLife;
    [SerializeField] private int shield;

    private int life;

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

        life = Mathf.Max(life, 0);
    }

    public void getHeal(int heal)
    {
        life = Mathf.Min(life + heal, maxLife);
    }
}
