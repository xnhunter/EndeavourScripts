using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionLeft : MonoBehaviour 
{
	public bool playerInSight = false;

	private Collider2D PlayerCrouchCollider;
	void Start() 
	{
		GameObject Player = GameObject.FindGameObjectWithTag("Player");
		PlayerCrouchCollider = Player.GetComponents<Collider2D>()[1];
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision == PlayerCrouchCollider)
		{
			Debug.Log("Left Enter");
			playerInSight = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
    {
		if (collision == PlayerCrouchCollider)
		{
			Debug.Log("Left Exit");
			playerInSight = false;
		}
	}
}
