using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5;
	public Rigidbody body;

	float horizontalInput;
	public float horizontalMultiplier = 3;

	void FixedUpdate()
	{
		Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
		Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
		body.MovePosition(body.position + forwardMove + horizontalMove);
	}

	// Update is called once per frame
	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
	}
}
