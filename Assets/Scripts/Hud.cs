using UnityEngine;
using UnityEngine.UIElements;

public class Hud : MonoBehaviour
{
    //ui elements
    private Label txtPlayerHealth;
    private Label txtEnemyCount;
    private Label txtEndScreen;

    //instance
    public static Hud Instance { get; private set; }

    //lifecycle methods
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        UIDocument uIDocument = GetComponent<UIDocument>();
        txtPlayerHealth = uIDocument.rootVisualElement.Q<Label>("PlayerHealthValue");
        txtEnemyCount = uIDocument.rootVisualElement.Q<Label>("EnemyCountValue");
        txtEndScreen = uIDocument.rootVisualElement.Q<Label>("EndScreenText");
    }

    //API
    public void SetPlayerHealth(int health)
    {
        txtPlayerHealth.text = health.ToString();
    }

    public void SetEnemyCount(int count)
    {
        txtEnemyCount.text = count.ToString();
    }

    public void ShowEndgameScreen(string gameResult)
    {
        txtEndScreen.text = gameResult;
    }
}
