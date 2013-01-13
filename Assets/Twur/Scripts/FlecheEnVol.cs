using UnityEngine;
using System.Collections;

public class FlecheEnVol : MonoBehaviour {
	
	public float _tempsDestructionFleche;
	//le transform au moment du tir
	private Vector3 vectorTir;
	
	private bool FlecheTiree;
	
	// Use this for initialization
	void Start () {
		
		
		FlecheTiree = false;
		vectorTir = transform.position;
		Destroy(gameObject, _tempsDestructionFleche);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(FlecheTiree)
		{
			//la fleche "regarde" dans la bonne direction (pointe devant) en vol.
			transform.LookAt(vectorTir - rigidbody.velocity);
		}
		else if (!FlecheTiree)
		{
			
		}
		else
		{
			Debug.LogError("probleme variable fleche tiree");
			return;
		}
	}
	
	void OnCollisionEnter(Collision Col) {
  		rigidbody.isKinematic =true; // stop physics
 		//transform.parent = Col.transform; // doesn't move yet, but will move w/what it hit
	}
	
	public void EstTiree(bool tir) {
		FlecheTiree = tir;
	}
}

