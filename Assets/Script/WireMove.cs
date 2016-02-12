using UnityEngine;
using System.Collections;

public class WireMove : MonoBehaviour {

	private float wireSpeed;
	private bool isMoving;

	// Use this for initialization
	void Awake () {
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		//moving always
		if (isMoving){
			transform.Translate(Vector3.right * Time.deltaTime * wireSpeed);
		}
	}

	public void Stop(){
		isMoving = false;
	}

	public void Start(){
		isMoving = true;
	}

	public void SetSpeed(float speed){
		wireSpeed = speed;
	}
}
