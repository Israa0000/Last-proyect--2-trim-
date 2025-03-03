using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float enemySpeed = 5;
    public float damage = 20;
    public float currentHealth = 100;
    [SerializeField] Gradient gradient;

    Transform playerPosition;

    void Start()
    {

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform;
        }
    }

    void Update()
    {
        Move();
        EnemyColor();
    }

    void Move()
    {
        Vector3 directionToPlayer = playerPosition.position - transform.position;
        directionToPlayer.Normalize();

        transform.position += directionToPlayer * enemySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void EnemyColor()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = gradient.Evaluate(currentHealth / 100);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}