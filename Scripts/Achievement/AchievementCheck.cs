using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Checks if an achievement is unlocked to consequently aware user.
// Achievement Pref States:
// 0 - locked
// 1 - unlocked
// 2 - showed
public class AchievementCheck : MonoBehaviour {
	public GameObject AchievementObj;
	private Text AchText;

	private string CurrentName;
	
	void Start () 
	{
		CurrentName = string.Empty;
	}
	
	void Update () 
	{
		if (AchievementNames.Names == null || (SceneManager.GetActiveScene().buildIndex == 10))
			return;

		foreach (string Name in AchievementNames.Names)
		{
			if (PlayerPrefs.GetInt(Name + "AchievementUnlocked", 0) == 1)
			{
				PlayerPrefs.SetInt(Name + "AchievementUnlocked", 2);

				if (CurrentName != string.Empty)
					CurrentName += " & ";

				CurrentName = Name;
			}

			if (CurrentName != string.Empty && CurrentName != "Winner")
				StartCoroutine(waiter());
		}

		if (AchievementObj && AchievementObj.activeInHierarchy)
		{
			AchText = AchievementObj.GetComponentInChildren<Text>();

			if(!AchText.text.Contains(CurrentName))
				AchText.text += CurrentName;
		}
	}

	IEnumerator waiter()
	{
		if (AchievementObj)
		{
			AchievementObj.SetActive(true);
			yield return new WaitForSeconds(15);
			AchievementObj.SetActive(false);
		}
		else
			yield return 0; // credits doesn't have Achievement Text Box
	}
}
