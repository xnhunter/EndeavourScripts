using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ladder : MonoBehaviour {
	public float speed = 4.0f;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			if(CrossPlatformInputManager.GetButtonDown("Jump"))
				collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15.0f);
		}
	}
}
