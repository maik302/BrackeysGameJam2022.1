using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 30;
	public Rigidbody body;
	float horizontalInput;
	public float horizontalMultiplier = 1;
	public int hitPoints = 5;

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

	public void hit(int points)
	{
		hitPoints -= points;
		if (hitPoints <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
