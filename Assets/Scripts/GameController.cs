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
        Player = FindFirstObjectByType<PlayerController>().GetComponent<Health>();
        Player.OnHit += UpdatePlayerHealth;
        Player.OnDeath += LoseGame;

        EnemyController[] enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None);
        EnemyCount = enemies.Length + 1; //UpdateEnemyCount call will subtract it to correct number
        foreach (EnemyController enemy in enemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.OnDeath += UpdateEnemyCount;
        }

        UpdatePlayerHealth();
        UpdateEnemyCount();
    }
    
    //internal logic
    private void LoseGame()
    {
        Hud.Instance.ShowEndgameScreen("You lose!");
        Invoke(nameof(Restart), 3f);
    }

    private void WinGame()
    {
        Hud.Instance.ShowEndgameScreen("You win!");
        Invoke(nameof(Restart), 3f);
    }

    private void UpdatePlayerHealth()
    {
        Hud.Instance.SetPlayerHealth(Player.CurrentHealth);
    }
    private void UpdateEnemyCount()
    {
        EnemyCount--;
        Hud.Instance.SetEnemyCount(EnemyCount);

        if(EnemyCount == 0)
        {
            WinGame();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
