using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;


	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private ObjectDestroyer[] theObjects;


	private ScoreManager theScoreManager;

	public GameObject tapToPlayButton;
	public DeathMenu theDeathMenu;
	public GameObject thePauseButton;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		//exit when press back
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("Stage_Selection");
		}
			
	}

	public void RestartGame(){

		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);

		theDeathMenu.gameObject.SetActive (true);
		thePauseButton.gameObject.SetActive (false);
		tapToPlayButton.gameObject.SetActive (false);

		theScoreManager.GabungSoul ();


		//StartCoroutine ("RestartGameCo");
	}

	public void Reset(){
		theDeathMenu.gameObject.SetActive (false);
		thePauseButton.gameObject.SetActive (true);
		theObjects = FindObjectsOfType<ObjectDestroyer> ();
		for (int i = 0; i < theObjects.Length; i++) {
			theObjects [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);

		PlayGame ();
	}

	/*public IEnumerator RestartGameCo(){

		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (1f);

		theObjects = FindObjectsOfType<ObjectDestroyer> ();
		for (int i = 0; i < theObjects.Length; i++) {
			theObjects [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);

		PlayGame ();
	}*/

	public void PlayGame(){
		thePlayer.moveSpeed = 10;
		thePlayer.jumpForce = 13;
		theScoreManager.scoreCount = 0;
		theScoreManager.soulCollected = 0;
		theScoreManager.scoreIncreasing = true;
		tapToPlayButton.gameObject.SetActive (false);
		thePauseButton.gameObject.SetActive (true);
	}
}
