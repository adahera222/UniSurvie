//arthur sore

using UnityEngine;
using System.Collections;


public class AttaqueJoueur : MonoBehaviour {
	
	public bool EnAttaque;
	public bool EnCharge;
	public bool Boussole;
	public float TimerArmeCac;
	public float DureeFocusRotationBras;
	

	
	//timers
	public bool timer;
	public bool RotationBras;
	
	
	private float tempRotBrasTimer;
	private float tempTimer;

	void Start () {
		EnAttaque = false;
		EnCharge = false;
		timer =false;
		RotationBras = false;
	}
	
	void Update () {
	
		if(Input.GetButtonDown("Fire1"))
		{
			
			if(!timer){
				/**
				//controle l'animation controller qui y accède et déplace l'arme
				EnCharge = true;
				EnAttaque = false;
				**/
				
				EnAttaque = true;
			}
		}
		else if(Input.GetButtonUp("Fire1"))
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
		else if(Input.GetKeyUp(KeyCode.B))
		{
			if(Boussole)
			{
				Boussole=false;
			}
			else if(!Boussole)
			{
				Boussole=true;
			}
		}
		
		if(timer)
		{
			if(Time.time > tempTimer)
			{
				timer = false;	
			}
		}
		else if(RotationBras)
		{
			if(Time.time > tempRotBrasTimer)
			{
				RotationBras =false;	
			}
		}
	}
}
