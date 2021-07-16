using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreLoadBehaviour : MonoBehaviour
{
	static public string enabledLevelName;

	public GameObject[] LevelsToDisplay;

	// Use this for initialization
	void Start()
	{

	}

	public void ClearSelectedName()
	{
		SceneBehaviour.selectedScene = string.Empty;
	}

	public void SelectLevel(Text levelButton)
	{
		Debug.Log("Selected scene: " + levelButton.text);
		SceneBehaviour.selectedScene = levelButton.text;
	}


	// Update is called once per frame
	void Update()
	{
		if (enabledLevelName != string.Empty) 
		{
			foreach (GameObject level in LevelsToDisplay) {
				if (level.name == SceneBehaviour.selectedScene) {
					level.SetActive (true);
				} else
					level.SetActive (false);
			}
		}
	}
}
	
