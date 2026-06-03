using System.IO;
using UnityEngine;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string path => Application.persistentDataPath + "/save.json";

    public static void Save()
    {
        var data = new InventorySaveData();

        data.score = ScoreManager.score;
        data.health = PlayerHealth.currentHealth;

        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    public static void Load()
    {
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<InventorySaveData>(json);

        ScoreManager.score = data.score;
        PlayerHealth.currentHealth = data.health;
    }
}

[System.Serializable]
public class InventorySaveData
{
    public int score;
    public int health;
}