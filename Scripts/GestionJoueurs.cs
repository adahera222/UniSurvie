//arthur sore
//Script attaché a l'objet MaitreDuJeu, sert a gérer toutes les variables des joueurs.
//Pas attaché au joueur pour pouvoir sérializer toutes les infos plus facilement et si mode multijoueur un jour 


using UnityEngine;
using System.Collections;


public class GestionJoueurs : MonoBehaviour {
	
	//prevu pour etre accédé pour la médecine, les dégats
	public float ModifieurVieParSeconde;
	//exemple 0.02 pour 2% par sec ou 0.1 pour 10%, idem * (-0.02)...
	public float MultiplicateurVieParSeconde;
	public bool BoolModVps;
	public bool BoolMulVps;
	// pour l'instant single player je me contente d'une référence au joueur via l'inspector d'unity
	public GameObject JoueurGameObject;
	//public pour le moment a fins de debug, a voir plus tard si utile..
	public float _pvJoueur;
	
	
	
	void Start () {
		BoolModVps = false;
		BoolMulVps = false;
		MultiplicateurVieParSeconde = 0.0f;
		ModifieurVieParSeconde = 0.0f;
		// partie qu'il faudra modifier vis a vis de la sauvegarde
		_pvJoueur = 100.0f;
	}
	
	void Update () {
	
		if(_pvJoueur <= 0.0f)
		{
			// mort du joueur
			Destroy(JoueurGameObject);
		}
		else
		{	//activation ou non du modificateur
			if(BoolModVps)
			{
				_pvJoueur = _pvJoueur + (ModifieurVieParSeconde*Time.deltaTime);
			}
			else{
			}
			//activation ou non du multiplicateur
			if(BoolMulVps)
			{
				_pvJoueur = _pvJoueur+(_pvJoueur * (MultiplicateurVieParSeconde*Time.deltaTime));
			}
			else
			{
				}

		}
	}
	//setters et getters
	public float getPvJoueur () {
		return _pvJoueur;
	}
	
	public void setPvJoueur (float pv) {
		_pvJoueur = pv;	
	}
	
	public float getModifieurVps () {
		return ModifieurVieParSeconde;	
	}
	
	public void setModifieurVps (float modVps) {
		ModifieurVieParSeconde = modVps;
	}
	
	public float getMultiplicateurVps () {
		return MultiplicateurVieParSeconde;
	}
	
	public void setMultiplicateurVps (float mulVps) {
		MultiplicateurVieParSeconde = mulVps;
	}
	
}
