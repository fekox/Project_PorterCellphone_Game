using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits() 
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
