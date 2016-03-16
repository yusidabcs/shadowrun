using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {

	private bool doublePoint;

	private bool powerupActive;

	private float powerupLengthCounter;

	private ScoreManager theScoreManager;
	//private PlatformGenerator thePlatformGenerator;

	private float normalPointPerSecond;
	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		//thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (powerupActive) {
			powerupLengthCounter -= Time.deltaTime;

			if (doublePoint) {
				theScoreManager.pointPerSecond = normalPointPerSecond * 5f;
			}
			if (powerupLengthCounter <= 0) {

				theScoreManager.pointPerSecond = normalPointPerSecond;
				powerupActive = false;

			}	
		}
	}

	public void ActivatePowerup(bool point, float length){
		doublePoint = point;
		powerupLengthCounter = length;

		normalPointPerSecond = theScoreManager.pointPerSecond;
		powerupActive = true;
	}
}
