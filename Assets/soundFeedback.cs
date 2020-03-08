using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundFeedback : MonoBehaviour {
	public Animator goodSound;
	public Animator badSound;
	public Animator sunColor;
	public Animator goodLight;
	public Animator badLight;
	public FlowerTracker flowerTracker;
	float numberOfThorns;
	float numberOfFlowers;
	float numberOfSeeds;
	// Use this for initialization
	void Start () {
		flowerTracker = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<FlowerTracker> ();

	}
	
	// Update is called once per frame
	void Update () {
		numberOfSeeds = flowerTracker.initialNumberOfSeeds;
//		Debug.Log ("number of Seeds" + numberOfSeeds);
		numberOfFlowers = flowerTracker.numberOfFlowers;
//		Debug.Log ("number of Flowers" + numberOfFlowers);
		numberOfThorns = flowerTracker.numberOfThorns;
//		Debug.Log ("number of Thorns" + numberOfThorns);

		goodSound.SetFloat ("goodSound", numberOfFlowers / numberOfSeeds);
		goodLight.SetFloat ("goodLight", numberOfFlowers / numberOfSeeds);
//		Debug.Log ("goodSound volume is " + numberOfFlowers / numberOfSeeds);
		badSound.SetFloat ("badSound", numberOfThorns / numberOfSeeds);
		badLight.SetFloat ("badLight", numberOfThorns / numberOfSeeds);
		sunColor.SetFloat ("sunColor",numberOfFlowers/numberOfThorns);
	}
}
