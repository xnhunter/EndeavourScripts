using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankProjectile : MonoBehaviour {
	private GameObject Player;
	public GameObject Explosion;
	public int Damage = 200;
	static public bool playerHit = false;
	static public bool propHit = false;


	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			playerHit = true;
			gameObject.SetActive(false);
			Player.GetComponent<PlayerStatsBehaviour>().Health -= Damage;
			Explosion.SetActive(true);
		}
	}
}
