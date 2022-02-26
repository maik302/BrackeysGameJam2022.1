using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody body;
	
	[SerializeField] Vector3 moveVal;
	[SerializeField] float speed = 30;
	[SerializeField] float horizontalMultiplier = 1;

	[SerializeField] private GameObject bulletPrefab;

	void FixedUpdate()
	{
		float vertialMultiplier = moveVal.y < 0 ? 0 : moveVal.y;
		Vector3 forwardMove = transform.forward * (1 + vertialMultiplier*2) * speed * Time.fixedDeltaTime;
		Vector3 horizontalMove = transform.right * moveVal.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
		body.MovePosition(body.position + forwardMove + horizontalMove);
	}

	void OnMove(InputValue value)
	{
		moveVal = value.Get<Vector2>().normalized;
	}

	void OnFire(InputValue value)
	{
		Instantiate(bulletPrefab, transform, false);
	}
}
