using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystem/Modules/Player")]
public class PlayerSaveModule : SaveModule
{

    public override void Save(GameData data)
    {
        data.player.health = PlayerHealth.currentHealth;
        data.player.score = ScoreManager.score;
        data.player.position = PlayerMovement.playerPosition; // Save player position from PlayerMovement
    }

    public override void Load(GameData data)
    {
        PlayerHealth.currentHealth = data.player.health;
        ScoreManager.score = data.player.score;
        PlayerMovement.playerPosition = data.player.position;
    }
}