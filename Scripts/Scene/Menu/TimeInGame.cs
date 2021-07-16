using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeInGame : MonoBehaviour {
	private Text text;

	void Start () {
		text = GetComponent<Text>();

		float time = PlayerPrefs.GetFloat("TimeInGame");
		text.text = ((int)time / 60).ToString() + " min.";

	}

	// Update is called once per frame
	void Update () {
		
	}
}
