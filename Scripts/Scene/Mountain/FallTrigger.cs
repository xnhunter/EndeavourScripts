using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
	public Rigidbody2D platrormToFall;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			platrormToFall.constraints = RigidbodyConstraints2D.None;
		}
	}
}