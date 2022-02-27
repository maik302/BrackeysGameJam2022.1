using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] Rigidbody body;
	
	[SerializeField] Vector3 moveVal;
	[SerializeField] float speed = 30;
	[SerializeField] float horizontalMultiplier = 1;
	[SerializeField] float _rayMagnitude;

    void FixedUpdate() {
		float vertialMultiplier = moveVal.y < 0 ? 0 : moveVal.y;
		Vector3 forwardMove = transform.forward * (1 + vertialMultiplier*2) * speed * Time.fixedDeltaTime;
		Vector3 horizontalMove = transform.right * moveVal.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
		MoveWithRestrictions(forwardMove, horizontalMove);
    }

	void MoveWithRestrictions(Vector3 forwardMove, Vector3 horizontalMove) {
		// Movement to the right
		if (horizontalMove.x > 0) {
			if (CanKeepMovingInDirection(Vector3.right)) {
				body.MovePosition(body.position + forwardMove + horizontalMove);
			} else {
				body.MovePosition(body.position + forwardMove);
			}
		}
		// Movement to the left
		else if (horizontalMove.x < 0) {
			if (CanKeepMovingInDirection(Vector3.left)) {
				body.MovePosition(body.position + forwardMove + horizontalMove);
			} else {
				body.MovePosition(body.position + forwardMove);
			}
		}
		// Forward movement
		else {
			body.MovePosition(body.position + forwardMove + horizontalMove);
		}
    }

	bool CanKeepMovingInDirection(Vector3 direction) {
		// Casts a ray from this transform origin to know if the object is near a *border wall*
		Ray ray = new Ray(transform.position, direction);
		var canKeepMovingInDirection = !Physics.Raycast(ray, _rayMagnitude);

		//Reports to every clone if they can keep moving horizontally
		ClonesManager.Instance.SetClonesHorizontalMovementState(canKeepMovingInDirection);
		return !Physics.Raycast(ray, _rayMagnitude);
    }

	void OnMove(InputValue value) {
		moveVal = value.Get<Vector2>().normalized;
	}
}
