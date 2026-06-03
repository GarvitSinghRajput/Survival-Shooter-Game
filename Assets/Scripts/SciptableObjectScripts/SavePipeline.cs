using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystem/SavePipeline")]
public class SavePipeline : ScriptableObject
{
    public List<SaveModule> modules = new List<SaveModule>();

    public void Save(GameData data)
    {
        foreach (var module in modules)
        {
            module.Save(data);
        }
    }

    public void Load(GameData data)
    {
        foreach (var module in modules)
        {
            module.Load(data);
        }
    }
}