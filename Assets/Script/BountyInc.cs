using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BountyInc : MonoBehaviour {

	private static Text text;
	private static bool animating;
	private float timer;
	private static AudioSource metalhit;

	// Use this for initialization
	void Start () {
		metalhit = GetComponent<AudioSource>();
		timer = 0f;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (animating){
			timer += Time.deltaTime;
			if (timer > 1f){
				text.enabled = false;
				animating = false;
				timer = 0f;
			}
		}
	}

	public static void TextBountyInc(){
		metalhit.Play();
		animating = true;
		text.enabled = true;
	}
}
