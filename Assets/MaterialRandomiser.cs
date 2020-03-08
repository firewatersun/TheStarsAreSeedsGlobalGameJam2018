using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomiser : MonoBehaviour {
	public List<Material> flowerMaterials;

	// Use this for initialization
	void Start () {
		int randomMat = Random.Range (1, flowerMaterials.Count);
		gameObject.GetComponent<MeshRenderer> ().material = flowerMaterials[randomMat];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
