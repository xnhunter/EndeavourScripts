using System.IO;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json.Linq;

public class LocalizationHandler : MonoBehaviour {
	public Text LanguageMenuLabel;
	public Toggle FollowSystemLanguage;

	private  Dictionary<string, string> Locales;

	static string LocalizationPath = @"Localization/";
	private string SystemLanguage;
	private TextAsset LocaleAsset;

	static public string JSONFileText;
	public static JObject parsedJSONText;

	public static string CurrentLanguage;

	// Use this for initialization
	void Awake () {
		
		Locales = new Dictionary<string, string>();
		Locales.Add ("en", "English");
		Locales.Add ("ua", "Ukrainian");
		Locales.Add ("ru", "Russian");

		JSONFileText = string.Empty;
		parsedJSONText = new JObject();
		
		LocaleAsset = new TextAsset ();
		
		LanguageMenuLabel.text = PlayerPrefs.GetString ("Language", "English");
		CurrentLanguage = LanguageMenuLabel.text;

		var temp = PlayerPrefs.GetInt ("FolloSystemLanguage", 1);
		if (temp == 1)
			FollowSystemLanguage.isOn = true;
		else
			FollowSystemLanguage.isOn = false;

		SystemLanguage = Application.systemLanguage.ToString ();

		UpdateLanguage (FollowSystemLanguage.isOn);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!(FollowSystemLanguage.isOn) && (LanguageMenuLabel.text != PlayerPrefs.GetString("Language")))
		{
			UpdateLanguage(false);

		}
		else if (FollowSystemLanguage.isOn && (LanguageMenuLabel.text != SystemLanguage))
		{
			UpdateLanguage(true);
		}
	}

	public void UpdateLanguage(bool followSystemSettings)
	{
		foreach (var loc in Locales) {
			if (loc.Value == (followSystemSettings ? SystemLanguage : LanguageMenuLabel.text )) {
				LocaleAsset = Resources.Load (LocalizationPath + loc.Key) as TextAsset;
				LanguageMenuLabel.text = loc.Value;
				PlayerPrefs.SetString ("Language", loc.Value);

				CurrentLanguage = loc.Value;

				UpdateLocale (loc.Key);

				break;
			}
		}

		JSONFileText = LocaleAsset.text;

		if (followSystemSettings) {

			// Couldn't math system language with existed ones.
			if(JSONFileText == string.Empty)
			{
				Awake();
				return;
			}

			PlayerPrefs.SetInt ("FolloSystemLanguage", 1);
		}
		else
			PlayerPrefs.SetInt ("FolloSystemLanguage", 0);


		parsedJSONText = JObject.Parse (LocalizationHandler.JSONFileText);
	}

	public void UpdateLocale(string locale)
	{
		Debug.Log ("Locale Updated: " + locale);
	}
}