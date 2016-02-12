using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Material[] materials;
	public GameObject wire, bonus;
	public int amountSizes;
	public float wireSpeed, gapSize, initXScale;

	private GameObject bufferWire, asdf;
	private float timer;
	private int randInt, randMat, bonusCount;
	private bool isStopped, bonusComing;

	// Use this for initialization
	void Awake () {
		bonusCount = 10;
		timer = 0f;
		randInt = Random.Range(1, amountSizes);
		randMat = Random.Range(0, materials.Length);
	}
	
	// Update is called once per frame
	void Update () {
		//flowing if not stopped
		if (!isStopped){
			timer -= Time.deltaTime;
		}
		//process that instantiates and translates wires and bonuses, many randoms 
		if (timer < 0f){
			if (bonusCount < 0){
				bufferWire = wireSpeed >= 0 ? (GameObject)Instantiate(bonus, new Vector3(-30, transform.position.y, transform.position.z), Quaternion.identity) : 
					(GameObject)Instantiate(bonus, new Vector3(30, transform.position.y, transform.position.z), Quaternion.identity);
				bonusCount = 10;
			}else{
				bufferWire = wireSpeed >= 0 ? (GameObject)Instantiate(wire, new Vector3(-30, transform.position.y, transform.position.z), Quaternion.identity) : 
					(GameObject)Instantiate(wire, new Vector3(30, transform.position.y, transform.position.z), Quaternion.identity);
				bufferWire.transform.localScale = new Vector3(randInt * initXScale, bufferWire.transform.localScale.y, 
				                                              bufferWire.transform.localScale.z);
				bufferWire.GetComponent<Renderer>().material = materials[randMat];
			}
			bufferWire.transform.parent = gameObject.transform;
			bufferWire.GetComponent<WireMove>().SetSpeed(wireSpeed);
			timer = bufferWire.transform.localScale.x / (wireSpeed * gapSize);
			randInt = Random.Range(1, amountSizes);
			timer += randInt * initXScale / (wireSpeed * gapSize);//can't be speed 0, wires always have speed
			bonusCount--;
		}
	}
	//spawner stop
	public void StopSpawner(){
		isStopped = true;
		//spawned lines stop
		foreach(WireMove wm in GetComponentsInChildren<WireMove>()){
			wm.Stop();
			wireSpeed = 0;
		}
	}
	//spawner start
	public void StartSpawner(float bufferedSpeed){
		timer = 0.3f;
		wireSpeed -= bufferedSpeed;
		isStopped = false;
		//spawned lines start
		foreach(WireMove wm in GetComponentsInChildren<WireMove>()){
			wm.Start();
			wm.SetSpeed(wireSpeed);
		}
	}
}
