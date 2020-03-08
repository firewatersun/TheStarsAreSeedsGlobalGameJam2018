using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerTransmission : MonoBehaviour {
	public bool activated;
	public bool iAmFlower;
//	public bool iAmThorn;
//	public bool shouldIBeThorn;
	public float thornProbModifier;
	float totalNumberOfFlowers;
	float probabilityOfThorn;
	public GameObject flowerMesh;
//	public GameObject thornMesh;
	public Animator flowerAnim;
	public float activationRadius;
	public float activationIterations;
	float activations;
	float initialActivationIterations;
	public Collider[] hitColliders;
	public Material seedMat;
	public Material thornMat;
	public Material flowerMat;
	public Material flowerMat2;
	public Material flowerMat3;
	public bool iAmInfected;
	public FlowerTracker flowerTracker;
	public ParticleSystem thornParticle;
	public ParticleSystem flowerParticle;

//	public float transmissionTime;
	// Use this for initialization

	void Start(){
		gameObject.transform.parent = GameObject.FindGameObjectWithTag ("rotator").transform;
		initialActivationIterations = activationIterations;
		flowerTracker = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<FlowerTracker> ();
//		thornParticle = gameObject.GetComponentInChildren<ParticleSystem> ();
		thornParticle.Stop();
		flowerParticle.Stop ();
	}

	void Update () {

		if (activated == true) {
			totalNumberOfFlowers = flowerTracker.numberOfFlowers;
			probabilityOfThorn = Random.Range (0, (Mathf.Abs(flowerTracker.initialNumberOfSeeds-flowerTracker.numberOfFlowers)*thornProbModifier));
//						Debug.Log ("probability of Thorn" + probabilityOfThorn);
			flowerAnim.SetBool ("activated", true);
			if (probabilityOfThorn>= 0 && probabilityOfThorn<=1){
				iAmFlower = false;

			}

			if (probabilityOfThorn>1){
				iAmFlower = true;
				//				Debug.Log ("I am flower");
			}

			if (iAmFlower == false){
//				iAmThorn = true;
//				iAmFlower = false;
				gameObject.tag = "thorn";
//				flowerMesh.SetActive (false);
//				thornMesh.SetActive (true);
				flowerAnim.SetBool ("thorn", true);
				flowerMesh.GetComponent<Renderer> ().material = thornMat;
//				gameObject.GetComponent<MeshRenderer> ().enabled = false;
				hitColliders = Physics.OverlapSphere (gameObject.transform.position, activationRadius);
				StartCoroutine ("ActivateOthers");
				activated = false;
				thornParticle.Play();
				flowerParticle.Stop ();
		
//				Debug.Log ("total Number of Flowers" + flowerTracker.numberOfFlowers);
			}
			if (iAmFlower == true) {
//				iAmThorn = false;
//				iAmFlower = true;
				gameObject.tag = "flower";
//				flowerMesh.SetActive (true);
//				thornMesh.SetActive (false);
				flowerAnim.SetBool ("thorn", false);
				int randomMat = Random.Range (1, 3);
				if (randomMat == 1) {
					flowerMesh.GetComponent<Renderer> ().material = flowerMat;
				}
				if (randomMat == 2) {
					flowerMesh.GetComponent<Renderer> ().material = flowerMat2;
				}
				if (randomMat == 3) {
					flowerMesh.GetComponent<Renderer> ().material = flowerMat3;
				}
//				gameObject.GetComponent<MeshRenderer> ().enabled = false;
				hitColliders = Physics.OverlapSphere (gameObject.transform.position, activationRadius);
				StartCoroutine ("ActivateOthers");
				activated = false;
				thornParticle.Stop();
				flowerParticle.Play ();
		
//				Debug.Log ("total Number of Flowers" + flowerTracker.numberOfFlowers);
			}


		}

		if (iAmInfected == true){
	
			iAmFlower = false;
			gameObject.tag = "thorn";

			flowerAnim.SetBool ("thorn", true);
			flowerMesh.GetComponent<Renderer> ().material = thornMat;

			hitColliders = Physics.OverlapSphere (gameObject.transform.position, activationRadius);
			StartCoroutine ("ActivateOthers");
			activated = false;


		}
		if (iAmInfected = false && iAmFlower == true) {

			gameObject.tag = "flower";
	
			flowerAnim.SetBool ("thorn", false);
			int randomMat = Random.Range (1, 3);
			if (randomMat == 1) {
				flowerMesh.GetComponent<Renderer> ().material = flowerMat;
			}
			if (randomMat == 2) {
				flowerMesh.GetComponent<Renderer> ().material = flowerMat2;
			}
			if (randomMat == 3) {
				flowerMesh.GetComponent<Renderer> ().material = flowerMat3;
			}
			//				gameObject.GetComponent<MeshRenderer> ().enabled = false;
			hitColliders = Physics.OverlapSphere (gameObject.transform.position, activationRadius);
			StartCoroutine ("ActivateOthers");
			activated = false;

			//				Debug.Log ("total Number of Flowers" + flowerTracker.numberOfFlowers);
		}

		if (activationIterations <= 0 && activated == false) {
			activationIterations = 1;
		}

	}
	

	IEnumerator ActivateOthers () {
//		Debug.Log ("activating closeby seeds");
//		Debug.Log ("hitColliders.Length" + hitColliders.Length);
		float activationNumber = activationIterations*hitColliders.Length;
		for (int i = 0 ; i<=hitColliders.Length; i++){
			
//			Debug.Log ("For Loop Running");
			if (iAmFlower == true) {
				if (activationNumber >= 1 && hitColliders[i].tag == "seed") {
					
//					Debug.Log ("flower activated others");
					hitColliders[i].GetComponent<flowerTransmission> ().activationIterations = activationIterations-1;
					hitColliders[i].GetComponent<flowerTransmission> ().activated = true;
					activationNumber--;
				}
			}

//			if (iAmFlower == false) {
//				if (activationNumber >= 1 && hitColliders[i].tag !="thorn") {
////					Debug.Log ("thorn activated others");
//					hitColliders[i].GetComponent<flowerTransmission> ().activationIterations = activationIterations-1;
//					hitColliders [i].GetComponent<flowerTransmission> ().activated = true;
//		
//					hitColliders [i].GetComponent<flowerTransmission> ().iAmFlower = false;
//		
//
//
//					activationNumber--;
//				}
//			}
				
		}


		yield return null;
	}

}
	