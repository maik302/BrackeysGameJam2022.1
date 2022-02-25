using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody body;
	[SerializeField] int hitPoints = 5;
	
	[SerializeField] Vector3 moveVal;
	[SerializeField] float speed = 30;
	[SerializeField] float horizontalMultiplier = 1;

	void FixedUpdate()
	{
		float vertialMultiplier = moveVal.y < 0 ? 0 : moveVal.y;
		Vector3 forwardMove = transform.forward * (1 + vertialMultiplier*2) * speed * Time.fixedDeltaTime;
		Vector3 horizontalMove = transform.right * moveVal.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
		body.MovePosition(body.position + forwardMove + horizontalMove);
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < -5)
		{
			Die();
		}
	}
	
	void OnMove(InputValue value)
	{
		moveVal = value.Get<Vector2>().normalized;
	}

	public void Hit(int points)
	{
		hitPoints -= points;
		if (hitPoints <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Invoke("Restart", 2);
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
