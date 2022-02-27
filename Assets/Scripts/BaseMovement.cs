using System;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 moveVal;
    [SerializeField] protected float speed = 30;
    [SerializeField] protected float horizontalMultiplier = 1;

    void FixedUpdate()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameManager.GameState.PLAYING) {
            return;
        }

        float verticalMultiplier = 1 + 2*Math.Max(0, moveVal.y);
        int speedMultiplier = 1 + ClonesManager.Instance.Count();
        Vector3 forwardMove = transform.forward * speed * verticalMultiplier * speedMultiplier * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * moveVal.x * speed * Time.fixedDeltaTime * horizontalMultiplier;
        MoveWithRestrictions(forwardMove, horizontalMove);
    }

    public abstract void MoveWithRestrictions(Vector3 forwardMove, Vector3 horizontalMove);
}
