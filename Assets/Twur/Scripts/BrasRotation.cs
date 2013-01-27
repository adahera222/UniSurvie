using UnityEngine;
using System.Collections;

public class BrasRotation : MonoBehaviour {
	private Vector3 tempVect3;
	public GameObject Joueur;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(Joueur.GetComponent<Nage> ().JoueurSousEau)
		{
			transform.rotation = Camera.mainCamera.transform.rotation;	
		}

	}
}
