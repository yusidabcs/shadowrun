using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour {

	public GameObject[] theStages;
	private int stageSelector = 0;
	List<Animator> anims;

	public GameObject leftBtn;
	public GameObject rightBtn;

	public Light lt;

	private Color[] colors;
	private List<string> names = new List<string>();
	private List<string> unlockStages = new List<string>();

	public Text allSoulText;
	private float allSoul;

 	// Use this for initialization
	void Start () {
		allSoul = PlayerPrefs.GetFloat ("allSoul");
		allSoulText.text = "" + allSoul;

		// check unclock stage
		if (PlayerPrefsX.GetStringArray ("StageListUnlockx").Length == 0) {
			unlockStages.Add(theStages [0].transform.name);
			if (!PlayerPrefsX.SetStringArray ("StageListUnlockx", unlockStages.ToArray()))
				Debug.Log ("Can't save names");
		}



		for (int i = 0; i < theStages.Length; i++) {
			names.Add(theStages [i].transform.name);
		}

		if (!PlayerPrefsX.SetStringArray ("StageListx", names.ToArray()))
			Debug.Log ("Can't save names");
		
		string[] rs = PlayerPrefsX.GetStringArray ("StageListUnlockx");

		for (int i = 0; i < names.Count; i++) {

			for (int x = 0; x < rs.Length; x++) {
				if (rs [x] == names [i]) {
					theStages [i].transform.FindChild ("Unlock").gameObject.SetActive (false);
					theStages [i].transform.FindChild ("Stage_Info").gameObject.SetActive (false);
					theStages [i].transform.FindChild ("Play").gameObject.SetActive (true);
				}
			}

		}

		for (int i = 0; i < theStages.Length; i++) {

			if (i == stageSelector) {
				Animator anim = theStages [stageSelector].GetComponent<Animator>();
				anim.SetBool ("Center",true);
				anim.SetBool ("Left",false);
				anim.SetBool ("Right", false);
			} else {
				Animator anim = theStages [i].GetComponent<Animator>();
				anim.SetBool ("Center",false);
				anim.SetBool ("Left",false);
				anim.SetBool ("Right", true);
				theStages [i].SetActive (true);
			}

		}


		if (stageSelector == 0) {
			rightBtn.SetActive (false);
		}else{
			rightBtn.SetActive (true);
		}

		if (stageSelector == theStages.Length - 1) {
			leftBtn.SetActive (false);
		}else{
			leftBtn.SetActive (true);
		}


		lt = lt.GetComponent<Light> ();

		colors = new Color[theStages.Length];
		colors[0] = hexToColor("1D8EFFFF");
		colors[1] = hexToColor("F71E1EFF");
		colors[2] = hexToColor("1EF7EEFF");
		lt.color = colors [0];
	}
	
	// Update is called once per frame
	void Update () {

		//exit when press back
		if (Input.GetKeyDown (KeyCode.Escape)) {

			backMainMenu ();
		}


		if (stageSelector == 0) {
			rightBtn.SetActive (false);
		}else{
			rightBtn.SetActive (true);
		}

		if (stageSelector == theStages.Length - 1) {
			leftBtn.SetActive (false);
		}else{
			leftBtn.SetActive (true);
		}


	}

	public void SlideLeft(){


		GameObject obj = theStages [stageSelector];

		Animator anim = obj.GetComponent<Animator>();
		anim.SetBool ("Center",false);
		anim.SetBool ("Left",true);
		anim.SetBool ("Right", false);


		stageSelector += 1;

		if (stageSelector == theStages.Length) {
			stageSelector = theStages.Length-1;
		}

		GameObject obj2 = theStages [stageSelector];
		Animator anim2 = obj2.GetComponent<Animator>();
		anim2.SetBool ("Center",true);
		anim2.SetBool ("Left",false);
		anim2.SetBool ("Right",false);

		//obj.SetActive (false);

		lt.color = colors[stageSelector];


	}

	public void SlideRight(){
		GameObject obj = theStages [stageSelector];

		Animator anim = obj.GetComponent<Animator>();
		anim.SetBool ("Center",false);
		anim.SetBool ("Left",false);
		anim.SetBool ("Right", true);



		stageSelector -= 1;

		if (stageSelector < 0) {
			stageSelector = 0;
		}
		GameObject obj2 = theStages [stageSelector];
		Animator anim2 = obj2.GetComponent<Animator>();
		anim2.SetBool ("Center",true);
		anim2.SetBool ("Left",false);
		anim2.SetBool ("Right",false);
		lt.color = colors[stageSelector];
	}

	public void LoadScene(string level){
		Application.LoadLevel (level);
	}

	public void backMainMenu(){
		Application.LoadLevel ("Main_Menu");
	}
	public static Color hexToColor(string hex)
	{
		hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
		hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
		byte a = 255;//assume fully visible unless specified in hex
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		//Only use alpha if the string has enough characters
		if(hex.Length == 8){
			a = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}

}
