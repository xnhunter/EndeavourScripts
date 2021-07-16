using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PortPlaneMove : MonoBehaviour {
	public GameObject Plane;
	private GameObject Player;
	public GameObject graphics;
	Transform w;

	//private readonly bool triggered = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

		if(w != null)
			w.position = new Vector3(w.position.x + 15, w.position.y, w.position.z);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			w = Plane.transform;

			Player.SetActive(false);

			//w.position = new Vector3(w.position.x + 15, w.position.y, w.position.z);
			graphics.GetComponent<Camera2DFollow>().autoFace = false;
			graphics.GetComponent<Camera2DFollow>().target = w;
			Plane.GetComponent<PlaneMoveHandler1>().enabled = true;
			this.gameObject.SetActive(false);
		}
	}
}
