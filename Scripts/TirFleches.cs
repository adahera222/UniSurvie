//arthur sore


using UnityEngine;
using System.Collections;

public class TirFleches : MonoBehaviour {

	//variables accédées par AttaqueJoueur pour cohérence
	public bool InputCharge;
	public bool InputTir;
	
	public Rigidbody prefabFleche;
	public float forceTir;
	public float timerArc;

	private Rigidbody instanceFleche;
	private Rigidbody instanceFleche2; // la fleche tirée est un autre objet pour éviter les bugs de rotation locale / globale	
	private bool _flecheChargee;
	private Transform _spawnFleche;
	
	private bool timer;
	private float tempTimerArc;
	

	
	
	
	void Start () {
		_flecheChargee = false;
		_spawnFleche = gameObject.transform.FindChild("spawnFleche");
		timer = false;
		tempTimerArc = 0.0f;


		
	}
	
	void Update () {
		
		if(InputCharge)
		{
			
			if(_flecheChargee)
			{
				return;
			}
			else if((!_flecheChargee)&&(!timer))
			{
				InputCharge=false;

				instanceFleche = (Rigidbody)Instantiate(prefabFleche, _spawnFleche.position, _spawnFleche.rotation);
				// instantie comme enfant du transform:
				instanceFleche.transform.parent = transform;

				// je boque la physique de la fleche pour pas qu'elle tombe au sol avant d'être tirée
				instanceFleche.isKinematic = true;
				_flecheChargee = true;
				instanceFleche.GetComponent<BoxCollider>().enabled = false;
			}
		}
		
		if(InputTir)
		{
			if(_flecheChargee){
				InputTir = false;
				
				
				Destroy(instanceFleche.gameObject);
				instanceFleche2 = (Rigidbody)Instantiate(prefabFleche, _spawnFleche.position, _spawnFleche.rotation);
					
					
				//acces a la fonction publique de fleche en vol via getComponent
				FlecheEnVol scriptFleche = instanceFleche2.GetComponent<FlecheEnVol>();
        		scriptFleche.EstTiree(true);
				
				instanceFleche2.AddForce(_spawnFleche.transform.forward * forceTir);
				_flecheChargee = false;
				timer = true;
				tempTimerArc = Time.time + timerArc;

		

			}
			else if (!_flecheChargee){
				return;
			}
		
		}
		
		if(timer)
		{
			
			if(Time.time > tempTimerArc)
			{
				timer = false;
				
			}
		}

	}
	

}
