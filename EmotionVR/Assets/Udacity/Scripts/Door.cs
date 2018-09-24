using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;
public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 
	public bool locked=true;
	public bool opening=false;
	public AudioClip[] opennlock;
	public GvrAudioSource soundSource;
	public GameObject player;
	public GameObject SafeUIpos;
	public GameObject SafeUI;
	public GameObject HorrorLogic;
	public TextMeshProUGUI score;
    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
		if (opening) {
			if (transform.position.y < 8.8) {
				transform.Translate (0, 2.5f * Time.deltaTime, 0, Space.World);
				iTween.MoveTo (player, iTween.Hash ("position",SafeUIpos.transform.position,"time",3f,"onstart","setSafeUIActive","onstarttarget",gameObject,"oncomplete","deacti","oncompletetarget",gameObject));	
			}
		}
    }
	public void setSafeUIActive() {
		SafeUI.SetActive (true);
		if (SceneManager.GetActiveScene ().name == "fearlevel2") {
			level2Complete ();
			int timelevel2 = (int)(GameLogic.Level2TimeTaken / 1);
			score.text = "You took " + timelevel2 + " seconds to complete this level.";
		} else {
			startlevel2 ();
			int timelevel1 = (int)(GameLogic.Level1TimeTaken / 1);
			score.text = "You took " + timelevel1 + " seconds to complete this level.";
		}
	}
	public void level2Complete() {
		float t = Time.realtimeSinceStartup - GameLogic.Level2thistime;
		if ((!Mathf.Approximately(GameLogic.Level2TimeTaken, 0.0f) && GameLogic.Level2TimeTaken > t)||Mathf.Approximately(GameLogic.Level2TimeTaken,0.0f)) {
			GameLogic.Level2TimeTaken = t;
		}
	}
	public void startlevel2() {
		float t = Time.realtimeSinceStartup - GameLogic.Level1thistime;
		if ((!Mathf.Approximately(GameLogic.Level1TimeTaken, 0.0f) && GameLogic.Level1TimeTaken > t)||Mathf.Approximately(GameLogic.Level1TimeTaken,0.0f)) {
			GameLogic.Level1TimeTaken = t;
		}
	}
    public void OnDoorClicked() {
        // If the door is clicked and unlocked
		if (!locked) {
			opening = true;
			soundSource.PlayOneShot(opennlock [1]);

		} else {
			soundSource.PlayOneShot(opennlock [0]);
		}
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
		locked=false;
    }
	public void deacti() {
		HorrorLogic.SetActive (false);
	}
}
