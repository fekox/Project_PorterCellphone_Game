using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurotialAndUnload : MonoBehaviour
{
    public Mediator mediator;

    private void Start()
    {
        mediator.player.Seleccionado = true;
    }
}
