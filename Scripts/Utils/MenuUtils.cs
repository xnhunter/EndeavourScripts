using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUtils : MonoBehaviour {
	public Text Version;

	public GameObject SkillSection;
	public GameObject WeaponSection;

	public GameObject LoadingPanel;
	public AudioSource MainTheme;


	void Start () {
		ProductVersion ();
		Version = GetComponent<Text>();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

#if !DEBUG
		if(PlayerPrefs.GetInt("fieldSceneLoaded") != 1)
		{
			SkillSection.SetActive(false);
			WeaponSection.SetActive(false);
		}
#endif
	}
	
	void Update () {
		if (LoadingPanel.activeInHierarchy)
			MainTheme.Stop();
	}

	public void ProductVersion() {
		Version.text = Application.version;
		
		var app_ver = 0;
		int.TryParse(Application.version, out app_ver);
		if (app_ver < 1.0)
			Version.text += " BETA";

		Debug.Log (Version.text);
	}
}
