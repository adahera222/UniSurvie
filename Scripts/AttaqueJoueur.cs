//arthur sore

using UnityEngine;
using System.Collections;


public class AttaqueJoueur : MonoBehaviour {
	

	
	public bool TirFlingue;
	public bool TirArc;
	public bool TirArcRelache;
	public bool AttaqueCac;
	public bool ChargeCac;
	public bool VueBoussole;

	

	//input
	private string inputStr;

	void Start () {
		TirFlingue = false;
		TirArc = false;
		AttaqueCac = false;
		VueBoussole = false;
		ChargeCac = false;

	}
	
	void Update () {
	

			//ARC

				if(TirArc)
				{
			
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = false;
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = true;
				}
				
				if(TirArcRelache)
				{
					TirArc = false;
					TirArcRelache = false;
					gameObject.GetComponentInChildren<TirFleches>().InputCharge = false;
					gameObject.GetComponentInChildren<TirFleches>().InputTir = true;
				}	
						
			//CAC
			if(AttaqueCac)
			{
			TirArcRelache = false;
			TirArc = false;
			}

		
		
	}
}		
			
