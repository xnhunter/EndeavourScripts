using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementStatusImage : MonoBehaviour {
	public bool isAchieved = false;
	public Sprite StatusImage;

	public Sprite Done;
	public Sprite InProgress;

	// Use this for initialization
	void Start () {
		StatusImage = InProgress;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAchieved)
			StatusImage = Done;
		else
			StatusImage = InProgress;

		GetComponent<Image>().sprite = StatusImage;
	}
}
