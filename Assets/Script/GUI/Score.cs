using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = "0";
	}
	
	public static void SetScore(int i){
		text.text = "" + i;
	}
}
