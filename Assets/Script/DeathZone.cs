﻿using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	public void OnTriggerEnter(Collider c){
		Destroy(c.gameObject);
	}
}
