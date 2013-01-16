using UnityEngine;
using System.Collections;

public class Nage : MonoBehaviour {
	
	public Transform JoueurPrefab;

	public float NiveauSousMarin;
	public float GraviteSousMarine;
	public float GraviteDefaut;
	public float vitesseMontee;
	
	private CharacterMotor caracMotor;
	
	// Use this for initialization
	void Start () {
		
		
		//On stocke la valeur de la gravite par defaut
		caracMotor = GetComponent<CharacterMotor>();
		

		caracMotor.movement.gravity = GraviteDefaut;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < NiveauSousMarin){
			caracMotor.movement.gravity = GraviteSousMarine;
			
		//deplacement vertical
		if(Input.GetKeyDown(KeyCode.A))
			{
				Debug.Log("touche active pour nage vers le haut");
				//JoueurPrefab.Translate(new Vector3(0, vitesseMontee, 0) * Time.deltaTime);
				caracMotor.SetVelocity(new Vector3(0, vitesseMontee, 0));;		
			}	

		}
		else{
			caracMotor.movement.gravity = GraviteDefaut;
		}

	}
}