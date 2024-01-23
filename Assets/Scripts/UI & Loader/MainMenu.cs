using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int mainMenuIndex = 0;
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
    [SerializeField] Timer timer;
    private int currentLevelIndex;
    private int selectedLevelIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Pausing");
            PauseMenu();
        }
        Debug.Log(Time.timeScale);
    }

    protected void ExitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    protected void PauseMenu()
    {
        Debug.Log("Pause");
        Debug.Log(currentLevelIndex);
        Time.timeScale = 0;
        menu.SetActive(true);
        pauseMenu.SetActive(true);
    }

    protected void LevelSelectionMenu()
    {
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    protected void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    protected void Back()
    {
        levelSelectionMenu.SetActive(false);
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    protected void Abort()
    {
        pauseMenu.SetActive(false);
        SceneManager.UnloadSceneAsync(currentLevelIndex);
        mainMenu.SetActive(true);
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
    }

    protected void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    protected void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        levelSelectionMenu.SetActive(false);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);
        selectionSytem.SetActive(true);
        overlay.SetActive(true);
        camera_m.transform.position = initialCameraPosition;
        currentLevelIndex = levelIndex;
        timer.timer = 0;
    }

    protected void LoadSelectedLevel()
    {
        LoadLevel(selectedLevelIndex);
        Debug.Log(selectedLevelIndex);
    }

    protected void Go()
    {
        Debug.Log("Go");
        LoadSelectedLevel();
    }

    protected void selectLevel1() { selectedLevelIndex = level1Index;  }
    protected void selectLevel2() { selectedLevelIndex = level2Index; }
    protected void selectLevel3() { selectedLevelIndex = level3Index; }
    protected void selectLevel4() { selectedLevelIndex = level4Index; }

    protected void NextLevel()
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

 /*   protected void changeGraphicsSetting()
    {
        EditorGraphicsSettings.SetTierSettings(BuildTargetGroup.Standalone, GraphicsTier.Tier1, TierSettings.standardShaderQuality);
    }*/
}
