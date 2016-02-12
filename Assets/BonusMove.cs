using UnityEngine;
using System.Collections;

public class BonusMove : WireMove {

	public void OnTriggerEnter(Collider c){
		Destroy(gameObject);
	}
}
