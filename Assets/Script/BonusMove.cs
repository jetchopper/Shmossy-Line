using UnityEngine;
using System.Collections;

public class BonusMove : WireMove {

	public float rotSpeed, fadeSpeed;

	private Renderer rend;
	private AudioSource bonusPick;
	private bool fading, goingUp;

	public override void Awake(){
		rend = GetComponent<Renderer>();
		bonusPick = GetComponent<AudioSource>();
	}

	public override void Update(){
		base.Update();
		//make it spin
		transform.Rotate(Vector3.right * rotSpeed);
		//blinking
		if (fading){
			rend.material.color -= Color.black * fadeSpeed;
			if (rend.material.color.a <= 0.3f){
				fading = false;
			}
		}else{
			rend.material.color += Color.black * fadeSpeed;
			if (rend.material.color.a >= 1f){
				fading = true;
			}
		}
		//flying up after picking
		if (goingUp){
			transform.Translate(Vector3.up * 0.5f, Space.World);
		}
	}

	public void OnTriggerEnter(Collider c){
		if (c.CompareTag("Player")){
			bonusPick.Play();
			goingUp = true;
			Destroy(gameObject, 3f);
		}else{
			Destroy(gameObject);
		}
	}
}
