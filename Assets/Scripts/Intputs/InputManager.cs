using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public float horizontalInput { get; set; }
    public float verticalInput { get; set; }

    private bool touchInputActive;
    private Vector2 touchStartPosition;
    private Vector2 touchDelta;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {

#if UNITY_EDITOR

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

#endif

#if UNITY_ANDROID || UNITY_IOS

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchInputActive = true;
                    touchStartPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    touchDelta = touch.position - touchStartPosition;
                    break;

                case TouchPhase.Ended:
                    touchInputActive = false;
                    break;
            }
        }

        else
        {
            touchInputActive = false;
        }
#endif

    }

    public Vector2 GetTouchDelta()
    {
        if (touchInputActive)
        {
            return touchDelta;
        }

        else
        {
            return Vector2.zero;
        }
    }
}
