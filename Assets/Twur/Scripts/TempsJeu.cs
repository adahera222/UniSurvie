using UnityEngine;
using System.Collections;

public class TempsJeu : MonoBehaviour {
	public Transform[] soleil;
	
	
	//Ajouté pour debug serialization du soleil, a retirer si plus besoin.
	[SerializeField]
	private CyclesTemps[] _cycleTempsScript;
	
	public float jourCycleMinutes = 1;
	
	public GUIText Horloge;
	
	private const float SECONDE = 1;
	private const float MINUTE = 60 * SECONDE;
	private const float HEURE = 60 * MINUTE;
	private const float JOUR = 24 * HEURE;
	
	private const float DEGREES_PAR_SECONDE = 360 / JOUR;
	
		//Ajouté pour debug serialization du soleil, a retirer si plus besoin.
	[SerializeField]
	private float _degreeRotation;
	
	
		//Ajouté pour debug serialization du soleil, a retirer si plus besoin.
	[SerializeField]
	private float _heureDuJour;
	public string HeureDuJour;
	
	private int _tempJours;
	private int _tempHeures;
	private int _tempMinutes;
	private int _tempReste;
	private int _tempIntSecondes;
	
	// Use this for initialization
	void Start () {
		_cycleTempsScript = new CyclesTemps[soleil.Length];
		
		for(int cnt = 0; cnt < soleil.Length; cnt++) {
			CyclesTemps temp = soleil[cnt].GetComponent<CyclesTemps>();
			
			if(temp == null) {
				Debug.LogWarning("Script Cycle Temps non trouvé. Ajout du script");
				soleil[cnt].gameObject.AddComponent<CyclesTemps>();
				
				temp = soleil[cnt].GetComponent<CyclesTemps>();
			}
			_cycleTempsScript[cnt] = temp;
		}
		
		_heureDuJour = 0;
		_degreeRotation = DEGREES_PAR_SECONDE * JOUR / (jourCycleMinutes * MINUTE);
	}
	
	// Update is called once per frame
	void Update () {
		for(int cnt = 0; cnt < soleil.Length; cnt++)
			soleil[cnt].Rotate(new Vector3(_degreeRotation, 0 ,0) * Time.deltaTime);
		
		_heureDuJour += Time.deltaTime;
		//Debug.Log (_heureDuJour);
		
		//Calcul de temps ig par moi meme
		_tempIntSecondes =  (int) _heureDuJour;
		
		if(_heureDuJour < 3600){
			_tempMinutes = (_tempIntSecondes / 60 );
			_tempReste = ( _tempIntSecondes % 60 );
		}
		else{
			Debug.Log("Oops pas encore prévu");
		}
		
		HeureDuJour = (_tempMinutes.ToString() + "Min " + _tempReste.ToString() + "Sec");
		Horloge.text = HeureDuJour;
		//Debug.Log (HeureDuJour);
	}
}
