using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	public enum Type
	{
		Weak,
		Average,
		Strong
	}

	public Type type = Type.Weak;
	public bool didShot = false;

	private EnemyStatsBehaviour Stats;

	public EnemyBullet bulletTemplate;
	private Stopwatch stopwatch;
	private EnemyCollisionLeft CollisionLeft;
	private EnemyCollisionRight CollisionRight;

	private SpriteRenderer Sprite;

	private GameObject Player;
	private PlayerStatsBehaviour psb;
	public GameObject initialBullet;

	public bool newBullet;
	private int timeToRefire = 4000; // in ms
	void Start()
	{
		Sprite = gameObject.GetComponent<SpriteRenderer>();

		CollisionLeft = GetComponentInChildren<EnemyCollisionLeft>();
		CollisionRight = GetComponentInChildren<EnemyCollisionRight>();
		
		Player = GameObject.FindGameObjectWithTag("Player");
		psb = Player.GetComponent<PlayerStatsBehaviour>();
		Stats = GetComponent<EnemyStatsBehaviour>();


		stopwatch = new Stopwatch();
		stopwatch.Start();
		newBullet = true;

		bulletTemplate.gameObject.SetActive(false);

		switch(type)
        {
			case Type.Weak:
				timeToRefire = 4000;
				break;

			case Type.Average:
				timeToRefire = 3000;
				break;

			case Type.Strong:
				timeToRefire = 2000;
				break;

			default:
				timeToRefire = 3000;
				break;
		}
	}

	void Update()
	{
		if (!psb)
			return;

#if !DEBUG
		return;
#endif
		if ((CollisionLeft.playerInSight || CollisionRight.playerInSight))
		{

			Sprite.flipX = CollisionLeft.playerInSight;
			didShot = true;
		}
		else
			Stats.ResetHealth();

		if (didShot)
        {
			if(newBullet)
				Fire();

			FireTimerUpdate();
        }
	}

	private void Fire()
    {
		EnemyBullet bullet = Instantiate(bulletTemplate, initialBullet.transform.position, Quaternion.identity);
		bullet.gameObject.SetActive(true);

		
		// Randomly fire to botton, in case the player is sitting.
		float rotation = 0.0f;
		int Direct = Random.Range(1, 3);

		if (CollisionRight.playerInSight)
		{
			if (Direct == 2)
			{
				bullet.transform.localEulerAngles = new Vector3(0, 0, 4);
				rotation = 0.4f;
			}

			bullet.GetComponentInChildren<SpriteRenderer>().flipY = true;
			bullet.GetComponent<Rigidbody2D>().velocity += new Vector2(bulletTemplate.speed, rotation);
			bullet.initialPosition = initialBullet.transform.position;
		}
		else
		{
			if (Direct == 1)
			{
				bullet.transform.localEulerAngles = new Vector3(0, 0, -4);
				rotation =0.4f;
			}

			bullet.GetComponentInChildren<SpriteRenderer>().flipY = false;
			bullet.GetComponent<Rigidbody2D>().velocity += new Vector2(-bulletTemplate.speed, rotation);
			bullet.initialPosition = new Vector2(initialBullet.transform.position.x - 2f, initialBullet.transform.position.y);
		}

		bullet.GetComponent<Rigidbody2D>().simulated = true;
		
		newBullet = false;
		UnityEngine.Debug.Log("Enemy Fire");
	}

	private void FireTimerUpdate()
	{
		if (stopwatch.ElapsedMilliseconds >= timeToRefire)
        {
			stopwatch.Reset();
			stopwatch.Start();

			newBullet = true;
        }
		else
			newBullet = false;
	}
}
