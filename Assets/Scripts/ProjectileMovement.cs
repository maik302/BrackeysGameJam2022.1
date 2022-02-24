using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    Rigidbody _rigidBody;

    void Start() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        _rigidBody.AddForce(Vector3.forward * Time.deltaTime * _speed);
    }
}
