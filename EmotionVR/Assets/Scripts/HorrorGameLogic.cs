using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HorrorGameLogic : MonoBehaviour {
	public GameObject zombie;
	public GameObject player;
	public GameObject EatUI;
	public GameObject StartUI;
	public GameObject Waypoints;
	public GameObject everything;
	//private float timing;
	public bool lose;
	// Use this for initialization
	void Awake () {
		lose = false;
		//GameLogic.TimesPlayed=GameLogic.TimesPlayed+1;
		if (GameLogic.Level1TimeTaken > 0.0f && Mathf.Approximately (GameLogic.Level2TimeTaken, 0.0f)) {
			SceneManager.LoadScene ("fearlevel2");
		}
	}
	public void startLevel2() {
		SceneManager.LoadScene ("fearlevel2");
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (player.transform.forward);
		//Debug.Log(Time.realtimeSinceStartup);
		if (!lose&&zombie.GetComponent<Chase>().startGame) {
			if (zombie.GetComponent<Animator> ().GetBool ("attack")) {
				GameLogic.Level1TimeTaken = 0.0f;
				StartCoroutine (waitnow ());
			}
		}
	}
	private IEnumerator waitnow() {
		yield return new WaitForSeconds( 3.0f );
		zombie.GetComponent<Animator> ().SetTrigger ("end");
		Object.Instantiate(EatUI,player.transform.position+player.transform.forward*2,player.transform.rotation).SetActive(true);
		deactivateEverything ();
		lose = true;
	}
	public void resetScene() {
		SceneManager.LoadScene ("fear");
	}
	public void startExp() {
		SceneManager.LoadScene ("mainScene");
	}
	public void startHorror() {
		StartUI.SetActive (false);
		Waypoints.SetActive (true);
		zombie.GetComponent<Animator> ().SetBool ("walk", true);
		zombie.GetComponent<Chase>().startGame = true;
		GameLogic.Level1thistime = Time.realtimeSinceStartup;
	}
	public void deactivateEverything() {
		gameObject.GetComponent<GvrAudioSource> ().Stop ();
		everything.SetActive (false);
	}
}