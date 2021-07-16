using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveHandler2 : MonoBehaviour
{
	public  GameObject objectToMove;
	public Vector3 Destination;

	public float yToMove = 0.0f;
	public float xToMove = 0.0f;

	public float totalMovementTime;
	public bool onCollision = false;

	public GameObject nextTriggerMove;
	public static bool pointReached = false;
	private bool started = false;

	// Use this for initialization
	void Start()
	{
		//objectToMove = transform.parent.gameObject;
		//Destination = new Vector3(objectToMove.transform.localPosition.x + xToMove, objectToMove.transform.position.y + yToMove);
	}

	// Update is called once per frame
	void Update()
	{
		if (PlaneMoveHandler1.pointReached)
		{
			Debug.Log("Plane forward");
			PlaneMoveHandler1.pointReached = false;
			StartCoroutine(MoveObject());
			started = true;
		}

		if(started)
        {
//			Vector3 DestinationToCompare = new Vector3(Destination.x - 1f, Destination.y - 1f, Destination.z - 0f);

			//if (objectToMove.transform.localPosition.x >= DestinationToCompare.x &&
//				objectToMove.transform.localPosition.y >= DestinationToCompare.y)
			if (objectToMove.transform.position.x >= 16f)
			{
				Debug.Log("Forward");
				pointReached = true;
				this.enabled = false;
			}
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