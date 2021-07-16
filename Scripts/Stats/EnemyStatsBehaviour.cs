using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsBehaviour : StatsBehaviour {

	new public int Health;
	private int MaxHealth;
	EnemyAI enemyAI;

	void Start() {
		enemyAI = GetComponent<EnemyAI>();

		switch (enemyAI.type)
		{
			case EnemyAI.Type.Weak:
				Health = 100;
				break;

			case EnemyAI.Type.Average:
				Health = 150;
				break;

			case EnemyAI.Type.Strong:
				Health = 200;
				break;

			default:
				Health = 100;
				break;
		}

		MaxHealth = Health;
	}

	public void ResetHealth()
    {
		Health = MaxHealth;
	}

	void Update () 
	{
		if (Health <= 0)
		{
			isAlive = false;
			int totalKills = PlayerPrefs.GetInt("KillsTotal", 0);
			PlayerPrefs.SetInt("KillsTotal", ++totalKills);

			this.gameObject.SetActive(false);
		}
	}
}
