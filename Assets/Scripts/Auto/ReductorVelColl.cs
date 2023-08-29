using UnityEngine;
using System.Collections;

public class ReductorVelColl : MonoBehaviour 
{
	public float ReduccionVel;
	bool Usado = false;
	public string PlayerTag = "Player";
	
	void OnCollisionEnter(Collision other) 
	{
		if(other.transform.tag == PlayerTag)
		{
			if(!Usado)
			{
				Chocado();
			}
		}
	}
	
	public virtual void Chocado()
	{
		Usado = true;
	}
}
