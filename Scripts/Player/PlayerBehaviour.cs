using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : MonoBehaviour 
{
	bool shoot = false;

	// private PlayerBullet bullet;

	void Start () 
	{
		//	bullet = GetComponentInChildren<PlayerBullet>();
	}
	
	void Update ()
	{
		if (Shoot())
			Debug.Log("Shoot Pressed");
			// bullet.Fire(true);
	}

	private bool Shoot()
	{
		shoot = CrossPlatformInputManager.GetButtonDown("Shoot");
		return shoot;
	}
}
