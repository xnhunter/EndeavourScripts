using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionRight : MonoBehaviour 
{
	public bool playerInSight = false;

	private Collider2D PlayerCrouchCollider;

	void Start()
	{
		GameObject Player = GameObject.FindGameObjectWithTag("Player");
		PlayerCrouchCollider = Player.GetComponents<Collider2D>()[1];
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision == PlayerCrouchCollider)
		{
			Debug.Log("Right Enter");
			playerInSight = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision == PlayerCrouchCollider)
		{
			Debug.Log("Right Exit");
			playerInSight = false;
		}
	}
}
