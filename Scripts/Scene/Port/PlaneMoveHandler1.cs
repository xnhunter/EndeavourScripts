using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveHandler1 : MonoBehaviour
{
	private GameObject objectToMove;
	public Vector3 Destination;

	private GameObject Player;

	public float yToMove = 0.0f;
	public float xToMove = 0.0f;

	public float totalMovementTime;
	public bool onCollision = false;

	public static bool pointReached = false;

	// Use this for initialization
	void Start()
	{
		if (objectToMove == null)
			objectToMove = gameObject;

		Player = GameObject.FindWithTag("Player");

		Destination = new Vector3(objectToMove.transform.localPosition.x + xToMove, objectToMove.transform.localPosition.y + yToMove);

		StartCoroutine(MoveObject());
	}

	// Update is called once per frame
	void Update()
	{
		//	Vector3 DestinationToCompare = new Vector3(Destination.x - 1f, Destination.y - 1f, Destination.z - 0f);

			if (objectToMove.transform.localPosition.y >= 40f)
			{
				Debug.Log("Up");
				this.enabled = false;
				pointReached = true;
			}
	}


	//	You need to continuously update the position using Lerp.You could do this using a coroutine as follows (assuming Origin and Destination are defined positions):

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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			StartCoroutine(MoveObject());
		}
	}
}