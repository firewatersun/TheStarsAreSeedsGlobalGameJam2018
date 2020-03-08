using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour {
	public List<GameObject> flowerTypes;
	public GameObject currentFlower;
	public GameObject rangeFinder;
	int randomFlowerCount;
	public int maxFlowerCount;
	int currentFlowercount;
	public float minDistance;
	public float maxDistance;
	float spawnDistance;
	public float minXRotation;
	public float minYRotation;
	public float maxYRotation;
	public float maxXRotation;
	float XRot;
	float YRot;
	// Use this for initialization
	void Start () {
		currentFlowercount = 0;
		for (currentFlowercount = 0; currentFlowercount<maxFlowerCount; currentFlowercount++) {
			randomFlowerCount = Random.Range (0, flowerTypes.Count);
			spawnDistance = Random.Range (minDistance, maxDistance);
			XRot = Random.Range (minXRotation, maxXRotation);
			YRot = Random.Range (minXRotation, maxXRotation);
			gameObject.transform.rotation = new Quaternion(XRot, YRot, gameObject.transform.eulerAngles.z, 0);
			rangeFinder.transform.localPosition = new Vector3 (rangeFinder.transform.localPosition.x,rangeFinder.transform.localPosition.y, spawnDistance);
			Instantiate (flowerTypes [randomFlowerCount], rangeFinder.transform.position, Quaternion.identity);
//			flowerTypes [randomFlowerCount].transform.parent = gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
