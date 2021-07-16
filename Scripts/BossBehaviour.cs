using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {
	public int Health = 0;

	public GameObject BossFX;
	public AudioSource ambient;
	public SceneBehaviour sb;

	private Stopwatch stopwatch;
	private GameObject Player;

	void Start () {
		stopwatch = new Stopwatch();
		stopwatch.Start();

		Player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		// Kill Boss alongside the Ambient
		if (stopwatch.ElapsedMilliseconds >= 100000)
        {
			if(Health <= 0)
            {
				GetComponentInChildren<SpriteRenderer>().enabled = false;
				BossFX.SetActive(true);

				if (stopwatch.ElapsedMilliseconds >= 105000)
					sb.LoadSceneNoLoadingbar(10);
			}
			else // Kill Player
			{
				Player.GetComponent<PlayerStatsBehaviour>().Health = 0;
				Player.GetComponent<PlayerStatsBehaviour>().isAlive = false;
			}
		}
	}
}
