using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDireccion : MonoBehaviour 
{
    [Header("Input")]

    public static ControlDireccion instance;

    public int playerID;

	float Giro = 0;
	
	public bool Habilitado = true;
	CarController carController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () 
	{
		carController = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Giro = InputManager.Instance.GetAxis($"Horizontal{playerID}");

        carController.SetGiro(Giro);
    }

    public float GetGiro()
	{
		return Giro;
	}
	
}