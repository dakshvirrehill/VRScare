using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;
public class GameLogic : MonoBehaviour {
	public GameObject StartUI;
	public GameObject EmotionsUI;
	public static int TimesPlayed=0;
	public static float Level1TimeTaken=0.0f;
	public static float Level2TimeTaken=0.0f;
	public static float Level1thistime = 0.0f;
	public static float Level2thistime=0.0f;
	//public Text score;
	public TextMeshProUGUI score;
	//public TextContainer;
	// Use this for initialization
	void Start () {
		//score.text = getScore ();
	}
	public string getScore() {
		string s="You have played this game "+TimesPlayed+" times.\n";
		int time1 = (int)(Level1TimeTaken / 1);
		int time2 = (int)(Level2TimeTaken / 1);
		if (Mathf.Approximately(Level1TimeTaken,0.0f)&&Mathf.Approximately(Level2TimeTaken,0.0f)) {
			s = s + "You have not cleared any level yet.";
		} else if (Mathf.Approximately(Level2TimeTaken,0.0f)) {
			s = s + "You took " + time1 + " seconds to finish Level 1.\n Try Level 2.";
		} else {
			s = s + "You took " + time1 + " seconds for Level 1,\n" + time2 + " seconds for Level 2. Beat your time!";
		}
		return s;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void startGame() {
		StartUI.SetActive (false);
		EmotionsUI.SetActive (true);
		score.text = getScore ();
	}
	public void loadScene (string sceneName) {
		if (sceneName == "fear") {
			TimesPlayed=TimesPlayed+1;
		}
		SceneManager.LoadScene (sceneName);
	}
}
