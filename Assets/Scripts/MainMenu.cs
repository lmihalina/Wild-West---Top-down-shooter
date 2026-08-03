using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    //audio
    AudioSource audioSource;

    //ui elements
    private VisualElement MainMenuScreen;
    private VisualElement DifficultyScreen;
    private VisualElement MapScreen;

    private Button btnPlay;
    private Button btnExit;

    private Button btnEasy;
    private Button btnMedium;
    private Button btnHard;

    private Button btnWesternTown;
    private Button btnSnowyHideout;

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
        MapScreen.style.display = DisplayStyle.None;
    }

    private void ShowDifficultyScreen()
    {
        MainMenuScreen.style.display = DisplayStyle.None;
        DifficultyScreen.style.display = DisplayStyle.Flex;
        MapScreen.style.display = DisplayStyle.None;
    }

    private void ShowMapScreen()
    {
        MainMenuScreen.style.display = DisplayStyle.None;
        DifficultyScreen.style.display = DisplayStyle.None;
        MapScreen.style.display = DisplayStyle.Flex;
    }

    //helpers
    private void RetrieveElemets()
    {
        UIDocument document = GetComponent<UIDocument>();

        MainMenuScreen = document.rootVisualElement.Q<VisualElement>("MainMenu");
        DifficultyScreen = document.rootVisualElement.Q<VisualElement>("Difficulty");
        MapScreen = document.rootVisualElement.Q<VisualElement>("Map");

        btnPlay = document.rootVisualElement.Q<Button>("PlayButton");
        btnExit = document.rootVisualElement.Q<Button>("ExitButton");

        btnEasy = document.rootVisualElement.Q<Button>("EasyButton");
        btnMedium = document.rootVisualElement.Q<Button>("MediumButton");
        btnHard = document.rootVisualElement.Q<Button>("HardButton");

        btnWesternTown = document.rootVisualElement.Q<Button>("WesternTownButton");
        btnSnowyHideout = document.rootVisualElement.Q<Button>("SnowyHideoutButton");

        //audio
        audioSource = GetComponent<AudioSource>();
    }

    private void AssignEventHandlers()
    {
        btnPlay.clicked += () => { audioSource.Play(); ShowDifficultyScreen(); };
        btnExit.clicked += () => { audioSource.Play(); Application.Quit(); };

        btnEasy.clicked += () => { audioSource.Play(); Difficulty.SetEasyDifficulty(); ShowMapScreen(); };
        btnMedium.clicked += () => { audioSource.Play(); Difficulty.SetMediumDifficulty(); ShowMapScreen(); };
        btnHard.clicked += () => { audioSource.Play(); Difficulty.SetHardDifficulty(); ShowMapScreen(); };

        btnWesternTown.clicked += () => { audioSource.Play(); SceneManager.LoadScene(1); };
        btnSnowyHideout.clicked += () => { audioSource.Play(); SceneManager.LoadScene(1); };
    }
}

