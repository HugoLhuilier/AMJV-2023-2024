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
    [SerializeField] GameObject selectionSytem;
    [SerializeField] GameObject overlay;
    private int currentLevelIndex;

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
        mainMenu.SetActive(true);
    }

    public void Resume()
    {
        menu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        menu.SetActive(false);
        levelSelectionMenu.SetActive(false);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);
        selectionSytem.SetActive(true);
        overlay.SetActive(true);
    }

    public void loadLevel1() { LoadLevel(level1Index); currentLevelIndex = level1Index; }
    public void loadLevel2() { LoadLevel(level2Index); currentLevelIndex = level2Index; }
    public void loadLevel3() { LoadLevel(level3Index); currentLevelIndex = level3Index; }
    public void loadLevel4() { LoadLevel(level4Index); currentLevelIndex = level4Index; }
}
