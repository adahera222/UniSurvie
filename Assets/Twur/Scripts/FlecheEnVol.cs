using UnityEngine;
using System.Collections;

public class FlecheEnVol : MonoBehaviour {
	
	public float _tempsDestructionFleche;
	
	// Use this for initialization
	void Start () {
		
		Destroy(gameObject, _tempsDestructionFleche);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
