using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    private void Update()
    {
        //Ketboard
        float horizontalInput = InputManager.instance.horizontalInput;
        float verticalInput = InputManager.instance.verticalInput;

        //Movile
        Vector2 touchDelta = InputManager.instance.GetTouchDelta();

        Vector3 movement = new Vector3(horizontalInput + touchDelta.x, 0f, verticalInput + touchDelta.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
