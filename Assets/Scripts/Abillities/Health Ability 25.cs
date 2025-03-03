using UnityEngine;

public class HealAbility : Ability
{
    public float healAmount;
    public Player player;

    public override void Trigger()
    {
        if (!isInCooldown)
        {
            Heal();
            StartCooldown();
        }
    }

    private void Heal()
    {
        player.currentHealth += healAmount;
        Debug.Log("Healing for " + healAmount + " HP");
    }
}