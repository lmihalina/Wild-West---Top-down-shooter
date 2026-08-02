using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Hud : MonoBehaviour
{
    //ui elements
    private Label txtPlayerHealth;
    private Label txtEnemyCount;
    private VisualElement EndScreen;
    private Label EndScreenText;
    private Button btnRetry;
    private Button btnExitToMenu;

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
        EndScreen = uIDocument.rootVisualElement.Q<VisualElement>("EndScreen");
        EndScreenText = uIDocument.rootVisualElement.Q<Label>("EndScreenText");
        btnRetry = uIDocument.rootVisualElement.Q<Button>("RetryButton");
        btnExitToMenu = uIDocument.rootVisualElement.Q<Button>("ExitToMenuButton");
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
        EndScreen.style.display = DisplayStyle.Flex;
        EndScreen.style.opacity = 1;
        EndScreenText.text = gameResult;
    }

    public void AssignButtonClickHandlers(Action onRetryClick, Action onExitToMenuClick)
    {
        btnRetry.clicked += onRetryClick;
        btnExitToMenu.clicked += onExitToMenuClick;
    }
}
