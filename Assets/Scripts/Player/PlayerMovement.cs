using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : BaseMovement {
	[SerializeField] Rigidbody body;

	[SerializeField] float _rayMagnitude;

    private void Start() {
		AudioManager.Instance.Play("CarEngineSound");
    }

    public override void MoveWithRestrictions(Vector3 forwardMove, Vector3 horizontalMove) {
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

	void OnFire(InputValue value) {
		if (GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PAUSE) {
			GameManager.Instance.SetGameState(GameManager.GameState.PLAYING);
		} else if (GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PLAYING) {
			GameManager.Instance.SetGameState(GameManager.GameState.PAUSE);
		}
	}
}
