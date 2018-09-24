using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chase : MonoBehaviour {
	// Use this for initialization
	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject player;
	public AudioClip[] zombiesounds;
	public GvrAudioSource soundsource;
	public bool startGame;
	void Awake () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		startGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (startGame) {
			agent.destination = player.transform.position;
			soundsource.PlayOneShot (zombiesounds [0]);
			if (!agent.pathPending) {
				if (agent.remainingDistance <= agent.stoppingDistance) {
					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
						gameObject.GetComponent<Animator> ().SetBool ("attack", true);
						soundsource.PlayOneShot (zombiesounds [1]);
					}
				}
			}
		}
	}
}