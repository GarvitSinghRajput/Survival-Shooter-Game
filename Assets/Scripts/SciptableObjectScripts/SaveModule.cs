using UnityEngine;

public abstract class SaveModule : ScriptableObject
{
    public abstract void Save(GameData data);
    public abstract void Load(GameData data);
}