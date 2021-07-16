using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;

public class MoneyNote : MonoBehaviour {
	private Text moneyText;

	public PlayerStatsBehaviour psb;

	void Start () {
		moneyText = GetComponent<Text>();
		//moneyText.text += psb.Money.ToString();
	}
	
	void Update () {

		//string money = psb.Money.ToString();

		//if (!money.Any(char.IsDigit))
		moneyText.text = psb.Money.ToString();
		
	}

	bool IsDigitsOnly(string str)
	{
		foreach (char c in str)
		{
			if (c < '0' || c > '9')
				return false;
		}

		return true;
	}
}
