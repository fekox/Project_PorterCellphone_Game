using UnityEngine;
using System.Collections;

public class Bolsa : MonoBehaviour
{
	public Pallet.Valores Monto;
	//public int IdPlayer = 0;
	public string TagPlayer = "";
	public Texture2D ImagenInventario;
	Player Pj = null;
	
	bool Desapareciendo;
	public GameObject Particulas;
	public float TiempParts = 2.5f;

	// Use this for initialization
	void Start () 
	{
		Monto = Pallet.Valores.Valor2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Desapareciendo)
		{
			TiempParts -= Time.deltaTime;
			if(TiempParts <= 0)
			{
				GetComponent<Renderer>().enabled = true;
				GetComponent<Collider>().enabled = true;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == TagPlayer)
		{
			Pj = coll.GetComponent<Player>();
			if(Pj.AgregarBolsa(this))
				Desaparecer();
		}
	}
	
	public void Desaparecer()
	{
		Particulas.SetActive(true);
		Desapareciendo = true;
		
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	
	}
}
