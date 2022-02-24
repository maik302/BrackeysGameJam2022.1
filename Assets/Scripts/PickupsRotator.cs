using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
