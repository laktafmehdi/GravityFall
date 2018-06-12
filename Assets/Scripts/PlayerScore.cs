using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerScore : MonoBehaviour {

	private Text scoreText;
	private int score = 0;
	public AudioClip coinSound;
	public AudioClip rockSound;
	public AudioClip deadSound;


	// Use this for initialization
	void Awake () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		scoreText.text = "0";
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D ( Collider2D target ) {
		if (target.tag == "Coin") {
			score++;
			scoreText.text = score.ToString ();
			this.gameObject.GetComponent<AudioSource> ().volume = 1f;
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (coinSound);
			Destroy(target.gameObject);

		}

		if (target.tag == "Mace") {
			this.gameObject.GetComponent<AudioSource> ().volume = 0.2f;
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (rockSound);
			transform.position = new Vector3 (0, 1000, 0);
			Destroy(target.gameObject);
			this.gameObject.GetComponent<AudioSource> ().Stop();
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (deadSound);
			StartCoroutine (RestartGame ());
		}


	}

	void OnTriggerExit2D ( Collider2D target ) {

		if (target.tag == "MainCamera") {
			transform.position = new Vector3 (0, 1000, 0);

			this.gameObject.GetComponent<AudioSource> ().volume = 0.2f;
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (deadSound);
			StartCoroutine (RestartGame ());
		}


	}
	
	IEnumerator RestartGame() {
		yield return new WaitForSecondsRealtime(1.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}

