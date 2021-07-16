using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortHandler : MonoBehaviour {
	public GameObject fog;
	public bool setBool = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
        {
			fog.SetActive(setBool);
		}
	}
}
