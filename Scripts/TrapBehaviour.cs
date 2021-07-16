using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour 
{
	private GameObject Player;
	public int Damage = 25;
	Stopwatch stopwatch = new Stopwatch();

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		stopwatch.Start();
	}

	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (stopwatch.ElapsedMilliseconds >= 1000)
		{
			if (collision.tag == "Player")
			{
				Player.GetComponent<PlayerStatsBehaviour>().Health -= Damage;
				stopwatch.Reset();
				stopwatch.Start();
			}
		}
	}
}
