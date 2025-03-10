using UnityEngine;

public class BigProjectile : MonoBehaviour
{
    [Header("Attributes")]
    public float damage = 100;
    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.currentHealth -= damage;
                if (enemy.currentHealth <= 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}
