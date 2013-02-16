//Merci a http://answers.unity3d.com/questions/164638/how-to-make-the-fps-character-controller-run-and-c.html
// code trouvé sur answers par Aldo Naletto, modifié par moi même

//upd - a refaire en cs
var walkSpeed: float = 4; // Vitesse normale
var crchSpeed: float = 2; // Vitesse accroupis
var runSpeed: float = 8; // Vitesse de course

private var chMotor: CharacterMotor;
private var ch: CharacterController;
private var tr: Transform;
private var height: float; // Taille initiale

function Start(){
    chMotor = GetComponent(CharacterMotor);
    tr = transform;
    ch = GetComponent(CharacterController);
	height = ch.height;
}

function Update(){

    var h = height;
    var speed = walkSpeed;
    
    //rajouter ch.isGrounded si besoin mails je veux une vitesse normale en saut pour le moment
    if (Input.GetKey("left shift") || Input.GetKey("right shift")){
        speed = runSpeed;
    }
    if (Input.GetKey("c")){ // "c" pour s'accroupir
        h = 0.5 * height;
        speed = crchSpeed; // Ralentir quand accroupis
    }
    chMotor.movement.maxForwardSpeed = speed; // Set la vitesse max
    chMotor.movement.maxBackwardsSpeed = speed; // Set la vitesse max
    chMotor.movement.maxSidewaysSpeed = speed; // Set la vitesse max

    var lastHeight = ch.height; // S'accroupir et se relever doucement
    ch.height = Mathf.Lerp(ch.height, h, 5*Time.deltaTime);
    tr.position.y += (ch.height-lastHeight)/2; // fix vertical position
}