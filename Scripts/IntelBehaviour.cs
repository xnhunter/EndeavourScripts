using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Newtonsoft.Json.Linq;

public class IntelBehaviour : MonoBehaviour {
	private Achievement allIntelsFound;
	//private int ID;

	// Use this for initialization
	void Start () {
		allIntelsFound = new Achievement();
		allIntelsFound.isUnlocked = false;

		//ID = SceneManager.GetActiveScene().buildIndex;

		int hasIntel = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "IntelFound", 0);
		if (hasIntel == 1)
			this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			PlayerPrefs.SetInt("IntelsTotal", PlayerPrefs.GetInt("IntelsTotal", 0) + 1);

			PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "IntelFound", 1);
			this.gameObject.SetActive(false);

			// every time player finds an intel, check if all archievement unlocked to reduce performance
			if (Achievement.AllAchievementsUnlocked())
			{
				allIntelsFound.isUnlocked = true;
			}
		}
	}
}
