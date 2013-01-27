using UnityEngine;
using System.Collections;

public class Control_anims : MonoBehaviour {
	
	private Animator anim; // reference du composant animator
	private AnimatorStateInfo etatCourant; // reference pour l'état courant de l'animator
	private bool _nage;
	
	// Use this for initialization
	void Start () {
		_nage = false;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
//		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		anim.SetFloat ("Vitesse", v);
		
		_nage = gameObject.GetComponent<Nage> ().JoueurSousEau;

	
		anim.SetBool("Nage", _nage);
		
	}
}
