using UnityEngine;
using System.Collections;

public class TirFleches : MonoBehaviour {

	public Rigidbody prefabFleche;
	public Transform cameraJoueurTransform;
	public float forceTir;
	

	
	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			//trouver comment régler ça, ajouter +90 provoque un bug lors de la rotation du transform et la fleche ne part pas toujours dans le meme sens, sans y toucher, elle part de profil.
			float tempRot = transform.rotation.z ;
			
			Rigidbody instanceFleche = (Rigidbody) Instantiate(prefabFleche, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y , tempRot));
			
			instanceFleche.AddForce(transform.forward * forceTir);
		}
	}
}
