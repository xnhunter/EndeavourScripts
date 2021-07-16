	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipBehaviour : MonoBehaviour {
	private GameObject Player;
	public GameObject TipText;

	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {

	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject == Player)
		{
			TipText.SetActive (true);
		}
	}

	private void OnTriggerExit2D (Collider2D collision) {
		if (collision.gameObject == Player)
		{
			this.GetComponent<Collider2D> ().enabled = false;
			TipText.SetActive (false);
		}
	}
}
