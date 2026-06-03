using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SavePipeline pipeline;
    public EnemyManager enemyManager;
    public SpawnConfig defaultSpawnConfig;
    public GameObject LoadUI;
    public PauseManager pauseManager;
    public GameObject player;

    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/save.json";
        bool canLoad = PlayerPrefs.GetInt("LoadOnStart", 0) == 1;
        if (canLoad)
        {
            pauseManager.Pause();
            LoadUI.SetActive(true);
        }
        else
        {
            player.SetActive(true);
            enemyManager.StartSpawning();
        }
    }

    public void Save()
    {
        GameData data = new GameData();

        pipeline.Save(data);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);

        PlayerPrefs.SetInt("LoadOnStart", 1); // Set flag to allow loading on next start
        Debug.Log("Saved!");
    }


    public void Load()
    {
        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);

        pipeline.Load(data);
    }
}