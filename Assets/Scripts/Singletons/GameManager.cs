using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private MainMenu menu;
    public GameObject carriedFlag;

    private void Start()
    {
        Instance = this;
    }

    public void StartGame()
    {

    }

    public void WinGame()
    {
        Debug.Log("Win");

        menu.VictoryScreen();
    }

    public void LoseGame()
    {
        Debug.Log("Lose");

        menu.DefeatScreen();
    }
}
