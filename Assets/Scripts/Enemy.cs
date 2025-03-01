using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    Transform playerPosition;
    public float damage = 20;
    Player player; 

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerPosition = player.transform;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 directionToPlayer = playerPosition.position - transform.position;
        directionToPlayer.Normalize();

        transform.position += directionToPlayer * enemySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
