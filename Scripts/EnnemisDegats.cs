//arthur sore

using UnityEngine;
using System.Collections;

public class EnnemisDegats : MonoBehaviour {
	
	public int PointsDeVie;
	
		
	void Start () {
		
	}
	
	void Update () {
		
		

	}
	
	//collision réglée via les layers physiques
	void OnCollisionEnter(Collision collision){
		PointsDeVie = PointsDeVie-10;	
		if(PointsDeVie <= 0)
			mort ();
	}
	
	void mort() {
		rigidbody.isKinematic = false;
		Destroy(gameObject, 5);
	}
}
