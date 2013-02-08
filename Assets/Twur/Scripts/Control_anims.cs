//arthur sore
using UnityEngine;
using System.Collections;

public class Control_anims : MonoBehaviour {
	
	private Animator anim; // reference du composant animator
	private AnimatorStateInfo etatCourant; // reference pour l'état courant de l'animator
	private bool _nage;
	private bool _attaqueCharge;
	private bool _attaqueCorps;
	private bool _boussole;
	
	void Start () {
		_nage = false;
		anim = GetComponent<Animator>();
	}
	
	void Update () {
	
//		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		anim.SetFloat ("Vitesse", v);
		
		_nage = gameObject.GetComponent<Nage> ().JoueurSousEau;
		_attaqueCorps = gameObject.GetComponent<AttaqueJoueur> ().EnAttaque;
		_attaqueCharge = gameObject.GetComponent<AttaqueJoueur> ().EnCharge;
		_boussole = gameObject.GetComponent<AttaqueJoueur>().Boussole;
		
		anim.SetBool("Boussole", _boussole);	
		

		if(_nage)
		{
			if(v > 0.1 && gameObject.GetComponent<Nage> ().JoueurSousEau)	{
				anim.SetBool("Nage", _nage);
			}
			else{
				_nage = false;
				anim.SetBool("Nage", _nage);
			}
				
		}
		else
		{
			anim.SetBool("Nage", false);	
		}
		
		if(_attaqueCharge)
		{
			anim.SetBool("AttaqueCharge", true);
			anim.SetBool("AttaqueCorps", false);
		}
		else if(_attaqueCorps)
		{
			anim.SetBool("AttaqueCharge", false);
			anim.SetBool("AttaqueCorps", true);		
		}
		//pour l'instant fait comme ça, si je continue sans "chargement, supprimer la premiere condition
		else if(!_attaqueCorps)
		{
			anim.SetBool("AttaqueCorps", false);	
		}
		
	}
}
