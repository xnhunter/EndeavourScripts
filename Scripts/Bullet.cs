using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {
	virtual public Vector3 initialPosition { get; set; }
	virtual public Vector3 initialPositionFlip { get; set; }

	virtual public int damage { get; set; }
	virtual public int speed { get; set; }
	virtual public int range { get; set; }

	virtual public Rigidbody2D rd {get; set;}

	void Start () {
		
	}
	
	void Update () {
		
	}
	virtual public void Hit()
	{

	}
}
