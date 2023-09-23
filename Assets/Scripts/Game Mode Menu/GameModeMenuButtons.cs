using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum Dificult
{
    None,
    Easy,
    Normal,
    Hard
}

public enum GameMode 
{
    None,
    Singleplayer,
    Multiplayer
}

public class GameModeMenuButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public GameObject gameModeMenu;

    public TextMeshProUGUI selectDificultText;
    public TextMeshProUGUI selectGameModeText;

    [SerializeField] private GameObject dificultEasy;
    [SerializeField] private GameObject dificultNormal;
    [SerializeField] private GameObject dificultHard;

    private void Start()
    {
        Time.timeScale = 0;

        dificultEasy.SetActive(false);
        dificultNormal.SetActive(true);
        dificultHard.SetActive(false);

        selectDificultText.text = "Select a dificulty:";
        selectGameModeText.text = "Select a game mode:";
    }

    public void EasyButton() 
    {
        selectDificultText.text = "Select a dificulty: Easy";

        dificultEasy.SetActive(true);
        dificultNormal.SetActive(false);
        dificultHard.SetActive(false);
    }

    public void NormalButton() 
    {
        selectDificultText.text = "Select a dificulty: Normal";

        dificultEasy.SetActive(false);
        dificultNormal.SetActive(true);
        dificultHard.SetActive(false);
    }

    public void HardButton() 
    {
        selectDificultText.text = "Select a dificulty: Hard";

        dificultEasy.SetActive(false);
        dificultNormal.SetActive(false);
        dificultHard.SetActive(true);
    }

    public void SinglePlayer() 
    {
        selectGameModeText.text = "Select a game mode: Singleplayer";
        gameManager.playerCount = 1;
    }

    public void Multiplayer() 
    {
        selectGameModeText.text = "Select a game mode: Multiplayer";
        gameManager.playerCount = 2;
    }

    public void PlayLevel() 
    {
        Time.timeScale = 1;
        gameModeMenu.SetActive(false);
    }
}