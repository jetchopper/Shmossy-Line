using UnityEngine;
using System.Collections;

public class SuperSpawner : MonoBehaviour {

	public GameObject midSpawner;
	public int currentLevel;
	public float velocityInc;

	private GameObject bufferedMidSpawner;

	// Use this for initialization
	void Start () {
		currentLevel = 0;
		bufferedMidSpawner = (GameObject)Instantiate(midSpawner, 
		                                             transform.position + Vector3.forward * currentLevel * 40, 
		                                             Quaternion.identity);
		bufferedMidSpawner.GetComponent<MidSpawner>().minSpeed = 1 + ((currentLevel + 1) * velocityInc);
		bufferedMidSpawner.GetComponent<MidSpawner>().maxSpeed = 5 + ((currentLevel + 1) * velocityInc);
		bufferedMidSpawner.GetComponent<MidSpawner>().spawnersCount = 20;

		Respawner(20);
	}

	public void Respawner(float z){
		currentLevel++;
		bufferedMidSpawner = (GameObject)Instantiate(midSpawner, 
		                                             transform.position + Vector3.forward * currentLevel * 40, 
		                                             Quaternion.identity);
		bufferedMidSpawner.GetComponent<MidSpawner>().minSpeed = 1 + ((currentLevel + 1) * velocityInc);
		bufferedMidSpawner.GetComponent<MidSpawner>().maxSpeed = 5 + ((currentLevel + 1) * velocityInc);
		bufferedMidSpawner.GetComponent<MidSpawner>().spawnersCount = 20;
	}
}
