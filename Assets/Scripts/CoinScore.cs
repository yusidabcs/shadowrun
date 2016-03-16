using UnityEngine;
using System.Collections;

public class CoinScore : MonoBehaviour {

	public int scoreToGive;
	public AudioSource coinSound;

	private ScoreManager theScoreManager; 
	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();
		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {

			theScoreManager.AddSoul (scoreToGive);
			gameObject.SetActive (false);
			coinSound.Play ();

		}
	}
}
