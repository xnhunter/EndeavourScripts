using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsBehaviour : MonoBehaviour {
	public Text GameName;
	public EndCreditsMusic EndCredits;

	//bool Infaded = false;
	bool goFaded = false;

	void Start () {
        // As far as we load it without Loading Bar, we manually create this pref.
        PlayerPrefs.SetInt("creditsSceneLoaded", 1);
    }

	void Update () {
        if (!goFaded)
            StartCoroutine(FadeTextToFullAlpha(2f, GameName));
        else
            StartCoroutine(D());
            //FadeTextToFullAlpha(FadeOut());
    }

    public IEnumerator D()
    {
        yield return new WaitForSeconds(11f);
        StartCoroutine(FadeTextToZeroAlpha(2f, GameName));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        if (i.color.a == 1.0f)
        {
            goFaded = true;
            yield return null;
        }

        while (i.color.a != 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);

        if(i.color.a == 0.0f)
        {
            yield return null;
        }

        while (i.color.a != 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        
    }
}
