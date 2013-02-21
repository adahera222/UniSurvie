//Arthur SOre
using UnityEngine;
using System.Collections;

public class Echelle : MonoBehaviour {

	public float VitesseEchelle;
	public Transform HautEchelle;
	
	private bool escalade;
	private Vector3 echelleMonte;
	
	void Start () {
		escalade = false;
	}
	
	void Update () {
		
		if(escalade)
		{
			CharacterController controller = GetComponent<CharacterController>();
			
			//controller.radius = 0.0f;
			//controller.center = new Vector3 (0,0,-0.5f);
			if(Input.GetAxis("Vertical")>0.1f){
				
			echelleMonte = new Vector3(0, Input.GetAxis("Horizontal"),0);
				
				echelleMonte.y += VitesseEchelle * Time.deltaTime;
				controller.Move(echelleMonte);
				
			//	transform.GetComponent<CharacterController>().Move(Vector3.Lerp(transform.position, Vector3.up, Time.deltaTime*VitesseEchelle));
				//transform.rigidbody.AddForce(echelleMonte * VitesseEchelle);
			}
			
		}
		else
		{

		}
	
	}
	
	void OnTriggerEnter (Collider other) {

		if(other.gameObject.CompareTag("Escalade"))
		{
							Debug.Log("EnterEch");
		}
	}
	void OnTriggerStay (Collider other) {
	
	if(escalade == false){
		if(other.gameObject.CompareTag("Escalade"))
		{
			escalade = true;
		}
			
		}
	}
	
	void OnTriggerExit (Collider other) {
		

		if(other.gameObject.CompareTag("Escalade"))
		{
					Debug.Log("ExitEch");
			
			escalade = false;

		}
	}
}
