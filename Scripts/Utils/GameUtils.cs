using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtils : MonoBehaviour {

	public static bool GamePlay = false;

	void Start () {
		// buildIndex 0 is menu, buildIndex 10 is credits
		if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 10)
			GamePlay = true;
		else
			GamePlay = false;
	}

	void Update () {
		
	}

	public void Pause()
    {
		Time.timeScale = 0f;
	}

	public void UnPause()
	{
		Time.timeScale = 1f;
	}
}
