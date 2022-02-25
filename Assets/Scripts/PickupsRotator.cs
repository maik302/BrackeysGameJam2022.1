using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _upwardsWhenEnding = 10f;
    private float _upwardsSpeed = 0;

    void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * _upwardsSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO: Check if its player
        GameManager.inst.AddPoints(1);

        // Destruction animation
        _rotationSpeed *= 100;
        _upwardsSpeed = _upwardsWhenEnding;

        Destroy(gameObject, 0.5f);
    }

}
