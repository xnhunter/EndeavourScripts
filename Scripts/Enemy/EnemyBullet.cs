using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
	private GameObject Player;

	private Collider2D bulletcol;

	public LayerMask m_WhatIsObstacle;

	public bool rightSide = false;
	new public int speed = 8;
	public bool hitPlayer = false;


	virtual public bool lastSideToFire { get; set; }

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");

		bulletcol = GetComponent<Collider2D>();
		rd = GetComponent<Rigidbody2D>();
		
		//switch (ai.type)
		//{
		//	case EnemyAI.Type.Weak:
		//		damage = 10;
		//		speed = 5;
		//		break;

		//	case EnemyAI.Type.Average:
		//		damage = 20;
		//		speed = 7;
		//		break;

		//	case EnemyAI.Type.Strong:
		//		damage = 30;
		//		speed = 9;
		//		break;

		//	default:
		//		damage = 20;
		//		speed = 7;
		//		break;
		//}
	}


	override public void Hit()
	{
		Player.GetComponent<PlayerStatsBehaviour>().Health -= 20; // damage

		hitPlayer = true;

		Destroy(this.gameObject);
		this.transform.position = initialPosition;
	}

	public void ReFire(bool flipped = false)
	{
		initialPosition = transform.parent.transform.position;
		initialPositionFlip = new Vector3(transform.parent.transform.position.x - 3, transform.parent.transform.position.y);

		if (lastSideToFire)
			transform.position = initialPosition;
		else
			transform.position = initialPositionFlip;
	}

	public void Update()
    {
		if(this && this.GetComponent<Collider2D>().IsTouchingLayers(m_WhatIsObstacle))
		{
			Destroy(this.gameObject);
			this.transform.position = initialPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Hit();
			Debug.Log("Enemy Bullet hit");
		}
	}
}