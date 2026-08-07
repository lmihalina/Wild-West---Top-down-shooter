using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //properties
    private Health Player;
    private int EnemyCount;

    //lifecycle methods
    void Start()
    {
        InitializePlayer();
        InitializeEnemies();
        InitializeWhiskeys();

        UpdatePlayerHealth();
        EnemyCount++; //updating enemycount always decrements, this is workaround 
        UpdateEnemyCount();
        Hud.Instance.AssignButtonClickHandlers(
            onRetryClick : () => SceneManager.LoadScene(1), 
            onExitToMenuClick : () => SceneManager.LoadScene(0)
        ); 
    }
    
    //internal logic
    private void UpdatePlayerHealth()
    {
        Hud.Instance.SetPlayerHealth(Player.CurrentHealth);

        if( Player.CurrentHealth == 0)
        {
            Hud.Instance.ShowEndgameScreen("YOU LOSE!");
        }
    }
    private void UpdateEnemyCount()
    {
        EnemyCount--;
        Hud.Instance.SetEnemyCount(EnemyCount);

        if(EnemyCount == 0)
        {
            Hud.Instance.ShowEndgameScreen("YOU WIN!");
        }
    }
    
    private void InitializePlayer()
    {
        Player = FindFirstObjectByType<PlayerController>().GetComponent<Health>();

        //difficulty settings
        Player.MaxHealth = Difficulty.PlayerMaxHealth;

        //event handlers
        Player.OnHit += UpdatePlayerHealth;
        Player.OnHeal += UpdatePlayerHealth;
        Player.OnDeath += UpdatePlayerHealth;
    }
    private void InitializeEnemies()
    {
        EnemyController[] enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None);
        Shuffle(enemies);
        int offset = Random.Range(-1, 1 + 1);
        EnemyCount = Difficulty.EnemyCount + offset;

        for(int i = 0; i < EnemyCount && i < enemies.Length; i++)
        {
            Vector2[] enemyDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
            Health enemyHealth = enemies[i].GetComponent<Health>();
            Gun enemyGun = enemies[i].GetComponent<Gun>();

            enemyHealth.MaxHealth = Difficulty.EnemyMaxHealth;
            enemyHealth.OnDeath += UpdateEnemyCount;
            enemies[i].Direction = enemyDirections[Random.Range(0, enemyDirections.Length)];
            enemies[i].Velocity = Difficulty.EnemyVelocity;
            enemyGun.ShootingCooldown = Difficulty.EnemyShootingCooldown;
            enemies[i].DetectionRange = Difficulty.EnemyDetectionRange + offset;
        }
        
        for(int i = EnemyCount; i < enemies.Length; i++)
        {
            enemies[i].gameObject.SetActive(false);
        }

        if (EnemyCount > enemies.Length) //failsafe, on properly designed scenes wont happen
            EnemyCount = enemies.Length;
    }
    private void InitializeWhiskeys()
    {
        Whiskey[] whiskeys = FindObjectsByType<Whiskey>(FindObjectsSortMode.None);
        Shuffle(whiskeys);
        int offset = Random.Range(-1, 1 + 1);
        int whiskeyCount = Difficulty.WhiskeyCount + offset;

        for(int i = whiskeyCount; i < whiskeys.Length; i++)
        {
            whiskeys[i].gameObject.SetActive(false);
        }
    }

    //helpers
    private void Shuffle(MonoBehaviour[] array) // Fisher-Yates
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            MonoBehaviour temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
