//Trouvé sur unity wiki modifié par moi meme

//This script enables underwater effects. Attach to main camera.
 
//Define variables
var niveauSousMarin = 24.5;
var test : float;
 
//fixé par rapport au script original, on ne peut pas acceder a ces variables en dehors de la fonction start
//donc en deux temps
private var defaultFog;
private var defaultFogColor;
private var defaultFogDensity;
private var defaultSkybox;
var noSkybox : Material;
 
function Start () {
	//Set the background color
	camera.backgroundColor = Color (0, 0.4, 0.7, 1);
	
	defaultFog = RenderSettings.fog;
	defaultFogColor = RenderSettings.fogColor;
	defaultFogDensity = RenderSettings.fogDensity;
	defaultSkybox = RenderSettings.skybox;
}
 
function Update () {
	if (transform.position.y < niveauSousMarin) {
		RenderSettings.fog = true;
		RenderSettings.fogColor = Color (0, 0.4, 0.7, 0.6);
		RenderSettings.fogDensity = 0.04;
		RenderSettings.skybox = noSkybox;
	}
 
	else {
		RenderSettings.fog = defaultFog;
		RenderSettings.fogColor = defaultFogColor;
		RenderSettings.fogDensity = defaultFogDensity;
		RenderSettings.skybox = defaultSkybox;
	}
}