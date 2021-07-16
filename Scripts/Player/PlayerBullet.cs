using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : Bullet
{
	public LayerMask m_WhatIsObstacle;

	new public int damage;
	private GameObject fire;

	private List<Collider2D> EnemyColliders;

	void Start()
	{
		transform.localScale = new Vector3(0.3f, 0.15f, 0.2f);

		GameObject Player = GameObject.FindGameObjectWithTag("Player");
		EnemyColliders = Player.GetComponent<WeaponSystem>().EnemyColliders;
	}

	void Update()
	{
		if (this && this.GetComponent<Collider2D>().IsTouchingLayers(m_WhatIsObstacle))
        {
			Destroy(this.gameObject);
			this.transform.position = initialPosition;
		}
	}

	override public void Hit()
	{
		Destroy(this.gameObject);
		this.transform.position = initialPosition;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		foreach (var collider in EnemyColliders)
		{
			if (collision == collider)
			{
				collider.gameObject.transform.parent.GetComponent<EnemyStatsBehaviour>().Health -= damage;
				Hit();

				Debug.Log("Player Bullet hit");
			}
		}
	}
}
