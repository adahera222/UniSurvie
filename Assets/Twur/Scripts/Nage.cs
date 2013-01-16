using UnityEngine;
using System.Collections;

public class Nage : MonoBehaviour {
	
	public CharacterController JoueurPrefab;

	public float NiveauSousMarin;
	public float GraviteSousMarine;
	public float GraviteDefaut;
	public float vitesseMontee;
	
	private CharacterMotor caracMotor;
	
	private bool toucheNage;
	
	// Use this for initialization
	void Start () {
		
		
		//On stocke la valeur de la gravite par defaut
		caracMotor = GetComponent<CharacterMotor>();
		

		caracMotor.movement.gravity = GraviteDefaut;
		
		toucheNage = false;		
		
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position.y < NiveauSousMarin) && (!caracMotor.IsGrounded())){
			caracMotor.movement.gravity = GraviteSousMarine;
			if(transform.position.y < (NiveauSousMarin-1))
			{
				//deplacement vertical
				
				if(Input.GetKeyDown(KeyCode.E))
				{
					toucheNage = true;
				}	
				else if(Input.GetKeyUp(KeyCode.E))
				{
					toucheNage = false;
				}
			
				//pas de while car on est dans la fonction update qui doit avoir lieu une fois par frame
				if(toucheNage){
					Debug.Log("touche active pour nage");
					JoueurPrefab.Move(new Vector3(0, vitesseMontee, 0) * Time.deltaTime);
				}
				else 
				{
					toucheNage = false;
				}
			}
			//surface de l'eau
			else if((transform.position.y < NiveauSousMarin+2) && (transform.position.y > NiveauSousMarin-2)){
				//surface
				Debug.Log("en surface");
				if(Input.GetKeyDown(KeyCode.E))
				{
					toucheNage = true;
				}	
				else if(Input.GetKeyUp(KeyCode.E))
				{
					toucheNage = false;
				}
			
			}
			else{
				toucheNage = false;
			}
		}
		else if (caracMotor.IsGrounded())
		{
			toucheNage = false;
			
		}
		else{
			caracMotor.movement.gravity = GraviteDefaut;
		}

		if(toucheNage)
		Debug.Log("touchenageOk");
		else if(!toucheNage)
			Debug.Log("touchenageNOK!!!!");

	}
}