using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text soulText;
	public Text highScoreText;
	public Text distanceText;

	public float scoreCount;
	public float HighScoreCount;
	public float soulCollected;
	public float allSoul;

	public float pointPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetFloat ("Max Distance") != null) {
			HighScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}

		if (PlayerPrefs.GetFloat ("allSoul") != null) {
			allSoul = PlayerPrefs.GetFloat ("allSoul");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {

			scoreCount += pointPerSecond * Time.deltaTime;
			PlayerPrefs.SetFloat ("HighScore", allSoul);
		}

		if (scoreCount > HighScoreCount) {
			HighScoreCount = scoreCount;
		}

		distanceText.text = "Distance: " + Mathf.Round( scoreCount) + " meter";
		soulText.text = ""+ Mathf.Round( soulCollected);
		highScoreText.text = "Max Distance: " + allSoul;
	}

	public void AddScore(int pointToAdd){

		scoreCount += pointToAdd;

	}

	public void AddSoul(int pointToAdd){

		soulCollected += pointToAdd;

	}

	public void GabungSoul(){
		allSoul += soulCollected;
		PlayerPrefs.SetFloat ("allSoul", allSoul);

	}
}
