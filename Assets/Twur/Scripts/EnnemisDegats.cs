using UnityEngine;
using System.Collections;

public class EnnemisDegats : MonoBehaviour {
	
	public int PointsDeVie;
	public Rigidbody EnnemiRigidbody;
	
		
	void Start () {
		
	}
	
	void Update () {
		
		

	}
	
	void OnCollisionEnter(Collision collision){
		PointsDeVie = PointsDeVie-10;	
		if(PointsDeVie <= 0)
			mort ();

	}
	
	void mort() {
		EnnemiRigidbody.isKinematic = false;
		Destroy(gameObject, 5);
	}
}
