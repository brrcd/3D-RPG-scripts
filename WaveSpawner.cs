using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public static WaveSpawner instance;
    public float spawnRate;
    public int enemyCount;

    private float spawnRateCooldown;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawnRate = 5f;
    }

    private void Update()
    {
        spawnRateCooldown -= Time.deltaTime;
        if (enemyCount < 5 && spawnRateCooldown <= 0f)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        spawnRateCooldown = spawnRate;
        enemyCount++;
    }
}
