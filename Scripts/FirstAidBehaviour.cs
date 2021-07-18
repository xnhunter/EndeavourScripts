using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidBehaviour : MonoBehaviour
{
	private GameObject Player;

	public int HealthAdd;
	private int hitpoints = 1;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			hitpoints--;

			if (hitpoints > -1)
			{
				PlayerPrefs.SetInt("MedkitsTotal", PlayerPrefs.GetInt("MedkitsTotal", 0) + 1);

				int health = Player.GetComponent<PlayerStatsBehaviour>().Health;

				health += HealthAdd;

				if (GameUtils.GamePlay)
					if (health > PlayerPrefs.GetInt("Health")) // In case of health gets overflowed
						health = PlayerPrefs.GetInt("Health");

				Player.GetComponent<PlayerStatsBehaviour>().Health = health;

				this.gameObject.SetActive(false);
			}
		}
	}
}
