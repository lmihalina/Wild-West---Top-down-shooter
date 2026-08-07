using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    //audio
    AudioSource audioSource;

    //ui elements
    private VisualElement MainMenuScreen;
    private Button btnPlay;
    private Button btnExit;

    private VisualElement DifficultyScreen;
    private Button btnEasy;
    private Button btnMedium;
    private Button btnHard;

    //lifecycle methods
    private void Start()
    {
       RetrieveElemets();
       AssignEventHandlers();
       ShowHomeScreen();
    }

    //internal logic
    private void ShowHomeScreen()
    {
        MainMenuScreen.style.display = DisplayStyle.Flex;
        DifficultyScreen.style.display = DisplayStyle.None;
    }

    private void ShowDifficultyScreen()
    {
        MainMenuScreen.style.display = DisplayStyle.None;
        DifficultyScreen.style.display = DisplayStyle.Flex;
    }

    //helpers
    private void RetrieveElemets()
    {
        UIDocument document = GetComponent<UIDocument>();
        audioSource = GetComponent<AudioSource>();

        MainMenuScreen = document.rootVisualElement.Q<VisualElement>("MainMenu");
        btnPlay = document.rootVisualElement.Q<Button>("PlayButton");
        btnExit = document.rootVisualElement.Q<Button>("ExitButton");

        DifficultyScreen = document.rootVisualElement.Q<VisualElement>("Difficulty");
        btnEasy = document.rootVisualElement.Q<Button>("EasyButton");
        btnMedium = document.rootVisualElement.Q<Button>("MediumButton");
        btnHard = document.rootVisualElement.Q<Button>("HardButton");
    }

    private void AssignEventHandlers()
    {
        btnPlay.clicked += () => { audioSource.Play(); ShowDifficultyScreen(); };
        btnExit.clicked += () => { audioSource.Play(); Application.Quit(); };

        btnEasy.clicked += () => { audioSource.Play(); Difficulty.SetEasyDifficulty(); SceneManager.LoadScene(1); };
        btnMedium.clicked += () => { audioSource.Play(); Difficulty.SetMediumDifficulty(); SceneManager.LoadScene(1); };
        btnHard.clicked += () => { audioSource.Play(); Difficulty.SetHardDifficulty(); SceneManager.LoadScene(1); };
    }
}

