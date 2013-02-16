//arthur sore
using UnityEngine;
using System.Collections;

public class Boussole : MonoBehaviour {


	public Transform Nord;

	private float nordAngle;
	private float positionNord;
	private float vitesseBoussole;
	
	
	void Start () {
		Nord = GameObject.FindGameObjectWithTag("Nord").transform;
		nordAngle = Nord.rotation.eulerAngles.y;
		vitesseBoussole= 2.0f;
		

	}
	
	void FixedUpdate () {
		positionNord = transform.rotation.eulerAngles.y - nordAngle;
		if(positionNord < 0)
		{
			positionNord +=360;
		}

		transform.Rotate(0, positionNord , 0);
	}
}

