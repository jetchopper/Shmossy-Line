using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static Text text;
	private static int score;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		score = 0;
	}
	
	public static void SetScore(int i){
		score += i;
		text.text = "" + score;
	}
}
