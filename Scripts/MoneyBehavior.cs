using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
	private GameObject Player;

	public int MoneyAdd;
	public static float MoneyAddMultiplyerPerc = 0.0f;

	private int hitpoints = 1;

	// Use this for initialization
	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		//MoneyAddMultiplyerPerc = PlayerPrefs.GetFloat("MoneyMultiplyerPercentage", 0.0f);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			hitpoints--;

			if (hitpoints > -1)
			{
				Player.GetComponent<PlayerStatsBehaviour>().Money += MoneyAdd + (int)(MoneyAdd);//* MoneyAddMultiplyerPerc);
				this.gameObject.SetActive(false);
			}
		}
	}
}
