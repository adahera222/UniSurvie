//arthur sore
using UnityEngine;
using System.Collections;

public class Control_anims : MonoBehaviour {
	
	private Animator anim;
	private AnimatorStateInfo etatCourant; // reference pour l'état courant de l'animator
	private bool _nage;
	private bool _attaqueCharge;
	private bool _attaqueCorps;
	private bool _boussole;
	private bool _attaqueArcCharge;
	private bool _attaqueArcTir;
	
	void Start () {
		_nage = false;


	}
	
	void Update () {
		
		anim = transform.GetComponent<Animator>();

		
//		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		anim.SetFloat ("Vitesse", v);
		
		_nage = transform.root.GetComponent<Nage> ().JoueurSousEau;
		_attaqueCorps = transform.root.GetComponent<AttaqueJoueur> ().AttaqueCac;
		_attaqueCharge = transform.root.GetComponent<AttaqueJoueur> ().ChargeCac;
		_boussole = transform.root.GetComponent<AttaqueJoueur>().VueBoussole;
		_attaqueArcCharge = transform.root.GetComponent<AttaqueJoueur>().TirArc;
		_attaqueArcTir = transform.root.GetComponent<AttaqueJoueur>().TirArcRelache;
		
		
		anim.SetBool("Boussole", _boussole);	
		

		if(_nage)
		{
			if(v > 0.1 && gameObject.transform.root.GetComponent<Nage> ().JoueurSousEau)	{
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
		//pour l'instant fait comme ça, si je continue sans "chargement des attaques, supprimer la premiere condition
		else if(!_attaqueCorps)
		{
			anim.SetBool("AttaqueCorps", false);	
		}
		//arc présent car préalablement testé dans AttaqueJoueur
		if (_attaqueArcCharge)
		{
			anim.SetBool("AttaqueArcCharge", true);
			anim.SetBool("AttaqueArcTir", false);
		}
		else if (_attaqueArcTir)
		{
			anim.SetBool("AttaqueArcCharge", false);
			anim.SetBool("AttaqueArcTir", true);
			gameObject.transform.root.GetComponent<AttaqueJoueur>().TirArc = false;
			
		}
		
	}
	

}
