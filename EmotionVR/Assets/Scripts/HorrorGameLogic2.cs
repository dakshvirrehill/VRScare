using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HorrorGameLogic2 : MonoBehaviour {

	public GameObject skeleton;
	public GameObject scarecrow;
	public GameObject player;
	public GameObject EatUI;
	public GameObject StartUI;
	public GameObject Waypoints;
	public GameObject everything;
	public GameObject campos2;
	public Animator OpenGate;
	//public GameObject Level1Logic;
	public bool lose;
	// Use this for initialization
	void Awake () {
		lose = false;

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (player.transform.forward);
		if (!lose&&skeleton.GetComponent<Chase>().startGame&&scarecrow.GetComponent<Chase>().startGame) {
			if (skeleton.GetComponent<Animator> ().GetBool ("attack")) {
				StartCoroutine (waitnow (skeleton));
			} else if (scarecrow.GetComponent<Animator> ().GetBool ("attack")) {
				StartCoroutine (waitnow (scarecrow));
			}
		}
	}
	private IEnumerator waitnow(GameObject enemy) {
		yield return new WaitForSeconds( 3.0f );
		enemy.GetComponent<Animator> ().SetTrigger ("end");
		Object.Instantiate(EatUI,player.transform.position+player.transform.forward*2,player.transform.rotation).SetActive(true);
		deactivateEverything ();
		lose = true;
	}
	public void resetScene() {
		SceneManager.LoadScene ("fearlevel2");
	}
	public void startExp() {
		SceneManager.LoadScene ("mainScene");
	}
	public void startHorror() {
		StartUI.SetActive (false);
		//Level1Logic.GetComponent<GvrAudioSource> ().Stop ();
		OpenGate.SetTrigger("open");
		iTween.MoveTo (player, iTween.Hash ("position", campos2.transform.position, "time", 5f,"oncomplete","startGame","oncompletetarget",gameObject));
		GameLogic.Level2thistime = Time.realtimeSinceStartup;
	}
	public void startGame() {
		Waypoints.SetActive (true);
		skeleton.GetComponent<Animator> ().SetBool ("walk", true);
		scarecrow.GetComponent<Animator> ().SetBool ("walk", true);
		//gameObject.GetComponent<GvrAudioSource> ().Play ();
		skeleton.GetComponent<Chase>().startGame = true;
		scarecrow.GetComponent<Chase> ().startGame = true;
	}
	public void deactivateEverything() {
		everything.SetActive (false);
	}

}
