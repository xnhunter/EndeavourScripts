using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsAuthorBehaviour : MonoBehaviour {
	private Text Author;

	void Start () {
		Author = GetComponent<Text>();

		if (LocalizationHandler.CurrentLanguage == "Russian" || LocalizationHandler.CurrentLanguage == "Ukrainian")
        {
			//Author.fontSize = 20; // Arial is smaller than 16 
			Author.text = "Валентин Бондаренко © 2021";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BackToMM()
	{
		yield return new WaitForSeconds(300);
		LoadMM();
	}

	public void LoadMM()
    {
		SceneManager.LoadScene(0);
	}
}
