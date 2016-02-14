using UnityEngine;
using System.Collections;

public class MidSpawner : MonoBehaviour {

	public float maxSpeed, minSpeed;
	public GameObject spawner;
	public Spawner[] spawners;
	public int spawnersCount;
	public static float bufferedSpeed;

	private GameObject bufferedSpawner;
	private Transform player;
	private SuperSpawner superSpawner;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		bufferedSpeed = 0f;
		for (int i = 0; i < spawnersCount; i++){
			bufferedSpawner = (GameObject)Instantiate (spawner, transform.position + Vector3.forward * i * 2, 
			                                           Quaternion.identity);
			bufferedSpawner.transform.parent = transform;
			bufferedSpawner.GetComponent<Spawner>().wireSpeed = i % 2 == 0 ? Random.Range(minSpeed, maxSpeed) : 
				Random.Range(-minSpeed, -maxSpeed);
			bufferedSpawner.GetComponent<Spawner>().gapSize = i % 2 == 0 ? 
				bufferedSpawner.GetComponent<Spawner>().gapSize : -bufferedSpawner.GetComponent<Spawner>().gapSize;
		}
		spawners = GetComponentsInChildren<Spawner>();
	}

	public void DisableByZ(float z){
		foreach (Spawner spawner in spawners){
			if (spawner.transform.position.z == z){
				bufferedSpeed = spawner.wireSpeed;
				spawner.StopSpawner();
			}
		}
		foreach (Spawner spawner in spawners){
			if (spawner.transform.position.z != z){
				spawner.StartSpawner(bufferedSpeed);
				if(spawner.wireSpeed < 0){
					spawner.gapSize = Mathf.Abs(spawner.gapSize) * -1;
				}else{
					spawner.gapSize = Mathf.Abs(spawner.gapSize);
				}

			}
		}
		if (player.position.z - transform.position.z > 60){
			superSpawner = FindObjectOfType (typeof(SuperSpawner)) as SuperSpawner;
			superSpawner.Respawner(transform.position.z + 40);
			PlayerMove.SetIncrement();
			Destroy(gameObject);
		}
	}
}
