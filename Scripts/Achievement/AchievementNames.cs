using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementNames : MonoBehaviour {
	public GameObject[] names;

	public static List<string> Names;
	void Start () {
		Names = new List<string>();

		foreach(GameObject name in names)
			Names.Add(name.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
