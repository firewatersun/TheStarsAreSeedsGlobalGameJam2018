using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTracker : MonoBehaviour {
	//public List<GameObject> flowers;
	GameObject[] seeds;
	GameObject[] flowers;
	GameObject[] thorns;
	public float initialNumberOfSeeds;
	public float numberOfFlowers;
	public float numberOfThorns;
	public float checkTime;
	float currentTime;
	float currentTime2;
	public bool winState;
	public float thornInfectTime;
	public Animator winStateAnimator;
	// Use this for initialization
	void Start () {
			
			seeds = GameObject.FindGameObjectsWithTag ("seed");
			initialNumberOfSeeds = seeds.Length;
		Debug.Log ("initial seeds" + initialNumberOfSeeds);

	}
	void Update () {

		if ((Time.time-currentTime) >= checkTime) {
			currentTime = Time.time;
			flowers = GameObject.FindGameObjectsWithTag ("flower");
			numberOfFlowers = flowers.Length;
//			Debug.Log ("there are" + numberOfFlowers + "flowers");
		}

		if ((Time.time-currentTime2) >= thornInfectTime) {
			currentTime2 = Time.time;
			thorns = GameObject.FindGameObjectsWithTag ("thorn");
			numberOfThorns = thorns.Length;
			foreach (GameObject thornObject in thorns) {
				thornObject.GetComponent<InfectionScript> ().haveIInfected = false;
			}

		}


		if (numberOfFlowers >= initialNumberOfSeeds / 0.95f && numberOfThorns<=0) {
			winState = true;
			winStateAnimator.SetBool ("winState", true);
		}

	}
	// Update is called once per frame

}
