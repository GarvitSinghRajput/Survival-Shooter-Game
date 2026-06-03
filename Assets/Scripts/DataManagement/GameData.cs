using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public PlayerData player = new PlayerData();
    public List<EnemyData> enemies = new List<EnemyData>();
}

[Serializable]
public class PlayerData
{
    public int health;
    public int score;
    public Vector3 position;
}

public enum EnemyType
{
    Zombunny,
    Zombear,
    Hellelephant
}

[Serializable]
public class EnemyData
{
    public EnemyType type;
    public Vector3 position;
    public int health;
    public float spawnTime;
}