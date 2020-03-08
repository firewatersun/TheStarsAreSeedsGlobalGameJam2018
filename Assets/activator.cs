using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour {
	public float activationTime;
	float currentTime;
	public Material selectedMat;
	public Material deselectedMat;

	// Use this for initialization
	void Start () {
		currentTime = Time.time;
	}

	void Update(){
		if (OVRInput.Get (OVRInput.Button.One, OVRInput.Controller.RTouch) == true) {
			gameObject.GetComponent<MeshRenderer> ().material = selectedMat;
		}
		if (OVRInput.Get (OVRInput.Button.One, OVRInput.Controller.RTouch) == false) {
			gameObject.GetComponent<MeshRenderer> ().material = deselectedMat;
		}
	}

	void OnTriggerEnter (Collider col){
		currentTime = Time.time;
	}

	// Update is called once per frame
	void OnTriggerStay (Collider col) {
		if (Time.time-currentTime >=activationTime && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) == true) {
//			gameObject.GetComponent<MeshRenderer> ().material = selectedMat;
//			if (Time.time - currentTime >= activationTime) {
				Debug.Log ("activating");
				col.gameObject.GetComponent<flowerTransmission> ().activated = true;
//			}
			if (col.gameObject.tag == "thorn"){
				col.gameObject.GetComponent<flowerTransmission> ().iAmInfected = false;

				col.gameObject.GetComponent<flowerTransmission> ().iAmFlower = true;
				currentTime = Time.time;
			}
		}
	}
}
