using UnityEngine;
using UnityEngine.InputSystem;

public class CloneMovement : MonoBehaviour {
    [SerializeField] Rigidbody body;

    PlayerMovement player;
    Vector3 distance;

    void Start() {
        player = FindObjectOfType<PlayerMovement>();
        distance = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 move = distance - (transform.position - player.transform.position);
        Debug.Log($"{distance} - ({transform.position} - {player.transform.position} = {transform.position - player.transform.position}) = {move}");
        body.MovePosition(body.position + move);
    }
}
