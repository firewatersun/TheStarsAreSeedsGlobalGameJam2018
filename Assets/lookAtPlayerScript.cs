using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayerScript : MonoBehaviour {
	public GameObject sun;

	// Use this for initialization
	void Start () {
		sun = GameObject.FindGameObjectWithTag("sun");
		transform.LookAt (sun.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (sun.transform.position);
	}
}
