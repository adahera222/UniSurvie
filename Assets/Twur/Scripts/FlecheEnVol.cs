using UnityEngine;
using System.Collections;

public class FlecheEnVol : MonoBehaviour {
	
	public float _tempsDestructionFleche;
	//le transform au moment du tir
	private Vector3 vectorTir;
	private BoxCollider colliderComp;
	private bool enVol;
	
	// Use this for initialization
	void Start () {
		
		//accédé par l'arc via EstTiree
		//enVol = false;
		vectorTir = transform.position;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enVol){
			//la fleche "regarde" dans la bonne direction (pointe devant) en vol.
			transform.LookAt(vectorTir + rigidbody.velocity);
			Debug.Log("en vol");

			
		}
	}
	
	void OnCollisionEnter(Collision Col) {
		
		enVol =false;
		
		if(Col.gameObject.tag != "Player")
		{
  		rigidbody.isKinematic =true;
		transform.parent= Col.transform;
		// on desactive le collider
		colliderComp = GetComponent<BoxCollider>();
		colliderComp.enabled = false;
		
		if(Col.gameObject.tag != "ennemi"){

			Destroy(gameObject, _tempsDestructionFleche);
			}
		}
		
	}
	
	public void EstTiree(bool tir) {
		enVol = tir;
		
	}
	

}

