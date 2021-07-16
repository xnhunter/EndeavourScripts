using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveForward : MonoBehaviour
{
	public GameObject objectToMove;
	public Vector3 Destination;
	public float totalMovementTime;

	// Use this for initialization
	void Start()
	{
	}
	public IEnumerator moveObject()
	{
		//the amount of time you want the movement to take
		float currentMovementTime = 0f; //The amount of time that has passed

		while (Vector3.Distance(objectToMove.transform.localPosition, Destination) > 0)
		{
			currentMovementTime = Time.deltaTime;
			objectToMove.transform.localPosition = Vector3.Lerp(objectToMove.transform.localPosition, Destination, currentMovementTime / totalMovementTime);

			yield return null;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (MovePlatrorm.pointReached)
			StartCoroutine(moveObject());
	}
}
