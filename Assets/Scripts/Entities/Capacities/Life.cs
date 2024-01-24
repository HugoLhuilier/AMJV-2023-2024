using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Life : MonoBehaviour
{
    /* Impl�mente le syst�me de points de vie � l'objet. Il dispose ainsi d'un nombre de points de vies, nombre de points de vie maximum, un �ventuel shield d�duisant
     * le nombre de d�g�ts re�us (tout en re�evant toujours au moins 1 point de d�g�ts), et il peut recevoir des d�g�ts ou du heal. */

    public int maxLife;
    public int shield;

    private bool invincible = false;
    public int life { get; private set; }

    private float acidCooldown = 0;

    private void Start()
    {
        life = maxLife;
    }

    public void GetDamages(int damage)
    {
        if (invincible)
            return;

        if (damage <= shield)
        {
            life--;
        }

        else
        {
            life = life - damage + shield;
        }


        // Debug.Log("AIIIEUUUUH IL ME RESTE " + life + " PONTS DE VIE");

        if (life <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        // Debug.Log("Je suis heal <3 <3");
        life = Mathf.Min(life + heal, maxLife);
    }

    public void Die()
    {
        GlobalVariables.DeleteUnit(gameObject);
    }

    public void BecomeInvincible()
    {
        invincible = true;
    }

    public void NotInivincibleAnymore()
    {
        invincible = false;
    }

    public void StaysInAcid(int damages)
    {
        acidCooldown += Time.fixedDeltaTime;

        if (acidCooldown > 1)
        {
            acidCooldown -= 1;
            GetDamages(damages);
        }
    }
}
