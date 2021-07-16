using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDetection : MonoBehaviour {

	public static bool playerDetected = false;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (playerDetected)
			Fire();
	}

	void OnTriggerEnter2D(Collider2D collider)
    {
		if(collider.tag == "Player")
        {
			playerDetected = true;
		}
    }

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			playerDetected = false;
		}
	}

	public void Fire()
    {

    }
}
