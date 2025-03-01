using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Enemy enemy;

    [Header("Attributes")]
    public float currentHealth;
    public float maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
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
        Debug.Log("Player has died");
        Destroy(gameObject);
    }
}