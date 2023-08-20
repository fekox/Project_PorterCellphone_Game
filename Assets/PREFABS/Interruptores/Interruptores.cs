using UnityEngine;
using System.Collections;

public class Interruptores : MonoBehaviour 
{
	public string TagPlayer = "Player";
	
	public GameObject[] AActivar;
	
	public bool Activado = false;
	
	void OnTriggerEnter(Collider other) 
	{
		if(!Activado)
		{
			if(other.tag == TagPlayer)
			{
				Activado = true;
				for(int i = 0; i < AActivar.Length; i++)
				{
					AActivar[i].SetActive(true);
				}
			}
		}
	}
}
