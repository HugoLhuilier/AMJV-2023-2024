using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int mainMenuIndex = 0;
    [SerializeField] int toolsIndex = 1;
    [SerializeField] int level1Index = 2;
    [SerializeField] int level2Index = 3;
    [SerializeField] int level3Index = 4;
    [SerializeField] int level4Index = 5;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject levelSelectionMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] GameObject selectionSytem;
    [SerializeField] GameObject overlay;
    [SerializeField] Camera camera_m;
    [SerializeField] Vector3 initialCameraPosition;
    private int currentLevelIndex;
    private int selectedLevelIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Pausing");
            PauseMenu();
        }
    }

    public void ExitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    public void PauseMenu()
    {
        Debug.Log("Pause");
        Time.timeScale = 0;
        menu.SetActive(true);
        pauseMenu.SetActive(true);
    }

    public void LevelSelectionMenu()
    {
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void Back()
    {
        levelSelectionMenu.SetActive(false);
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Abort()
    {
        SceneManager.UnloadSceneAsync(currentLevelIndex);
        pauseMenu.SetActive(false);
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        levelSelectionMenu.SetActive(false);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);
        selectionSytem.SetActive(true);
        overlay.SetActive(true);
        camera_m.transform.position = initialCameraPosition;
    }

    public void LoadSelectedLevel()
    {
        LoadLevel(selectedLevelIndex);
    }

    public void selectLevel1() { selectedLevelIndex = level1Index;  }
    public void selectLevel2() { selectedLevelIndex = level2Index; }
    public void selectLevel3() { selectedLevelIndex = level3Index; }
    public void selectLevel4() { selectedLevelIndex = level4Index; }

    public void NextLevel()
    {
        if (currentLevelIndex == 4)
        {
            Abort();
        } else
        {
            LoadLevel(currentLevelIndex + 1);
        }
    }

    public void VictoryScreen()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }

    public void DefeatScreen()
    {
        Time.timeScale = 0;
        defeatScreen.SetActive(true);
    }
}
