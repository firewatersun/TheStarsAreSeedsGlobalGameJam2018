using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionScript : MonoBehaviour {
	float currentTime;
//	public float flowerInfectTime;
//	public float thornInfectTime;
	public Collider[] colliderstoinfect;
	public bool haveIInfected;
//	public bool waiting;
	// Use this for initialization
	void Start () {
//		currentTime = Time.time;
		haveIInfected = false;
	}
	
	// Update is called once per frame
	void Update () {


		//if thorn
		if (gameObject.tag == "thorn" && haveIInfected == false) {
//			Debug.Log ("infection spread at" + Time.time);

			int whichCollider = Random.Range (0, colliderstoinfect.Length);
			colliderstoinfect = Physics.OverlapSphere (gameObject.transform.position, 1.8f * gameObject.GetComponent<flowerTransmission> ().activationRadius);
			
			colliderstoinfect [whichCollider].GetComponent<flowerTransmission> ().iAmInfected = true;
			
			haveIInfected = true;

		}


			
	}

//	IEnumerator infectOthers () {
//
//	
//			int whichCollider = Random.Range (0, colliderstoinfect.Length);
//			colliderstoinfect = Physics.OverlapSphere (gameObject.transform.position, 1.8f * gameObject.GetComponent<flowerTransmission> ().activationRadius);
//
//			colliderstoinfect [whichCollider].GetComponent<flowerTransmission> ().iAmInfected = true;
//
//			Debug.Log ("infection spread at" + Time.time);
//			haveIInfected = true;
//
//		yield return new WaitForSeconds(thornInfectTime);
//	}
//
//	IEnumerator countDown () {
//		haveIInfected = false;
//		yield return new WaitForSeconds(thornInfectTime);
//	}

}
