using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAbilityFull : Ability
{
    public Player player;
    public override void Trigger()
    {
        if (!isInCooldown)
        {
            FullHeal();
            StartCooldown();
        }
    }
    void FullHeal()
    {
        player.currentHealth = player.maxHealth;
    }
}
