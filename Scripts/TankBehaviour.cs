using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour {
	private Rigidbody2D Projectile;
	//private Collider2D Collider;

	public Vector2 initialPosion;
	public GameObject Explosion;
	public LayerMask m_WhatIsObstacle;

	void Start () {
		Projectile = GetComponent<Rigidbody2D>();
		//Collider = GetComponent<Collider2D>();
	}

	void Update () {
		if (TankDetection.playerDetected && !TankProjectile.playerHit)
			Projectile.velocity += new Vector2(-2f, 0f);

		if (TankProjectile.playerHit)
        {
			Projectile.velocity = new Vector2(0f, 0f);
        }
	}
}
