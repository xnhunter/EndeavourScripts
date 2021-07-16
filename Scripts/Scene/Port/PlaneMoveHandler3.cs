using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlaneMoveHandler3 : MonoBehaviour
{
	public GameObject objectToMove;
	public Vector3 Destination;

	public GameObject Plane;
	private GameObject Player;
	public GameObject graphics;

	public float yToMove = 0.0f;
	public float xToMove = 0.0f;

	public float totalMovementTime;
	public bool onCollision = false;

	public static bool pointReached = false;

	// Use this for initialization
	void Start()
	{
		if (objectToMove == null)
			objectToMove = transform.gameObject;

		Player = GameObject.FindWithTag("Player");

		//Destination = new Vector3(objectToMove.transform.localPosition.x + xToMove, objectToMove.transform.localPosition.y + yToMove);
	}

	// Update is called once per frame
	void Update()
	{
		if (PlaneMoveHandler2.pointReached)
		{
			Debug.Log("Plane forward");
			PlaneMoveHandler2.pointReached = false;
			StartCoroutine(MoveObject());
		}

		if (objectToMove.transform.position.x >= 30f)
			pointReached = true;

		if (pointReached)
        {
			Debug.Log("test");

			graphics.GetComponent<Camera2DFollow>().autoFace = true;
			graphics.GetComponent<Camera2DFollow>().target = Player.transform;

			Vector3 x = new Vector3(Player.transform.position.x + 75, Player.transform.position.y);
			Player.transform.position = x;
			Player.SetActive(true);
			objectToMove.GetComponent<Collider2D>().enabled = false;

			this.enabled = false;
        }
	}


	//	You need to continuously update the localPosition using Lerp.You could do this using a coroutine as follows (assuming Origin and Destination are defined localPositions):

	public IEnumerator MoveObject()
	{
		//the amount of time you want the movement to take
		float currentMovementTime = 0f;//The amount of time that has passed

		while (Vector3.Distance(objectToMove.transform.localPosition, Destination) > 0)
		{
			currentMovementTime = Time.deltaTime;
			objectToMove.transform.localPosition = Vector3.Lerp(objectToMove.transform.localPosition, Destination, currentMovementTime / totalMovementTime);

			yield return null;
		}
	}
}