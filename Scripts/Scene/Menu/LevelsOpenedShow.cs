using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsOpenedShow : MonoBehaviour {
	public GameObject[] OpenedLevelsToDisplay;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("introSceneLoaded", 1);

		foreach (GameObject level in OpenedLevelsToDisplay)
		{
#if DEBUG
			level.SetActive(true);
#else
			bool lvlOpened = PlayerPrefs.GetInt(level.name.ToLower() + "SceneLoaded") == 1;

			if (lvlOpened)
				level.SetActive(true);
			else
				level.SetActive(false);
#endif
		}
	}
}
