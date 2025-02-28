using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage()
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
    }

}
