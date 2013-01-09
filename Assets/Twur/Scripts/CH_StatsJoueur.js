#pragma strict


private var Vie : int = 100;
private var MunitionsPrincipale : int = 20;
private var MunitionsSecondaire : int = 20;
private var Argent : int = 0;
enum TypedeMunition{
Principale,
Secondaire,
};


function Start () {

}

function Update () {

}

function GetMunition(MunitionType : int){
	switch(MunitionType){
		case TypedeMunition.Principale:
			return MunitionsPrincipale;
			break;
		case TypedeMunition.Secondaire:
			return MunitionsSecondaire;
			break;
		default:
			Debug.Log ("Debug - Mauvais Type de munitions.");
	}
}

//function AddMunition(MunitionType : int , quantite : int, modifier : int){
//	switch (MunitionType)