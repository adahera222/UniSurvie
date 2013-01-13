using UnityEngine;
using System.Collections;

public class TirFleches : MonoBehaviour {

	public Rigidbody prefabFleche;
	public Transform cameraJoueurTransform;
	public float forceTir;
	
	private Rigidbody instanceFleche;
	private bool _flecheChargee;
	

	
	
	// Use this for initialization
	void Start () {
		_flecheChargee = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			if(_flecheChargee)
			{
				return;
			}
			else if(!_flecheChargee)
			{
				instanceFleche = (Rigidbody) Instantiate(prefabFleche, transform.position, transform.rotation);
				// instantie comme enfant du transform:
				instanceFleche.transform.parent = transform;
				
				// je boque la physique de la fleche pour pas qu'elle tombe au sol avant d'être tirée
				instanceFleche.isKinematic = true;
				_flecheChargee = true;
			}
		}
		
		if(Input.GetButtonUp("Fire1"))
		{
			if(_flecheChargee){
				//si la fleche est chargée et que le bouton est relachée, on remet la physique et on applique une force.
				instanceFleche.isKinematic = false;
				instanceFleche.AddForce(transform.forward * forceTir);
				
				
				//on se détache du parent Arc pour ne pas être influé par son déplacement lors du vol
				instanceFleche.transform.parent = null;
				_flecheChargee = false;
				
				//acces a la fonction publique de fleche en vol via getComponent
				FlecheEnVol scriptFleche = instanceFleche.GetComponent<FlecheEnVol>();
        		scriptFleche.EstTiree(true);
			}
			else if (!_flecheChargee){
				return;
			}
	
		}
	}
}
