using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D ( Collider2D target ) {
		if (target.tag == "Player") {
			this.gameObject.GetComponent<AudioSource> ().Play ();

		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
