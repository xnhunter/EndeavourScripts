using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class PlayerStatsBehaviour : StatsBehaviour
{
	public new int Health;
	public int Money;

	public Text HealthStr;
	public Text MoneyStr;

	public int Damage = 10;
	public float Speed = 6;

	public GameObject DieGapCollider;
	private Animator m_Anim;
	// Use this for initialization
	void Start()
	{
		Health = PlayerPrefs.GetInt("Health", 100);
		Money = PlayerPrefs.GetInt("Money", 0);
		Speed = PlayerPrefs.GetFloat("Speed", 6.0f);
		Damage = PlayerPrefs.GetInt("Damage", 10);

		PlayerPrefs.SetInt("Health", Health);
		PlayerPrefs.SetInt("Money", Money);
		PlayerPrefs.SetFloat("Speed", Speed);
		PlayerPrefs.SetInt("Damage", Damage);

		if(SceneManager.GetActiveScene().buildIndex == 1)
			Health = 75;

		HealthStr.text = Health.ToString();
		MoneyStr.text = Money.ToString();

		isAlive = true;
		m_Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Health < 1)
		{
			Health = 0;

			if (isAlive)
			{
				isAlive = false;
				m_Anim.SetBool("Dead", true);

				//var x = transform.Find("Weapon").gameObject;
				//if (x)
					//x.SetActive(false);

				var pc2d = GetComponent<Platformer2DUserControl>();
				pc2d.enabled = false;
				StartCoroutine(DeadEnd());
			}
		}

		HealthStr.text = Health.ToString();
		MoneyStr.text = Money.ToString();

		if (Money < 0)
			Money = 0;
	}

	private IEnumerator DeadEnd()
    {
		yield return new WaitForSeconds(0.75f);
		
		m_Anim.speed = 0f;

		if (DieGapCollider)
			DieGapCollider.GetComponent<GameOverTrigger>().Invoke();
	}
}