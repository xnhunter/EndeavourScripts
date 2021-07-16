using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoving : MonoBehaviour {
	public float Speed = 5.0f;
	Vector3 Direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
