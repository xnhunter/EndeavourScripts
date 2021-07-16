using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {
	private GameObject Player;
	public GameObject PlayerUI;
	public GameObject text;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Invoke ()
    {
		Player.GetComponent<PlayerStatsBehaviour>().Health = 0;
		text.SetActive(true);
		
		this.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.tag == "Player")
		{
			Invoke();
			Player.SetActive(false);
		}
	}
}
