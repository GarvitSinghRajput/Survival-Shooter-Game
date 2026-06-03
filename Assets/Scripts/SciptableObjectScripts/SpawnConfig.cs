using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnSystem/SpawnConfig")]
public class SpawnConfig : ScriptableObject
{
    public List<SpawnEntry> spawns = new List<SpawnEntry>();
}

[Serializable]
public class SpawnEntry
{
    public EnemyType type;
    public Vector3 position;
    public float delay;
    public int health;
}