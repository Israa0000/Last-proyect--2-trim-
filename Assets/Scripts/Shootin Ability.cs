using UnityEngine;

public class ProjectileAbility : Ability
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public override void Trigger()
    {
        if (!isInCooldown)
        {
            Shoot();
            StartCooldown();
        }
    }

    private void Shoot()
    {

    }
}