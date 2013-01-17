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
	private Vector3 avanceNage;
	
	// Use this for initialization
	void Start () {
		
		
		//On stocke la valeur de la gravite par defaut
		caracMotor = GetComponent<CharacterMotor>();
		

		caracMotor.movement.gravity = GraviteDefaut;
		
		toucheNage = false;		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if((transform.position.y < NiveauSousMarin)){
			caracMotor.movement.gravity = GraviteSousMarine;
			if(transform.position.y < (NiveauSousMarin-1))
			{
				//deplacement vertical
				


				if(Input.GetKeyDown(KeyCode.Z))
				{
					toucheNage = true;
				}	
				else if(Input.GetKeyUp(KeyCode.Z))
				{
					toucheNage = false;
				}
			
				//pas de while car on est dans la fonction update qui doit avoir lieu une fois par frame
				if(toucheNage){
					caracMotor.SetVelocity(new Vector3(0,0,0));
					caracMotor.movement.gravity = 0;
					float curVitesse = vitesseMontee * Input.GetAxis("Vertical");
					if(Input.GetAxis("Vertical") > 0)
					JoueurPrefab.transform.position = JoueurPrefab.transform.position + (Camera.mainCamera.transform.forward * vitesseMontee * Time.deltaTime);
					if(Input.GetAxis("Vertical") < 0)
					JoueurPrefab.transform.position = JoueurPrefab.transform.position - (Camera.mainCamera.transform.forward * vitesseMontee * Time.deltaTime);					
					Debug.Log("touche active pour nage");
					//JoueurPrefab.Move(new Vector3(0, vitesseMontee, 0) * Time.deltaTime);
					
					
				}
				else 
				{
					toucheNage = false;
				}
			}

			else{
				toucheNage = false;
			}
		}
		else{
			caracMotor.movement.gravity = GraviteDefaut;
			toucheNage = false;
		}

		if(toucheNage)
		Debug.Log("touchenageOk");
		else if(!toucheNage)
			Debug.Log("touchenageNOK!!!!");

	}
}