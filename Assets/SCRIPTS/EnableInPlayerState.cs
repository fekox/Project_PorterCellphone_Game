using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInPlayerState : MonoBehaviour
{
    public Player.Estados[] MisEstados;

    Player.Estados prevEstado = Player.Estados.Ninguno;
    public void SetPlayerState(Player.Estados state) {
        if (prevEstado != state) {
            bool activo = false;
            foreach (var estados in MisEstados) {
                if (estados == state) {
                    activo = true;
                    break;
                }
            }
            gameObject.SetActive(activo);
            prevEstado = state;
        }
        
    }
}
