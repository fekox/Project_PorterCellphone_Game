using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MngPts : MonoBehaviour 
{	
	public float TiempEmpAnims = 2.5f;
	float Tempo = 0;
	
	public GameObject[] Winers;
	public TextMeshProUGUI[] Scores;

    public float TiempEspReiniciar = 10;
	
	
	public float TiempParpadeo = 0.7f;
	float TempoParpadeo = 0;
	bool PrimerImaParp = true;
	
	public bool ActivadoAnims = false;
	
	Visualizacion Viz = new Visualizacion();
	
	//---------------------------------//
	
	void Start () 
	{
		for (int i = 0; i < 2; i++) 
		{
            Winers[i].SetActive(false);
		}

		SetGanador();
	}
	
	void Update () 
	{		
		TiempEspReiniciar -= Time.deltaTime;
		if(TiempEspReiniciar <= 0 )
		{
			SceneManager.LoadScene(0);
		}
		
		if(ActivadoAnims)
		{
			TempoParpadeo += Time.deltaTime;
			
			if(TempoParpadeo >= TiempParpadeo)
			{
				TempoParpadeo = 0;
				
				if(PrimerImaParp)
					PrimerImaParp = false;
				else
				{
					TempoParpadeo += 0.1f;
					PrimerImaParp = true;
				}
			}
		}
		
		if(!ActivadoAnims)
		{
			Tempo += Time.deltaTime;
			if(Tempo >= TiempEmpAnims)
			{
				Tempo = 0;
				ActivadoAnims = true;
			}
		}

        if (ActivadoAnims)
        {
            SetDinero();
        }
    }
	
	void SetGanador()
	{
		switch(DatosPartida.LadoGanadaor)
		{
            case DatosPartida.Lados.Izq:

            Winers[0].SetActive(true);

            break;

			case DatosPartida.Lados.Der:
			
			Winers[1].SetActive(true);
			
			break;
		}
	}
	
	void SetDinero()
	{
		
		if(DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq)//izquierda
		{
			if(!PrimerImaParp)//para que parpadee
                Scores[0].text = "$" + Viz.PrepararNumeros(DatosPartida.PtsGanador).ToString();
		}
		else
		{
            Scores[0].text = "$" + Viz.PrepararNumeros(DatosPartida.PtsPerdedor).ToString();
		}
				
		
		if(DatosPartida.LadoGanadaor == DatosPartida.Lados.Der)//derecha
		{
			if(!PrimerImaParp)//para que parpadee
                Scores[1].text = "$" + Viz.PrepararNumeros(DatosPartida.PtsGanador).ToString();
        }
		else
		{
            Scores[1].text = "$" + Viz.PrepararNumeros(DatosPartida.PtsPerdedor).ToString();
        }

    }
	
	public void DesaparecerGUI()
	{
		ActivadoAnims = false;
		Tempo = -100;
	}
}
