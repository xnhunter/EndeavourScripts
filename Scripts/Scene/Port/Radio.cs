using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {
	public GameObject Ladder;
	public GameObject PlaneTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Ladder.SetActive(true);
			PlaneTrigger.gameObject.SetActive(false);

			this.gameObject.SetActive(false);
		}
	}
}
