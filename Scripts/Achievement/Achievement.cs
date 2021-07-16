using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achievement : MonoBehaviour
{
	public string Name;
	public string Desc;
	public uint ID;

	public bool isUnlocked = false;
	public System.Predicate<int> condition;
	public System.Predicate<int> condition2;
	public System.Predicate<int> condition3;
	public System.Predicate<int> condition4;
	public System.Predicate<int> Winner;
	public System.Predicate<int> SpeedRunner;

	public AchievementStatusImage asi;
	public PlayerStatsBehaviour psb;

	bool isCredits = false;

	void Start()
	{
		Name = gameObject.name;

		Desc = GetComponentInChildren<Text>().text;

		condition = isScoutUnlocked;
		condition2 = isRichBitchUnlocked;
		condition3 = isMedicUnlocked;
		condition4 = isKillerUnlocked;
		Winner = isWinnerUnlocked;
		SpeedRunner = isSpeedRunnerUnlocked;

		isCredits = SceneManager.GetActiveScene().buildIndex == 10;
	}

	void Update()
	{
		if (isCredits)
			return;

		switch(Name)
        {
			case "Scout":
				isUnlocked = condition(PlayerPrefs.GetInt("IntelsTotal"));
				break;

			case "Rich Bitch":
				isUnlocked = condition2(psb.Money);
				break;

			case "Medic":
				isUnlocked = condition3(PlayerPrefs.GetInt("MedkitsTotal", 0));
				break;

			case "Killer":
				isUnlocked = condition4(PlayerPrefs.GetInt("KillsTotal", 0));
				break;

			case "Winner":
				isUnlocked = Winner(PlayerPrefs.GetInt("creditsSceneLoaded", 0));
				break;

			case "SpeedRunner":
				isUnlocked = SpeedRunner(PlayerPrefs.GetInt("TimeInGame", 0));
				break;

			default:
				break;
		}

		// if no achievement is unlocked, do not show it
		if (isUnlocked)
		{
			asi.isAchieved = isUnlocked;

			if((PlayerPrefs.GetInt(Name + "AchievementUnlocked", 0) != 2))
				PlayerPrefs.SetInt(Name + "AchievementUnlocked", 1);
		}
	}

	private bool isScoutUnlocked(int intelsTotal)
    {

		return intelsTotal == 9;
    }

	private bool isRichBitchUnlocked(int money)
    {
		return money >= 10000;
    }

	private bool isMedicUnlocked(int medkits)
	{

		return medkits >= 100;
	}

	private bool isKillerUnlocked(int kills)
	{

		return kills >= 100;
	}

	private bool isWinnerUnlocked(int pref)
	{

		return pref == 1;
	}

	private bool isSpeedRunnerUnlocked(int minutes)
    {
		return minutes <= 11 && (PlayerPrefs.GetInt("creditsSceneLoaded", 0) == 1);
    }

	public static bool AllAchievementsUnlocked()
    {
		return true;
	}

}