using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [HideInInspector]
    public int Health;
    [HideInInspector]
    public float NextSpawnTime;
    public abstract new EnemyType GetType();
}





