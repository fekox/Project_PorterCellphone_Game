using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurotialAndUnload : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager.Player1.Seleccionado = true;
    }
}
