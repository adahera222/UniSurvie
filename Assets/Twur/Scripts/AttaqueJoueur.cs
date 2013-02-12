//arthur sore

using UnityEngine;
using System.Collections;


public class AttaqueJoueur : MonoBehaviour {
	
	public bool EnAttaque;
	public bool EnCharge;
	public bool Boussole;
	public bool ChargeArc;
	public bool TirArc;
	public float TimerArmeCac;
	public float DureeFocusRotationBras;
	

	
	//timers
	public bool timer;
	public bool RotationBras;
	
	
	private float tempRotBrasTimer;
	private float tempTimer;
	
	//arrête d'utiliser les objets neutres si arme.
	private bool stopUtils;
	
	//input
	private string inputStr;

	void Start () {
		EnAttaque = false;
		EnCharge = false;
		timer =false;
		RotationBras = false;
		ChargeArc =false;
		TirArc = false;
		
		inputStr ="";
		stopUtils = false;
	}
	
	void Update () {
	
		if(inputStr !="")
		{
			//jpeux faire comme ça car la boussole et a priori les autres utils passent "" en string
			if(stopUtils == true){
				Boussole= false;
			}
			
			
			//ARC
			if(GameObject.FindGameObjectWithTag("Arc") != null)
			{
				if(Input.GetButtonDown("Fire1"))
				{
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = false;
					Debug.Log ("ChargeArc");
					ChargeArc =true;
					RotationBras = true;
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = true;
					
				}
				
				if(Input.GetButtonUp("Fire1"))
				{
					
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = false;
					gameObject.GetComponentInChildren<TirFleches>().InputTir = true;
					
					ChargeArc =false;
					TirArc = true;
								
					
				}	
			}			
			//CAC
			if(Input.GetButtonDown(inputStr))
			{

				
				//code timer désactivé pour le moment reste toujours faux		
				if(!timer){
					/**
					//controle l'animation controller qui y accède et déplace l'arme
					EnCharge = true;
					EnAttaque = false;
					**/
					

					EnAttaque = true;
					
		
				}
			}
			else if(Input.GetButtonUp(inputStr))
			{
				/**
				if(EnCharge){
					EnCharge = false;
					EnAttaque = true;
					tempTimer = Time.time +TimerArmeCac;
				}
				**/
				
				//timers 
				// timer = true;
								
				RotationBras = true;
				
				EnAttaque =false;
				tempTimer = Time.time +TimerArmeCac;
				
				//timer en attaque, surement a modifier pour définir la direction des bras toujours dans le sens de la camera lorsqu'une arme en main
				tempRotBrasTimer = Time.time + DureeFocusRotationBras;
				
				
				
			}

			
			if(timer)
			{
				if(Time.time > tempTimer)
				{
					timer = false;	
				}
			}
			//on teste si l'arc est pas en visée car là on veut la garder.
			else if(RotationBras && (GameObject.FindGameObjectWithTag("Arc") == null))
			{
				if(Time.time > tempRotBrasTimer)
				{
					RotationBras =false;	
				}
			}
		}
		//si le string passé a inputStr est null
		{
			if(Input.GetKeyUp(KeyCode.B))
			{
				RotationBras = false;
				if(Boussole)
				{
					Boussole=false;
					stopUtils = false;
				}
				else if(!Boussole)
				{
					Boussole=true;
					stopUtils = true;
				}
			}
			
		}
	}
	
	//setter pour input
	public void SetInputsArmes(string str)
	{
			inputStr = str;
	}
}
