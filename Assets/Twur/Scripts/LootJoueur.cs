//arthur sore
using UnityEngine;
using System.Collections;

public class LootJoueur : MonoBehaviour {
	
	//armes
	public GameObject[] Armes;
	public Transform TransformArmeMain;
	public Transform TransformArmeDistance;
	public Transform TransformPaumeZero;
	
	//strings pour inputs, a passer au script d'attaque (AttaqueJoueur)
	public string[] ArmesInputs;
	
	private GameObject armeCourante;
	private Vector3 nullPosition;
	private Quaternion nullRotation;
	private AttaqueJoueur setter;
	
	void Start () {
	
		nullPosition = new Vector3(0, 0, 0);
		nullRotation = new Quaternion(0,0,0,0);
		
		//il faudrait penser a protéger le cas ou AttaqueJoueur n'existe pas...
		setter = transform.GetComponent<AttaqueJoueur>();
	}
	
	void Update () {
	
		//temp avec des input en attendant un vrai loot
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}
			armeCourante = (GameObject)Instantiate(Armes[0], TransformArmeMain.position, TransformArmeMain.rotation);
			// instantie comme enfant du transform:
			armeCourante.transform.parent = TransformArmeMain;
			armeCourante.transform.localPosition = nullPosition;
			armeCourante.transform.localRotation = nullRotation;
				

			setter.SetInputsArmes(ArmesInputs[0]);

				
			
		}
		else if(Input.GetKeyUp(KeyCode.Alpha2))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}
			armeCourante = (GameObject)Instantiate(Armes[1], TransformArmeDistance.position, TransformArmeDistance.rotation);
			armeCourante.transform.parent = TransformArmeDistance;
			armeCourante.transform.localPosition = nullPosition;
			armeCourante.transform.localRotation = nullRotation;
			setter.SetInputsArmes(ArmesInputs[1]);

			
		}
		else if(Input.GetKeyUp(KeyCode.B))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}

			armeCourante = (GameObject)Instantiate(Armes[2], TransformPaumeZero.position, TransformPaumeZero.rotation);
			armeCourante.transform.parent = TransformPaumeZero;
			armeCourante.transform.localPosition = nullPosition;
			//armeCourante.transform.localRotation = nullRotation;		
			//pour l'instant je fais un test dans attaque joueur pour desactiver les inputs sur les objets utilitaires, a remanier si sélection d'emplacements par le joueur...
			setter.SetInputsArmes("");

			
		}
	}
}
