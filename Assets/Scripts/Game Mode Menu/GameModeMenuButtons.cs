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

    public Dificult dificult = Dificult.None;
    public GameMode gameMode = GameMode.None;

    public GameObject gameModeMenu;

    public TextMeshProUGUI selectDificultText;
    public TextMeshProUGUI selectGameModeText;

    private void Start()
    {
        Time.timeScale = 0;
        selectDificultText.text = "Select a dificulty:";
        selectGameModeText.text = "Select a game mode:";
    }

    public void EasyButton() 
    {
        selectDificultText.text = "Select a dificulty: Easy";
        dificult = Dificult.Easy;
    }

    public void NormalButton() 
    {
        selectDificultText.text = "Select a dificulty: Normal";
        dificult = Dificult.Normal;
    }

    public void HardButton() 
    {
        selectDificultText.text = "Select a dificulty: Hard";
        dificult = Dificult.Hard;
    }

    public void SinglePlayer() 
    {
        selectGameModeText.text = "Select a game mode: Singleplayer";
        gameMode = GameMode.Singleplayer;
        gameManager.playerCount = 1;
    }

    public void Multiplayer() 
    {
        selectGameModeText.text = "Select a game mode: Multiplayer";
        gameMode = GameMode.Multiplayer;
        gameManager.playerCount = 2;
    }

    public void PlayLevel() 
    {
        Time.timeScale = 1;
        gameModeMenu.SetActive(false);
    }
}