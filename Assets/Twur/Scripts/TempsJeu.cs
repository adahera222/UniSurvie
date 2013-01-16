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
	private int _tempsReste;
	private int _tempIntSecondes;
	
	// Use this for initialization
	void Start () {
		
		//POur unity Serializer, ca evite de ré initialiser la classe
		//if(LevelSerializer.IsDeserializing) return;
			
	//	_cycleTempsScript = new CyclesTemps[soleil.Length];
		



			
	/*	
		for(int cnt = 0; cnt < soleil.Length; cnt++) {
			CyclesTemps temp = soleil[cnt].GetComponent<CyclesTemps>();
			
			if(temp == null) {
				Debug.LogWarning("Script Cycle Temps non trouvé. Ajout du script");
				soleil[cnt].AddComponent<CyclesTemps>();
				
				temp = soleil[cnt].GetComponent<CyclesTemps>();
			}
			_cycleTempsScript[cnt] = temp;
		}
		*/
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
		_tempIntSecondes =  (int) _heureDuJour;
		
		if(_heureDuJour < 3600){
			
			_tempsMinutes = (_tempIntSecondes / 60 );
			_tempsReste = ( _tempIntSecondes % 60 );
			
		}
		else if(_heureDuJour > 3600 && _heureDuJour < 86400{
			Debug.Log("Oops pas encore prévu le temps dépass");
		}
		
		HeureDuJour = (_tempMinutes.ToString() + "Min " + _tempReste.ToString() + "Sec");
		Horloge.text = HeureDuJour;
		//Debug.Log (HeureDuJour);
	}
}
