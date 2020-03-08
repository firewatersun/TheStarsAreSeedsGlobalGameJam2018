using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatorMovement : MonoBehaviour {
	public float randomMinForce;
	public float randomMaxForce;
	float forcePush;
	float currentTime;
	public float pushtime;
	// Use this for initialization

	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
		Debug.Log ("touched");
		other.attachedRigidbody.WakeUp ();
		currentTime = Time.time;
		other.attachedRigidbody.drag = other.attachedRigidbody.drag / 4;
		other.attachedRigidbody.isKinematic = false;
		forcePush = Random.Range (randomMinForce, randomMaxForce);
		other.attachedRigidbody.AddForce (new Vector3 (forcePush, forcePush, forcePush));
	}

	void OnTriggerExit (Collider other){
		other.attachedRigidbody.drag = other.attachedRigidbody.drag * 4;
		if (Time.time-currentTime >= pushtime){
			other.attachedRigidbody.isKinematic = true;
		}
	}
}
