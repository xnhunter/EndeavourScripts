using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsBehaviour : MonoBehaviour
{
	virtual public int Health { get; set; }
	virtual public bool isAlive { get; set; }

	// Use this for initialization
	void Start () 
	{
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ApplyDamage()
	{

	}
}
