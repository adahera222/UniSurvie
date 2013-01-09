using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {
	
	public GUITexture MenuDePause;
	
	public string NomSauvegarde;
	private bool _estActif;

	void Start () {
	
		MenuDePause.enabled = false;
		_estActif = false;
		
	}
	
	void Update () {
		if(MenuDePause != null){
			if(Input.GetKeyDown(KeyCode.Escape)){
				Debug.Log("Touche echap appuyee");
				if(!_estActif){
					MenuDePause.enabled = true;
					_estActif = true;
				}
				else if(_estActif){
					MenuDePause.enabled = false;
					_estActif = false;
				}
			
			}
		}// fin de if menudepause not null
		else{
		}
	}
	
	void OnGUI() {
		
		if(_estActif){
			//temporaire pour tester les fonctions de sauvegardes
			GUI.Box (new Rect (0, 0, Screen.width/2 , Screen.height/2 ), "Touche Echap");	
			
			if(GUI.Button (new Rect(20, 40, 120, 20), "Sauvegarder")) {
				Debug.Log("Bouton Sauvegarder");	
				LevelSerializer.SaveGame(NomSauvegarde);
			}
			if(GUI.Button (new Rect(20, 70, 120, 20), "Charger")) {
				Debug.Log("Bouton Charger");

			}
										GUILayout.Label("Available saved games");
				//tiré de TestSerialization (scene d'exemple de Unity Serializer.
				//Look for saved games under the given player name
				foreach(var g in LevelSerializer.SavedGames[LevelSerializer.PlayerName])
				{
					if(GUILayout.Button(g.Caption))
					{
						g.Load();
					}
					
				}
		}
	}
}
