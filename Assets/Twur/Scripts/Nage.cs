//arthur sore 
// attaché a l'objet joueur contenant un charactermotor

using UnityEngine;
using System.Collections;

public class Nage : MonoBehaviour {
	
	public CharacterController JoueurPrefab;

	public float NiveauSousMarin;
	public float GraviteSousMarine;
	public float GraviteDefaut;
	public float vitesseMontee;
	public bool JoueurSousEau;
	
	private CharacterMotor caracMotor;
	
	private bool toucheNage;
	private Vector3 avanceNage;
	private bool testTouche;
	
	void Start () {
		//On stocke le charactermotor, la valeur de la gravite par defaut
		caracMotor = GetComponent<CharacterMotor>();
		caracMotor.movement.gravity = GraviteDefaut;
		toucheNage = false;		
		JoueurSousEau = false;
	}
	void Update () {
		//Si en dessous du niveau sous marin, et que le joueur nage..
		if((transform.position.y < NiveauSousMarin-1)){
			//gravité sous marine (touche nage relachée, en descente)
			caracMotor.movement.gravity = GraviteSousMarine;
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
				//Arret du joueur pour éviter trop d'inertie
				caracMotor.SetVelocity(new Vector3(0,0,0));
				//gravité a zero pendant la nage
				caracMotor.movement.gravity = 0;
				//vitesse normalisée au deltatime
				float curVitesse = (vitesseMontee * Input.GetAxis("Vertical")* Time.deltaTime);
				//move et pas simplemove pour ne pas tenir compte de la gravité, et dans la direction de la main camera * la vitesse
				JoueurPrefab.Move(Camera.mainCamera.transform.forward * curVitesse);
			}
			else 
			{
			}
		}
		else{
			//sorti de l'eau
			caracMotor.movement.gravity = GraviteDefaut;
		}
	}
}