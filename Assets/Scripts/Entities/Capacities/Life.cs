using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    /* Implémente le système de points de vie à l'objet. Il dispose ainsi d'un nombre de points de vies, nombre de points de vie maximum, un éventuel shield déduisant
     * le nombre de dégâts reçus (tout en reçevant toujours au moins 1 point de dégâts), et il peut recevoir des dégâts ou du heal. */

    private GameObject floatingText;

    public int maxLife;
    public int shield;

    private bool invincible = false;
    public int life { get; private set; }

    private float acidCooldown = 0;

    private void Start()
    {
        life = maxLife;
        floatingText = GlobalVariables.Instance.floatingText;
    }

    public void GetDamages(int damage)
    {
        if (invincible)
            return;

        int damagesTaken = 0;

        if (damage <= shield)
        {
            damagesTaken = 1;
        }

        else
        {
            damagesTaken = damage - shield;
        }

        life -= damagesTaken;

        SpawnFloatingText(damagesTaken, false);

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
        SpawnFloatingText(heal, true);
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

    public void SpawnFloatingText(int dmg, bool heal)
    {
        GameObject go = Instantiate(floatingText, transform.position + 2 * transform.lossyScale.y * Vector3.up, Quaternion.identity);
        TextMeshPro txt = go.GetComponentInChildren<TextMeshPro>();

        txt.text = dmg.ToString();
        if (heal )
        {
            txt.color = Color.green;
        }
        else
        {
            txt.color = Color.red;
        }
    }
}
