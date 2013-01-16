using UnityEngine;
using System.Collections;

[SerializeAll]
public class TempsJeu : MonoBehaviour {
	public GameObject Soleil;
	
	

	//private CyclesTemps[] _cycleTempsScript;
	
	public float jourCycleMinutes = 1;
	
	public GUIText Horloge;
	
	private const float SECONDE = 1;
	private const float MINUTE = 60 * SECONDE;
	private const float HEURE = 60 * MINUTE;
	private const float JOUR = 24 * HEURE;
	
	private const float DEGREES_PAR_SECONDE = 360 / JOUR;
	

	private float _degreeRotation;
	
	

	public float _heureDuJour;
	public string HeureDuJour;
	
	private int _tempsJours;
	private int _tempsHeures;
	private int _tempsMinutes;
	private int _tempsResteSec;
	private int _tempsResteMin;
	private int _tempsResteHeures;	
	private int _tempsIntSecondes;
	
	// Use this for initialization
	void Start () {
		

		_heureDuJour = 0;
		_degreeRotation = DEGREES_PAR_SECONDE * JOUR / (jourCycleMinutes * MINUTE);
	}
	
	// Update is called once per frame
	void Update () {
		//for(int cnt = 0; cnt < soleil.Length; cnt++)
			//soleil[cnt]
		Soleil.transform.Rotate(new Vector3(_degreeRotation, 0 ,0) * Time.deltaTime);
		
		_heureDuJour += Time.deltaTime;
		//Debug.Log (_heureDuJour);
		
		//Calcul de temps ig par moi meme
		_tempsIntSecondes =  (int) _heureDuJour;
		
		//si moins d'une heure de jeu écoulée
		if(_heureDuJour < 3600){
			
			_tempsMinutes = (_tempsIntSecondes / 60 );
			
			//modulo pour le reste des secondes
			_tempsResteSec = ( _tempsIntSecondes % 60 );
			
		}
		//si plus d'une heure et moins d'un jour de jeu écoulé
		else if(_heureDuJour > 3600 && _heureDuJour < 86400){
			_tempsMinutes = (_tempsIntSecondes / 60 );
			_tempsHeures = (_tempsMinutes /60);
			
			//calcul des modulos minutes pour avoir un résultat correct a l'affichage
			_tempsResteSec = ( _tempsIntSecondes % 60 );
			
		}
		else if(_heureDuJour > 86400){
			
			//Une fois déterminé le nombre de minutes, on peut calculer le nombre d'heures et une fois le nombre d'heures acquis.. etc.
			_tempsMinutes = (_tempsIntSecondes / 60 );
			_tempsHeures = (_tempsMinutes / 60);
			_tempsJours = (_tempsHeures / 24);
			
			//calcul des modulos..
			_tempsResteSec = ( _tempsIntSecondes % 60 );

		}
		else
		{
			Debug.LogError("Problème dans le calcul du temps en jeu écoulé (script: TempsJeu.cs)");
		}
		
		
		HeureDuJour = (_tempsMinutes.ToString() + "Min " + _tempsResteSec.ToString() + "Sec");
		Horloge.text = HeureDuJour;
		//Debug.Log (HeureDuJour);
	}
}
