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
			//temporaire pour tester les fonctions de sauvegardes
			
			//On crée un groupe au centre de l'écran qui contiendra le menu, tant que je suis dans le groupe les coordonées du gui sont "relatives" a celui ci
			GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
			
			//La box dans le groupe
			GUI.Box (new Rect (0, 0, 100 , 100 ), "Menu");

			GUI.Box (new Rect (Screen.width/2, Screen.height/2, Screen.width/2, Screen.height/2), "Sauvegardes:");
			
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
			GUI.EndGroup ();
		}

	}
}
