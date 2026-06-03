using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystem/Modules/Enemies")]
public class EnemySaveModule : SaveModule
{
    private EnemyManager enemyManager;

    public override void Save(GameData data)
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        data.enemies.Clear();

        foreach (var enemy in enemyManager.activeEnemies)
        {
            float remainingTime = Mathf.Max(0, enemy.NextSpawnTime - Time.time);

            if (enemy == null) continue; // Skip if enemy was destroyed during save process

            data.enemies.Add(new EnemyData
            {
                type = enemy.GetType(),
                position = enemy.transform.position,
                health = enemy.Health,
                spawnTime = remainingTime
            });
        }
    }

    public override void Load(GameData data)
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.Clear();

        foreach (var e in data.enemies)
        {
            enemyManager.SpawnEnemy(
                e.type,
                e.position,
                e.health
            );

        }

        enemyManager.StartSpawning(); // Ensure spawning continues after loading
    }
}