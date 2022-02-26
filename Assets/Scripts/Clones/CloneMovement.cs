using UnityEngine;
using UnityEngine.InputSystem;

public class CloneMovement : MonoBehaviour {
	[SerializeField] Rigidbody body;

	[SerializeField] Vector3 moveVal;
	[SerializeField] float speed = 30;
	[SerializeField] float horizontalMultiplier = 1;

	bool _canMoveHorizontally;

    void Awake() {
		_canMoveHorizontally = true;
    }

    void FixedUpdate() {
		float vertialMultiplier = moveVal.y < 0 ? 0 : moveVal.y;
		Vector3 forwardMove = transform.forward * (1 + vertialMultiplier * 2) * speed * Time.fixedDeltaTime;
		Vector3 horizontalMove = transform.right * moveVal.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
		
		if (_canMoveHorizontally) {
			body.MovePosition(body.position + forwardMove + horizontalMove);
		} else {
			body.MovePosition(body.position + forwardMove);
		}
	}

	void OnMove(InputValue value) {
		moveVal = value.Get<Vector2>().normalized;
	}

	public void SetCanMoveHorizontally(bool canMoveHorizontally) {
		_canMoveHorizontally = canMoveHorizontally;
    }
}
