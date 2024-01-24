using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private int level1Index = 1;
    private int level2Index = 2;
    private int level3Index = 3;
    private int level4Index = 4;
    private int currentLevelIndex;
    public int selectedLevelIndex { private set; get; }


    [SerializeField] private MainMenu menu;
    public GameObject carriedFlag;
    public bool isQuitting = false;

    [SerializeField] private AudioClip selectionSFX;

    private void Start()
    {
        Instance = this;
        selectedLevelIndex = 1;
    }

    public void StartGame()
    {
        isQuitting = false;
        Time.timeScale = 1;
        Debug.Log("Game started");
        AudioManager.Instance.Level(currentLevelIndex);
    }

    public void WinGame()
    {
        if(!isQuitting)
        {
            Debug.Log("Win");
            isQuitting = true;
            menu.VictoryScreen();
        }
    }

    public void LoseGame()
    {
        if (!isQuitting)
        {
            Debug.Log("Lose");
            isQuitting = true;
            menu.DefeatScreen();
        }
    }

    public void LoadLevel()
    {
        currentLevelIndex = selectedLevelIndex;
        SceneManager.LoadScene(selectedLevelIndex, LoadSceneMode.Additive);
    }

    public void LoadNextLevel()
    {
        selectedLevelIndex = currentLevelIndex + 1;
        LoadLevel();
    }

    public void UnloadLevel()
    {
        SceneManager.UnloadScene(currentLevelIndex);
    }

    public void selectLevel1() {
        selectedLevelIndex = level1Index;
        AudioManager.Instance.PlaySFX(selectionSFX);
    }
    public void selectLevel2() {
        selectedLevelIndex = level2Index;
        AudioManager.Instance.PlaySFX(selectionSFX);
    }
    public void selectLevel3() {
        selectedLevelIndex = level3Index;
        AudioManager.Instance.PlaySFX(selectionSFX);
    }
    public void selectLevel4() {
        selectedLevelIndex = level4Index;
        AudioManager.Instance.PlaySFX(selectionSFX);
    }
}
