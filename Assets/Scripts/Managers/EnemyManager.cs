using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> activeEnemies = new List<Enemy>();
    public EnemyFactory factory;
    public SpawnConfig defaultSpawnConfig;

    public void StartSpawning()
    {
        Spawner();
    }

    private void Spawner()
    {
        // Initialize with some default enemies or configurations
        InitializeFromConfig(defaultSpawnConfig);
    }

    public void InitializeFromConfig(SpawnConfig config)
    {
        foreach (var spawn in config.spawns)
        {
            SpawnEnemyWithDelay(
                spawn.type,
                spawn.position,
                spawn.health,
                spawn.delay
            );
        }
    }

    public void SpawnEnemy(EnemyType type, Vector3 pos, int health)
    {
        Enemy e = factory.Spawn(type, pos);
        e.Health = health;
        e.NextSpawnTime = Time.time;

        activeEnemies.Add(e);
    }

    public void SpawnEnemyWithDelay(EnemyType type, Vector3 pos, int health, float delay)
    {
        StartCoroutine(SpawnCoroutine(type, pos, health, delay));
    }

    private IEnumerator SpawnCoroutine(EnemyType type, Vector3 pos, int health, float delay)
    {
        while(true)
        {
            SpawnEnemy(type, pos, health);
            yield return new WaitForSeconds(delay);
        }
    }

    public void Clear()
    {
        foreach (var e in activeEnemies)
            Destroy(e.gameObject);

        activeEnemies.Clear();
    }
}