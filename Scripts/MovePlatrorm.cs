using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatrorm : MonoBehaviour 
{
	public GameObject objectToMove;
	public Vector3 Destination;
	
	private GameObject Player;

	public float yToMove = 0.0f;
	public float xToMove = 0.0f;

	public float totalMovementTime;

	public GameObject triggerMoveForward;
	public static bool pointReached = false;
	public bool planeBackground = false;

	// Use this for initialization
	void Start() {
		if(objectToMove == null)
			objectToMove = transform.parent.gameObject;

		Player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update() {
		if (triggerMoveForward == null)
			return;

		if (objectToMove.transform.localPosition.y >= 34.9f)
		{
			this.enabled = false;
			pointReached = true;
		}
	}


	//	You need to continuously update the position using Lerp.You could do this using a coroutine as follows (assuming Origin and Destination are defined positions):

	public IEnumerator moveObject()
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

	private void Awake()
    {
		if(planeBackground)
			StartCoroutine(moveObject());
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			StartCoroutine(moveObject());
		}
	}
}