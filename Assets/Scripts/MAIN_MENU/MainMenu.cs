using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public CanvasGroup uiCanvasGroup;
	public CanvasGroup confirmQuitCanvasGroup;

	public string gameStage;
	private List<string> hints;
	public Text hintText;
	public int soundStatus;
	public AudioSource BGSound;
	public Animator soundBtn;

	void Start(){

		hints = new List<string>(new string[] { "\"Jump and collect as many soul you can.\"", "\"Use soul to unlock new cool stage.\"" });
		int selectedHint = Random.Range (0, hints.Count);
		Debug.Log (selectedHint);
		hintText.text = "" + hints[selectedHint];

		if (PlayerPrefs.GetInt ("SoundStatus") == null) {
			PlayerPrefs.SetInt ("SoundStatus", 1);
			soundStatus = 1;
		} else {
			soundStatus = PlayerPrefs.GetInt ("SoundStatus");
		}
		if (soundStatus == 1) {
			BGSound.Play ();
		}
		soundBtn.SetInteger ("SoundStatus",soundStatus);
	}
	private void Awake()
	{
		//disable the quit confirmation panel
		DoConfirmQuitNo();
	}

	void Update(){
		//exit when press back
		if (Input.GetKeyDown (KeyCode.Escape)) {

			QuitGame ();
		}



	}
	public void DoConfirmQuitNo()
	{
		Debug.Log("Back to the game");

		//enable the normal ui
		uiCanvasGroup.alpha = 1;
		uiCanvasGroup.interactable = true;
		uiCanvasGroup.blocksRaycasts = true;

		//disable the confirmation quit ui
		confirmQuitCanvasGroup.alpha = 0;
		confirmQuitCanvasGroup.interactable = false;
		confirmQuitCanvasGroup.blocksRaycasts = false;
	}

	public void DoConfirmQuitYes()
	{
		Debug.Log("Ok bye bye");
		Application.Quit();
	}

	/// <summary>
	/// Called if clicked on Quit
	/// </summary>
	public void DoQuit()
	{
		Debug.Log("Check form quit confirmation");

		//reduce the visibility of normal UI, and disable all interraction
		uiCanvasGroup.alpha = 0.5f;
		uiCanvasGroup.interactable = false;
		uiCanvasGroup.blocksRaycasts = false;

		//enable interraction with confirmation gui and make visible
		confirmQuitCanvasGroup.alpha = 1;
		confirmQuitCanvasGroup.interactable = true;
		confirmQuitCanvasGroup.blocksRaycasts = true;
	}

	/// <summary>
	/// Called if clicked on new game (example)
	/// </summary>
	public void DoNewGame()
	{
		Debug.Log("Launch a new game");
	}
	public void PlayGame () {
		Application.LoadLevel (gameStage);
	}
	
	public void QuitGame () {
		Application.Quit ();
	}

	public void SoundSetting(){
		if (soundStatus == 1) {
			BGSound.Stop ();
			soundStatus = 0;
		} else {
			BGSound.Play ();
			soundStatus = 1;
		}

		PlayerPrefs.SetInt ("SoundStatus",soundStatus);
		soundBtn.SetInteger ("SoundStatus",soundStatus);
	}
}
