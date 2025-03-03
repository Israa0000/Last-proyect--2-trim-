using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Attributes")]
    public float damage = 50;
    private void Update()
    {
    Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

    if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.currentHealth -= damage;
                if (enemy.currentHealth <= 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}