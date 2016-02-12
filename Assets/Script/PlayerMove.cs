using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public float stepForward, speed;
	public GameObject explodeCube;
	public int explodeCubesCount;

	private Rigidbody rbPlayer;
	private float nextZPosition;
	private bool go, end;
	private AudioSource[] audioClips;

	// Use this for initialization
	void Start () {
		audioClips = GetComponents<AudioSource>();
		rbPlayer = GetComponent<Rigidbody>();
		nextZPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		//touch screen read
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			go = true;
			nextZPosition += stepForward;
		}
		//keyboard read
		if (Input.GetKeyDown("space")){
			go = true;
			nextZPosition += stepForward;
		}
		//movement animation
		if (go && !end){
			if (transform.position.z < nextZPosition - Time.deltaTime * speed){
				rbPlayer.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
			}
			else{
				rbPlayer.MovePosition(new Vector3(transform.position.x, transform.position.y, nextZPosition));
				foreach (GameObject mid in GameObject.FindGameObjectsWithTag("MidSpawner")){
					mid.GetComponent<MidSpawner>().DisableByZ(nextZPosition);
				}
				Score.SetScore((int)(nextZPosition + 2) / 2);
				go = false;
			}
		}
		//pause after death
		if (end && (Input.touchCount > 0 || Input.GetKeyDown("space"))) {
				Application.LoadLevel(0);
		}
		//exit application
		if (Input.GetKey("escape")){
			Application.Quit();
		}
	}

	//death or bonus pick
	public void OnTriggerEnter(Collider c){
		if (c.CompareTag("Bonus")){
			ScoreBonus.SetScore(1);
		}else{
			audioClips[0].Play();
			audioClips[1].Play();
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<BoxCollider>().enabled = false;
			for (int i = 0; i < explodeCubesCount; i++){
				Instantiate(explodeCube, transform.position, Quaternion.identity);
			}
			end = true;
		}
	}
}
