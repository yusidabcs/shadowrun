using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class UnlockStage : MonoBehaviour {

	public GameObject theStage;
	public Text allSoulText;
	public float needSoul;
	private float allSoul;
	private List<string> unlockStage = new List<string>();
	Button myButton;

	void Awake()
	{
		allSoul = PlayerPrefs.GetFloat ("allSoul");
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(delegate{UnlockStages(theStage,needSoul);});
	}

	void UnlockStages(GameObject stage, float soul)
	{

		if (allSoul < soul) {
			Debug.Log ("Soul not enough");
		} else {
			string[] rs  = PlayerPrefsX.GetStringArray ("StageListUnlockx");
			for(int i = 0;i<rs.Length;i++){
				unlockStage.Add (rs [i]);
			}
			unlockStage.Add (stage.transform.name);

			if (!PlayerPrefsX.SetStringArray ("StageListUnlockx", unlockStage.ToArray()))
				Debug.Log ("Can't save names");

			stage.transform.FindChild ("Unlock").gameObject.SetActive (false);
			stage.transform.FindChild ("Stage_Info").gameObject.SetActive (false);
			stage.transform.FindChild ("Play").gameObject.SetActive (true);
			allSoul = allSoul - needSoul;
			allSoulText.text = "" + allSoul;
			PlayerPrefs.SetFloat ("allSoul", allSoul);
		}

	}


}
