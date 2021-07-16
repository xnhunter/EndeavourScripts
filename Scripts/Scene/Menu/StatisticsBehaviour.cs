using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatisticsBehaviour : MonoBehaviour {
	public Text Money;
	public Text Speed;
	public Text Damage;

	public Text MaxHealth;
	public Text EnemyKilled;
	public Text LevelsOpened;

	public Text SkillsBought;

	public InputField PlayerName;

	public PlayerStatsBehaviour psb;
	private string PlayerNameDefault = "Player";

	public PreLoadBehaviour plb;
	void Start()
	{
		Money.text = psb.Money.ToString();
		Speed.text = psb.Speed.ToString();
		Damage.text = psb.Damage.ToString();

		LevelsOpened.text = plb.LevelsToDisplay.Length.ToString();
		SkillsBought.text = PlayerPrefs.GetInt("SkillsTotal", 0).ToString();

		PlayerName.text = PlayerPrefs.GetString("PlayerNameStat", PlayerNameDefault);
	}

	void Update()
    {
		SkillsBought.text = PlayerPrefs.GetInt("SkillsTotal", 0).ToString(); // mush be updated to syncronize values
	}

	static public bool AllIntelsFound()
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			int intelFound = PlayerPrefs.GetInt(SceneManager.GetSceneAt(i).name + "IntelFound", 0);

			if (intelFound != 1)
				return false;
		}

		return true;
	}

	void CheckPlayerNameField()
    {
		if (PlayerName.text == string.Empty)
			PlayerName.text = PlayerNameDefault;
	}

	public void OnPlayerNameFieldEnd()
    {
		PlayerPrefs.SetString("PlayerNameStat", PlayerName.text);

	}
}
