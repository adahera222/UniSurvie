//arthur sore
using UnityEngine;
using System.Collections;

public class LootJoueur : MonoBehaviour {
	
	//armes
	public GameObject[] Armes;
	public Transform TransformArmeMain;
	public Transform TransformArmeDistance;
	public Transform TransformPaumeZero;
	private GameObject armeCourante;
	private Vector3 nullPosition;
	private Quaternion nullRotation;
	
	void Start () {
	
		nullPosition = new Vector3(0, 0, 0);
		nullRotation = new Quaternion(0,0,0,0);
	}
	
	void Update () {
	
		//temp avec des input en attendant un vrai loot
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}
			else {
				armeCourante = (GameObject)Instantiate(Armes[0], TransformArmeMain.position, TransformArmeMain.rotation);
				// instantie comme enfant du transform:
				armeCourante.transform.parent = TransformArmeMain;
				armeCourante.transform.localPosition = nullPosition;
				armeCourante.transform.localRotation = nullRotation;
				
			}
		}
		else if(Input.GetKeyUp(KeyCode.Alpha2))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}
			else {
				armeCourante = (GameObject)Instantiate(Armes[1], TransformArmeDistance.position, TransformArmeDistance.rotation);
				armeCourante.transform.parent = TransformArmeDistance;
				armeCourante.transform.localPosition = nullPosition;
				armeCourante.transform.localRotation = nullRotation;				
			}
		}
		else if(Input.GetKeyUp(KeyCode.B))
		{
			if(armeCourante != null)
			{
				Destroy(armeCourante);
			}
			else {
				armeCourante = (GameObject)Instantiate(Armes[2], TransformPaumeZero.position, TransformPaumeZero.rotation);
				armeCourante.transform.parent = TransformPaumeZero;
				armeCourante.transform.localPosition = nullPosition;
				//armeCourante.transform.localRotation = nullRotation;				
			}
		}
	}
}
