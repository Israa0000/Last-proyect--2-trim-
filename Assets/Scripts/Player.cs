using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float time;
    public Enemy enemy;
    [SerializeField] Gradient gradient;
    public SpriteRenderer spriteRenderer;

    [Header("Attributes")]
    public float currentHealth;
    public float maxHealth = 100;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        time += Time.deltaTime;
        PassiveHealing();

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        currentColor();
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
        FindAnyObjectByType<GameOver>().TurnPanelOn();
        Destroy(gameObject);
    }

    void PassiveHealing()
    {
        if (time > 1)
        {
            currentHealth += 1;
            time = 0;
        }
    }

    void currentColor()
    {
        spriteRenderer.color = gradient.Evaluate(currentHealth/ 100);
    }
}