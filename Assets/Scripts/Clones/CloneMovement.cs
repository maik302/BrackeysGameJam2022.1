using UnityEngine;
using UnityEngine.InputSystem;

public class CloneMovement : BaseMovement {
    [SerializeField] Rigidbody body;

    bool _canMoveHorizontally;

    void Awake() {
        _canMoveHorizontally = true;
    }

    public override void MoveWithRestrictions(Vector3 forwardMove, Vector3 horizontalMove) {
        if (GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PLAYING) {
            if (_canMoveHorizontally) {
                body.MovePosition(body.position + forwardMove + horizontalMove);
            } else {
                body.MovePosition(body.position + forwardMove);
            }
        }
    }

    void OnMove(InputValue value) {
        moveVal = value.Get<Vector2>().normalized;
    }

    public void SetCanMoveHorizontally(bool canMoveHorizontally) {
        _canMoveHorizontally = canMoveHorizontally;
    }
}
