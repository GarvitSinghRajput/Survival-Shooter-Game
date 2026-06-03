using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject zombunnyPrefab;
    public GameObject zombearPrefab;
    public GameObject hellelephantPrefab;

    public Enemy Spawn(EnemyType type, Vector3 pos)
    {
        GameObject prefab = type switch
        {
            EnemyType.Zombunny => zombunnyPrefab,
            EnemyType.Zombear => zombearPrefab,
            EnemyType.Hellelephant => hellelephantPrefab,
            _ => null
        };

        return Instantiate(prefab, pos, Quaternion.identity).GetComponent<Enemy>();
    }
}