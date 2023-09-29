using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour
{
    [Header("Game Manager")]

    public GameManager gameManager;

    [Header("Controll Direction")]

    public ControlDireccion controlDireccion;

    [Header("Player")]

    public Player player;

    [Header("PlayerID")]

    public int playerID;
}
