using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	// My vars
	private float speed = 3f;
	private Rigidbody2D myBody;
	public AudioClip jumpSound;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x += speed * Time.deltaTime;
		transform.position = temp;

		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void FixedUpdate(){
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.gameObject.GetComponent<AudioSource> ().volume = 0.2f;

			GetComponent<AudioSource> ().PlayOneShot (jumpSound);
			myBody.gravityScale *= -1;
			Vector3 temp = transform.localScale;
			temp.y *= -1;
			transform.localScale = temp;
		}



	}
}
