using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject thePauseMenu;


	// Use this for initialization
	public void RestartGame () {
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();
		thePauseMenu.SetActive (false);
	}

	// Use this for initialization
	public void ResumeGame () {
		Time.timeScale = 1f;
		thePauseMenu.gameObject.SetActive (false);
	}

	public void PauseGame () {
		thePauseMenu.gameObject.SetActive (true);
		Time.timeScale = 0f;	
	}

	public void QuitToMain(){
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}
}
