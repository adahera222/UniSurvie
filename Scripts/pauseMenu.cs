using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {
	
	private bool _navigateurSaves;
	public string NomSauvegarde;
	private bool _estActif;

	void Start () {
	
		_estActif = false;
		
	}
	
	void Update () {
			if(Input.GetKeyDown(KeyCode.Escape)){
				Debug.Log("Touche echap appuyee");
				if(!_estActif){
					_estActif = true;
				}
				else if(_estActif){
					_estActif = false;
				}
			
			}
	}
	
	void OnGUI() {
		
		if(_navigateurSaves)
		{
			GUI.BeginGroup (new Rect (Screen.width / 2 + 50, Screen.height /2 -150, Screen.width/2, 500));
			
			//tiré de TestSerialization (scene d'exemple de Unity Serializer.
			//Look for saved games under the given player name
			foreach(var g in LevelSerializer.SavedGames[LevelSerializer.PlayerName])
			{
				if(GUILayout.Button(g.Caption))
				{
					g.Load();
				}
					
			}
			GUI.EndGroup();
		}
		
		if(_estActif){
			//reactivation curseur via public bool LockCursor dans script UFPSC
			GameObject m_joueur = GameObject.FindGameObjectWithTag("Player");
			m_joueur.GetComponent<vp_FPSPlayer>().LockCursor = false;
			//temporaire pour tester les fonctions de sauvegardes
			
			//On crée un groupe au centre de l'écran qui contiendra le menu, tant que je suis dans le groupe les coordonées du gui sont "relatives" a celui ci
			GUI.BeginGroup (new Rect (Screen.width / 2 , Screen.height / 2 , Screen.width/2, Screen.height / 2));
			
			//La box dans le groupe
			//GUI.Box (new Rect (0, 0, 200 , 200 ), "Menu");

			//GUI.Box (new Rect (Screen.width/2, Screen.height/2, Screen.width/2, Screen.height/2), "Sauvegardes:");
			
			if(GUI.Button (new Rect(10, 20, 80, 30), "Sauvegarder")) {
				Debug.Log("Bouton Sauvegarder");	
				LevelSerializer.SaveGame(NomSauvegarde);
			}
			if(GUI.Button (new Rect(10, 50, 80, 30), "Charger")) {
				Debug.Log("Bouton Charger");
				
				if(!_navigateurSaves)
					_navigateurSaves = true;
				else if(_navigateurSaves)
					_navigateurSaves = false;
			}
			if(GUI.Button(new Rect(10,80,300,30), "MODE MOCHE")) {
				Debug.Log("Baisse Distance vegetation");
				Terrain.activeTerrain.detailObjectDistance = 25.0f;
				Debug.Log("Baisse densitée arbres");
				Terrain.activeTerrain.treeDistance = 15.0f;
				Terrain.activeTerrain.treeBillboardDistance = 30.0f;
				Debug.Log("Baisse densitée Veg");
				Terrain.activeTerrain.detailObjectDensity = 0.2f;
			}	
			GUI.EndGroup ();
		}
		else{
			//lock du curseur..
			GameObject m_joueur = GameObject.FindGameObjectWithTag("Player");
			m_joueur.GetComponent<vp_FPSPlayer>().LockCursor = true;
		}

	}
}
