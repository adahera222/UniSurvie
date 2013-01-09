#pragma strict

private var caracMotor: CharacterMotor;
var niveauSousMarin = 24.5;
var graviteSousMarine = 5.0;
var graviteDefaut = 35.0;

function Start () {

	caracMotor = GetComponent (CharacterMotor);
	caracMotor.movement.gravity = graviteDefaut;
}


function Update () {
	if (transform.position.y < niveauSousMarin) {
		caracMotor.movement.gravity = graviteSousMarine;
	}
 
	else {
		caracMotor.movement.gravity = graviteDefaut;
	}
}