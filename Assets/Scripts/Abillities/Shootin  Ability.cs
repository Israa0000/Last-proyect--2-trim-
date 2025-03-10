using UnityEngine;

public class ShootingAbility : Ability
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed;

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
        Vector3 cursorPosition = Input.mousePosition;
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        cursorWorldPosition.z = 0;

        Vector3 shootDirection = (cursorWorldPosition - firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }
    }
}
