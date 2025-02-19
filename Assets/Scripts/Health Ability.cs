using UnityEngine;

public class HealAbility : Ability
{
    public int healAmount;

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
        Debug.Log("Healing for " + healAmount + " HP");
    }
}