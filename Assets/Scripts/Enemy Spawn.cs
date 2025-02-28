using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeSpawn;
    public float rangeSpawn;
    public int maxEnemiesOnScreen;

    void Start()
    {
        InvokeRepeating("Spawn", 0, timeSpawn);
    }

    void Spawn()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount >= maxEnemiesOnScreen)
        {
            return;
        }

        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Vector3 spawnPosition = Vector3.zero;
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0: //arriba
                spawnPosition = new Vector3(Random.Range(-camWidth / rangeSpawn, camWidth / rangeSpawn), camHeight / rangeSpawn, 0);
                break;
            case 1: //abajo
                spawnPosition = new Vector3(Random.Range(-camWidth / rangeSpawn, camWidth / rangeSpawn), -camHeight / rangeSpawn, 0);
                break;
            case 2: //izquierda
                spawnPosition = new Vector3(-camWidth / rangeSpawn, Random.Range(-camHeight / rangeSpawn, camHeight / rangeSpawn), 0);
                break;
            case 3: //derecha
                spawnPosition = new Vector3(camWidth / rangeSpawn, Random.Range(-camHeight / rangeSpawn, camHeight / rangeSpawn), 0);
                break;
        }


        spawnPosition += new Vector3(Random.Range(-rangeSpawn, rangeSpawn), Random.Range(-rangeSpawn, rangeSpawn), 0);

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.tag = "Enemy";
    }
}
