using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LocalizationTextBehaviour : MonoBehaviour {
	private Text text;

	private Font CyrilicFont;
	private Font AquireFont;

	private string lastLanguage;
	void Start ()
	{
		text = this.GetComponent<Text> ();
		
		CyrilicFont = Resources.Load<Font>(@"kz-taurus");
		AquireFont = text.font;

		UpdateLocalization();
	}

	public void Update()
	{
		// Update a text ony if the language was changed.
		if(lastLanguage != LocalizationHandler.CurrentLanguage)
			UpdateLocalization();
	}

	public void UpdateLocalization()
    {
		if (text != null)
		{
			// Switch fonts to cyrilic and backwards.
			if (LocalizationHandler.CurrentLanguage == "Russian" || LocalizationHandler.CurrentLanguage == "Ukrainian")
			{
				if (text.font.fontNames[0] == "Aquire")
					text.font = CyrilicFont;
			}
			else if (text.font.fontNames[0] == "KZ Taurus")
				text.font = AquireFont;


			// Localize text by finding the right pair.
			foreach (var pair in LocalizationHandler.parsedJSONText)
			{
				var parent = transform.parent.name;

				if (parent.Contains(pair.Key))
				{
					text.text = pair.Value.ToString();
				}
			}
		
			lastLanguage = LocalizationHandler.CurrentLanguage;
		}
	}
}
