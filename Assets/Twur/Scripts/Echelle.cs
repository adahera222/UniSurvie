//Arthur SOre
using UnityEngine;
using System.Collections;

public class Echelle : MonoBehaviour {


	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
	
		if(other.gameObject.tag == "Escalade")
		{
			transform.GetComponent<CharacterController>().slopeLimit = 91;
			transform.GetComponent<CharacterMotor>().sliding.enabled = false;
			Debug.Log("EnterEch");
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(other.gameObject.tag == "Escalade")
		{
			transform.GetComponent<CharacterController>().slopeLimit = 50;
			transform.GetComponent<CharacterMotor>().sliding.enabled = true;
			Debug.Log("ExitEch");
		}
	}
}
