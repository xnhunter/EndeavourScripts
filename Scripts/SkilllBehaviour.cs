using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SkilllBehaviour : MonoBehaviour {
	public enum SkillType
    {
		Lite,
		Average,
		Pro
    }

	private string Name;
	private string SkillDesc;
	private SkillType Skill;
	private int Price;

    public static int SkillsTotal = 0;

	private Button button;
	public PlayerStatsBehaviour psb;

    private GameObject AlreadyBoughtNote;
    private GameObject NotEnoughtMoneyNote;

    void Start()
	{
		Name = transform.parent.parent.name;

		SkillDesc = transform.parent.name;

        AlreadyBoughtNote = transform.parent.parent.parent.parent.Find("AlreadyBought").gameObject;
        NotEnoughtMoneyNote = transform.parent.parent.parent.parent.Find("NotEnoughtMoney").gameObject;

        if (SkillDesc == "Lite")
			Skill = SkillType.Lite;
		else if (SkillDesc == "Average")
			Skill = SkillType.Average;
		else if (SkillDesc == "Pro")
			Skill = SkillType.Pro;
		else
			Skill = SkillType.Lite;

		switch (Skill)
        {
			case SkillType.Lite:
				Price = 1000;
				break;

			case SkillType.Average:
				Price = 2500;
				break;

			case SkillType.Pro:
				Price = 5000;
				break;
		}

		// Already bought.
		button = transform.parent.GetComponent<Button>();

        CheckButtonColor();
	}

	public void TryBuy()
    {
		// Already bought.
		if (PlayerPrefs.GetInt(Name + SkillDesc + "Bought") == 1)
        {
            StartCoroutine(ShowNote(AlreadyBoughtNote));
            Debug.Log("Skill " + Name + SkillDesc + " is already bought.");

			return;
        }

		if (psb.Money > Price)
        {
			psb.Money -= Price;
			PlayerPrefs.SetInt("Money", psb.Money);

			PlayerPrefs.SetInt(Name + SkillDesc + "Bought", 1);
			SetUpSkill();
			CheckButtonColor();
            
            Debug.Log("Skill " + Name + SkillDesc + " is bought.");
        }
		else
        {
            StartCoroutine(ShowNote(NotEnoughtMoneyNote));
            Debug.Log("You don't have enought money.");
        }
	}

    IEnumerator ShowNote(GameObject Note)
    {
        Note.SetActive(true);
        Debug.Log("DeDSDS");
        yield return new WaitForSeconds(5);
        Note.SetActive(false);
    }

	private void CheckButtonColor()
    {
		if (PlayerPrefs.GetInt(Name + SkillDesc + "Bought") == 1)
		{
			ColorBlock i = button.colors;

            i.normalColor = new Color(1f, 0.3f, .3f, 1f);
			i.highlightedColor = new Color(1f, 0.3f, .3f, 1f);
			i.pressedColor = new Color(1f, 0.3f, .3f, 1f);

			button.colors = i;
        }
    }

    private void SetUpSkill()
    {
        var skills = PlayerPrefs.GetInt("SkillsTotal", 0);
        PlayerPrefs.SetInt("SkillsTotal", ++skills);
        PlayerPrefs.Save();

        if (Name == "Health")
        {
            switch (Skill)
            {
                case SkillType.Lite:
                    // can't use variables here, it will increase every time player presses the button.
                    PlayerPrefs.SetInt("Health", 120); 
                    break;

                case SkillType.Average:
                    PlayerPrefs.SetInt("Health", 150);
                    break;

                case SkillType.Pro:
                    PlayerPrefs.SetInt("Health", 200);
                    break;
            }

            psb.Health = PlayerPrefs.GetInt("Health");
        }

        if (Name == "Speed")
        {
            switch (Skill)
            {
                case SkillType.Lite:
                    PlayerPrefs.SetFloat("Speed", 8.0f);
                    break;

                case SkillType.Average:
                    PlayerPrefs.SetFloat("Speed", 10.0f);
                    break;

                case SkillType.Pro:
                    PlayerPrefs.SetFloat("Speed", 13.0f);
                    break;
            }

            psb.Speed = PlayerPrefs.GetFloat("Speed");
        }

        if (Name == "Damage")
        {
            switch (Skill)
            {
                case SkillType.Lite:
                    PlayerPrefs.SetInt("Damage", 15);
                    break;

                case SkillType.Average:
                    PlayerPrefs.SetInt("Damage", 25);
                    break;

                case SkillType.Pro:
                    PlayerPrefs.SetInt("Damage", 40);
                    break;
            }

            psb.Damage = PlayerPrefs.GetInt("Damage");
        }

        /*
        if (Name == "Money")
        {
            switch (Skill)
            {
                case SkillType.Lite:
                    PlayerPrefs.SetFloat("MoneyMultiplyerPercentage", MoneyBehavior.MoneyAddMultiplyerPerc + 0.1f);
                    break;

                case SkillType.Average:
                    PlayerPrefs.SetFloat("MoneyMultiplyerPercentage", MoneyBehavior.MoneyAddMultiplyerPerc + 0.2f);
                    break;

                case SkillType.Pro:
                    PlayerPrefs.SetFloat("MoneyMultiplyerPercentage", MoneyBehavior.MoneyAddMultiplyerPerc + 0.3f);
                    break;
            }

            MoneyBehavior.MoneyAddMultiplyerPerc = PlayerPrefs.GetFloat("MoneyMultiplyerPercentage");
        }
        */
    }
}
