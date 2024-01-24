using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
    [SerializeField] public AudioClip goAudioClip;

    private void Start()
    {
        Debug.Log(AudioManager.Instance);
        AudioManager.Instance.TitleScreen();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Pausing");
            PauseMenu();
        }
    }

    protected void ExitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    protected void PauseMenu()
    {
        AudioManager.Instance.Pause();
        if (menu.activeSelf == false)
        {
            Debug.Log("Pause");
            Time.timeScale = 0;
            menu.SetActive(true);
            pauseMenu.SetActive(true);
            selectionSytem.SetActive(false);
            AudioManager.Instance.PlaySFX(goAudioClip);
        }
    }

    protected void LevelSelectionMenu()
    {
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
        AudioManager.Instance.PlaySFX(goAudioClip);
    }

    protected void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
        AudioManager.Instance.PlaySFX(goAudioClip);
    }

    protected void Back()
    {
        levelSelectionMenu.SetActive(false);
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
        AudioManager.Instance.PlaySFX(goAudioClip);
    }

    protected void Abort()
    {
        GameManager.Instance.isQuitting = true;
        GameManager.Instance.UnloadLevel();
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        AudioManager.Instance.PlaySFX(goAudioClip);
    }

    protected void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        selectionSytem.SetActive(true);
        AudioManager.Instance.PlaySFX(goAudioClip);
        AudioManager.Instance.Level(GameManager.Instance.selectedLevelIndex);
    }

    protected void Go()
    {
        AudioManager.Instance.PlaySFX(goAudioClip);
        levelSelectionMenu.SetActive(false);
        menu.SetActive(false);
        overlay.SetActive(true);
        selectionSytem.SetActive(true);
        camera_m.transform.position = initialCameraPosition;
        timer.timer = 0;
        GameManager.Instance.LoadLevel();
        GameManager.Instance.StartGame();
    }

    protected void NextLevel()
    {
        victoryScreen.SetActive(false);
        menu.SetActive(false);
        overlay.SetActive(true);
        selectionSytem.SetActive(true);
        camera_m.transform.position = initialCameraPosition;
        timer.timer = 0;
        Debug.Log("Loading next level");
        Debug.Log(Time.timeScale);
        GameManager.Instance.UnloadLevel();
        Debug.Log(Time.timeScale);
        GameManager.Instance.LoadNextLevel();
        Debug.Log(Time.timeScale);
        GameManager.Instance.isQuitting = true;
        GameManager.Instance.StartGame();
        Debug.Log(Time.timeScale);
        AudioManager.Instance.PlaySFX(goAudioClip);
    }

    public void VictoryScreen()
    {
        Time.timeScale = 0.0f;
        menu.SetActive(true);
        victoryScreen.SetActive(true);
    }

    public void DefeatScreen()
    {
        Time.timeScale = 0.0f;
        defeatScreen.SetActive(true);
    }

    protected void selectLevel1() { GameManager.Instance.selectLevel1();  }
    protected void selectLevel2() { GameManager.Instance.selectLevel2(); }
    protected void selectLevel3() { GameManager.Instance.selectLevel3(); }
    protected void selectLevel4() { GameManager.Instance.selectLevel4(); }

    /*   protected void changeGraphicsSetting()
       {
           EditorGraphicsSettings.SetTierSettings(BuildTargetGroup.Standalone, GraphicsTier.Tier1, TierSettings.standardShaderQuality);
       }*/
}
