using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// clase encargada de TODA la visualizacion
/// de cada player, todo aquello que corresconda a 
/// cada seccion de la pantalla independientemente
/// </summary>
public class Visualizacion : MonoBehaviour 
{
	public enum Lado{Izq, Der}
	public Lado LadoAct;
	
	ControlDireccion Direccion;
	Player Pj;

    public GameObject uiRoot;
    private EnableInPlayerState[] enableInPlayerStates;
	
	//las distintas camaras
	public Camera CamCalibracion;
	public Camera CamConduccion;
	public Camera CamDescarga;

    //EL DINERO QUE SE TIENE
    public Text Dinero;
	
	//EL VOLANTE
	public Transform volante;
	
	//PARA EL INVENTARIO
	public float Parpadeo = 0.8f;
	public float TempParp = 0;
	public bool PrimIma = true;
    public Sprite[] InvSprites;

    public Image Inventario;
	
	//BONO DE DESCARGA
	public GameObject BonusRoot;
	public Image BonusFill;
	public Text BonusText;


    //CALIBRACION MAS TUTO BASICO
    public GameObject TutoCalibrando;
    public GameObject TutoDescargando;
    public GameObject TutoFinalizado;

    //------------------------------------------------------------------//

    void Awake() {
        enableInPlayerStates = uiRoot.GetComponentsInChildren<EnableInPlayerState>(includeInactive:true);
    }

    // Use this for initialization
    void Start () 
	{
		Direccion = GetComponent<ControlDireccion>();
		Pj = GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        switch (Pj.EstAct) {

            case Player.Estados.EnConduccion:
                //inventario
                SetInv();
                //contador de dinero
                SetDinero();
                //el volante
                SetVolante();
                break;

            case Player.Estados.EnDescarga:
                //inventario
                SetInv();
                //el bonus
                SetBonus();
                //contador de dinero
                SetDinero();
                break;

            case Player.Estados.EnTutorial:
                SetTuto();
                break;
        }
    }
	
	//--------------------------------------------------------//
	
	public void CambiarATutorial()
	{
		CamCalibracion.enabled = true;
		CamConduccion.enabled = false;
		CamDescarga.enabled = false;

        Array.ForEach(enableInPlayerStates, e => e.SetPlayerState(Pj.EstAct));
    }
	
	public void CambiarAConduccion()
	{
		CamCalibracion.enabled = false;
		CamConduccion.enabled = true;
		CamDescarga.enabled = false;

        Array.ForEach(enableInPlayerStates, e => e.SetPlayerState(Pj.EstAct));
    }
	
	public void CambiarADescarga()
	{
		CamCalibracion.enabled = false;
		CamConduccion.enabled = false;
		CamDescarga.enabled = true;

        Array.ForEach(enableInPlayerStates, e => e.SetPlayerState(Pj.EstAct));
    }
	
	//---------//
	
	public void SetLado(Lado lado)
	{
		LadoAct = lado;
		
		Rect r = new Rect();
		r.width = CamConduccion.rect.width;
		r.height = CamConduccion.rect.height;
		r.y = CamConduccion.rect.y;
		
		switch (lado)
		{
		case Lado.Der:
			r.x = 0.5f;
			break;
			
			
		case Lado.Izq:
			r.x = 0;
			break;
		}
		
		CamCalibracion.rect = r;
		CamConduccion.rect = r;
		CamDescarga.rect = r;
	}
	
	void SetBonus()
	{
		if(Pj.ContrDesc.PEnMov != null)
		{
            BonusRoot.SetActive(true);

            //el fondo
			float bonus = Pj.ContrDesc.Bonus;
			float max = (float)(int)Pallet.Valores.Valor1;
			float t = bonus / max;
            BonusFill.fillAmount = t;
            //la bolsa
            BonusText.text = "$" + Pj.ContrDesc.Bonus.ToString("0");
        }
        else {
            BonusRoot.SetActive(false);
        }
	}
	
	void SetDinero()
	{
        Dinero.text = PrepararNumeros(Pj.Dinero);
    }
	
	void SetTuto()
	{
		switch(Pj.ContrCalib.EstAct)
		{
		case ContrCalibracion.Estados.Calibrando:
                TutoCalibrando.SetActive(true);
                TutoDescargando.SetActive(false);
                TutoFinalizado.SetActive(false);
                break;
			
		case ContrCalibracion.Estados.Tutorial:
                TutoCalibrando.SetActive(false);
                TutoDescargando.SetActive(true);
                TutoFinalizado.SetActive(false);
                break;
			
		case ContrCalibracion.Estados.Finalizado:
                TutoCalibrando.SetActive(false);
                TutoDescargando.SetActive(false);
                TutoFinalizado.SetActive(true);
                break;
		}
	}
	
	void SetVolante()
	{
		float angulo = - 45 * Direccion.GetGiro();
        Vector3 rot = volante.localEulerAngles;
        rot.z = angulo;
        volante.localEulerAngles = rot;
	}
	
	void SetInv()
	{
		int contador = 0;
		for(int i = 0; i < 3; i++)
		{
			if(Pj.Bolasas[i]!=null)
				contador++;
		}

        if(contador >= 3) {
			TempParp += T.GetDT();

			if(TempParp >= Parpadeo) {
				TempParp = 0;
				if(PrimIma)
					PrimIma = false;
				else
					PrimIma = true;


				if(PrimIma) {
					Inventario.sprite = InvSprites[3];
				}
				else {
					Inventario.sprite = InvSprites[4];
				}
			}
		}
        else {
			Inventario.sprite = InvSprites[contador];
		}
	}
	
	public string PrepararNumeros(int dinero)
	{
		string strDinero = dinero.ToString();
		string res = "";
		
		if(dinero < 1)//sin ditero
		{
			res = "";
		}else if(strDinero.Length == 6)//cientos de miles
		{
			for(int i = 0; i < strDinero.Length; i++)
			{
				res += strDinero[i];
				
				if(i == 2)
				{
					res += ".";
				}
			}
		}else if(strDinero.Length == 7)//millones
		{
			for(int i = 0; i < strDinero.Length; i++)
			{
				res += strDinero[i];
				
				if(i == 0 || i == 3)
				{
					res += ".";
				}
			}
		}
		
		return res;
	}
}
