using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUIRotator : MonoBehaviour {

    [SerializeField] private float _rotationSpeed;

    // Update is called once per frame
    void Update() {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
