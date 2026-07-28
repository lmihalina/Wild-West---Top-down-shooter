using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    //ui elements

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
        btnPlay.style.display = DisplayStyle.Flex;
        btnExit.style.display = DisplayStyle.Flex;

        btnEasy.style.display = DisplayStyle.None;
        btnMedium.style.display = DisplayStyle.None;
        btnHard.style.display = DisplayStyle.None;

        btnWesternTown.style.display = DisplayStyle.None;
        btnSnowyHideout.style.display = DisplayStyle.None;
    }

    private void ShowDifficultyScreen()
    {
        btnPlay.style.display = DisplayStyle.None;
        btnExit.style.display = DisplayStyle.None;

        btnEasy.style.display = DisplayStyle.Flex;
        btnMedium.style.display = DisplayStyle.Flex;
        btnHard.style.display = DisplayStyle.Flex;

        btnWesternTown.style.display = DisplayStyle.None;
        btnSnowyHideout.style.display = DisplayStyle.None;
    }

    private void ShowMapScreen()
    {
        btnPlay.style.display = DisplayStyle.None;
        btnExit.style.display = DisplayStyle.None;

        btnEasy.style.display = DisplayStyle.None;
        btnMedium.style.display = DisplayStyle.None;
        btnHard.style.display = DisplayStyle.None;

        btnWesternTown.style.display = DisplayStyle.Flex;
        btnSnowyHideout.style.display = DisplayStyle.Flex;
    }

    //helpers
    private void RetrieveElemets()
    {
        UIDocument document = GetComponent<UIDocument>();

        btnPlay = document.rootVisualElement.Q<Button>("PlayButton");
        btnExit = document.rootVisualElement.Q<Button>("ExitButton");

        btnEasy = document.rootVisualElement.Q<Button>("EasyButton");
        btnMedium = document.rootVisualElement.Q<Button>("MediumButton");
        btnHard = document.rootVisualElement.Q<Button>("HardButton");

        btnWesternTown = document.rootVisualElement.Q<Button>("WesternTownButton");
        btnSnowyHideout = document.rootVisualElement.Q<Button>("SnowyHideoutButton");
    }

    private void AssignEventHandlers()
    {
        btnPlay.clicked += ShowDifficultyScreen;
        btnExit.clicked += () => Application.Quit();

        btnEasy.clicked += () => { Difficulty.SetEasyDifficulty(); ShowMapScreen(); };
        btnMedium.clicked += () => { Difficulty.SetMediumDifficulty(); ShowMapScreen();};
        btnHard.clicked += () => { Difficulty.SetHardDifficulty(); ShowMapScreen(); };

        btnWesternTown.clicked += () => SceneManager.LoadScene(1);
        btnSnowyHideout.clicked += () => SceneManager.LoadScene(2);
    }
}
